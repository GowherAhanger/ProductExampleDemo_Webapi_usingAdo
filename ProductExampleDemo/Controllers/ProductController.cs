using Microsoft.AspNetCore.Mvc;
using ProductExampleDemo.Models;
using ProductExampleDemo.Repositories;

namespace ProductExampleDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController:ControllerBase
{
    private readonly IProductRepository _repo;

    public ProductController(IProductRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public ActionResult<List<Product>> GetAll()
    {
        return Ok(_repo.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = _repo.GetById(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public IActionResult Add(Product product)
    {
        _repo.Add(product);
        return Ok("Product added successfully.");
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Product product)
    {
        product.Id = id;
        _repo.Update(product);
        return Ok("Product updated successfully.");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _repo.Delete(id);
        return Ok("Product deleted successfully.");
    }
}