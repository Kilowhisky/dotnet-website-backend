using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetwebsitebackend.Models
{
    public class ContactInfo
    {
        [Key]
        public int Id { get; set; }
        public string content { get; set; }
    }
}
