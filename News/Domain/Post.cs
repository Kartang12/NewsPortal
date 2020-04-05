using System;
using System.ComponentModel.DataAnnotations;


namespace News.Domain
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
