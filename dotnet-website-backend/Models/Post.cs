using System;
namespace dotnetwebsitebackend.Models
{
    public class Post
    {
        public string id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime createdAt { get; set; }
    }
}
