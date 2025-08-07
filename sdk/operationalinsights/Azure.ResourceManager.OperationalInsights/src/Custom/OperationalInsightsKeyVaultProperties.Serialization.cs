// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.OperationalInsights.Models
{
    // This is a fix for issue 48747.
    [CodeGenSerialization(nameof(KeyVaultUri), SerializationValueHook = nameof(WriteKeyVaultUri), DeserializationValueHook = nameof(DeserializeKeyVaultUri))]
    public partial class OperationalInsightsKeyVaultProperties
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteKeyVaultUri(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (KeyVaultUri.IsAbsoluteUri)
                writer.WriteStringValue(KeyVaultUri.AbsoluteUri);
            else
                writer.WriteStringValue(KeyVaultUri.OriginalString);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeKeyVaultUri(JsonProperty property, ref Uri keyVaultUri)
        {
            if (property.Value.ValueKind != JsonValueKind.Null)
            {
                keyVaultUri = String.IsNullOrEmpty(property.Value.GetString()) ? new Uri("", UriKind.Relative) : new Uri(property.Value.GetString());
            }
        }
    }
}
