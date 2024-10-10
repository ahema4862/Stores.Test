using Store.Mina.Core.Dtos.Products;
using Store.Mina.Core.Entities;
using Store.Mina.Core.Helper;
using Store.Mina.Core.Specifications.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Mina.Core.Services.Contract
{
    public interface IProductService
    {
        Task<PaginationResponse<ProductDto>> GetAllProductAsync(ProductSpecParams productSpec);
        Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync();
        Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
    }
}
