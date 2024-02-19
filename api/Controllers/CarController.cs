using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.Controllers
{
    //[Route("api/car")]
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepo;
        private readonly IHColorRepository _hColorRepo;
        private readonly ITokenService _tokenService;

        public CarController(ICarRepository carRepo, IHColorRepository hColorRepo, ITokenService tokenService)
        {
            _carRepo = carRepo;
            _hColorRepo = hColorRepo;
            _tokenService = tokenService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllCars()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cars = await _carRepo.GetAllAsync();

            var carsDto = cars.Select(c => c.ToCarDto());
            
            return Ok(carsDto);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetCarById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var car = await _carRepo.GetByIdAsync(id);

            if (car is null)
            {
                return NotFound();
            }

            return Ok(car.ToCarDto());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCar([FromBody] CreateCarRequestDto carDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var carModel = carDto.ToCarFromCreateDto();
            await _carRepo.CreateAsync(carModel);

            return CreatedAtAction(nameof(GetCarById), new {id = carModel.Id}, carModel.ToCarDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateCar([FromRoute] int id, [FromBody] UpdateCarRequestDto carDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var carModel = await _carRepo.UpdateAsync(id, carDto);
            
            if (carModel is null)
            {
                return NotFound();
            }

            return NoContent();
            //return Ok(carModel.ToCarDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteCar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var carModel = await _carRepo.DeleteAsync(id);

            if (carModel is null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        [Route("color")]
        [Authorize]
        public async Task<IActionResult> GetAllHColor()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var hColor = await _hColorRepo.GetAllAsync();
            var hColorDto = hColor.Select(s => s.ToHColorDto());

            return Ok(hColorDto);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AppUser appUser)
        {
            if (appUser.UserName == "MainUser" && appUser.Password == "MainUserPwd")
            {
                var token = _tokenService.CreateToken(appUser);
                return Ok(token);
            }
            return Unauthorized();
        } 
    }
}

