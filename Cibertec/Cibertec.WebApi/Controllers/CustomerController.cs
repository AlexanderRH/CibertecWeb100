using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;

namespace Cibertec.WebApi.Controllers
{
    [Route("api/Customer")]
    public class CustomerController : BaseController
    {
        public CustomerController(IUnitOfWork unit) : base(unit)
        {
        }

        public IActionResult GetList()
        {
            return Ok(_unit.Customer.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Customer.GetById(id));
        }

        [Route("{firstName}/{lastName}")]
        public IActionResult SearchByNames(string firstName, string lastName)
        {
            return Ok(_unit.Customer.SearchByNames(firstName, lastName));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Customer.Insert(customer));

            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Customer customer)
        {
            if (ModelState.IsValid && _unit.Customer.Update(customer))
                return Ok(new { Message = "The customer is updated" });

            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Customer customer)
        {
            if (customer.Id > 0)
                return Ok(_unit.Customer.Delete(customer));

            return BadRequest(new { Message = "Incorrect data." });
        }
    }
}