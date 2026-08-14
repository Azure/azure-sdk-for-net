// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: Adds public constructor matching prior GA shape (name only).
// Provides fields/properties referenced by the generated partial and serialization.
// Serialization/DeserializationValueHooks work around generator bug where @@alternateType
// to armResourceType emits WriteObjectValue(ResourceType) (throws NotSupportedException)
// and ResourceType.DeserializeResourceType (doesn't exist).
// Generator bug: https://github.com/Azure/azure-sdk-for-net/issues/57287
// TODO: Clean up after the generator bug is resolved.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The parameters used to check the availability of the storage account name. </summary>
    [CodeGenSerialization(nameof(ResourceType), DeserializationValueHook = nameof(DeserializeResourceType), SerializationValueHook = nameof(SerializeResourceType))]
    public partial class StorageAccountNameAvailabilityContent
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="StorageAccountNameAvailabilityContent"/>. </summary>
        /// <param name="name"> The storage account name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public StorageAccountNameAvailabilityContent(string name)
        {
            Argument.AssertNotNull(name, nameof(name));
            Name = name;
        }

        /// <summary> The storage account name. </summary>
        [WirePath("name")]
        public string Name { get; }

        /// <summary> The type of resource, Microsoft.Storage/storageAccounts. </summary>
        [WirePath("type")]
        public ResourceType ResourceType { get; } = new ResourceType("Microsoft.Storage/storageAccounts");

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SerializeResourceType(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStringValue(ResourceType.ToString());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeResourceType(JsonProperty property, ref ResourceType resourceType)
        {
            resourceType = new ResourceType(property.Value.GetString());
        }
    }
}
