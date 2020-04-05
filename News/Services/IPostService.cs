using News.Domain;
using System;
using System.Collections.Generic;

namespace News.Services
{
    public interface IPostService
    {
        List<Post> GetPosts();
        Post GetPostById(Guid postId);
        bool UpadatePost(Post postToUpdate);
        bool DeletePost(Guid postId);

    }
}
