// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Elastic.Models
{
    // This is the fix for issue #50974
    [CodeGenSerialization(nameof(ElasticsearchServiceUri), SerializationValueHook = nameof(WriteElasticsearchServiceUri), DeserializationValueHook = nameof(DeserializeElasticsearchServiceUri))]
    [CodeGenSerialization(nameof(KibanaServiceUri), SerializationValueHook = nameof(WriteKibanaServiceUri), DeserializationValueHook = nameof(DeserializeKibanaServiceUri))]
    [CodeGenSerialization(nameof(KibanaSsoUri), SerializationValueHook = nameof(WriteKibanaSsoUri), DeserializationValueHook = nameof(DeserializeKibanaSsoUri))]
    public partial class ElasticCloudDeployment
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteElasticsearchServiceUri(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            WriteUri(writer, ElasticsearchServiceUri);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeElasticsearchServiceUri(JsonProperty property, ref Uri elasticsearchServiceUrl)
        {
            DeserializeUri(property, ref elasticsearchServiceUrl);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteKibanaServiceUri(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            WriteUri(writer, KibanaServiceUri);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeKibanaServiceUri(JsonProperty property, ref Uri kibanaServiceUrl)
        {
            DeserializeUri(property, ref kibanaServiceUrl);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteKibanaSsoUri(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            WriteUri(writer, KibanaSsoUri);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeKibanaSsoUri(JsonProperty property, ref Uri kibanaSsoUrl)
        {
            DeserializeUri(property, ref kibanaSsoUrl);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void WriteUri(Utf8JsonWriter writer, Uri uri)
        {
            writer.WriteStringValue(uri.IsAbsoluteUri ? uri.AbsoluteUri : uri.OriginalString);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeUri(JsonProperty property, ref Uri uri)
        {
            if (property.Value.ValueKind != JsonValueKind.Null)
            {
                var uriString = property.Value.GetString();
                uri = Uri.TryCreate(uriString, UriKind.Absolute, out var absoluteUri)
                    ? absoluteUri
                    : new Uri(uriString, UriKind.Relative);
            }
        }
    }
}
