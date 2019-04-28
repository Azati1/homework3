using System;
using System.Threading.Tasks;
using BooksProject.Commands;
using BooksProject.Models;
using BooksProject.Services.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace BooksProject.BusinessLogic
{
    public class UpdateBookRequestHandler
    {
        private readonly IBookService _bookService;

        public UpdateBookRequestHandler(IBookService bookService)
        {
            _bookService = bookService;
        }
        
        public Task<string> Handle(Book book)
        {
            if (book.Id == Guid.Empty)
            {
                throw new ArgumentException("Некорректный индетификатор книги", nameof(book.Id));
            }

            return _bookService.UpdateBook(book);
        }
        
    }
}