using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using News.Domain;

namespace News.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetPostsAsync();

        Task<List<Post>> GetPostsByAuthorAsync(string userId);

        Task<bool> CreatePostAsync(Post post);

        Task<Post> GetPostByIdAsync(Guid postId);

        Task<bool> UpdatePostAsync(Post postToUpdate);

        Task<bool> DeletePostAsync(Guid postId);
        
        Task<bool> UserOwnsPostAsync(Guid postId, string userId);
        
        Task<List<Tag>> GetAllTagsAsync();

        Task<bool> CreateTagAsync(Tag tag);

        Task<Tag> GetTagByNameAsync(string tagName);
        
        Task<bool> DeleteTagAsync(string tagName);
        
        Task<List<Post>> GetPostsByTagAsync(string tagName);
    }
}