namespace RealEstateApp.DTO
{
    public class ShtepiaCreateDto
    {
        public string Emri { get; set; }
        public string Adresa { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public double size { get; set; }
        public int nrFloors { get; set; }
        public bool kaGarazhd { get; set; }
        public bool kaPool { get; set; }
        public IFormFile Photo { get; set; }
    }
}
