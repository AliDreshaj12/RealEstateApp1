using RealEstateApp.Data;
using RealEstateApp.DTO;
using RealEstateApp.Entities;

namespace RealEstateApp.Features
{
    public class ShtepiaFeature
    {
        private readonly DataContext _context;

        public ShtepiaFeature(DataContext context)
        {
            _context = context;
        }

        public async Task<Shtepia> CreateShtepiaAsync(ShtepiaCreateDto shtepiaDto)
        {
            string photoPath = null;

            if (shtepiaDto.Photo != null)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Shtepia-Img");
                Directory.CreateDirectory(uploadsFolder);

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(shtepiaDto.Photo.FileName)}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await shtepiaDto.Photo.CopyToAsync(fileStream);
                }

                photoPath = Path.Combine("Images", "Shtepia-Img", fileName);
            }

            var shtepia = new Shtepia
            {
                Emri = shtepiaDto.Emri,
                Adresa = shtepiaDto.Adresa,
                Price = shtepiaDto.Price,
                Description = shtepiaDto.Description,
                Status = "Available",
                Type = shtepiaDto.Type,
                Photo = photoPath,
                size = shtepiaDto.size,
                nrFloors = shtepiaDto.nrFloors,
                kaGarazhd = shtepiaDto.kaGarazhd,
                kaPool = shtepiaDto.kaPool
            };

            _context.Shtepiat.Add(shtepia);
            await _context.SaveChangesAsync();

            return shtepia;
        }
    }
}
