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
    public class TransactionController : ApiController
    {
        private readonly ApplicationDBContext _context = new ApplicationDBContext();

        public async Task<IHttpActionResult> Post(Transaction transaction)
        {
            if (transaction == null)
                return BadRequest("The request body was empty.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Customer customer = await _context.Customers.FindAsync(transaction.CustomerID);
            if (customer == null)
                return BadRequest("Invalid Customer ID, no customer by that ID.");

            Product product = await _context.Products.FindAsync(transaction.ProductID);
            if (product == null)
                return BadRequest("Invalid Product ID, no product by that ID.");

            transaction.DateOfTransaction = DateTime.Now;
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return Ok();

        }

        public async Task<IHttpActionResult> GetAll()
        {
            return Ok(await _context.Transactions.ToListAsync());

        }
    }
}
