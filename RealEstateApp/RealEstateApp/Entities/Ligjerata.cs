namespace RealEstateApp.Entities
{
    public class Ligjerata
    {
        public int LectureId { get; set; }
        public string LectureName { get; set; }
        public int LecturerID {  get; set; }
        public Ligjeruesi Ligjeruesi { get; set; }
    }
}
