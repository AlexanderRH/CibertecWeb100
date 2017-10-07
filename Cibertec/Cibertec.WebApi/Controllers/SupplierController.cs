using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;

namespace Cibertec.WebApi.Controllers
{
    [Route("api/Supplier")]
    public class SupplierController : BaseController
    {
        public SupplierController(IUnitOfWork unit) : base(unit)
        {
        }

        public IActionResult GetList()
        {
            return Ok(_unit.Supplier.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Supplier.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Supplier supplier)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Supplier.Insert(supplier));

            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Supplier supplier)
        {
            if (ModelState.IsValid && _unit.Supplier.Update(supplier))
                return Ok(new { Message = "The Order is updated" });

            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Supplier supplier)
        {
            if (supplier.Id > 0)
                return Ok(_unit.Supplier.Delete(supplier));

            return BadRequest(new { Message = "Incorrect data." });
        }
    }
}