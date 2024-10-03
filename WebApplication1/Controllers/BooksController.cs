using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

public class BooksController(BooksService service) : Controller
{
    public IActionResult Index()
    {
        return View(service.GetAllBooks());
    }

    public IActionResult View(uint id)
    {
        return View(service.FindById(id));
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Book book)
    {
        if (!ModelState.IsValid)
        {
            return View(book); // Return the view with the model if validation fails
        }

        service.Create(book);

        return RedirectToAction("Index");
    }

    public IActionResult Edit(uint id)
    {
        return View(service.FindById(id));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Book editedBook)
    {
        service.Update(editedBook);

        return RedirectToAction("Index");
    }

    public IActionResult Delete(uint id)
    {
        service.DeleteById(id);

        return RedirectToAction("Index");
    }
}