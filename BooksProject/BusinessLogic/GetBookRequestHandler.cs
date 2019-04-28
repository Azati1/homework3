using System;
using System.Threading.Tasks;
using BooksProject.Models;
using BooksProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BooksProject.BusinessLogic
{
    public class GetBookRequestHandler
    {
        private readonly IBookService _bookService;

        public GetBookRequestHandler(IBookService bookService)
        {
            _bookService = bookService;
        }
        
        public Task<Book> Handle(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Некорректный идентификатор книги", nameof(id));
            }
            return _bookService.GetBook(id);
        }
    }
}