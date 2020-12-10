using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace WebApi.Models.DogImages
{
    public class DogImageResponse
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }  
        public int DogId { get; set; }
    }
}