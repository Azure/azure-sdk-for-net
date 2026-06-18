// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The current TypeSpec shape renamed this GA model to GcpProjectEnvironmentInfo. Keep this hidden compatibility type and delegate wire operations to the generated replacement.
    /// <summary>
    /// Provides a compatibility shim for the GcpProjectEnvironment class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class GcpProjectEnvironment : SecurityConnectorEnvironment, IJsonModel<GcpProjectEnvironment>, IPersistableModel<GcpProjectEnvironment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GcpProjectEnvironment"/> type for compatibility with the previous public API surface.
        /// </summary>
        public GcpProjectEnvironment() { }

        private GcpProjectEnvironment(GcpProjectEnvironmentInfo info) : this()
        {
            OrganizationalData = info.OrganizationalData;
            ProjectDetails = info.ProjectDetails;
            ScanInterval = info.ScanInterval;
        }

        private GcpProjectEnvironmentInfo ToGenerated()
        {
            return new GcpProjectEnvironmentInfo(EnvironmentType.GcpProject, new Dictionary<string, BinaryData>(), OrganizationalData, ProjectDetails, ScanInterval);
        }
        /// <summary>
        /// Gets or sets the OrganizationalData value preserved from the previous public API surface.
        /// </summary>
        public GcpOrganizationalInfo OrganizationalData { get; set; }
        /// <summary>
        /// Gets or sets the ProjectDetails value preserved from the previous public API surface.
        /// </summary>
        public GcpProjectDetails ProjectDetails { get; set; }
        /// <summary>
        /// Gets or sets the ScanInterval value preserved from the previous public API surface.
        /// </summary>
        public long? ScanInterval { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(((IPersistableModel<GcpProjectEnvironmentInfo>)ToGenerated()).Write(options), ModelSerializationExtensions.JsonDocumentOptions);
            foreach (JsonProperty property in document.RootElement.EnumerateObject())
            {
                property.WriteTo(writer);
            }
        }
        GcpProjectEnvironment IJsonModel<GcpProjectEnvironment>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new GcpProjectEnvironment(((IJsonModel<GcpProjectEnvironmentInfo>)new GcpProjectEnvironmentInfo()).Create(ref reader, options));
        void IJsonModel<GcpProjectEnvironment>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<GcpProjectEnvironmentInfo>)ToGenerated()).Write(writer, options);
        GcpProjectEnvironment IPersistableModel<GcpProjectEnvironment>.Create(System.BinaryData data, ModelReaderWriterOptions options) => new GcpProjectEnvironment(((IPersistableModel<GcpProjectEnvironmentInfo>)new GcpProjectEnvironmentInfo()).Create(data, options));
        string IPersistableModel<GcpProjectEnvironment>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<GcpProjectEnvironmentInfo>)new GcpProjectEnvironmentInfo()).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<GcpProjectEnvironment>.Write(ModelReaderWriterOptions options) => ((IPersistableModel<GcpProjectEnvironmentInfo>)ToGenerated()).Write(options);
    }
}
