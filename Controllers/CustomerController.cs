


using AgriBid1.Models;
using Microsoft.AspNetCore.Mvc;


namespace AgriBid1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AgriContext context;

        // Constructor to inject AgriContext
        public CustomerController(AgriContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        [Route("GetCustomer")]
        public List<Customer> Get()
        {
            return context.Customers.ToList();
        }

       [HttpGet]
        [Route("GetCustomerById")]
        public Customer  GetCustomer(int id)
            
        {
            return context.Customers.Where(x=>x.Id==id).FirstOrDefault();
        }
        [HttpPost]
        [Route("AddCustomer")]
        public string AddCustomer(Customer customers)
        {
            string response = string.Empty;
            context.Customers.Add(customers);
            context.SaveChanges();
            return "Customer added";

        }

       [HttpPut]
        [Route("UpdateCustomer")]
        public string UpdateCustomer(Customer customer)
        {
            context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return "Customer Updated";

        }
        [HttpDelete]
        [Route("DeleteCustomer")]
        public string DeleteCustomer(int id)
        {
            Customer customer = context.Customers.Where(x => x.Id == id).FirstOrDefault();
            if (customer != null)
            {
                context.Remove(customer);
                context.SaveChanges();
                return "Customer Delete";
            }
            else
                return "Customer Not Found";
            

        }
       
    }
}
