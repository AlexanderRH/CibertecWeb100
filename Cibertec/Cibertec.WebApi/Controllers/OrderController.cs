using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;

namespace Cibertec.WebApi.Controllers
{
    [Route("api/Order")]
    public class OrderController : BaseController
    {
        public OrderController(IUnitOfWork unit) : base(unit)
        {
        }

        public IActionResult GetList()
        {
            return Ok(_unit.Order.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Order.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Order.Insert(order));

            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Order order)
        {
            if (ModelState.IsValid && _unit.Order.Update(order))
                return Ok(new { Message = "The Order is updated" });

            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Order order)
        {
            if (order.Id > 0)
                return Ok(_unit.Order.Delete(order));

            return BadRequest(new { Message = "Incorrect data." });
        }
    }
}