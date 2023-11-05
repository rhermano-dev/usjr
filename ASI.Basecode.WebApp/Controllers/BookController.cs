using ASI.Basecode.Services.Models;
using ASI.Basecode.WebApp.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ASI.Basecode.WebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IGenreService _genreService;

        public BookController(IMapper mapper, IBookService bookService, IAuthorService authorService, IGenreService genreService)
        {
            _mapper = mapper;
            _bookService = bookService;
            _authorService = authorService;
            _genreService = genreService;
        }

        public IActionResult Index()
        {
            var bookViewModels = _bookService.GetAllBooks();
            return View(bookViewModels);
        }

        public IActionResult Details(int id)
        {
            var viewModel = _bookService.GetBookById(id);
            if (viewModel == null)
            {
                _logger.LogWarning("Book with ID {BookId} not found.", id); // Log warning
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var authors = _authorService.GetAllAuthors()
                                   .Select(a => new
                                   {
                                       Id = a.Id,
                                       FullName = a.FirstName + " " + a.LastName
                                   })
                                   .ToList();
            var genres = _genreService.GetAllGenres()
                                   .Select(g => new
                                   {
                                       Id = g.Id,
                                       Name = g.Name
                                   })
                                   .ToList();

            ViewBag.AuthorList = new SelectList(authors, "Id", "FullName");
            ViewBag.GenreList = new SelectList(genres, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                _bookService.AddBook(model);
                _logger.LogInformation("Book created: {BookTitle}", model.AuthorNames); // Log information
                return RedirectToAction(nameof(Index));
            }
            _logger.LogWarning("Invalid model state for creating book."); // Log warning
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _bookService.GetBookById(id);
            if (viewModel == null)
            {
                _logger.LogWarning("Edit attempted for non-existent book with ID {BookId}.", id); // Log warning
                return NotFound();
            }

            var authors = _authorService.GetAllAuthors()
                                   .ToList()
                                   .Select(a => new
                                   {
                                       Id = a.Id,
                                       FullName = a.FirstName + " " + a.LastName
                                   })
                                   .ToList();
            var genres = _genreService.GetAllGenres()
                                   .Select(g => new
                                   {
                                       Id = g.Id,
                                       Name = g.Name
                                   })
                                   .ToList();
            
            if (viewModel == null)
            {
                return NotFound();
            }

            ViewBag.AuthorList = new SelectList(authors, "Id", "FullName");
            ViewBag.GenreList = new SelectList(genres, "Id", "Name");

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(model);
                _logger.LogInformation("Book updated: {BookId}", model.Id); // Log information
                return RedirectToAction(nameof(Index));
            }
            _logger.LogWarning("Invalid model state for editing book with ID {BookId}.", model.Id); // Log warning
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _bookService.DeleteBook(id);
            _logger.LogInformation("Book deleted: {BookId}", id); // Log information
            return RedirectToAction(nameof(Index));
        }
    }
}
