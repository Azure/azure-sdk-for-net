// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    internal partial class UnknownAlertResourceIdentifier
    {
        internal static UnknownAlertResourceIdentifier DeserializeUnknownAlertResourceIdentifier(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifierType type = "Unknown";
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceIdentifierType(property.Value.GetString());
                    continue;
                }
            }
            return new UnknownAlertResourceIdentifier(type);
        }
    }
}
