using System.Threading.Tasks;
using BooksProject.Commands;
using BooksProject.Services.Interfaces;
using MassTransit;

namespace BooksProject.Consumers
{
    public class InsertBookConsumer : IConsumer<InsertBookCommand>
    {
        private readonly IBookService _bookService;

        public InsertBookConsumer(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task Consume(ConsumeContext<InsertBookCommand> context)
        {
            await _bookService.InsertBook(context.Message.Book);
        }
    }
}