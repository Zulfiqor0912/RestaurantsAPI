using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.API.Controllers;


[ApiController]
[Route("api/restaurants")]
public class RestaurantsController
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var restaurants = 
            return Ok(restaurants);
    }
}

