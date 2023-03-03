using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuberBreakfast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreakfastController : ControllerBase
    {
        private readonly IBreakfastService _breakfastService;

        public BreakfastController(IBreakfastService breakfastService)
        {
            _breakfastService = breakfastService;
        }

        [HttpPost]
        public IActionResult CreateBreakfast(CreateBreakfastRequest request)
        {
            var breakfast = new Breakfast(Guid.NewGuid(), request.Name, request.Description, request.StartDateTime, request.EndDateTime,
            DateTime.UtcNow, request.Savory, request.Sweet);

            _breakfastService.CreateBreakfast(breakfast);


            var response = new BreakfastResponse(
                breakfast.Id,
                breakfast.Name,
                breakfast.Description,
                breakfast.StartDateTime,
                breakfast.EndDateTime,
                breakfast.LastModifiedDateTime,
                breakfast.Savory,
                breakfast.Sweet);



            return CreatedAtAction(nameof(GetBreakfast), new { id = breakfast.Id }, response);

        }

        [HttpGet("{id:guid}")]
        public IActionResult GetBreakfast(Guid id)
        {

            Breakfast breakfast = _breakfastService.GetBreakfast(id);

            var response = new BreakfastResponse(
            breakfast.Id, breakfast.Name, breakfast.Description, breakfast.StartDateTime, breakfast.EndDateTime, breakfast.LastModifiedDateTime, breakfast.Savory, breakfast.Sweet);


            return Ok(response);

        }

        [HttpGet]
        public IActionResult GetBreakfasts()
        {
            return Ok();

        }

        [HttpPut]
        public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
        {
            return Ok(request);

        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBreakfast(Guid id)
        {
            return Ok(id);

        }

    }
}