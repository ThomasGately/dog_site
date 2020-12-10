using AutoMapper;
using WebApi.Entities;
using WA = WebApi.Models.Accounts;
using WD = WebApi.Models.Dogs;
using WDI = WebApi.Models.DogImages;
using WebApi.Models.Dogs;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Collections.Generic;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        // mappings between model and entity objects

        public AutoMapperProfile()
        {
            CreateMap<Account, WA.AccountResponse>();

            CreateMap<Account, WA.AuthenticateResponse>();

            CreateMap<WA.RegisterRequest, Account>();

            CreateMap<WA.CreateRequest, Account>();

            CreateMap<WA.UpdateRequest, Account>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                )
            );

            CreateMap<WD.CreateRequest, Dog>();
            
            CreateMap<WD.CreateWithImagesRequest, Dog>();
            
            CreateMap<Dog, WD.DogResponse>();
            
            CreateMap<WDI.CreateRequest, DogImage>();
            
            CreateMap<DogImage, WDI.DogImageResponse>();
        
        }
/* 
        public List<DogImage> temp1(List<IFormFile> DogImages)
        {

        }
 */


/* 
        public String[] SaveImageToDogImagesList(List<IFormFile> listDogImage)
        {
            List<String> listDogImageByte = new List<String>();
            foreach (var dogImage in listDogImage)
            {
                listDogImageByte.Add(SaveImageToDogImages(dogImage));
            }
            return listDogImageByte.ToArray();
        }

        public String SaveImageToDogImages(IFormFile image)
        {
            string path = Directory.GetCurrentDirectory() + "\\Resources\\DogImages\\";
            var guid = Guid.NewGuid();
            path += guid;
            path += "--FileName-->" + Path.GetFileName(image.FileName);;
            if(image.Length > 0)
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                return guid.ToString();
            }
            return null;
        }

        public List<IFormFile> LoadImageToIFormFilelis(String[] listDogImage)
        {
            List<IFormFile> listDogImageByte = new List<IFormFile>();
            foreach (var dogImage in listDogImage)
            {
                listDogImageByte.Add(LoadImageToIFormFilet(dogImage));
            }
            return listDogImageByte;
        }

        public IFormFile LoadImageToIFormFilet(String image)
        {
            string path = Directory.GetCurrentDirectory() + "\\Resources\\DogImages\\" + image;

            using (var stream = System.IO.File.OpenRead(path))
            {
                    return new FormFile(stream, 0, stream.Length, null, path);
            }
        }










        public Image IFormFileToImage(IFormFile dogImage)
        {
            //Getting FileName
            var fileName = Path.GetFileName(dogImage.FileName);
            //Getting file Extension
            var fileExtension = Path.GetExtension(fileName);
            // concatenating  FileName + FileExtension
            var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

            var image = new Image()
            {
                Name = newFileName,
                FileType = fileExtension,
                Created = DateTime.Now
            };
            using (var target = new MemoryStream())
            {
                dogImage.CopyTo(target);
                image.DataFiles = target.ToArray();
            }
            return image;
        }

        public List<Image> listOfIFormFileToImageList(List<IFormFile> listDogImage)
        {
            List<Image> listDogImageByte = new List<Image>();
            foreach (var dogImage in listDogImage)
            {
                listDogImageByte.Add(IFormFileToImage(dogImage));
            }
            return listDogImageByte;
        }

        public IFormFile imageToIFormFile(Image image)
        {
            using (var target = new MemoryStream(image.DataFiles))
            {
                return new FormFile(target, 0, image.DataFiles.Length, "name", image.Name);
            }
        }

        public List<IFormFile> listOfimageToIFormFileList(List<Image> images)
        {
            List<IFormFile> imagesByte = new List<IFormFile>();
            foreach (var dogImage in images)
            {
                imagesByte.Add(imageToIFormFile(dogImage));
            }
            return imagesByte;
        } */
    }
}