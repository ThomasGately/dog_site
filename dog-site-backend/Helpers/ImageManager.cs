using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Collections.Generic;/* 
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
 */

using WebApi.Entities;

namespace WebApi.Helpers
{
    public class ImageManager
    {/* 
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
            using var target = new MemoryStream(image.DataFiles);
            return new FormFile(target, 0, image.DataFiles.Length, image.Name, image.Name);
        }

        public List<IFormFile> listOfimageToIFormFileList(List<Image> images)
        {
            List<IFormFile> imagesByte = new List<IFormFile>();
            foreach (var dogImage in images)
            {
                imagesByte.Add(imageToIFormFile(dogImage));
            }
            return imagesByte;
        }

        public byte[] IFormFileToByteArray(IFormFile dogImage)
        {
            using (var target = new MemoryStream())
            {
                dogImage.CopyTo(target);
                return target.ToArray();
            }
        }

        public List<byte[]> listOfIFormFileToByteArray(List<IFormFile> listDogImage)
        {
            List<byte[]> listDogImageByte = new List<byte[]>();
            foreach (var dogImage in listDogImage)
            {
                listDogImageByte.Add(IFormFileToByteArray(dogImage));
            }
            return listDogImageByte;
        }

        public String SaveImageToDogImages(IFormFile image)
        {
            string path = Directory.GetCurrentDirectory() + "Resources\\DogImages";
            var guid = Guid.NewGuid();
            path += guid;
            if(image.Length > 0)
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                return guid.ToString();
            }
            return null;
        } */
    }
}