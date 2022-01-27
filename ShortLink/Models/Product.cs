using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShortLink.Models
{
    public class Product
    {
        [Key]
        public int ShortId { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(4)]
        public string Shortkey { get; set; }

        public DateTime CreateDate { get; set; }
    }
}