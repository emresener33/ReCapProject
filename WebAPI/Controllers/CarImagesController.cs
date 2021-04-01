using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage image)
        {
            var result = _carImageService.Add(file, image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int Id)
        {
            var image = _carImageService.GetById(Id).Data;
            var result = _carImageService.Delete(image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("update")]
        public IActionResult Update([FromForm(Name = "Image")] IFormFile file, CarImage image)
        {
            var result = _carImageService.Update(file, image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getbycar")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
