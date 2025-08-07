#nullable enable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.AI.OpenAI.Tests.Utils
{
    public class UnixDateTimeConverter : JsonConverterFactory
    {
        private static Lazy<DateTimeOffsetConverter> _dateTimeOffset = new(() => new DateTimeOffsetConverter(), false);
        private static Lazy<NullableDateTimeOffsetConverter> _nullableDateTimeOffset = new(() => new NullableDateTimeOffsetConverter(), false);
        private static Lazy<DateTimeConverter> _dateTime = new(() => new DateTimeConverter(), false);
        private static Lazy<NullableDateTimeConverter> _nullableDateTime = new(() => new NullableDateTimeConverter(), false);

        public override bool CanConvert(Type typeToConvert)
            => typeToConvert == typeof(DateTime)
            || typeToConvert == typeof(DateTime?)
            || typeToConvert == typeof(DateTimeOffset)
            || typeToConvert == typeof(DateTimeOffset?);

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            switch (typeToConvert)
            {
                case Type t when t == typeof(DateTime):
                    return _dateTime.Value;
                case Type t when t == typeof(DateTime?):
                    return _nullableDateTime.Value;
                case Type t when t == typeof(DateTimeOffset):
                    return _dateTimeOffset.Value;
                case Type t when t == typeof(DateTimeOffset?):
                    return _nullableDateTimeOffset.Value;
                default:
                    throw new NotSupportedException();
            }
        }

        private static DateTimeOffset? Read(ref Utf8JsonReader reader)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return default;
            }
            else if (reader.TokenType == JsonTokenType.Number)
            {
                long unixTimeInSeconds = reader.GetInt64();
                return DateTimeOffset.FromUnixTimeSeconds(unixTimeInSeconds).ToLocalTime();
            }
            else if (reader.TokenType == JsonTokenType.String
                && long.TryParse(reader.GetString(), out long unixTime))
            {
                return DateTimeOffset.FromUnixTimeSeconds(unixTime).ToLocalTime();
            }
            else
            {
                throw new JsonException("Expected a number token type but got " + reader.TokenType);
            }
        }

        private static void Write(Utf8JsonWriter writer, DateTimeOffset? value)
        {
            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteNumberValue(value.Value.ToUnixTimeSeconds());
            }
        }

        private class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
        {
            public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
                => UnixDateTimeConverter.Read(ref reader) ?? default;

            public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
                => UnixDateTimeConverter.Write(writer, value);
        }

        private class NullableDateTimeOffsetConverter : JsonConverter<DateTimeOffset?>
        {
            public override DateTimeOffset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
                => UnixDateTimeConverter.Read(ref reader);

            public override void Write(Utf8JsonWriter writer, DateTimeOffset? value, JsonSerializerOptions options)
                => UnixDateTimeConverter.Write(writer, value);
        }

        private class DateTimeConverter : JsonConverter<DateTime>
        {
            public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
                => UnixDateTimeConverter.Read(ref reader)?.LocalDateTime ?? default;

            public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
                => UnixDateTimeConverter.Write(writer, value);
        }

        private class NullableDateTimeConverter : JsonConverter<DateTime?>
        {
            public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
                => UnixDateTimeConverter.Read(ref reader)?.LocalDateTime ?? default;

            public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
                => UnixDateTimeConverter.Write(writer, value);
        }
    }
}
