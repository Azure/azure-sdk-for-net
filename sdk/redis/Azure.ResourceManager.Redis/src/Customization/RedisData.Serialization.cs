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
    // Workaround for MGMT generator bug: the generated RedisData deserializer emits
    // `ManagedServiceIdentity.DeserializeManagedServiceIdentity(...)`, but this static
    // helper does not exist on the cross-assembly common type
    // Azure.ResourceManager.Models.ManagedServiceIdentity, causing CS0117. Until the
    // generator is fixed to use ModelReaderWriter.Read<T> for cross-assembly common
    // types, this DeserializationValueHook reroutes Identity deserialization.
    // TODO: Remove once https://github.com/Azure/azure-sdk-for-net/issues/<TBD> is fixed.
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
