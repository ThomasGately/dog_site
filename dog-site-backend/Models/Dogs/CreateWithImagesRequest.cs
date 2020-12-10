using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;

namespace WebApi.Models.Dogs
{
    public class CreateWithImagesRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Neutered { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public List<string> DogImageNames { get; set; }

        [Required]
        public List<IFormFile> DogImages { get; set; }
    }
}