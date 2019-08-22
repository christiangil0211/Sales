namespace Sales.Backend.Models
{
    using Domain.Models;

    public class LocalDataContex : DataContext
    {
        public System.Data.Entity.DbSet<Sales.Common.Models.Product> Products { get; set; }
    }
}