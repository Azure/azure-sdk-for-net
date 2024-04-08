// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Monitor.Models
{
    [CodeGenSerialization(nameof(TenantId), DeserializationValueHook = nameof(DeserializeTenantIdValue))]
    public partial class EventDataInfo : IUtf8JsonSerializable, IJsonModel<EventDataInfo>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeTenantIdValue(JsonProperty property, ref Guid? tenantId)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
                return;
            var str = property.Value.GetString();
            if (!string.IsNullOrEmpty(str))
            {
                tenantId = Guid.Parse(str);
            }
        }
    }
}
