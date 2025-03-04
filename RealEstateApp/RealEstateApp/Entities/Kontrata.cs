namespace RealEstateApp.Entities
{
    public class Kontrata
    {
        public int KontrataId { get; set; }
        public int PronaID { get; set; }
        public Prona Pronat { get; set; }
        public string UserID { get; set; }
        public ApplicationUser Users { get; set; }
        public double koheZgjatja { get; set; }
        public string Type { get; set; }
    }
}
