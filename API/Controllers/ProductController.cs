using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
[ApiController]
[Route("api/[controller]")]
    public class ProductController : ControllerBase{
        private readonly StoreContext _context;
        public ProductController(StoreContext context){
            _context=context;

        }
        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProducts(){
           var products=await _context.Products.ToListAsync();
           return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProduct(int id){
            return await _context.Products.FindAsync(id);
        }

    }

}