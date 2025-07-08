// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
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
            if (ElasticsearchServiceUri.IsAbsoluteUri)
                writer.WriteStringValue(ElasticsearchServiceUri.AbsoluteUri);
            else
                writer.WriteStringValue(ElasticsearchServiceUri.OriginalString);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeElasticsearchServiceUri(JsonProperty property, ref Uri elasticsearchServiceUrl)
        {
            if (property.Value.ValueKind != JsonValueKind.Null)
            {
                if (Uri.TryCreate(property.Value.GetString(), UriKind.Absolute, out elasticsearchServiceUrl))
                {
                    elasticsearchServiceUrl = new Uri(property.Value.GetString(), UriKind.Absolute);
                }
                else
                {
                    elasticsearchServiceUrl = new Uri(property.Value.GetString(), UriKind.Relative);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteKibanaServiceUri(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (KibanaServiceUri.IsAbsoluteUri)
                writer.WriteStringValue(KibanaServiceUri.AbsoluteUri);
            else
                writer.WriteStringValue(KibanaServiceUri.OriginalString);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeKibanaServiceUri(JsonProperty property, ref Uri kibanaServiceUrl)
        {
            if (property.Value.ValueKind != JsonValueKind.Null)
            {
                if (Uri.TryCreate(property.Value.GetString(), UriKind.Absolute, out kibanaServiceUrl))
                {
                    kibanaServiceUrl = new Uri(property.Value.GetString(), UriKind.Absolute);
                }
                else
                {
                    kibanaServiceUrl = new Uri(property.Value.GetString(), UriKind.Relative);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteKibanaSsoUri(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (KibanaSsoUri.IsAbsoluteUri)
                writer.WriteStringValue(KibanaSsoUri.AbsoluteUri);
            else
                writer.WriteStringValue(KibanaSsoUri.OriginalString);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeKibanaSsoUri(JsonProperty property, ref Uri kibanaSsoUrl)
        {
            if (property.Value.ValueKind != JsonValueKind.Null)
            {
                if (Uri.TryCreate(property.Value.GetString(), UriKind.Absolute, out kibanaSsoUrl))
                {
                    kibanaSsoUrl = new Uri(property.Value.GetString(), UriKind.Absolute);
                }
                else
                {
                    kibanaSsoUrl = new Uri(property.Value.GetString(), UriKind.Relative);
                }
            }
        }
    }
}
