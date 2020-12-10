using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.DogImages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Services
{
    public interface IDogImageService
    {
        IEnumerable<DogImageResponse> GetAll();
        DogImageResponse GetById(int id);
        DogImageResponse Create(CreateRequest model);
        DogImageResponse Update(int id, UpdateRequest model);
        void Delete(int id);
    }
    
    public class DogImageService : IDogImageService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;
        private readonly ImageManager _imageManager;


        public DogImageService(
            DataContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IEmailService emailService,
            ImageManager imageManager)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _emailService = emailService;
            _imageManager = imageManager;
        }

        public IEnumerable<DogImageResponse> GetAll()
        {
            var DogImages = _context.DogImages;
            return _mapper.Map<IList<DogImageResponse>>(DogImages);
        }

        public DogImageResponse GetById(int id)
        {
            var DogImage = getDogImage(id);
            return _mapper.Map<DogImageResponse>(DogImage);
        }

        public DogImageResponse Create(CreateRequest model)
        {

            // map model to new DogImage object
            var DogImage = _mapper.Map<DogImage>(model);
            DogImage.FileName = saveImageToDogImages(model.DogImages);
            DogImage.Created = DateTime.UtcNow;

            // save dog
            _context.DogImages.Add(DogImage);
            _context.SaveChanges();

            var response = _mapper.Map<DogImageResponse>(DogImage);
            //response.DogImage = readDogImagesToIFormFile(DogImage.FileName);

            return response;
        }

        public DogImageResponse Update(int id, UpdateRequest model)
        {
            var DogImage = getDogImage(id);

            // copy model to dog and save
            _mapper.Map(model, DogImage);
            DogImage.Updated = DateTime.UtcNow;
            _context.DogImages.Update(DogImage);
            _context.SaveChanges();

            return _mapper.Map<DogImageResponse>(DogImage);
        }
        
        public void Delete(int id)
        {
            var DogImage = getDogImage(id);
            _context.DogImages.Remove(DogImage);
            _context.SaveChanges();
        }

        // helper methods

        private DogImage getDogImage(int id)
        {
            var DogImage = _context.DogImages.Find(id);
            if (DogImage == null) throw new KeyNotFoundException("DogImage not found");
            return DogImage;
        }

        private FormFile readDogImagesToIFormFile(String image)
        {
            string path = Directory.GetCurrentDirectory() + "\\Resources\\DogImages\\" + image;

            using (var stream = System.IO.File.OpenRead(path))
            {
                    return new FormFile(stream, 0, stream.Length, null, path);
            }
        }

        private String saveImageToDogImages(IFormFile image)
        {
            string path = Directory.GetCurrentDirectory() + "\\Resources\\DogImages\\";
            var guid = Guid.NewGuid();
            path += guid + System.IO.Path.GetExtension(image.FileName);
            if(image.Length > 0)
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                return guid.ToString() + System.IO.Path.GetExtension(image.FileName);
            }
            return null;
        }
    }
}