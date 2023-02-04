using TrincaChurrasAPI.Domain.Entities;
using TrincaChurrasAPI.Domain.Entities.Request;
using TrincaChurrasAPI.Domain.Entities.Response;

namespace TrincaChurrasAPI.Business.Interfaces
{
    public interface IReservaServices 
    {
        IQueryable<ReservaRequest> QueryAll();

        ReservaRequest Query(string key);

        void AddAsync(ReservaRequest entity);

        bool DataDisponivel(ReservaRequest entity);
    }
}