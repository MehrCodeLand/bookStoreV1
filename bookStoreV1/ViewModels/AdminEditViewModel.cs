namespace bookStoreV1.ViewModels
{
    public class AdminEditViewModel
    {
        public int MyBookId { get; set; }
        public string TitleBook { get; set; }
        public string Author { get; set; }
        public string BookImageName { get; set; }
        public string Description { get; set; }
        public bool IsExist { get; set; }
        public int Discount { get; set; }
        public bool IsDiscount { get; set; }
        public float Price { get; set; }
        public string PubTitle { get; set; }
        public IFormFile BookImageFile { get; set; }

    }
}
