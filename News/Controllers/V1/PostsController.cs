using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using News.Contracts.V1;
using News.Contracts.V1.Requests;
using News.Contracts.V1.Responses;
using News.Domain;
using News.Services;
using News.Extensions;

namespace News.Controllers.V1
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;

        private readonly IIdentityService _identityService;

        public PostsController(IPostService postService, IIdentityService identityService)
        {
            _postService = postService;
            _identityService = identityService;
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _postService.GetPostsAsync());
        }

        [HttpPut(ApiRoutes.Posts.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid postId, [FromBody] UpdatePostRequest request)
        {
            // var userOwnsPost = await _postService.UserOwnsPostAsync(postId, HttpContext.GetUserId());
            //
            // if (!userOwnsPost)
            // {
            //     return BadRequest(new {error = "You do not own this post"});
            // }

            var post = await _postService.GetPostByIdAsync(postId);
            post.Name = request.Name;
            post.Content = request.Content;
            List<PostTag> tags = new List<PostTag>();
            tags.Add(new PostTag(){PostId = postId, Tag = null, TagName = request.Tag});
            post.Tags = tags;

            var updated = await _postService.UpdatePostAsync(post);

            if(updated)
                return Ok(post);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Posts.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid postId)
        {
            // var userOwnsPost = await _postService.UserOwnsPostAsync(postId, HttpContext.GetUserId());
            //
            // if (!userOwnsPost)
            // {
            //     return BadRequest(new {error = "You do not own this post"});
            // }
            
            var deleted = await _postService.DeletePostAsync(postId);

            if (deleted)
                return NoContent();

            return NotFound();
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public async Task<IActionResult> Get([FromRoute]Guid postId)
        {
            var post = await _postService.GetPostByIdAsync(postId);

            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePostRequest postRequest)
        {
            var newPostId = Guid.NewGuid();
            var post = new Post
            {
                Id = newPostId,
                Name = postRequest.Name,
                Content = postRequest.Content,
                UserName = postRequest.UserName,
                Tags = postRequest.Tags.Select(x=> new PostTag{TagName = x}).ToList()
            };
            
            await _postService.CreatePostAsync(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", post.Id.ToString());

            var response = new PostResponse {Id = post.Id};
            return Created(locationUri, response);
        }
        
        [HttpGet(ApiRoutes.Posts.GetByAuthorName)]
        public async Task<IActionResult> Get([FromRoute] string userName)
        {
            IdentityUser user = await _identityService.GetUserByName(userName);

            return Ok(await _postService.GetPostsByAuthorAsync(user.UserName));
        }
        
        [HttpGet(ApiRoutes.Posts.ByTag)]
        public async Task<IActionResult> GetByTag([FromRoute] string tagName)
        {
            return Ok(await _postService.GetPostsByTagAsync(tagName));
        }
        
        
    }
}