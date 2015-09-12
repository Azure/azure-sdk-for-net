// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System;
using Newtonsoft.Json;

namespace Microsoft.Azure.Search.Serialization
{
    /// <summary>
    /// Converts System.DateTime objects to System.DateTimeOffset before serialization.
    /// </summary>
    internal class DateTimeConverter : ConverterBase
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(DateTime).IsAssignableFrom(objectType) || typeof(DateTime?).IsAssignableFrom(objectType);
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
