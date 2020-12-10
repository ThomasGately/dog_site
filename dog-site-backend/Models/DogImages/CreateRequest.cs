using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace WebApi.Models.DogImages
{
    public class CreateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public IFormFile DogImages { get; set; }

        [Required]
        public int DogId { get; set; }
    }
}