using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Post
    {
        [Key]
        public string id { get; set; }
        public string title { get; set; }
        [MaxLength(int.MaxValue)]
        public string content { get; set; }
        public string category { get; set; }
        public bool allowComments { get; set; }
        public DateTime createdAt { get; set; }
    }
}
