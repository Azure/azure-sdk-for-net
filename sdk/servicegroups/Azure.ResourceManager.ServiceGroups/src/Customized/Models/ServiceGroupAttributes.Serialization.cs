// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;

namespace Azure.ResourceManager.ServiceGroups.Models
{
    // The service may return criticality as a JSON number with a fractional part (for example 2.0),
    // for which JsonElement.GetInt32() throws a FormatException.
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(Criticality), DeserializationValueHook = nameof(ReadCriticality))]
    internal partial class ServiceGroupAttributes
    {
        internal static void ReadCriticality(JsonProperty property, ref int? value)
        {
            JsonElement element = property.Value;
            if (element.ValueKind == JsonValueKind.Null)
            {
                value = null;
                return;
            }
            if (element.TryGetInt32(out int intValue))
            {
                value = intValue;
                return;
            }
            double doubleValue = element.GetDouble();
            if (doubleValue != Math.Truncate(doubleValue) || doubleValue < int.MinValue || doubleValue > int.MaxValue)
            {
                throw new FormatException($"The value '{element.GetRawText()}' for 'criticality' is not a valid integer.");
            }
            value = (int)doubleValue;
        }
    }
}
