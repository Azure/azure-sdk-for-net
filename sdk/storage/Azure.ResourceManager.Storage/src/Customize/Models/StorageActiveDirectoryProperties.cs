// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    [CodeGenSerialization(nameof(DomainGuid), DeserializationValueHook = nameof(DeserializeNullableGuid))]
    public partial class StorageActiveDirectoryProperties
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeNullableGuid(JsonProperty property, ref Guid domainGuid)
        {
            if (string.IsNullOrEmpty(property.Value.GetString()))
            {
                domainGuid = Guid.Empty;
            }
            else
            {
                domainGuid = property.Value.GetGuid();
            }
        }
    }
}
