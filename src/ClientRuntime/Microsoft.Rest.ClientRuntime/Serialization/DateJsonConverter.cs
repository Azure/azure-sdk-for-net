// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Microsoft.Rest.Serialization
{
    /// <summary>
    /// JsonConverter that handles serialization for dates in yyyy-MM-dd format.
    /// </summary>
    public class DateJsonConverter : IsoDateTimeConverter
    {
        /// <summary>
        /// Initializes a new instance of DateJsonConverter.
        /// </summary>
        public DateJsonConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
            catch (FormatException ex)
            {
                throw new JsonException("Unable to deserialize a Date.", ex);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            try
            {
                base.WriteJson(writer, value, serializer);
            }
            catch (FormatException ex)
            {
                throw new JsonException("Unable to serialize a Date.", ex);
            }
        }
    }
}