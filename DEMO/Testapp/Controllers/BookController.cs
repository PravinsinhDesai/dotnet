using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BOL;
using DAL;
using Testapp.Models;

namespace Testapp.Controllers;

public class BookController : Controller
{
    private readonly ILogger<BookController> _logger;

    public BookController(ILogger<BookController> logger)
    {
        _logger = logger;
    }

    public IActionResult show()
    {
        List<Book> books=BookManager.GetAllBooks();
        ViewData["book"]=books;
        return View();
    }

    public IActionResult AddBook(){

        return View();

    }
    public IActionResult Insert(int id, string name){
        BookManager.insertBook(new Book(){Id=id, Name=name});

        return Redirect("/Book/show");

    }

    public IActionResult DeleteBook(int Id){
        Console.WriteLine(Id);
        BookManager.Deletebook(Id);

        return Redirect("/Book/show");

    }

    public IActionResult UpdateBook(int Id){
        Console.WriteLine(Id);
        Book book=BookManager.FindById(Id);
        ViewData["book"]=book;
        return View();

    }
    public IActionResult UpdatedBook(int id, string name){
        Console.WriteLine(id+ name);
        Book book=new Book(){Id=id, Name=name};
        BookManager.Update(book);

        return Redirect("/Book/show");

    }
    
}