using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BooksProject.BusinessLogic;
using BooksProject.Models;
using BooksProject.Services;
using MassTransit;

namespace BooksProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly GetBooksRequestHandler _getBooksRequestHandler;
        private readonly GetBookRequestHandler _getBookRequestHandler;
        private readonly InsertBookRequestHandler _insertBookRequestHandler;
        private readonly UpdateBookRequestHandler _updateBookRequestHandler;
        private readonly DeleteBookRequestHandler _deleteBookRequestHandler;

        public BooksController(
            GetBooksRequestHandler getBooksRequestHandler,
            GetBookRequestHandler getBookRequestHandler,
            InsertBookRequestHandler insertBookRequestHandler,
            UpdateBookRequestHandler updateBookRequestHandler,
            DeleteBookRequestHandler deleteBookRequestHandler
            )
        {
            _getBooksRequestHandler = getBooksRequestHandler;
            _getBookRequestHandler = getBookRequestHandler;
            _insertBookRequestHandler = insertBookRequestHandler;
            _updateBookRequestHandler = updateBookRequestHandler;
            _deleteBookRequestHandler = deleteBookRequestHandler;
        }

        [HttpGet]
        public Task<List<Book>> GetBooks()
        {
            return _getBooksRequestHandler.Handle();
        }

        [HttpGet("{id:guid}")]
        public Task<Book> GetBook(Guid id)
        {
            return _getBookRequestHandler.Handle(id);
        }
        
        // POST api/values
        [HttpPost]
        public Task<Book> CreateBook([FromBody] Book book)
        {
            return _insertBookRequestHandler.Handle(book);
        }
        
        [HttpPut]
        public Task<string> UpdateBook([FromBody] Book book)
        {
            return _updateBookRequestHandler.Handle(book);
        }
        
        [HttpDelete("{id}")]
        public Task<string> DeleteBook(Guid id)
        {
            return _deleteBookRequestHandler.Handle(id);
        }
       
    }

}