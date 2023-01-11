using bookStoreV1.Core.Services;
using bookStoreV1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bookStoreV1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeAdminController : Controller
    {
        private readonly IBookService _bookService;
        public HomeAdminController( IBookService bookService)
        {
             _bookService = bookService;
        }

        #region Main_Page
        public IActionResult IndexAdmin() => View();
        #endregion

        #region Create_Book

        [Route("CreateBook")]
        public IActionResult CreateBook()
        {
            return View();
        }

        [Route("CreateBook")]
        [HttpPost]
        public IActionResult CreateBook(CreateBookViewModel createBook)
        {
            bool result = _bookService.CreateBooks(createBook);
            ViewBag.IsCreate = result;
            return View();
        }

        #endregion

        #region Show_all_book

        [Route("ShowAllBook")]
        public IActionResult ShowAllBook(int pageId = 1, string bookname = "", string author = "")
        {
            AdminAllBooks allBooks = new AdminAllBooks();
            allBooks = _bookService.GetAllBooks(pageId, bookname, author);
            return View(allBooks);
        }

        #endregion

        #region Delete_And_Edit

        [Route("BookDelete")]
        public IActionResult BookDelete(int id)
        {
            AdminDeleteBookViewModel adminDeleteBookViewModel = new AdminDeleteBookViewModel();
            adminDeleteBookViewModel = _bookService.GetBookInfo(id);
            return View(adminDeleteBookViewModel);
        }

        [Route("BookDelete")]
        [HttpPost]
        public IActionResult BookDelete(AdminDeleteBookViewModel deleteBook)
        {
            bool result = _bookService.DeleteBook(deleteBook.MyBookId);
            ViewBag.IsDelete = result;
            return RedirectToAction("IndexAdmin");
        }


        [Route("BookEdit")]
        public IActionResult BookEdit(int id)
        {
            AdminEditViewModel editBook = new AdminEditViewModel();
            editBook = _bookService.GetBookEdit(id);
            if(editBook != null)
            {
                return View(editBook);
            }

            return NotFound();
        }

        [Route("BookEdit")]
        [HttpPost]
        public IActionResult BookEdit(AdminEditViewModel adminEdit)
        {
            bool result = _bookService
            return View();
        }
        #endregion





    }
}
