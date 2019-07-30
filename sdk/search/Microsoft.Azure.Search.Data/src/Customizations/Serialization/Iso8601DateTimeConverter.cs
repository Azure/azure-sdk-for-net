// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Reflection;
using Newtonsoft.Json;

namespace Microsoft.Azure.Search.Serialization
{
    /// <summary>
    /// Converts between dates serialized in ISO 8601 format in JSON strings and <c cref="System.DateTime">System.DateTime</c> instances.
    /// </summary>
    /// <remarks>
    /// This JSON converter ensures that <c cref="System.DateTime">System.DateTime</c> instances are serialized to have the UTC timezone
    /// explicitly included in the JSON. It also ensures that any time zone information in the JSON is taken into account when
    /// deserializing to a new <c cref="System.DateTime">System.DateTime</c> instance. For example, if the JSON value's time component
    /// is noon and its time zone is UTC-8, the deserialized <c cref="System.DateTime">System.DateTime</c> instance's time will be 8 PM
    /// and its <c cref="System.DateTime.Kind">Kind</c> will be <c cref="System.DateTimeKind.Utc">DateTimeKind.Utc</c>.
    /// </remarks>
    internal class Iso8601DateTimeConverter : JsonConverter
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

            DateTimeOffset? dateTimeOffset = reader.Expect<DateTimeOffset?>(JsonToken.Date);
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
