using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Globalization;

namespace TrincaChurrasAPI.Domain.Util
{
    public class DataConvert
    {
        public class DateTimeConverterData : JsonConverter<DateTime>
        {
    
            public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var data =  DateTime.ParseExact(reader.GetString(), "dd/MM/yyyy", CultureInfo.CurrentCulture);
                return data;

            }

            public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.Date.ToString("dd/MM/yyyy"));
            }
        }

        public class DateTimeConverterHora : JsonConverter<TimeSpan>
        {
            public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return TimeSpan.ParseExact(reader.GetString(), "c", CultureInfo.CurrentCulture);
                ///

            }

            public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString("c", CultureInfo.CurrentCulture));
            }
        }
    }
}
