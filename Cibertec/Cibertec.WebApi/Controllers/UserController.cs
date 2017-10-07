using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;

namespace Cibertec.WebApi.Controllers
{
    [Route("api/User")]
    public class UserController : BaseController
    {
        public UserController(IUnitOfWork unit) : base(unit)
        {
        }

        public IActionResult GetList()
        {
            return Ok(_unit.User.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.User.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (ModelState.IsValid)
                return Ok(_unit.User.Insert(user));

            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            if (ModelState.IsValid && _unit.User.Update(user))
                return Ok(new { Message = "The Order is updated" });

            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] User user)
        {
            if (user.Id > 0)
                return Ok(_unit.User.Delete(user));

            return BadRequest(new { Message = "Incorrect data." });
        }
    }
}