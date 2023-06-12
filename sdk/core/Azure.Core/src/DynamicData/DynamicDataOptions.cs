// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core.Serialization;

namespace Azure.Core.Dynamic
{
    internal class DynamicDataOptions
    {
        public DynamicDataOptions()
        {
            // Set the default
            DateTimeFormat = "o";
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="options"></param>
        public DynamicDataOptions(DynamicDataOptions options)
        {
            PropertyNamingConvention = options.PropertyNamingConvention;
            DateTimeFormat = options.DateTimeFormat;
        }

        public PropertyNamingConvention PropertyNamingConvention { get; set; }

        public string DateTimeFormat { get; set; }

        internal static JsonSerializerOptions ToSerializerOptions(DynamicDataOptions options)
        {
            JsonSerializerOptions serializerOptions = new()
            {
                Converters =
                {
                    new DynamicData.DefaultTimeSpanConverter(),
                    new DynamicData.DynamicDateTimeConverter(options.DateTimeFormat),
                    new DynamicData.DynamicDateTimeOffsetConverter(options.DateTimeFormat),
                }
            };

            switch (options.PropertyNamingConvention)
            {
                case PropertyNamingConvention.CamelCase:
                    serializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    break;
                case PropertyNamingConvention.None:
                default:
                    break;
            }

            return serializerOptions;
        }

        internal static DynamicDataOptions FromSerializerOptions(JsonSerializerOptions options)
        {
            DynamicDataOptions value = new();

            IEnumerable<JsonConverter> dtcs = options.Converters.Where(c => c.GetType() == typeof(DynamicData.DynamicDateTimeConverter));
            if (dtcs.FirstOrDefault() != null)
            {
                DynamicData.DynamicDateTimeConverter dtc = (DynamicData.DynamicDateTimeConverter)dtcs.First();
                value.DateTimeFormat = dtc.Format;
            }

            if (options.PropertyNamingPolicy == JsonNamingPolicy.CamelCase)
            {
                value.PropertyNamingConvention = PropertyNamingConvention.CamelCase;
            }

            return value;
        }
    }
}
