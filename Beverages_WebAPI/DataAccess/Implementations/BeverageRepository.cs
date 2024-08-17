using Beverages_WebAPI.DataAccess.DataSource;
using Beverages_WebAPI.DataAccess.Interfaces;
using Beverages_WebAPI.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace Beverages_WebAPI.DataAccess.Implementations
{
    public class BeverageRepository : IBeverageRepository
    {
        public void Add(Beverage beverage)
        {
            StaticDb.Beverages.Add(beverage);
        }

        public List<Beverage> GetAll()
        {
            var allBeverages = StaticDb.Beverages;
            return allBeverages.ToList();
        }

        public Beverage GetById(int id)
        {
            var beverage = StaticDb.Beverages.SingleOrDefault(x => x.Id == id);
            return beverage;
        }

        public Beverage GetByNameOrType(string? name, string? type)
        {
            var beverage = new Beverage();

            if(name != null && type != null)
            {
                beverage = StaticDb.Beverages.FirstOrDefault(x => x.Brand.ToLower() == name.ToLower() && x.Type.ToLower() == type.ToLower());
            } else if(name == null && type != null)
            {
                beverage = StaticDb.Beverages.FirstOrDefault(x => x.Type.ToLower() == type.ToLower());
            } else if (name != null && type == null)
            {
                beverage = StaticDb.Beverages.FirstOrDefault(x => x.Brand.ToLower() == name.ToLower());
            }

            return beverage;
        }
    }
}
