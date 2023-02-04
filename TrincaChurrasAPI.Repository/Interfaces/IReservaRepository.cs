using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrincaChurrasAPI.Domain.Entities.Request;
using TrincaChurrasAPI.Domain.Entities.Response;
namespace TrincaChurrasAPI.Repository.Interfaces
{
    public interface IReservaRepository 
    {
        void AddAsync(ReservaRequest reserva);

        ReservaResponse Query(Guid key);

        IQueryable<ReservaResponse> QueryAll();
    }
}
