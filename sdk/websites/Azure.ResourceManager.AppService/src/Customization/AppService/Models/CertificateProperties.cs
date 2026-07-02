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
    // KeyVaultId is modeled as armResourceIdentifier in spec; some legacy recordings/payloads serialize it as
    // an empty string. ResourceIdentifier's ctor throws ArgumentException on empty input, so add a deserialization
    // hook that treats empty/null as missing instead of constructing a ResourceIdentifier.
    [CodeGenSerialization(nameof(KeyVaultId), DeserializationValueHook = nameof(DeserializeKeyVaultId))]
    internal partial class CertificateProperties
    {
        // Compatibility shim: property CerBlob is now writable.
        /// <summary>
        /// Raw bytes of .cer file
        /// <para>
        /// To assign a byte[] to this property use <see cref="BinaryData.FromBytes(byte[])"/>.
        /// The byte[] will be serialized to a Base64 encoded string.
        /// </para>
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
