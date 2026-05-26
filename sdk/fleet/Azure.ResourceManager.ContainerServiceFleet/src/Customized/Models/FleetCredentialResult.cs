// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerServiceFleet.Models
{
    [CodeGenSerialization(nameof(Value), DeserializationValueHook = nameof(DeserializeValue))]
    public partial class FleetCredentialResult
    {
        /// <summary> Base64-encoded Kubernetes configuration file. </summary>
        public byte[] Value { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeValue(JsonProperty property, ref byte[] value)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            value = property.Value.GetBytesFromBase64("D");
        }
    }
}
