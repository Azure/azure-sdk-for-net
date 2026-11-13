// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Keep the GA environment model shape writable: the generated discriminator hierarchy does not expose the previous public constructor and flattened settable properties needed for source compatibility.
    public partial class GcpProjectEnvironment : IPersistableModel<GcpProjectEnvironment>
    {
        /// <summary> Initializes a new instance of <see cref="GcpProjectEnvironment"/>. </summary>
        public GcpProjectEnvironment() : base(EnvironmentType.GcpProject, new ChangeTrackingDictionary<string, BinaryData>())
        {
        }

        /// <summary> Gets or sets the GCP project's organizational data. </summary>
        public GcpOrganizationalInfo OrganizationalData { get; set; }

        /// <summary> Gets or sets the GCP project's details. </summary>
        public GcpProjectDetails ProjectDetails { get; set; }

        /// <summary> Gets or sets the scan interval in hours. </summary>
        public long? ScanInterval { get; set; }

        void IJsonModel<GcpProjectEnvironment>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        GcpProjectEnvironment IJsonModel<GcpProjectEnvironment>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (GcpProjectEnvironment)JsonModelCreateCore(ref reader, options);
        BinaryData IPersistableModel<GcpProjectEnvironment>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        GcpProjectEnvironment IPersistableModel<GcpProjectEnvironment>.Create(BinaryData data, ModelReaderWriterOptions options) => (GcpProjectEnvironment)PersistableModelCreateCore(data, options);
        string IPersistableModel<GcpProjectEnvironment>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
