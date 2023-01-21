using Microsoft.AspNetCore.Mvc;
using PMS.BLL.Service.Interface;
using PMS.DAL.DBModel;
using PMS.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.WebAdmin.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private readonly IGenericService<ProductCategoryDto, ProductCategory> _genericService;

        public ProductCategoriesController(IGenericService<ProductCategoryDto, ProductCategory> genericService)
        {
            _genericService = genericService;
        }
        public async Task<IActionResult> Index()
        {
            List<ProductCategoryDto> productCategories = await _genericService.GetListAsync();
            return View(productCategories);
        }
    }
}
