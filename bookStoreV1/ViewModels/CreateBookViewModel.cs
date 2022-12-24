using System.ComponentModel.DataAnnotations;

namespace bookStoreV1.ViewModels
{
    public class CreateBookViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string BookImageTitle { get; set; }
        [Required]
        public IFormFile BookImageFile { get; set; }
        [Required]
        public bool IsExist { get; set; }
        [Required]
        public string PubTitle { get; set; }
        [Required]
        public float Price { get; set; }
    }
}
