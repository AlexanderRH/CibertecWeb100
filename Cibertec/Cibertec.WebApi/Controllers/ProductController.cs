using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;

namespace Cibertec.WebApi.Controllers
{
    [Route("api/Product")]
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork unit) : base(unit)
        {
        }

        public IActionResult GetList()
        {
            return Ok(_unit.Product.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Product.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Product.Insert(product));

            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            if (ModelState.IsValid && _unit.Product.Update(product))
                return Ok(new { Message = "The Order is updated" });

            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Product product)
        {
            if (product.Id > 0)
                return Ok(_unit.Product.Delete(product));

            return BadRequest(new { Message = "Incorrect data." });
        }

        [HttpGet]
        [Route("count")]
        public IActionResult GetCount()
        {
            return Ok(_unit.Product.Count());
        }
        [HttpGet]
        [Route("list/{page}/{rows}")]
        public IActionResult GetList(int page, int rows)
        {
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return Ok(_unit.Product.PagedList(startRecord, endRecord));
        }
    }
}