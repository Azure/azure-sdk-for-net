// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Why: This type was removed in the new generator (flattened to ResourceIdentifier), but baseline API
// exposed it as a standalone type. Recreated for backward compatibility.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    /// <summary> File source details. </summary>
    public partial class EdgeFileSourceInfo : IJsonModel<EdgeFileSourceInfo>, IPersistableModel<EdgeFileSourceInfo>
    {
        /// <summary> Initializes a new instance of <see cref="EdgeFileSourceInfo"/>. </summary>
        /// <param name="shareId"> File share ID. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="shareId"/> is null. </exception>
        public EdgeFileSourceInfo(ResourceIdentifier shareId)
        {
            Argument.AssertNotNull(shareId, nameof(shareId));
            ShareId = shareId;
        }

        /// <summary> File share ID. </summary>
        public ResourceIdentifier ShareId { get; set; }

        void IJsonModel<EdgeFileSourceInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("shareId"u8);
            writer.WriteStringValue(ShareId);
            writer.WriteEndObject();
        }

        EdgeFileSourceInfo IJsonModel<EdgeFileSourceInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return new EdgeFileSourceInfo(new ResourceIdentifier(doc.RootElement.GetProperty("shareId").GetString()));
        }

        BinaryData IPersistableModel<EdgeFileSourceInfo>.Write(ModelReaderWriterOptions options)
        {
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<EdgeFileSourceInfo>)this).Write(writer, options);
            }
            return new BinaryData(stream.ToArray());
        }

        EdgeFileSourceInfo IPersistableModel<EdgeFileSourceInfo>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return new EdgeFileSourceInfo(new ResourceIdentifier(doc.RootElement.GetProperty("shareId").GetString()));
        }

        string IPersistableModel<EdgeFileSourceInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
