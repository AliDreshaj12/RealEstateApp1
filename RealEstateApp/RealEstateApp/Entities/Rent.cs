namespace RealEstateApp.Entities
{
    public class Rent
    {
        public int RentId { get; set; }
        public DateTime BookingDate { get; set; }
        public string PaymentMethod { get; set; }

        public string UserID { get; set; }
        public ApplicationUser Users { get; set; }

        public int PronaID { get; set; }
        public Prona Pronat { get; set; }

    }
}
