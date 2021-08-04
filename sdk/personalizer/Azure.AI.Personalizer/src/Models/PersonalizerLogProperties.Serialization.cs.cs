// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Personalizer
{
    public partial class PersonalizerLogProperties
    {
        internal static PersonalizerLogProperties DeserializePersonalizerLogProperties(JsonElement element)
        {
            Optional<PersonalizerLogPropertiesDateRange> dateRange = default;
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
                    continue;
                }
            }
            return new PersonalizerLogProperties(dateRange.Value.From, dateRange.Value.To);
        }
    }
}
