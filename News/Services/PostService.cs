using Microsoft.EntityFrameworkCore;
using News.Data;
using News.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Services
{
    public class PostService : IPostService
    {
        private readonly DataContext _dataContext;

        //private readonly List<Post> _posts;

        //public PostService()
        //{
        //    _posts = new List<Post>();
        //    for (int i = 0; i < 5; i++)
        //    {
        //        _posts.Add(new Post
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = $"Post name {i}"
        //        });
        //    }
        //}

        public PostService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            return await _dataContext.posts.ToListAsync();
        }
        
        public async Task<Post> GetPostByIdAsync(Guid postId)
        {
            return await _dataContext.posts.SingleOrDefaultAsync(x => x.Id == postId);
        }

        public async Task<bool> CreatePostAsync(Post post)
        {
            await _dataContext.posts.AddAsync(post);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> UpadatePostAsync(Post postToUpdate)
        {
            _dataContext.posts.Update(postToUpdate);
            var updated = await _dataContext.SaveChangesAsync();

            //var exists = GetPostById(postToUpdate.Id) != null;
            //if (!exists)
            //    return false;

            //var index = _posts.FindIndex(x => x.Id == postToUpdate.Id);
            //_posts[index] = postToUpdate;
            return updated > 0;
        }

        public async Task<bool> DeletePostAsync(Guid postId)
        {
            var post = await GetPostByIdAsync(postId);
            _dataContext.posts.Remove(post);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}
