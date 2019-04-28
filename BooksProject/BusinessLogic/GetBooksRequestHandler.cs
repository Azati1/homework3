using System.Collections.Generic;
using System.Threading.Tasks;
using BooksProject.Models;
using BooksProject.Services.Interfaces;

namespace BooksProject.BusinessLogic
{
    public class GetBooksRequestHandler
    {
        private readonly IBookService _bookService;

        public GetBooksRequestHandler(IBookService bookService)
        {
            _bookService = bookService;
        }
        
        public Task<List<Book>> Handle()
        {
            return _bookService.GetBooks();
        }

    }
}
