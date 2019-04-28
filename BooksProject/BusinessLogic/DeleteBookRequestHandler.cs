using System;
using System.Threading.Tasks;
using BooksProject.Commands;
using BooksProject.Services.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace BooksProject.BusinessLogic
{
    public class DeleteBookRequestHandler
    {
        private readonly IBookService _bookService;

        public DeleteBookRequestHandler(IBookService bookService)
        {
            _bookService = bookService;
        }
        
        public Task<string> Handle(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Некорректный индетификатор книги", nameof(id));
            }

            return _bookService.DeleteBook(id);
        }
    }
    
    
}