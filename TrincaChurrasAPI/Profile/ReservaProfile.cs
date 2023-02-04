
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrincaChurrasAPI.Domain.Entities.Request;
using TrincaChurrasAPI.Domain.Entities.Response;

namespace TrincaChurrasAPI.Controllers
{
    public class ReservaProfile : Profile
    {
        public ReservaProfile()
        {
            CreateMap<ReservaRequest, ReservaResponse>()
                .ForMember(e => e.Data, e => e.MapFrom(i => i.Data))
                .ForMember(e => e.Hora, e => e.MapFrom(i => i.Hora));

            CreateMap<ReservaResponse, ReservaRequest>()
                .ForMember(e => e.Data, e => e.MapFrom(i => i.Data))
                .ForMember(e => e.Hora, e => e.MapFrom(i => i.Hora));
        }
    }
}
