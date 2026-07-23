// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.AppService;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppService.Models
{
    [CodeGenSerialization(nameof(KeyVaultId), DeserializationValueHook = nameof(DeserializeKeyVaultId))]
    internal partial class CertificatePatchResourceProperties
    {
        // Compatibility shim: property CerBlob is now writable.
        /// <summary>
        /// Raw bytes of .cer file
        /// </summary>
        [WirePath("cerBlob")]
        public BinaryData CerBlob { get; set;}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeKeyVaultId(JsonProperty property, ref ResourceIdentifier keyVaultId)
        {
            if (property.Value.ValueKind == JsonValueKind.Null || property.Value.GetString().Length == 0)
            {
                return;
            }
            keyVaultId = new ResourceIdentifier(property.Value.GetString());
        }
    }
}
