using Beverages_WebAPI.DomainModels;
using Beverages_WebAPI.DTOs;

namespace Beverages_WebAPI.Services.Interfaces
{
    public interface IBeverageService
    {
        public string AddSingleBeverage(BeverageDto beverageDto);
        public Beverage GetBeverageById(int id);
        public List<Beverage> GetAllBeverages();
        public Beverage GetBeveragesByNameOrType (string? name, string? type);
        public void AddBulkBeverages(List<BeverageDto> beveragesDtos);
    }
}
