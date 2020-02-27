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
    public class CustomerController : ApiController
    {
        private readonly ApplicationDBContext _context = new ApplicationDBContext();
        //POST
        [HttpPost]
        public async Task<IHttpActionResult> PostCustomer(Customer customer)
        {
            if (ModelState.IsValid && customer != null)
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        //get all
        public async Task<IHttpActionResult> GetAll()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();
            return Ok(customers);

            return Ok(await _context.Customers.ToListAsync());
            //both work, no real need to make the list though...because we're doing very little with the list..nothing really beyond glimpsing at it.
        }

        //get by id

        //delete
    }
}
