// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// Provides options to be used with <see cref="DynamicData"/>.
    /// </summary>
    internal class DynamicDataOptions
    {
        public DynamicDataOptions()
        {
            // Set the default
            DateTimeFormat = "o";
        }

        public DynamicDataOptions() { }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="options"></param>
        public DynamicDataOptions(DynamicDataOptions options)
        {
            PropertyNamingConvention = options.PropertyNamingConvention;
            DateTimeHandling = options.DateTimeHandling;
        }

        /// <summary>
        /// Gets or sets an object that specifies how dynamic property names will be mapped to member names in the data buffer.
        /// </summary>
        public PropertyNamingConvention PropertyNamingConvention { get; set; }

        /// <summary>
        /// </summary>
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

            switch (options.CaseMapping)
            {
                case DynamicCaseMapping.PascalToCamel:
                    serializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    break;
                case DynamicCaseMapping.None:
                default:
                    break;
            }

            return serializerOptions;
        }

        internal static DynamicDataOptions FromSerializerOptions(JsonSerializerOptions options)
        {
            DynamicDataOptions value = new DynamicDataOptions();

            IEnumerable<JsonConverter> dtcs = options.Converters.Where(c => c.GetType() == typeof(DynamicData.DynamicDateTimeConverter));
            if (dtcs.FirstOrDefault() != null)
            {
                DynamicData.DynamicDateTimeConverter dtc = (DynamicData.DynamicDateTimeConverter)dtcs.First();
                value.DateTimeFormat = dtc.Format;
            }

            if (options.PropertyNamingPolicy == JsonNamingPolicy.CamelCase)
            {
                value.CaseMapping = DynamicCaseMapping.PascalToCamel;
            }

            return value;
        }
    }
}
