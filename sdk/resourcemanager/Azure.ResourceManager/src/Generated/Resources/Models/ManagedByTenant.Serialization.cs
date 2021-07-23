﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    public partial class ManagedByTenant
    {
        internal static ManagedByTenant DeserializeManagedByTenant(JsonElement element)
        {
            Optional<string> tenantId = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tenantId"))
                {
                    tenantId = property.Value.GetString();
                    continue;
                }
            }
            return new ManagedByTenant(tenantId.Value);
        }
    }
}
