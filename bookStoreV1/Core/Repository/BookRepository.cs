using bookStoreV1.Core.Creator;
using bookStoreV1.Core.Services;
using bookStoreV1.DbContextFolder;
using bookStoreV1.Models;
using bookStoreV1.ViewModels;

namespace bookStoreV1.Core.Repository
{
    public class BookRepository : IBookService
    {
        private readonly MyDbContext _db;
        public BookRepository( MyDbContext db)
        {
            _db = db;
        }
        public bool CreateBooks(CreateBookViewModel book)
        {
            Book newBook = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                IsExist = book.IsExist,
                IsDiscount = false,
                PubTitle = book.PubTitle,
                Discount = 0,
                BookImage = "",
                MyBookId = CreateMyBookId.CreateId(),
                Price = book.Price,
            };

            if(book.BookImageFile != null)
            {
                string path = "";
                string newImageName = NameGenerator.GenerateUniqCode();
                newBook.BookImage = newImageName; 
                book.BookImageTitle = newImageName + ".jpg";
                path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", book.BookImageTitle);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    book.BookImageFile.CopyTo(stream);
                    newBook.BookImage = book.BookImageTitle;
                }
            }

            _db.Books.Add(newBook);
            Save();
            bool result = IsBookCreate(newBook.MyBookId);
            return result ;
        }
        public Book FindBookByMyBookId(int id)
        {
            return _db.Books.SingleOrDefault(u => u.MyBookId == id);
        }
        public AdminAllBooks GetAllBooks(int pageId, string bookName, string author)
        {
            IQueryable<Book> result = _db.Books;

            if (!string.IsNullOrEmpty(bookName))
            {
                result = result.Where(u => u.Title == bookName);
            }
            if (!string.IsNullOrEmpty(author))
            {
                result = result.Where(u => u.Author == author);
            }

            int take = 15; 
            int skip = (pageId - 1 )* take;

            AdminAllBooks allBokks = new AdminAllBooks();
            allBokks.CurrentPage = pageId;
            allBokks.Books = result.OrderBy(u => u.Created).Skip(skip).Take(take).ToList();

            return allBokks;
        }
        public bool IsBookCreate(int myBookId)
        {
            return _db.Books.Any(x => x.MyBookId == myBookId);
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        #region Edit

        public AdminEditViewModel GetBookEdit(int myBookId)
        {
            Book book = _db.Books.SingleOrDefault(u => u.MyBookId == myBookId);
            if(book == null)
            {
                return null;
            }

            AdminEditViewModel viewModel = new AdminEditViewModel()
            {
                IsExist = book.IsExist,
                Author = book.Author,
                BookImageName = book.BookImage,
                Description = book.Description,
                TitleBook = book.Title,
                Discount = 0,
                IsDiscount = false,
                Price = book.Price,
                MyBookId = myBookId,
                PubTitle = book.PubTitle,
            };

            return viewModel;

        }
        public bool UpdateBook(AdminEditViewModel adminEdit)
        {
            // we need the best validation
            // V1

            Book newBook = new Book()
            {
                MyBookId = adminEdit.MyBookId,
                Author = adminEdit.Author,
                BookImage = adminEdit.BookImageName,
                Description = adminEdit.Description,
                Discount = adminEdit.Discount,
                Price = adminEdit.Price,
                IsDiscount = adminEdit.IsDiscount,
                PubTitle = adminEdit.PubTitle,
            };
            if (adminEdit.BookImageFile != null)
            {
                string path = "";
                string newImageName = NameGenerator.GenerateUniqCode();

                // for delete old image
                string oldImageName = adminEdit.BookImageName;

                adminEdit.BookImageName = newImageName + ".jpg";
                path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img" , adminEdit.BookImageName);
                using(var stream = new FileStream(path, FileMode.Create))
                {
                    adminEdit.BookImageFile.CopyTo(stream);
                    newBook.BookImage = adminEdit.BookImageName;
                }

                // now we need delete old image

            }



            _db.Books.Update(newBook);
            return true;
        }

        #endregion

        #region Delete
        public bool DeleteBook(int bookId)
        {
            Book book = new Book();
            book = FindBookByMyBookId(bookId);
            if (book != null)
            {
                _db.Books.Remove(book);
                Save();
                return IsDeleteBook(bookId);
            }
            else
            {
                return false;
            }
        }

        public AdminDeleteBookViewModel GetBookInfo(int myBookId)
        {
            Book book = new Book();
            book = _db.Books.FirstOrDefault(x => x.MyBookId == myBookId);
            if( book != null)
            {
                AdminDeleteBookViewModel bookViewModel = new AdminDeleteBookViewModel()
                {
                    MyBookId = myBookId,
                    BookImageName = book.BookImage,
                    TitleBook = book.Title,
                    Author = book.Author,
                };

                return bookViewModel;
            }
            else
            {
                return null;
            }

        }
        public bool IsDeleteBook(int id)
        {
            Book book = new Book();
            book = FindBookByMyBookId(id);
            if (book != null)
            {
                return false;
            }

            return true;
        }



        #endregion
    }
}
