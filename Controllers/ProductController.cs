
using Microsoft.AspNetCore.Mvc;
using System.IO;
namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(await _context.Products.ToListAsync());
            
         }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            return BadRequest("Product not found.");
            return Ok(product);
          }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
         
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product request)
        {
            var dbProduct = await _context.Products.FindAsync(request.idProduct);
            if (dbProduct == null)
                return BadRequest("Product not found.");

            dbProduct.productName = request.productName;
            dbProduct.productDescription = request.productDescription; 
            

            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }

      
    }
}