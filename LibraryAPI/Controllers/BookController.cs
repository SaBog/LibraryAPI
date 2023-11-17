using Library.API.Controllers;

using Library.Application.Books.Commands.CreateBook;
using Library.Application.Books.Commands.DeleteBook;
using Library.Application.Books.Commands.UpdateBook;

using Library.Application.Books.Queries.GetAllBooks;
using Library.Application.Books.Queries.GetBookByIsbnQuery;
using Library.Application.Books.Queries.GetBookQuery;

using Library.Application.Books.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Authorize]
    [Route("api/books")]
    public class BookController : ApiBaseController
    {

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<BookViewModel>>> GetAllBooks()
        {
            var books = await Mediator.Send(new GetAllBooksQuery());
            return Ok(books);
        }

        [AllowAnonymous]
        [HttpGet("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookViewModel>> GetBook(long id)
        {
            var book = await Mediator.Send(new GetBookQuery(id));

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [AllowAnonymous]
        [HttpGet("isbn/{isbn}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookViewModel>> GetBookByIsbn(string isbn)
        {
            var book = await Mediator.Send(new GetBookByIsbnQuery(isbn));

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BookViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> AddBook(CreateBookCommand command)
        {
            var book = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BookViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookViewModel>> UpdateBook(long id, UpdateBookCommand command)
        {
            command.Id = id;
            await Mediator.Send(command);
            return await GetBook(id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteBookAsync(int id)
        {
            await Mediator.Send(new DeleteBookCommand(id));
            return NoContent();

        }

    }
}
