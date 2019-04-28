using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Dapper;
using BooksProject.Models;
using BooksProject.Services.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace BooksProject.Services
{
    public class BookService : IBookService
    {
        private const string ConnectionString =
            "server=localhost;userid=postgres;password=1;database=test;Pooling=false";

        public async Task<List<Book>> GetBooks()
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
               string sqlQuery = "SELECT * FROM books";
               var result =  await connection.QueryAsync<Book>(sqlQuery);
               return result.ToList();
            }
        }

        public async Task<Book> GetBook(Guid id)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                string sqlQuery = "SELECT * FROM books WHERE Id = @id";
                return await connection.QuerySingleAsync<Book>(sqlQuery, new {id});
            }
        }
        
        public async Task<Book> InsertBook(Book book)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                string sqlQuery = "INSERT INTO books (id, name, url) VALUES (@id, @name, @url)";
                await connection.ExecuteAsync(sqlQuery, book); // если вернул 1, значит гуд. если вернул 0, значит не гуд
                return book;
            }
        }

        public async Task<string> UpdateBook(Book book)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                string sqlQuery = "UPDATE books SET name = @name, url = @url WHERE Id = @id";
                int responseCode = await connection.ExecuteAsync(sqlQuery, book);
                if (responseCode != 0)
                    return "Book successfully updated";
                return "Some error happened";
            }
        }

        public async Task<string> DeleteBook(Guid id)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                string sqlQuery = "DELETE FROM books WHERE Id = @id";
                int responseCode = await connection.ExecuteAsync(sqlQuery, new {id});
                if (responseCode != 0)
                    return "Book successfully deleted";
                return "Some error happened";
            }
        }
    }
}
