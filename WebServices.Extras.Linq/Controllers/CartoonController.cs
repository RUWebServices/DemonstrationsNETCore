using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebServices.Extras.Linq.Controllers
{
    [Route("api/cartoons")]
    public class CartoonController : Controller
    {
        private static readonly List<Cartoon> _cartoons;
        [HttpGet]
        [Route("")]
        public IActionResult GetAllCartoons(/* Should contain paging later on */)
        {
            return Ok();
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetCartoonById(int id)
        {
            return Ok();
        }

        [Route("{id}/characters")]
        [HttpGet]
        public IActionResult GetCharactersByCartoonId(int id)
        {
            return Ok();
        }
    }
}