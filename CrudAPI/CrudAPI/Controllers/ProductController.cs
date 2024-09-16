using CrudAPI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        internal IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.Product.ToList());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name ="GetProduct")]
        public ActionResult Get(int id)
        {
            try
            {
                var producto = _context.Product.FirstOrDefault(p => p.Id == id);
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Models.Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _context.Product.Add(product);
                _context.SaveChanges();
                return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Models.Product product)
        {
            try
            {
                if(product.Id == id)
                {
                    _context.Entry(product).State = EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var product = _context.Product.FirstOrDefault(p => p.Id == id);
                if(product != null)
                {
                    _context.Product.Remove(product);
                    _context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
