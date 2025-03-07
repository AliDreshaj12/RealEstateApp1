﻿using RealEstateApp.Data;
using RealEstateApp.DTO;
using RealEstateApp.Entities;

namespace RealEstateApp.Features
{
    public class ApartmentFeature
    {
        private readonly DataContext _context;

        public ApartmentFeature(DataContext context)
        {
            _context = context;
        }

        public async Task<Apartment> CreateApartmentAsync(ApartmentCreateDto apartmentDto)
        {
            string photoPath = null;

            if (apartmentDto.Photo != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Apartment-Img");
                Directory.CreateDirectory(uploadsFolder);

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(apartmentDto.Photo.FileName)}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await apartmentDto.Photo.CopyToAsync(fileStream);
                }

                photoPath = Path.Combine("Images", "Apartment-Img", fileName);
            }

            var apartment = new Apartment
            {
                Emri = apartmentDto.Emri,
                Adresa = apartmentDto.Adresa,
                Price = apartmentDto.Price,
                Description = apartmentDto.Description,
                Status = "Available",
                Type = apartmentDto.Type,
                Photo = photoPath,
                floor = apartmentDto.floor,
                nrDhomave = apartmentDto.nrDhomave,
                kaAnshensor = apartmentDto.kaAnshensor
            };

            _context.Apartments.Add(apartment);
            await _context.SaveChangesAsync();

            return apartment;
        }
    }
}
