// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    public partial class InstancePoolUsageName : System.ClientModel.Primitives.IJsonModel<InstancePoolUsageName>
    {
        [WirePath("value")]
        public string Value { get; set; }
        [WirePath("localizedValue")]
        public string LocalizedValue { get; set; }

        void System.ClientModel.Primitives.IJsonModel<InstancePoolUsageName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options)
        {
            SqlCompatibilityModelSerialization.ValidateFormat(nameof(InstancePoolUsageName), options);
        }

        InstancePoolUsageName System.ClientModel.Primitives.IJsonModel<InstancePoolUsageName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options)
            => SqlCompatibilityModelSerialization.Create<InstancePoolUsageName>(nameof(InstancePoolUsageName));

        System.BinaryData System.ClientModel.Primitives.IPersistableModel<InstancePoolUsageName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options)
            => SqlCompatibilityModelSerialization.Write(writer => ((System.ClientModel.Primitives.IJsonModel<InstancePoolUsageName>)this).Write(writer, options));

        InstancePoolUsageName System.ClientModel.Primitives.IPersistableModel<InstancePoolUsageName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options)
            => SqlCompatibilityModelSerialization.Create<InstancePoolUsageName>(nameof(InstancePoolUsageName));

        string System.ClientModel.Primitives.IPersistableModel<InstancePoolUsageName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) => "J";
    }
}
