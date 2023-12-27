
using System.Text.Json;
using Core.Entities;
using Infrastructue.Data;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context) {
            if(!context.ProductBrand.Any()) {
                var barandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(barandsData);
                context.ProductBrand.AddRange(brands);
            }

            if(!context.ProductType.Any()) {
                var typeData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var type = JsonSerializer.Deserialize<List<ProductType>>(typeData);
                context.ProductType.AddRange(type);
            }

            if(!context.Products.Any()) {
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRange(products); 
            }

            if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }

        
    }
}