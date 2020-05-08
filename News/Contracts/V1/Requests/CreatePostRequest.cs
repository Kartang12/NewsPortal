using System.Collections.Generic;

namespace News.Contracts.V1.Requests
{
    public class CreatePostRequest
    {
        public string Name { get; set; }
        
        public string Content { get; set; }
        
        public string UserName{ get; set; }
        
        public IEnumerable<string> Tags { get; set; }
    }
}