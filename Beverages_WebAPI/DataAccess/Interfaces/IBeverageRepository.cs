using Beverages_WebAPI.DomainModels;

namespace Beverages_WebAPI.DataAccess.Interfaces
{
    public interface IBeverageRepository
    {
        public void Add(Beverage beverage);
        public List<Beverage> GetAll();
        public Beverage GetById(int id);
        public Beverage GetByNameOrType(string? name, string? type);
    }
}
