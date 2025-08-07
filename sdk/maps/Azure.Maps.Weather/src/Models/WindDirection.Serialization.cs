// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using System;
using System.Text.Json;

namespace Azure.Maps.Weather.Models
{
    [CodeGenSuppress("DeserializeWindDirection", typeof(JsonElement))]
    public partial class WindDirection
    {
        internal static WindDirection DeserializeWindDirection(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int? degrees = default;
            string localizedDescription = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("degrees"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    degrees = Convert.ToInt32(property.Value.GetDouble());
                    continue;
                }
                if (property.NameEquals("localizedDescription"u8))
                {
                    localizedDescription = property.Value.GetString();
                    continue;
                }
            }
            return new WindDirection(degrees, localizedDescription);
        }
    }
}
