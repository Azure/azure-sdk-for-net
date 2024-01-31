// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Monitor.Models
{
    public partial class MonitorScaleCapacity : IUtf8JsonSerializable
    {
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("minimum"u8);
            writer.WriteStringValue(Minimum.ToString(CultureInfo.InvariantCulture));
            writer.WritePropertyName("maximum"u8);
            writer.WriteStringValue(Maximum.ToString(CultureInfo.InvariantCulture));
            writer.WritePropertyName("default"u8);
            writer.WriteStringValue(Default.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndObject();
        }

        internal static MonitorScaleCapacity DeserializeMonitorScaleCapacity(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int minimum = default;
            int maximum = default;
            int @default = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("minimum"u8))
                {
                    if (!int.TryParse(property.Value.GetString(), out minimum))
                    {
                        throw new FormatException();
                    }
                    continue;
                }
                if (property.NameEquals("maximum"u8))
                {
                    if (!int.TryParse(property.Value.GetString(), out maximum))
                    {
                        throw new FormatException();
                    }
                    continue;
                }
                if (property.NameEquals("default"u8))
                {
                    if (!int.TryParse(property.Value.GetString(), out @default))
                    {
                        throw new FormatException();
                    }
                    continue;
                }
            }
            return new MonitorScaleCapacity(minimum, maximum, @default);
        }
    }
}
