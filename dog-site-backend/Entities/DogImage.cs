using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class DogImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public int DogId { get; set; }
        public Dog Dog { get; set; }
    }
}