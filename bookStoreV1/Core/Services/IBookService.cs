using bookStoreV1.Models;
using bookStoreV1.ViewModels;

namespace bookStoreV1.Core.Services
{
    public interface IBookService
    {
        bool CreateBooks(CreateBookViewModel book);
        bool IsBookCreate(int myBookId);
        bool DeleteBook(int bookId);
        Book FindBookByMyBookId(int id);
        bool IsDeleteBook(int id);
        AdminDeleteBookViewModel GetBookInfo(int myBookId);
        AdminAllBooks GetAllBooks(int pageId , string bookName , string author );
        AdminEditViewModel GetBookEdit(int myBookId);
        bool UpdateBook(AdminEditViewModel adminEdit);
        void Save();
    }
}
