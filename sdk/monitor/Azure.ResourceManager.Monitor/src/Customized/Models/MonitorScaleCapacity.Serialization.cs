// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Text.Json;
using Azure.Core;

[assembly: CodeGenSuppressType("MonitorScaleCapacity")]

namespace Azure.ResourceManager.Monitor.Models
{
    public partial class MonitorScaleCapacity : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("minimum");
            writer.WriteStringValue(Minimum.ToString(CultureInfo.InvariantCulture));
            writer.WritePropertyName("maximum");
            writer.WriteStringValue(Maximum.ToString(CultureInfo.InvariantCulture));
            writer.WritePropertyName("default");
            writer.WriteStringValue(Default.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndObject();
        }

        internal static MonitorScaleCapacity DeserializeMonitorScaleCapacity(JsonElement element)
        {
            int minimum = default;
            int maximum = default;
            int @default = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("minimum"))
                {
                    if (!int.TryParse(property.Value.GetString(), out minimum))
                    {
                        throw new FormatException();
                    }
                    continue;
                }
                if (property.NameEquals("maximum"))
                {
                    if (!int.TryParse(property.Value.GetString(), out maximum))
                    {
                        throw new FormatException();
                    }
                    continue;
                }
                if (property.NameEquals("default"))
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
