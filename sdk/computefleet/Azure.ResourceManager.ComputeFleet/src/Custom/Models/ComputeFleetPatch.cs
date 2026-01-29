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

namespace Azure.ResourceManager.ComputeFleet.Models
{
    /// <summary> Fleet Update Model. </summary>
    [CodeGenSerialization(nameof(Identity), DeserializationValueHook = nameof(DeserializeManagedServiceIdentity))]
    public partial class ComputeFleetPatch
    {
        /// <summary> Updatable managed service identity. </summary>
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get; set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeManagedServiceIdentity(JsonProperty property, ref ManagedServiceIdentity identity)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            identity = ModelReaderWriter.Read<ManagedServiceIdentity>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerComputeFleetContext.Default);
        }
    }
}
