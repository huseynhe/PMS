using AutoMapper;
using PMS.BLL.Helper;
using PMS.BLL.Service.Interface;
using PMS.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BLL.Service
{
    public class GenericService<TDto, TEntity> : IGenericService<TDto, TEntity> where TDto : class where TEntity : class
    {
        protected readonly IMapper _mapper;
        protected readonly IGenericRepository<TEntity> _repository;

        public GenericService(IMapper mapper, IGenericRepository<TEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<TDto> AddAsync(TDto item)
        {

            TEntity mapperItem = _mapper.Map<TEntity>(item);
            mapperItem = Util.MapAuditFields<TEntity>(mapperItem, true);
            TEntity dbItem = await _repository.AddAsync(mapperItem);
          
            return _mapper.Map<TDto>(dbItem);

        }
        public TDto Update(TDto item)
        {
            TEntity mapperItem = _mapper.Map<TEntity>(item);
            mapperItem = Util.MapAuditFields<TEntity>(mapperItem, false);
            TEntity dbItem = _repository.Update(mapperItem);
            var response = _mapper.Map<TDto>(dbItem);
        
            return response;
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            var mapperItem = _mapper.Map<TDto>(item);
            return mapperItem;
        }

        public async Task<List<TDto>> GetListAsync()
        {
            var items = await _repository.GetListAsync();
            var mapperItems = _mapper.Map<List<TDto>>(items);
            return mapperItems;
        }


    }
}
