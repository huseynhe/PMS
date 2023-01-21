using PMS.DAL.DBModel;
using PMS.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BLL.Service.Interface
{
    public interface IProductService : IGenericService<ProductDto, Product>
    {
        public Task<ProductDto> AddProductWithDocument(ProductDto productDto);
        public Task<List<ProductCategoryDto>> GetProductCategoryDtos();
    }
}
