

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleCrudOnDocker.Models;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class ProductController : ControllerBase
{
    [HttpPost]
    public int Add(Product product)
    {
        return 0;
    }

    [HttpGet]
    public List<Product> GetAll()
    {
        return new List<Product>();
    }

    [HttpGet]
    public Product Get(int id)
    {
        return new Product();
    }

    [HttpPost]
    public Product Update(Product product)
    {
        return new Product();
    }

    [HttpPost]
    public bool Delete(int id)
    {
        return true;
    }
}