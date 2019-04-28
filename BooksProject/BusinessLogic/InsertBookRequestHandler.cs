using System;
using System.Threading.Tasks;
using BooksProject.Commands;
using BooksProject.Models;
using BooksProject.Services.Interfaces;
using MassTransit;

namespace BooksProject.BusinessLogic
{
    public class InsertBookRequestHandler
    {
        
        private readonly IBus _bus;
        
        public InsertBookRequestHandler(IBus bus)
        {
            _bus = bus;
        }
        
        public Task<Book> Handle(Book book)
        {            
            book.Id = Guid.NewGuid();
            //_bookService.InsertBook(book);
            _bus.Send(new InsertBookCommand
            {
                Book = book
            });
            Console.WriteLine("InsertBookRequestHandler masstransit");
            return Task.FromResult(book);
        }
        
    }
}