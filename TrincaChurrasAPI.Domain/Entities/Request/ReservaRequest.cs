using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TrincaChurrasAPI.Domain.Base;

namespace TrincaChurrasAPI.Domain.Entities.Request
{
    public class ReservaRequest : Entity
    {

        public string Nome { get; set; }

        public string Descricao { get; set; }

        [JsonConverter(typeof(Util.DataConvert.DateTimeConverterData))]
        public DateTime Data { get; set; }
       
        [JsonConverter(typeof(Util.DataConvert.DateTimeConverterHora))] 
        public TimeSpan Hora { get; set; }
    }
}
