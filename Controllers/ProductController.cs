using Microsoft.AspNetCore.Mvc;
using SimpleStore.BLL;
using SimpleStore.Models;

namespace SimpleStore.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        ViewBag.Total = _service.GetTotalCount();
        return View(_service.GetProducts());
    }

    public IActionResult Create()
        => View();

    [HttpPost]
    public IActionResult Create(Product product)
    {
        if (!ModelState.IsValid)
            return View(product);

        _service.Create(product);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var product = _service.GetById(id);
        if(product == null)
        {
            return NotFound();
        }

        return View(product);
    }

[HttpPost]
    public IActionResult Edit(Product product)
    {
        if(!ModelState.IsValid) 
            return View(product);
        
        _service.Update(product);
        return RedirectToAction(nameof(Index));
    }
}