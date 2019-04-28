using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BooksProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksProject.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetBooks();

        Task<Book> GetBook(Guid id);
        Task<string> UpdateBook(Book book);
        Task<Book> InsertBook(Book book);
        
        Task<string> DeleteBook(Guid id);
    }
}
