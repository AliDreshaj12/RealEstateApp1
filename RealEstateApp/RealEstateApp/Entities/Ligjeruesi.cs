using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace RealEstateApp.Entities
{
    public class Ligjeruesi
    {
        [Key]
        public int LecturerID {  get; set; }
        public string LecturerName {  get; set; }
        public string Departament {  get; set; }
        public string Email {  get; set; }
    }
}
