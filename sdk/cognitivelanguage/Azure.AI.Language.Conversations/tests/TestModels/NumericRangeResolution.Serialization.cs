// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class NumericRangeResolution
    {
        internal static NumericRangeResolution DeserializeNumericRangeResolution(JsonElement element)
        {
            RangeKind rangeKind = default;
            double minimum = default;
            double maximum = default;
            ResolutionKind resolutionKind = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("rangeKind"))
                {
                    rangeKind = new RangeKind(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("minimum"))
                {
                    minimum = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("maximum"))
                {
                    maximum = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("resolutionKind"))
                {
                    resolutionKind = new ResolutionKind(property.Value.GetString());
                    continue;
                }
            }
            return new NumericRangeResolution(resolutionKind, rangeKind, minimum, maximum);
        }
    }
}
