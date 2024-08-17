using Beverages_WebAPI.DataAccess.Interfaces;
using Beverages_WebAPI.DomainModels;
using Beverages_WebAPI.DTOs;
using Beverages_WebAPI.Services.Interfaces;

namespace Beverages_WebAPI.Services.Implementations
{
    public class BeverageService : IBeverageService
    {
        public readonly IBeverageRepository _beverageRepository;
        public BeverageService(IBeverageRepository beverageRepository)
        {
            _beverageRepository = beverageRepository;
        }
        public void AddBeverage(Beverage beverage)
        {
            _beverageRepository.Add(beverage);
        }

        public List<Beverage> GetAllBeverages()
        {
            var allBeverages = _beverageRepository.GetAll();
            return allBeverages;
        }

        public Beverage GetBeverageById(int id)
        {
            var beverage = _beverageRepository.GetById(id);
            return beverage;
        }

        public Beverage GetBeveragesByNameOrType(string? name, string? type)
        {
            var beverage = _beverageRepository.GetByNameOrType(name, type);
            return beverage;
        }

        public string AddSingleBeverage(BeverageDto beverageDto)
        {
            var nextId = _beverageRepository.GetAll().ToList().Count + 1;

            var checkIfExist = _beverageRepository.GetAll().Where(x => x.Brand ==  beverageDto.Brand).FirstOrDefault();

            if (checkIfExist != null) {
                return $"Drink with brand {beverageDto.Brand} already exist.";
            } else
            {
                var newBeverage = new Beverage
                {
                    Id = nextId,
                    Brand = beverageDto.Brand,
                    Type = beverageDto.Type
                };

                _beverageRepository.Add(newBeverage);
                return $"{beverageDto.Brand} is added to the list.";
            }
        }

        public void AddBulkBeverages(List<BeverageDto> beveragesDtos)
        { 
            foreach(var beverage in beveragesDtos)
            {
                AddSingleBeverage(beverage);
            }
        }
    }
}
