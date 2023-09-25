using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly StoreContext Context;

        public ProductsController(StoreContext storeContext)
        {
            Context = storeContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return await Context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await Context.Products.FindAsync(id);
        }
    }
}
