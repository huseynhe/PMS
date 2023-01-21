using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS.BLL.Service.Interface;
using PMS.DAL.DBModel;
using PMS.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericService<ProductDto, Product> _genericService;

        public ProductsController(IGenericService<ProductDto, Product> genericService)
        {
            _genericService = genericService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetList()
        {
            var response = await _genericService.GetListAsync();
            return response;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductCategoryDto>> GetByIdAsync(int id)

        {
            if (id == 0)
            {
                return BadRequest();
            }

            var response = await _genericService.GetByIdAsync(id);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create(ProductDto itemDto)
        {

            var response = await _genericService.AddAsync(itemDto);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public ActionResult<ProductDto> Update(int id, [FromBody] ProductDto obj)
        {
            if (id == 0 || id != obj.Id)
            {
                return BadRequest();
            }

            var response = _genericService.GetByIdAsync(id).Result;
            if (response == null)
            {
                return NotFound();
            }
            response = _genericService.Update(obj);
            return Ok(response); ;
        }

        [HttpDelete("{id:int}")]

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var response = _genericService.GetByIdAsync(id).Result;
            if (response == null)
            {
                return NotFound();
            }

            _genericService.Delete(id);
            return NoContent();
        }
    }
}
