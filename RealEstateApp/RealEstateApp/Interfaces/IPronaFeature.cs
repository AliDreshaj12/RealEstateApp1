using RealEstateApp.Entities;

namespace RealEstateApp.Interfaces
{
    public interface IPronaFeature
    {
        Task<IEnumerable<Prona>> GetByCategoryAsync(string category);
        Task<IEnumerable<Prona>> GetAllPropertiesAsync();
        Task<IEnumerable<Prona>> GetFilteredPropertiesAsync(string? location, string? category, double? maxPrice, string? propertyType);
        Task<Prona?> GetPropertyDetailsAsync(int id);
    }
}
