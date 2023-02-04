using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TrincaChurrasAPI.Domain.Base;
using TrincaChurrasAPI.Domain.Interfaces;

namespace TrincaChurrasAPI.Domain.Entities.Response
{ 
    [BsonIgnoreExtraElements]
    public class ReservaResponse : Entity
    {
        
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [JsonConverter(typeof(Util.DataConvert.DateTimeConverterData))]
        public DateTime Data { get; set; }

        [JsonConverter(typeof(Util.DataConvert.DateTimeConverterHora))]
        public TimeSpan Hora { get; set; } 

    }
}
