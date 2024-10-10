using Store.Mina.Core.Entities;
using Store.Mina.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Mina.Repository.Data
{
    public class StoreDbContextSeed
    {
        public async static Task SeedAsync(StoreDbContext _context)
        {
            if (_context.Brands.Count() == 0)
            {
                // 1.Read data from json file

                var brandsData = File.ReadAllText(@"..\Store.Mina.Repository\Data\DataSeed\brands.json");

                // 2.Convert json string to list<T>

                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                // 3.Seed Data Tp DB
                if (brands is not null && brands.Count() > 0)
                {
                    await _context.Brands.AddRangeAsync(brands);
                }
            }

            if (_context.Types.Count() == 0)
            {
                // 1.Read data from json file

                var typesData = File.ReadAllText(@"..\Store.Mina.Repository\Data\DataSeed\types.json");

                // 2.Convert json string to list<T>

                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                // 3.Seed Data Tp DB
                if (types is not null && types.Count() > 0)
                {
                    await _context.Types.AddRangeAsync(types);
                }
            }

            if (_context.Products.Count() == 0)
            {
                // 1.Read data from json file

                var productsData = File.ReadAllText(@"..\Store.Mina.Repository\Data\DataSeed\products.json");

                // 2.Convert json string to list<T>

                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                // 3.Seed Data Tp DB
                if (products is not null && products.Count() > 0)
                {
                    await _context.Products.AddRangeAsync(products);
                }
            }


            await _context.SaveChangesAsync();
        }
    }
}
