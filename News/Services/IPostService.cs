﻿using News.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetPostsAsync();
        Task<Post> GetPostByIdAsync(Guid postId);
        Task<bool> CreatePostAsync(Post post);
        Task<bool> UpadatePostAsync(Post postToUpdate);
        Task<bool> DeletePostAsync(Guid postId);
    }
}
