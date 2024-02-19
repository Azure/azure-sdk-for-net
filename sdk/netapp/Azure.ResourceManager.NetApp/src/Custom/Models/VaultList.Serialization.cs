// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    internal partial class VaultList
    {
        internal static VaultList DeserializeVaultList(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<NetAppVault>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<NetAppVault> array = new List<NetAppVault>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(NetAppVault.DeserializeNetAppVault(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new VaultList(Optional.ToList(value));
        }
    }
}
