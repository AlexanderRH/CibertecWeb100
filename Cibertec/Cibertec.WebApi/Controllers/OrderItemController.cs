﻿using Microsoft.AspNetCore.Mvc;
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
        [Route("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id.HasValue && id.Value > 0)
                return Ok(_unit.OrderItem.Delete(new OrderItem { Id = id.Value }));

            return BadRequest(new { Message = "Incorrect data." });
        }
        [HttpGet]
        [Route("count")]
        public IActionResult GetCount()
        {
            return Ok(_unit.OrderItem.Count());
        }
        [HttpGet]
        [Route("list/{page}/{rows}")]
        public IActionResult GetList(int page, int rows)
        {
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return Ok(_unit.OrderItem.PagedList(startRecord, endRecord));
        }
    }
}