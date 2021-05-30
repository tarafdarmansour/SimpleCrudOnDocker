

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimpleCrudOnDocker.Models;
using SimpleCrudOnDocker.MyDBContext;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class ProductController : ControllerBase
{
    private readonly ProductDBContext _context;

    public ProductController(ProductDBContext context)
    {
        _context = context;
    }
    [HttpPost]
    public int Add(Product product)
    {
        var entity = _context.Products.Add(product).Entity;
        _context.SaveChanges();
        return entity.Id;
    }

    [HttpGet]
    public List<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    [HttpGet]
    public Product Get(int id)
    {
        return _context.Products.Find(id);
    }

    [HttpPost]
    public Product Update(Product product)
    {
        var entity = _context.Products.Find(product.Id);
        if (entity == null)
            return new Product();
        entity.Description = product.Description;
        entity.Title = product.Title;
        entity.Price = product.Price;
        _context.Update(entity);
        _context.SaveChanges();
        return entity;
    }

    [HttpPost]
    public bool Delete(int id)
    {
        var entity = _context.Products.Find(id);
        if (entity == null)
            return false;
        _context.Products.Remove(entity);
        return _context.SaveChanges() > 0;
    }
}