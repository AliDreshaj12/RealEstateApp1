namespace RealEstateApp.Entities
{
    public class Sell
    {
        public int SellID { get; set; }
        public DateTime SaleDate { get; set; }
        public double SalePrice { get; set; }
        public double Commision { get; set; }
        public string PaymentMethod { get; set; }

        public string UserID { get; set; }
        public ApplicationUser Users { get; set; }

        public int PronaID { get; set; }
        public Prona Pronat { get; set; }
    }
}
