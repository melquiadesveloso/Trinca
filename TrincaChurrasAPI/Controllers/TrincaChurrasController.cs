using AutoMapper;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrincaChurrasAPI.Business.Interfaces;
using TrincaChurrasAPI.Business.Services;
using TrincaChurrasAPI.Domain.Entities.Request;
using TrincaChurrasAPI.Domain.Entities.Response;
using TrincaChurrasAPI.Repository.Context;

namespace TrincaChurrasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrincaChurrasController : ControllerBase
    {
 
        private readonly ILogger<TrincaChurrasController> _logger;
        private readonly IReservaServices _reservaServices;
        private readonly IMapper _mapper;
        private readonly CosmoDbContext _cosmoDbContext;

        public TrincaChurrasController(ILogger<TrincaChurrasController> logger, 
            IReservaServices reservaServicesRequest,  
            IMapper mapper,
            CosmoDbContext cosmoDbContext
            )
        {
            _logger = logger;
            _reservaServices = reservaServicesRequest; 
            _cosmoDbContext = cosmoDbContext;
            _mapper = mapper;
        }

        [HttpGet("GetAllReserva")]
        public ActionResult<ReservaResponse> GetAllReserva()
        {
            try
            {
               var reserva = _reservaServices.QueryAll().ToList();
               var result = _mapper.Map<List<ReservaRequest>,List<ReservaResponse>>(reserva);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("GetReserva/{id}")]
        public ActionResult<ReservaResponse> GetReserva([FromRoute] string id)
        {
            try
            {

                var reserva = _reservaServices.Query(id);
                var result = _mapper.Map<ReservaResponse>(reserva);
              
                return Ok(reserva);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, id);
                return new StatusCodeResult(500);
            }
        }
        [HttpPost("Reservar")]
        public ActionResult<ReservaRequest> Reservar([FromBody] ReservaRequest reserva)
        {
            try
            {
                 
                if(_reservaServices.DataDisponivel(reserva))
                {
                    return BadRequest($"Já existe reserva para essa data e hora - {reserva.Data.ToString("dd/MM/yyyy")} {reserva.Hora}");
                }
                _reservaServices.AddAsync(reserva);
 
                return Ok($"Churras agendando! Id = {reserva.id}");
            }
            catch (Exception ex)
            { 
                 _logger.LogError(ex, ex.Message, reserva);
                return new StatusCodeResult(500);
            }
        } 
    }
}