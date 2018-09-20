using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServices.Extras.Paging.Models;

namespace WebServices.Extras.Paging.Controllers
{
    [Route("api/superheroes")]
    public class SuperheroController : Controller
    {
        private readonly IEnumerable<Superhero> Superheroes = new List<Superhero>
        {
            new Superhero
            {
                Id = 1,
                Name = "Batman"
            },
            new Superhero
            {
                Id = 2,
                Name = "Superman"
            },
            new Superhero
            {
                Id = 3,
                Name = "Black Panther"
            },
            new Superhero
            {
                Id = 4,
                Name = "Aquaman"
            },
            new Superhero
            {
                Id = 5,
                Name = "Thor"
            },
            new Superhero
            {
                Id = 6,
                Name = "Wonder Woman"
            },
            new Superhero
            {
                Id = 7,
                Name = "Spiderman"
            },
            new Superhero
            {
                Id = 8,
                Name = "Green Lantern"
            },
            new Superhero
            {
                Id = 9,
                Name = "Flash"
            },
            new Superhero
            {
                Id = 10,
                Name = "Captain America"
            },
            new Superhero
            {
                Id = 11,
                Name = "Invisible Woman"
            },
            new Superhero
            {
                Id = 12,
                Name = "Silver Surfer"
            },
            new Superhero
            {
                Id = 13,
                Name = "Wolverine"
            },
            new Superhero
            {
                Id = 14,
                Name = "Iron Man"
            },
            new Superhero
            {
                Id = 15,
                Name = "Supergirl"
            },
            new Superhero
            {
                Id = 16,
                Name = "Daredevil"
            },
            new Superhero
            {
                Id = 17,
                Name = "Hulk"
            },
            new Superhero
            {
                Id = 18,
                Name = "Cyborg"
            },
            new Superhero
            {
                Id = 19,
                Name = "Black Lightning"
            },
            new Superhero
            {
                Id = 20,
                Name = "Power Girl"
            }
        };

        [HttpGet]
        [Route("")]
        public IActionResult GetAllSuperheroes([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var envelope = new Envelope<Superhero>(pageSize, pageNumber);

            // Setup envelope
            envelope.Items = Superheroes.ToList().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            envelope.MaxPages = (int) Math.Ceiling(Superheroes.Count() / (decimal) pageSize);

            return Ok(envelope);
        }
    }
}