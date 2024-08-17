using Beverages_WebAPI.DomainModels;

namespace Beverages_WebAPI.DataAccess.DataSource
{
    public static class StaticDb
    {
        public static List<Beverage> Beverages = new List<Beverage>()
        {
            new Beverage() { Id = 1, Brand = "Coca Cola", Type = "Soda" },
            new Beverage() { Id = 2, Brand = "Skopsko", Type = "Beer" },
            new Beverage() { Id = 3, Brand = "Chardone", Type = "Wine" },
            new Beverage() { Id = 4, Brand = "Tullamore Due", Type = "Whiskey" },
            new Beverage() { Id = 5, Brand = "Pepsi", Type = "Soda" },
            new Beverage() { Id = 6, Brand = "Leffe", Type = "Beer" },
            new Beverage() { Id = 7, Brand = "Vranec", Type = "Wine" },
            new Beverage() { Id = 8, Brand = "Johny Walker", Type = "Whiskey" }
        };
    }
}
