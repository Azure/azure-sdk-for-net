// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated resource data now follows the current TypeSpec model, constructor, and property graph; this previous GA data shape is no longer described, so the generator cannot emit its old public setters and constructor. Keep a hidden stateful shim for ApiCompat.
    /// <summary>
    /// Provides a compatibility shim for the SoftwareInventoryData class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SoftwareInventoryData : ResourceData, IJsonModel<SoftwareInventoryData>, IPersistableModel<SoftwareInventoryData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SoftwareInventoryData"/> type for compatibility with the previous public API surface.
        /// </summary>
        public SoftwareInventoryData() { }
        /// <summary>
        /// Gets or sets the DeviceId value preserved from the previous public API surface.
        /// </summary>
        public string DeviceId { get; set; }
        /// <summary>
        /// Gets or sets the EndOfSupportDate value preserved from the previous public API surface.
        /// </summary>
        public string EndOfSupportDate { get; set; }
        /// <summary>
        /// Gets or sets the EndOfSupportStatus value preserved from the previous public API surface.
        /// </summary>
        public EndOfSupportStatus? EndOfSupportStatus { get; set; }
        /// <summary>
        /// Gets or sets the FirstSeenOn value preserved from the previous public API surface.
        /// </summary>
        public DateTimeOffset? FirstSeenOn { get; set; }
        /// <summary>
        /// Gets or sets the NumberOfKnownVulnerabilities value preserved from the previous public API surface.
        /// </summary>
        public int? NumberOfKnownVulnerabilities { get; set; }
        /// <summary>
        /// Gets or sets the OSPlatform value preserved from the previous public API surface.
        /// </summary>
        public string OSPlatform { get; set; }
        /// <summary>
        /// Gets or sets the SoftwareName value preserved from the previous public API surface.
        /// </summary>
        public string SoftwareName { get; set; }
        /// <summary>
        /// Gets or sets the Vendor value preserved from the previous public API surface.
        /// </summary>
        public string Vendor { get; set; }
        /// <summary>
        /// Gets or sets the Version value preserved from the previous public API surface.
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SoftwareInventoryData IJsonModel<SoftwareInventoryData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<SoftwareInventoryData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SoftwareInventoryData IPersistableModel<SoftwareInventoryData>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<SoftwareInventoryData>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<SoftwareInventoryData>.Write(ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
