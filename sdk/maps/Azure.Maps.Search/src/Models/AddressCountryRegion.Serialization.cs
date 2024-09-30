// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;

namespace Azure.Maps.Search.Models
{
    public partial class AddressCountryRegion
    {
        internal static AddressCountryRegion DeserializeAddressCountryRegion(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string iso = default;
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("iso"u8))
                {
                    iso = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
            }
            return new AddressCountryRegion(iso, name);
        }
    }
}
