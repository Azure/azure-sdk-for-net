// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    public partial class InstancePoolUsage : System.ClientModel.Primitives.IJsonModel<InstancePoolUsage>
    {
        [WirePath("id")]
        public ResourceIdentifier Id { get; set; }
        [WirePath("name")]
        public InstancePoolUsageName Name { get; set; }
        [WirePath("type")]
        public ResourceType? ResourceType { get; set; }
        [WirePath("unit")]
        public string Unit { get; set; }
        [WirePath("currentValue")]
        public int? CurrentValue { get; set; }
        [WirePath("limit")]
        public int? Limit { get; set; }
        [WirePath("requestedLimit")]
        public int? RequestedLimit { get; set; }

        void System.ClientModel.Primitives.IJsonModel<InstancePoolUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options)
        {
            SqlCompatibilityModelSerialization.ValidateFormat(nameof(InstancePoolUsage), options);
        }

        InstancePoolUsage System.ClientModel.Primitives.IJsonModel<InstancePoolUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options)
            => SqlCompatibilityModelSerialization.Create<InstancePoolUsage>(nameof(InstancePoolUsage));

        System.BinaryData System.ClientModel.Primitives.IPersistableModel<InstancePoolUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options)
            => SqlCompatibilityModelSerialization.Write(writer => ((System.ClientModel.Primitives.IJsonModel<InstancePoolUsage>)this).Write(writer, options));

        InstancePoolUsage System.ClientModel.Primitives.IPersistableModel<InstancePoolUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options)
            => SqlCompatibilityModelSerialization.Create<InstancePoolUsage>(nameof(InstancePoolUsage));

        string System.ClientModel.Primitives.IPersistableModel<InstancePoolUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) => "J";
    }
}
