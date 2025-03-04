using RealEstateApp.Data;
using RealEstateApp.Entities;

namespace RealEstateApp.Features
{
    public class SellFeature
    {
        private readonly DataContext _context;

        public SellFeature(DataContext context)
        {
            _context = context;
        }

        public async Task<Sell> CreateSellAsync(string userId, int pronaId, Sell sell)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                throw new Exception("User not found.");

            var prona = await _context.Pronas.FindAsync(pronaId);
            if (prona == null)
                throw new Exception("Property not found.");

            if (prona.Status != "Available")
                throw new Exception("Property is not Available.");

            if (prona.Type != "Sell")
                throw new Exception("Property is not for Sale, it is for Rent.");

            sell.UserID = userId;
            sell.PronaID = pronaId;
            sell.Users = user;
            sell.Pronat = prona;

            prona.Status = "Unavailable";
            var commissionRate = 0.10;
            sell.Commision = prona.Price * commissionRate;

            _context.Sells.Add(sell);
            await _context.SaveChangesAsync();

            return sell;
        }
    }
}
