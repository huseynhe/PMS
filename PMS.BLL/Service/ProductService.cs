using AutoMapper;
using PMS.BLL.Helper;
using PMS.BLL.Service.Interface;
using PMS.DAL.DBModel;
using PMS.DAL.Dtos;
using PMS.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BLL.Service
{
    public class ProductService :GenericService<ProductDto, Product>, IProductService
    {
   
        private readonly IGenericRepository<ProductDocument> _productDocumentRepository;
        private readonly IGenericRepository<ProductCategory> _categoryRepository;

        public ProductService(IMapper mapper, IGenericRepository<Product> repository, IGenericRepository<ProductDocument> productDocumentRepository, IGenericRepository<ProductCategory> categoryRepository = null)
        : base(mapper, repository)
        {
            _productDocumentRepository = productDocumentRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<ProductDto> AddProductWithDocument(ProductDto productDto)
        {

            Product mapperItem = _mapper.Map<Product>(productDto);
            mapperItem = Util.MapAuditFields<Product>(mapperItem, true);
            Product dbItem = await _repository.AddAsync(mapperItem);

            //foreach (var item in productDto.ProductDocuments)
            //{
            //    ProductDocument productDocument = _mapper.Map<ProductDocument>(item);
            //    productDocument.ProductId = dbItem.Id;
            //    productDocument = Util.MapAuditFields<ProductDocument>(productDocument, true);
            //    ProductDocument dbdocument = await _productDocumentRepository.AddAsync(productDocument);
            //}

            return _mapper.Map<ProductDto>(dbItem);
        }

        public async Task<List<ProductCategoryDto>> GetProductCategoryDtos()
        {
            List<ProductCategory> categories=await _categoryRepository.GetListAsync();

            List<ProductCategoryDto> personCategories = _mapper.Map<List<ProductCategoryDto>>(categories);
   
            return personCategories;
        }
    }
}
