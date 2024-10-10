using AutoMapper;
using Store.Mina.Core;
using Store.Mina.Core.Dtos.Products;
using Store.Mina.Core.Entities;
using Store.Mina.Core.Helper;
using Store.Mina.Core.Services.Contract;
using Store.Mina.Core.Specifications;
using Store.Mina.Core.Specifications.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Mina.Service.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task <PaginationResponse<ProductDto>> GetAllProductAsync(ProductSpecParams productSpec)
        {


            var spec = new ProductSpecifications(productSpec);

            var products = await _unitOfWork.Repository<Product, int>().GetAllWithSpecAsync(spec);
            var mapperdProducts = _mapper.Map<IEnumerable<ProductDto>>(products);

            var countSpec = new ProductWithCountSpecifications(productSpec);

            var count = await _unitOfWork.Repository<Product, int>().GetCountAsync(countSpec);

                return new PaginationResponse<ProductDto>(productSpec.PageSize, productSpec.PageIndex, count, mapperdProducts);
            
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var spec = new ProductSpecifications(id);

            //var product = await _unitOfWork.Repository<Product, int>().GetWithSpecAsync(spec);
            //var MappedProduct = _mapper.Map<ProductDto>(product);
            //return MappedProduct;

            return _mapper.Map<ProductDto>(await _unitOfWork.Repository<Product, int>().GetAllWithSpecAsync(spec));

        }


        public async Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync()
        {
            return _mapper.Map<IEnumerable<TypeBrandDto>>(await _unitOfWork.Repository<ProductType,int>().GetAllAsync());
        }

     

        public async Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync();
            var MappedBrands = _mapper.Map<IEnumerable<TypeBrandDto>>(brands);
            return MappedBrands;
        }

     

      
    }
}
