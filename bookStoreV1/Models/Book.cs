using System.ComponentModel.DataAnnotations;

namespace bookStoreV1.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required] 
        public string Title { get; set; }
        [Required]
        public int MyBookId { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string BookImage { get; set; }
        [Required]
        public bool IsExist { get; set; }
        public int Discount { get; set; }
        [Required]
        public bool IsDiscount { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        [Required]
        public string PubTitle { get; set; }
        [Required]
        public float Price { get; set; }
    }
}
