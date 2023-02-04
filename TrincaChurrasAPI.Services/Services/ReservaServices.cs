using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrincaChurrasAPI.Business.Interfaces;
using TrincaChurrasAPI.Domain.Base;
using TrincaChurrasAPI.Domain.Entities;
using TrincaChurrasAPI.Domain.Entities.Request;
using TrincaChurrasAPI.Domain.Entities.Response;
using TrincaChurrasAPI.Repository;
using TrincaChurrasAPI.Repository.Interfaces;
using ZstdSharp.Unsafe;

namespace TrincaChurrasAPI.Business.Services
{
    public class ReservaServices : IReservaServices
    {
 
        private readonly IRepositoryBase<ReservaRequest> _repositoryBase;

        public ReservaServices(IRepositoryBase<ReservaRequest> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public IQueryable<ReservaRequest> QueryAll()
        {
            return _repositoryBase.QueryAll();
        }

        public ReservaRequest Query(string key)
        {
            return _repositoryBase.Query(key);
        }

        public void AddAsync(ReservaRequest entity)
        {
            _repositoryBase.AddAsync(entity);
        }

        public bool DataDisponivel(ReservaRequest entity)
        {
            Expression<Func<ReservaRequest, bool>> expression;
            expression = x => x.Data == entity.Data && x.Hora == entity.Hora;

           var query = _repositoryBase.GetFilter(expression).ToList();

            return query.Count > 0;

        }
    }
}
