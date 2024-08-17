using Beverages_WebAPI.DomainModels;
using Beverages_WebAPI.DTOs;
using Beverages_WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Beverages_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeveragesController : ControllerBase
    {
        public IBeverageService _beverageService { get; set; }
        public BeveragesController(IBeverageService beverageService) 
        {
            _beverageService = beverageService;
        }

        [HttpGet]
        public ActionResult<List<Beverage>> Get() 
        {
            try
            {
                var beverages = _beverageService.GetAllBeverages();
                if (beverages.Count > 0) 
                {
                    return Ok(beverages);
                } else
                {
                    return NoContent();
                }
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Server error: {ex}");
            }
        }

        [HttpGet("queryById")]
        public ActionResult<Beverage> GetBeverageById(int id)
        {
            var beverage = _beverageService.GetBeverageById(id);
            if(beverage != null)
            {
                return Ok(beverage);
            } else
            {
                return BadRequest($"No beverage with id {id}.");
            }
        }

        [HttpGet("queryByNameAndType")]
        public ActionResult<Beverage> GetBeveragesByNameOrType(string? name, string? type)
        {
            if (name == null && type == null)
            {
                return BadRequest("At least one parameter is needed.");
            } else
            {
                var beverage = _beverageService.GetBeveragesByNameOrType(name, type);

                if (beverage != null)
                {
                    return Ok(beverage);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "No such drink!");
                }
            }
        }

        [HttpPost("addBeverage")]
        public ActionResult<BeverageDto> AddSingleBeverage([FromBody] BeverageDto beverageDto)
        {
            try
            {
                if(string.IsNullOrEmpty(beverageDto.Brand) || string.IsNullOrEmpty(beverageDto.Type))
                {
                    return BadRequest("Make sure to provide values for both brand and type.");
                } else
                {
                    return Ok(_beverageService.AddSingleBeverage(beverageDto));
                }
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost("addBulkBeverages")]
        public ActionResult<List<BeverageDto>> AddBulkBeverages(List<BeverageDto> newBeverages)
        {
            _beverageService.AddBulkBeverages(newBeverages);
            return Ok(newBeverages);
        }
    }
}
