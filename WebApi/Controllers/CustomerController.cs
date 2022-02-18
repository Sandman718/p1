using Microsoft.AspNetCore.Mvc;
using DL;
using BL;
using SignUp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {  // private InterRepos _bl;
       // public CustomerController(InterRepos bl) {
         //   _bl = bl;
       // }
        // GET: api/<CustomerController>
        [HttpGet]

        //List of type SignUp is what we are getting here
        //Hard coding the info.
        public List<SignUpCustomer> Get()
        {
               
            return  new DataBaseRepos().getCustomers();
          
                    
        } 

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult Post([FromBody] SignUpCustomer addCustomers)
        {
           
            new DataBaseRepos().AddSignUpCustomer(addCustomers);
             return NoContent();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
