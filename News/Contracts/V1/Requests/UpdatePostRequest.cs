namespace News.Contracts.V1.Requests
{
    public class UpdatePostRequest
    {
        public string Name { get; set; }
        
        public string Content { get; set; }

        public string Tag { get; set; }
    }
}