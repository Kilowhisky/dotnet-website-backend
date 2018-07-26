using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetwebsitebackend.Models
{
    public class Post
    {
        [Key]
        public string id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string category { get; set; }
        public bool allowComments { get; set; }
        public DateTime createdAt { get; set; }
    }
}
