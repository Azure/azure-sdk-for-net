// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    public partial class ManagedInstanceQuery : Azure.ResourceManager.Models.ResourceData, IJsonModel<ManagedInstanceQuery>
    {
        public ManagedInstanceQuery()
        {
        }

        [WirePath("properties.queryText")]
        public string QueryText { get; set; }

        void IJsonModel<ManagedInstanceQuery>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (((IPersistableModel<ManagedInstanceQuery>)this).GetFormatFromOptions(options) != "J")
            {
                throw new FormatException($"The model {nameof(ManagedInstanceQuery)} does not support writing '{options.Format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (QueryText is not null)
            {
                writer.WritePropertyName("queryText"u8);
                writer.WriteStringValue(QueryText);
            }
            writer.WriteEndObject();
        }

        ManagedInstanceQuery IJsonModel<ManagedInstanceQuery>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            ManagedInstanceQuery result = new ManagedInstanceQuery();
            if (document.RootElement.TryGetProperty("properties", out JsonElement properties) &&
                properties.TryGetProperty("queryText", out JsonElement queryText))
            {
                result.QueryText = queryText.GetString();
            }
            return result;
        }

        BinaryData IPersistableModel<ManagedInstanceQuery>.Write(ModelReaderWriterOptions options)
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            ((IJsonModel<ManagedInstanceQuery>)this).Write(writer, options);
            writer.Flush();
            return BinaryData.FromBytes(stream.ToArray());
        }

        ManagedInstanceQuery IPersistableModel<ManagedInstanceQuery>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            Utf8JsonReader reader = new Utf8JsonReader(data.ToArray());
            return ((IJsonModel<ManagedInstanceQuery>)this).Create(ref reader, options);
        }

        string IPersistableModel<ManagedInstanceQuery>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
