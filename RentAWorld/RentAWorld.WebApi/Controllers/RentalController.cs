using Microsoft.AspNetCore.Mvc;
using RentAWorld.Models.InputModels;
using RentAWorld.Services;
using RentAWorld.WebApi.Models;

namespace RentThePlace.WebApi.Controllers
{
    [Route("api/rentals")]
    public class RentalController : Controller
    {
        private readonly RentalService _rentalService = new RentalService();

        // http://localhost:5000/api/rentals [GET]
        [HttpGet] 
        [Route("")]
        public IActionResult GetAllRentals([FromQuery] bool containUnavailable)
        {
            return Ok(_rentalService.GetAllRentals(containUnavailable));
        }

        // http://localhost:5000/api/rentals/5 [GET]
        [HttpGet]
        [Route("{id:int}", Name = "GetRentalById")]
        public IActionResult GetRentalById(int id)
        {
            return Ok(_rentalService.GetRentalById(id));
        }

        // http://localhost:5000/api/rentals [POST]
        [HttpPost]
        [Route("")]
        public IActionResult CreateNewRental([FromBody] RentalInputModel rental)
        {
            if (!ModelState.IsValid) { return StatusCode(412, rental); }
            var id = _rentalService.CreateNewRental(rental);
            return CreatedAtRoute("GetRentalById", new { id }, null);
        }

        // http://localhost:5000/api/rentals/3 [PUT]
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateRentalById(int id, [FromBody] RentalInputModel rental)
        {
            if (!ModelState.IsValid) { return StatusCode(412, rental); }
            
            _rentalService.UpdateRentalById(rental, id);

            return NoContent();
        }

        // http://localhost:5000/api/rentals/5 [PATCH]
        [HttpPatch]
        [Route("{id:int}")]
        public IActionResult UpdateRentalPartiallyById(int id, [FromBody] RentalInputModel rental)
        {
            _rentalService.UpdateRentalPartiallyById(rental, id);

            return NoContent();
        }

        // http://localhost:5000/api/rentals/5 [DELETE]
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteRentalById(int id)
        {
            _rentalService.DeleteRentalById(id);
            return NoContent();
        }
    }
}