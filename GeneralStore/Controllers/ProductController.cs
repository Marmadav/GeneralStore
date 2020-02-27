using GeneralStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GeneralStore.Controllers
{
    public class ProductController : ApiController
    {
        private readonly ApplicationDBContext _context = new ApplicationDBContext();
            //post
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (ModelState.IsValid && product!= null)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }
        //get all
        public async Task<IHttpActionResult> GetAll()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        public async Task<IHttpActionResult> GetByID(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            
            if (product==null)
            {
                return NotFound();
            }
            return Ok(product);
        }

       

    }
}
