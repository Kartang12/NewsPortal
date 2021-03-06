﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace News.Domain
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public string Content { get; set; }

        public string UserName { get; set; }

        // [ForeignKey(nameof(UserId))]
        // public IdentityUser User { get; set; }
        
        public virtual List<PostTag> Tags { get; set; }
    }
}