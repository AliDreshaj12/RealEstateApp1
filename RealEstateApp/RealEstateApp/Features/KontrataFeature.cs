using RealEstateApp.Data;
using RealEstateApp.Entities;

namespace RealEstateApp.Features
{
    public class KontrataFeature
    {
        private readonly DataContext _context;

        public KontrataFeature(DataContext context)
        {
            _context = context;
        }

        public async Task<Kontrata> CreateKontrataAsync(string userId, int pronaId, string type)
        {
            var kontrata = new Kontrata
            {
                PronaID = pronaId,
                UserID = userId,
                Type = type
            };

            _context.Kontrata.Add(kontrata);
            await _context.SaveChangesAsync();

            return kontrata;
        }

        public async Task<Kontrata> CreateKontrataSellAsync(string userId, int pronaId)
        {
            var kontrata = new Kontrata
            {
                PronaID = pronaId,
                UserID = userId,
                Type = "Sell Contract"
            };

            _context.Kontrata.Add(kontrata);
            await _context.SaveChangesAsync();

            return kontrata;
        }

        public async Task<Kontrata> CreateKontrataRentAsync(string userId, int pronaId)
        {
            var kontrata = new Kontrata
            {
                PronaID = pronaId,
                UserID = userId,
                Type = "Rent Contract"
            };

            _context.Kontrata.Add(kontrata);
            await _context.SaveChangesAsync();

            return kontrata;
        }
    }
}
