// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    internal class AuthenticationEventResponseConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(WebJobsAuthenticationEventResponse).IsAssignableFrom(typeToConvert);
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            JsonConverter converter = (JsonConverter)Activator.CreateInstance(
                typeof(AuthEventResponseConverter<>).MakeGenericType(new Type[] { typeToConvert }));
            return converter;
        }

        internal class AuthEventResponseConverter<T> : JsonConverter<T> where T : WebJobsAuthenticationEventResponse
        {
            public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return (T)JsonSerializer.Deserialize(ref reader, typeToConvert, options);
            }

            public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
            {
                writer.WriteStartObject();
                foreach (var property in value.GetType().GetProperties())
                {
                    var attribute = property.GetCustomAttributes(false).FirstOrDefault(x => x.GetType() == typeof(JsonPropertyNameAttribute));
                    if (attribute is JsonPropertyNameAttribute nameAttribute)
                    {
                        writer.WritePropertyName(nameAttribute.Name);
                        JsonSerializer.Serialize(writer, property.GetValue(value, null), property.PropertyType, options);
                    }
                }
                writer.WriteEndObject();
            }
        }
    }
}
