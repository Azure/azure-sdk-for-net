using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.AI.OpenAI.Tests.Utils
{
    public class UnixDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return default;
            }
            else if (reader.TokenType == JsonTokenType.Number)
            {
                long unixTimeInSeconds = reader.GetInt64();
                return DateTimeOffset.FromUnixTimeSeconds(unixTimeInSeconds);
            }
            else
            {
                throw new JsonException("Expected a number token type but got " + reader.TokenType);
            }
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.ToUnixTimeSeconds());
        }
    }
}
