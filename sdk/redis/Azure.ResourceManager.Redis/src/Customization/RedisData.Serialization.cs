// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Redis
{
    [CodeGenSerialization(nameof(Identity), DeserializationValueHook = nameof(ReadIdentity))]
    public partial class RedisData
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadIdentity(JsonProperty property, ref ManagedServiceIdentity identity)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
                return;

            identity = ModelReaderWriter.Read<ManagedServiceIdentity>(
                new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())),
                ModelSerializationExtensions.WireOptions,
                AzureResourceManagerRedisContext.Default);
        }
    }
}
