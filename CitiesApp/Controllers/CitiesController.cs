﻿using CitiesApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CitiesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : Controller
    {
        CitiesContext _context;

        public CitiesController(CItiesContext context)
        {
            this._context = context;
        }

        [HttpGet()]
        public List<City> GetCities()
        {
            return _context.Cities.Include(x=>x.coords).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> Get(int id)
        {
            City city = await _context.Cities.Include(x => x.coords).FirstOrDefaultAsync(x => x.Id == id);
            if(city == null)
            {
                return NotFound();
            }
            return new ObjectResult(city);
        }


    }
}
