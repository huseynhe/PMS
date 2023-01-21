using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PMS.BLL.Service;
using PMS.BLL.Service.Interface;
using PMS.DAL.DBModel;
using PMS.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.WebAdmin.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IProductService _productService;
        public ProductsController(IHostingEnvironment hostingEnvironment, IProductService productService)
        {
            _hostingEnvironment = hostingEnvironment;
            _productService = productService;
        }



        public async Task<IActionResult> Index()
        {
            List<ProductDto> products = await _productService.GetListAsync();
            return View(products);

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ProductDto product = new ProductDto();
            List<ProductCategoryDto> productCategories = await _productService.GetProductCategoryDtos();
            product.CategoryDtos = productCategories;
            //  ViewBag.Categories = new SelectList(productCategories, "Id", "Name");
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto item, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostingEnvironment.WebRootPath;
                string folderPath = @"images\product";
                string currentPath = Path.Combine(wwwRootPath, folderPath);
                item.ProductDocuments = new List<ProductDocumentDto>();
                foreach (var file in files)
                {
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(file.FileName);
                    string realPath = Path.Combine(currentPath, fileName + extension);

                    using (var fileStream = new FileStream(realPath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    ProductDocumentDto productDocument = new ProductDocumentDto()
                    {
                        DocumentUrl = @"images/product/" + fileName + extension

                    };
                    item.ProductDocuments.Add(productDocument);

                }
                if (item.ProductDocuments.Count > 0)
                {
                    item.PorfileDocPath = item.ProductDocuments[0].DocumentUrl;
                }
                await _productService.AddProductWithDocument(item);

                TempData["success"] = "Product added succecfully";
                return RedirectToAction("Index");
            }


            return View(item);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            ProductDto product = new ProductDto();
            List<ProductCategoryDto> productCategories = await _productService.GetProductCategoryDtos();
            product.CategoryDtos = productCategories;

            if (id == null)
            {
                return NotFound();
            }

            var item = await _productService.GetByIdAsync((int)id);
            if (item == null)
            {
                return NotFound();
            }
            product = item;
            product.CategoryDtos = productCategories;

            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductDto productDto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostingEnvironment.WebRootPath;
                string folderPath = @"images\product";
                string currentPath = Path.Combine(wwwRootPath, folderPath);
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(file.FileName);
                string realPath = Path.Combine(currentPath, fileName + extension);

                string oldPath = Path.Combine(wwwRootPath, productDto.PorfileDocPath);
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }
                using (var fileStream = new FileStream(realPath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                productDto.PorfileDocPath = @"images/product/" + fileName + extension;
                _productService.Update(productDto);
                TempData["success"] = "Product updated succecfully";
                return RedirectToAction("Index");
            }
            return View(productDto);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            ProductDto product = new ProductDto();
            List<ProductCategoryDto> productCategories = await _productService.GetProductCategoryDtos();
            if (id == null)
            {
                return NotFound();
            }

            var item = await _productService.GetByIdAsync((int)id);
            if (item == null)
            {
                return NotFound();
            }
            product = item;
            product.CategoryDtos = productCategories;
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _productService.Delete(id);
            TempData["success"] = "Product deleted succecfully";
            return RedirectToAction(nameof(Index));

        }
    }
    }
