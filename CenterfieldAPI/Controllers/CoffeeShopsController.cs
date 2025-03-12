using CenterfieldAPI.Database;
using CenterfieldAPI.DTOs;
using CenterfieldAPI.Entities;
using CenterfieldAPI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CenterfieldAPI.Controllers
{
    [Route("[controller]")]
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
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CreateCoffeeShopDto>>> GetAll()
        {
            var coffeeShops = _dbContext.CoffeeShops
                     .Select(coffeeShop => new CoffeeShopDto(
                         coffeeShop.Id,
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

        // GET: api/coffeeshops/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CoffeeShopDetailsDto>> GetById(Guid id)
        {
            // Find the coffee shop by the provided ID
            var coffeeShop = await _dbContext.CoffeeShops
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (coffeeShop == null)
            {
                // If no coffee shop is found, return NotFound
                return NotFound();
            }

            // Return the coffee shop details as DTO
            return Ok(new CoffeeShopDetailsDto(
                coffeeShop.Id,
                coffeeShop.Name,
                coffeeShop.OpeningTime,
                coffeeShop.ClosingTime,
                coffeeShop.Location,
                coffeeShop.Rating
            ));
        }


        // GET: api/coffeeshops
        // Filtered GET by minRating and/or isOpen
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<CreateCoffeeShopDto>>> GetFiltered(
            [FromQuery] decimal? minRating,
            [FromQuery] bool? isOpen)
        {
            var query = _dbContext.CoffeeShops.AsQueryable();

            if (minRating.HasValue)
            {
                query = query.Where(b => b.Rating >= minRating);
            }

            var coffeeShops = query.AsEnumerable();

            if (isOpen.HasValue)
            {
                coffeeShops = coffeeShops.Where(b => IsCoffeeShopOpen(b) == isOpen.Value);
            }

            var businesses =  coffeeShops
                     .Select(coffeeShop => new CoffeeShopDto(
                         coffeeShop.Id,
                         coffeeShop.Name,
                         coffeeShop.OpeningTime,
                         coffeeShop.ClosingTime,
                         coffeeShop.Location,
                         coffeeShop.Rating,
                         IsCoffeeShopOpen(coffeeShop)
                         ))
                     .ToList();

            return Ok(await Task.FromResult(businesses));
        }

        // POST: api/coffeeshops
        [HttpPost]
        [ActionName("Post")]
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
            return CreatedAtAction("Post",
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
            // Get the current date and time
            TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
            // Check if current time is between opening and closing times
            return currentTime >= coffeeShop.OpeningTime && currentTime <= coffeeShop.ClosingTime;
        }
    }
}
