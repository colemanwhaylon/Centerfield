using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CenterfieldAPI.Features.CoffeeShops.CreateCoffeeShop;
using CenterfieldAPI.Features.CoffeeShops.GetCoffeeShops;
using Microsoft.EntityFrameworkCore;
using CenterfieldAPI.Entities;
using CenterfieldAPI.Database;
using CenterfieldAPI.Extensions;
using CenterfieldAPI.Features.CoffeeShops.Constants;

namespace CenterfieldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeShopsController : ControllerBase
    {
        private ILogger<CoffeeShopsController> _logger;
        private CoffeeShopContext _dbContext;

        public CoffeeShopsController(CoffeeShopContext dbContext,
            ILogger<CoffeeShopsController> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        // GET: api/coffeeshops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreateCoffeeShopDto>>> Get()
        {
            var coffeeShops = _dbContext.CoffeeShops
                     .Select(coffeeShop => new CoffeeShopDto(
                         coffeeShop.Name,
                         coffeeShop.OpeningTime,
                         coffeeShop.ClosingTime,
                         coffeeShop.Location,
                         coffeeShop.Rating,
                         IsCoffeeShopOpen(coffeeShop)
                         ))
                     .AsNoTracking()
                     .ToListAsync();

            // Return all coffee shop instances asynchronously
            return Ok(await Task.FromResult(coffeeShops));
        }

        // POST: api/coffeeshops
        [HttpPost]
        public async Task<ActionResult<CoffeeShopDetailsDto>> Post([FromBody] CreateCoffeeShopDto coffeeShopDto)
        {
            if (!ModelState.IsValid)
            {
                // Return BadRequest if model is invalid
                return BadRequest(ModelState);
            }

            var coffeeShop = new CoffeeShop
            {
                Id = new Guid().NewSequentialGuid(),
                Name = coffeeShopDto.Name,
                OpeningTime = coffeeShopDto.OpeningTime,
                ClosingTime = coffeeShopDto.ClosingTime,
                Location = coffeeShopDto.Location,
                Rating = coffeeShopDto.Rating,
            };

            _dbContext.CoffeeShops.Add(coffeeShop);
            await _dbContext.SaveChangesAsync();

            // Return a Created response with the newly added coffee shop
            return CreatedAtAction(EndpointNames.GetCoffeeShops,
                new { id = coffeeShop.Id },
                new CoffeeShopDetailsDto(
                    coffeeShop.Id,
                    coffeeShop.Name,
                    coffeeShop.OpeningTime,
                    coffeeShop.ClosingTime,
                    coffeeShop.Location,
                    coffeeShop.Rating
                ));
        }

        private static bool IsCoffeeShopOpen(CoffeeShop coffeeShop)
        {
            TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
            // Check if current time is between opening and closing times
            return currentTime >= coffeeShop.OpeningTime && currentTime <= coffeeShop.ClosingTime;
        }
    }
}
