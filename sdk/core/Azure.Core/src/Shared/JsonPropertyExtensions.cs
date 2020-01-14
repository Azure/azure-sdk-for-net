// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;

namespace Azure.Core
{
    internal static class JsonPropertyExtensions
    {
        public static DateTimeOffset? GetDateTimeOffsetOrNull(this JsonProperty property)
            => property.Value.ValueKind == JsonValueKind.Null ? (DateTimeOffset?)null : DateTimeOffset.Parse(property.Value.GetString(), CultureInfo.InvariantCulture);

        public static bool? GetBooleanOrNull(this JsonProperty property)
            => property.Value.ValueKind == JsonValueKind.Null ? (bool?)null : property.Value.GetBoolean();

        public static void ReadToDictionary(this JsonProperty property, IDictionary<string, string> dictionary)
        {
            foreach (JsonProperty element in property.Value.EnumerateObject())
            {
                dictionary.Add(element.Name, element.Value.GetString());
            }
        }
    }
}
