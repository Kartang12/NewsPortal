using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using News.Contracts.V1;
using News.Contracts.V1.Requests;
using News.Domain;
using Xunit;

namespace News.IntegrationTests
{
    public class PostsControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetAll_WithoutAnyPosts_ReturnsEmptyResponse()
        {
            await AuthenticateAsync();

            var response = await TestClient.GetAsync(ApiRoutes.Posts.GetAll);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<List<Post>>()).Should().BeEmpty();
        }

        [Fact]
        public async Task Get_ReturnsPost_WhenPostExistsInTheDatabase()
        {
            await AuthenticateAsync();
            var createdPost = await CreatePostAsync(new CreatePostRequest {Name = "Test post"});

            var response = await TestClient.GetAsync(ApiRoutes.Posts.Get.Replace("{postId}", createdPost.Id.ToString()));
            
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var returnedPost = await response.Content.ReadAsAsync<Post>();
            returnedPost.Id.Should().Be(createdPost.Id);
            returnedPost.Name.Should().Be("Test post");
        }
    }
}