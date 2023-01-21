using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BLL.Service.Interface
{
    public interface IGenericService<TDto, TEntity> where TDto : class where TEntity:class
    {
        public Task<TDto> AddAsync(TDto item);
        public Task<List<TDto>> GetListAsync();
        public Task<TDto> GetByIdAsync(int id);
        public TDto Update(TDto item);
        public void Delete(int id);
    }
}
