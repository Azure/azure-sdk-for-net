// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DataFactory.Tests.Framework
{
    /// <summary>
    /// A customized DateTime ISO8601-based format converter.
    /// 
    /// The difference with the IsoDateTimeFormat defined in Json.Net are below:
    ///   1. Accepts shorthand formats such as "2014-10-14"
    /// 
    ///   2. If no timezone designator is specified, assumes Utc as default.
    /// </summary>
    public class CustomIsoDateTimeConverter : JsonConverter
    {
        // The default DateTime format is identical to the one defined in Json.Net
        // https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Converters/IsoDateTimeConverter.cs
        public const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";

        public static CultureInfo DefaultCulture = CultureInfo.InvariantCulture;

        public const DateTimeStyles DefaultDateTimeStyles = DateTimeStyles.RoundtripKind;

        public static string[] ValidDateTimeFormats = 
        {
            DefaultDateTimeFormat,

            // Additional supported DateTime formats
            "yyyy'-'MM'-'dd'T'HH':'mm':'ssK",
            "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
            "yyyy'-'MM'-'ddK",
            "yyyy'-'MM'-'dd",

            // Allow lowercase "t" in Json
            "yyyy'-'MM'-'dd't'HH':'mm':'ss.FFFFFFFK",
            "yyyy'-'MM'-'dd't'HH':'mm':'ssK",
            "yyyy'-'MM'-'dd't'HH':'mm':'ss"
        };

        private readonly IsoDateTimeConverter defaultDateTimeConverter = new IsoDateTimeConverter()
        {
            DateTimeFormat = DefaultDateTimeFormat,

            Culture = DefaultCulture,

            DateTimeStyles = DateTimeStyles.RoundtripKind
        };

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            bool isNullableType = objectType == typeof(DateTime?) || objectType == typeof(DateTimeOffset?);

            bool isDateTimeOffset = objectType == typeof(DateTimeOffset) || objectType == typeof(DateTimeOffset?);

            if (reader.TokenType == JsonToken.Null)
            {
                if (!isNullableType)
                {
                    throw new JsonSerializationException();
                }

                return null;
            }

            if (reader.TokenType == JsonToken.Date)
            {
                if (isDateTimeOffset)
                {
                    return reader.Value is DateTimeOffset
                        ? reader.Value
                        : new DateTimeOffset(((DateTime)reader.Value).EnforceUtcZone());
                }

                return reader.Value is DateTime
                    ? ((DateTime)reader.Value).EnforceUtcZone()
                    : ((DateTimeOffset)reader.Value).UtcDateTime;
            }

            if (reader.TokenType != JsonToken.String)
            {
                throw new JsonSerializationException();
            }

            string text = reader.Value.ToString();

            if (string.IsNullOrWhiteSpace(text))
            {
                if (!isNullableType)
                {
                    throw new JsonSerializationException();
                }

                return null;
            }

            DateTime result;
            if (!DateTime.TryParseExact(text, ValidDateTimeFormats, DefaultCulture, DefaultDateTimeStyles, out result))
            {
                throw new JsonSerializationException();
            }

            result = result.EnforceUtcZone();

            // Note: do not use conditional operator "return isDateTimeOffset ? new DateTimeOffset(result) : result;"
            //       due to implicit type conversion issue.
            if (isDateTimeOffset)
            {
                return new DateTimeOffset(result);
            }

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            defaultDateTimeConverter.WriteJson(writer, value, serializer);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?) ||
                   objectType == typeof(DateTimeOffset) || objectType == typeof(DateTimeOffset?);
        }
    }
}
