using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;

namespace Cibertec.WebApi.Controllers
{
    [Route("api/OrderItem")]
    public class OrderItemController : BaseController
    {
        public OrderItemController(IUnitOfWork unit) : base(unit)
        {
        }

        public IActionResult GetList()
        {
            return Ok(_unit.OrderItem.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.OrderItem.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrderItem orderItem)
        {
            if (ModelState.IsValid)
                return Ok(_unit.OrderItem.Insert(orderItem));

            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] OrderItem orderItem)
        {
            if (ModelState.IsValid && _unit.OrderItem.Update(orderItem))
                return Ok(new { Message = "The Order is updated" });

            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] OrderItem orderItem)
        {
            if (orderItem.Id > 0)
                return Ok(_unit.OrderItem.Delete(orderItem));

            return BadRequest(new { Message = "Incorrect data." });
        }
    }
}