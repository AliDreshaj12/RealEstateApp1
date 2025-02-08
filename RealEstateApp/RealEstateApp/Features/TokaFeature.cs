using RealEstateApp.Data;
using RealEstateApp.DTO;
using RealEstateApp.Entities;

namespace RealEstateApp.Features
{
    public class TokaFeature
    {
        private readonly DataContext _context;

        public TokaFeature(DataContext context)
        {
            _context = context;
        }

        public async Task<Toka> CreateTokaAsync(TokaCreateDto tokaDto)
        {
            string photoPath = null;

            if (tokaDto.Photo != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Toka-Img");
                Directory.CreateDirectory(uploadsFolder);

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(tokaDto.Photo.FileName)}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await tokaDto.Photo.CopyToAsync(fileStream);
                }

                photoPath = Path.Combine("Images", "Toka-Img", fileName);
            }

            var toka = new Toka
            {
                Emri = tokaDto.Emri,
                Adresa = tokaDto.Adresa,
                Price = tokaDto.Price,
                Description = tokaDto.Description,
                Type = tokaDto.Type,
                Status = "Available",
                Photo = photoPath,
                LandType = tokaDto.LandType,
                Zona = tokaDto.Zona,
                TopografiaTokes = tokaDto.TopografiaTokes,
                WaterSource = tokaDto.WaterSource
            };

            _context.Tokat.Add(toka);
            await _context.SaveChangesAsync();

            return toka;
        }
    }
}
