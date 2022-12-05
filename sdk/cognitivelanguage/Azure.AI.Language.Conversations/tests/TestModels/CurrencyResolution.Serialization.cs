// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class CurrencyResolution
    {
        internal static CurrencyResolution DeserializeCurrencyResolution(JsonElement element)
        {
            Optional<string> isO4217 = default;
            string unit = default;
            double value = default;
            ResolutionKind resolutionKind = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ISO4217"))
                {
                    isO4217 = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("unit"))
                {
                    unit = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("value"))
                {
                    value = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("resolutionKind"))
                {
                    resolutionKind = new ResolutionKind(property.Value.GetString());
                    continue;
                }
            }
            return new CurrencyResolution(resolutionKind, isO4217.Value, unit, value);
        }
    }
}
