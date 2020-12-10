using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace WebApi.Models.Dogs
{
    public class DogResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public string Neutered { get; set; }
        public string Sex { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}