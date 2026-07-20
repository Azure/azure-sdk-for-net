// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Storage.Models
{
    // The service may return tenantId as an empty or malformed string even though the SDK exposes Guid?.
    // Keep deserialization tolerant so storage account GET/list operations do not fail on those values.
    [CodeGenSerialization(nameof(TenantId), DeserializationValueHook = nameof(DeserializeNullableGuid))]
    public partial class StorageAccountResourceAccessRule
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeNullableGuid(JsonProperty property, ref Guid? tenantId)
        {
            var str = property.Value.GetString();
            if (string.IsNullOrWhiteSpace(str) || !Guid.TryParse(str, out var parsed))
            {
                tenantId = null;
            }
            else
            {
                tenantId = parsed;
            }
        }
    }
}
