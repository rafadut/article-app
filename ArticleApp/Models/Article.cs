using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArticleApp.Models
{
    public class Article
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Title { get; set; }
        [RegularExpression(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}")]
        public string AuthorEmail { get; set; }
        [DataType(DataType.Date)]
        [Range(300, 3000)]
        public int NumberOfAuthors { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(1, 250)]
        [DataType(DataType.Currency)]
        [Required]
        public decimal Price { get; set; }
        [Required]
        [StringLength(6, MinimumLength = 3)]
        [Remote("IsUserAvailable", "Validation")]
        [RegularExpression(@"(\S)+", ErrorMessage = "White space is not allowed.")]
        [Editable(true)]
        public string UserName { get; set; }
    }

    //public class ArticleDBContext : DbContext
    //{
    //    public DbSet<Article> Articles { get; set; }
    //}
}