using bookStoreV1.Models;

namespace bookStoreV1.ViewModels
{
    public class AdminAllBooks
    {
        public List<Book> Books { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}
