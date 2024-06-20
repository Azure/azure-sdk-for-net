// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Personalizer
{
    public partial class PersonalizerLogProperties
    {
        internal static PersonalizerLogProperties DeserializePersonalizerLogProperties(JsonElement element)
        {
            PersonalizerLogPropertiesDateRange dateRange = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("dateRange"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    dateRange = PersonalizerLogPropertiesDateRange.DeserializePersonalizerLogPropertiesDateRange(property.Value);
                    return new PersonalizerLogProperties(dateRange.From, dateRange.To);
                }
            }
            return new PersonalizerLogProperties(DateTime.MinValue, DateTime.MinValue);
        }
    }
}
