using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace WebApi.Models.DogImages
{
    public class UpdateRequest
    {
        public string Name { get; set; }

        public IFormFile DogImage { get; set; }
    
        public int DogId { get; set; }
    }
}