using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.KeyVault.Models
{
    class UnixTimeConverter : JsonConverter
    {
        private static DateTime? FromUnixTime(long? unixTime)
        {
            if (unixTime.HasValue)
                return UnixEpoch.FromUnixTime((long)unixTime);
            else
                return null;
        }

        private static long? ToUnixTime(DateTime? value)
        {
            if (value.HasValue)
                return ((DateTime)value).ToUniversalTime().ToUnixTime();
            else
                return null;
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(DateTime?) || objectType == typeof(DateTime))
                return true;

            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType != typeof(DateTime?) && objectType != typeof(DateTime))
            {
                return serializer.Deserialize(reader, objectType);
            }
            else
            {
                var value = serializer.Deserialize<long?>(reader);

                if (value != null)
                {
                    return FromUnixTime(value);
                }
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value.GetType() != typeof(DateTime?) && value.GetType() != typeof(DateTime))
            {
                JToken.FromObject(value).WriteTo(writer);
            }
            else
            {
                JToken.FromObject(ToUnixTime((DateTime?)value)).WriteTo(writer);
            }
        }
    }
}
