// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Serialization
{
    using System;
    using System.Reflection;
    using Newtonsoft.Json;

    /// <summary>
    /// Converts System.DateTime objects to System.DateTimeOffset before serialization.
    /// </summary>
    internal class DateTimeConverter : ConverterBase
    {
        public override bool CanConvert(Type objectType)
        {
            TypeInfo objectTypeInfo = objectType.GetTypeInfo();
            return
                typeof(DateTime).GetTypeInfo().IsAssignableFrom(objectTypeInfo) ||
                typeof(DateTime?).GetTypeInfo().IsAssignableFrom(objectTypeInfo);
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            // Check for null first.
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            DateTimeOffset? dateTimeOffset = Expect<DateTimeOffset?>(reader, JsonToken.Date);
            return dateTimeOffset.HasValue ? dateTimeOffset.Value.UtcDateTime : (DateTime?)null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dateTime = (DateTime)value;

            var dateTimeOffset = 
                dateTime.Kind == DateTimeKind.Unspecified ? 
                    new DateTimeOffset(dateTime, TimeSpan.Zero) : 
                    new DateTimeOffset(dateTime);

            serializer.Serialize(writer, dateTimeOffset);
        }
    }
}
