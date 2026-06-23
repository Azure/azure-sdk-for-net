// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    /// <summary> Provides a compatibility shim for the IngestionSettingData class. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class IngestionSettingData : ResourceData, IJsonModel<IngestionSettingData>, IPersistableModel<IngestionSettingData>
    {
        /// <summary> Initializes a new instance of <see cref="IngestionSettingData"/>. </summary>
        public IngestionSettingData()
        {
        }

        internal IngestionSettingData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, BinaryData properties) : base(id, name, resourceType, systemData)
        {
            Properties = properties;
        }

        /// <summary> Gets or sets the ingestion setting properties. </summary>
        public BinaryData Properties { get; set; }

        IngestionSettingData IJsonModel<IngestionSettingData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new IngestionSettingData();
        void IJsonModel<IngestionSettingData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
        IngestionSettingData IPersistableModel<IngestionSettingData>.Create(BinaryData data, ModelReaderWriterOptions options) => new IngestionSettingData();
        string IPersistableModel<IngestionSettingData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<IngestionSettingData>.Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");
    }
}
