using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApi.Entities;
using WebApi.Models.DogImages;
using WebApi.Services;
using System.IO;
using      System.Threading.Tasks ;

using System.ComponentModel.DataAnnotations;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogImagesController : BaseController
    {
        private readonly IDogImageService _dogImageService;
        private readonly IMapper _mapper;

        public DogImagesController(
            IDogImageService dogImageService,
            IMapper mapper)
        {
            _dogImageService = dogImageService;
            _mapper = mapper;
        }

        //[Authorize(Role.Admin)]
        [HttpGet]
        public ActionResult<IEnumerable<DogImageResponse>> GetAll()
        {
            var dogImages = _dogImageService.GetAll();
            return Ok(dogImages);
        }

        //[Authorize(Role.Admin)]
        [HttpGet("{id:int}")]
        public ActionResult<DogImageResponse> GetById(int id)
        {
            //admins can get any dog
            //if (id != Account.Id && Account.Role != Role.Admin)
               // return Unauthorized(new { message = "Unauthorized" });

            var dogImage = _dogImageService.GetById(id);
            return Ok(dogImage);
        }

        [HttpGet("temp{id:int}")]
        public IActionResult TempGetById(int id)
        {
            var dogImage = _dogImageService.GetById(id);
            string path = Directory.GetCurrentDirectory() + "\\Resources\\DogImages\\" + dogImage.FileName;

            Byte[] b = System.IO.File.ReadAllBytes(path);   // You can use your own method over here.         
            return File(b, "image/jpeg");
        }

        //[Authorize(Role.Admin)]
        [HttpPost]
        public ActionResult<DogImageResponse> Create([FromForm]CreateRequest model)
        {
            var dogImage = _dogImageService.Create(model);
            return Ok(dogImage);
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public ActionResult<DogImageResponse> Update(int id, [FromForm] UpdateRequest model)
        {
            // users can update their own account and admins can update any account
            if (id != Account.Id && Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            // only admins can update role
            ////if (Account.Role != Role.Admin)
                /////model.Role = null;

            var dog = _dogImageService.Update(id, model);
            return Ok(dog);
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            // users can delete their own account and admins can delete any account
            if (id != Account.Id && Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            _dogImageService.Delete(id);
            return Ok(new { message = "Account deleted successfully" });
        }

        // helper methods

    }
}