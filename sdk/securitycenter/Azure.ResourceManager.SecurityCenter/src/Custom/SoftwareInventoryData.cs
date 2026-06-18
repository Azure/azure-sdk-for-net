// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter
{
    // The latest TypeSpec removed this legacy resource or operation path, so the generator cannot emit the previous GA management-plane method; keep a hidden shim for ApiCompat and throw because the service path is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the SoftwareInventoryData class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SoftwareInventoryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SoftwareInventoryData"/> type for compatibility with the previous public API surface.
        /// </summary>
        public SoftwareInventoryData() { }
        /// <summary>
        /// Gets or sets the DeviceId value preserved from the previous public API surface.
        /// </summary>
        public string DeviceId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the EndOfSupportDate value preserved from the previous public API surface.
        /// </summary>
        public string EndOfSupportDate { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the EndOfSupportStatus value preserved from the previous public API surface.
        /// </summary>
        public Azure.ResourceManager.SecurityCenter.Models.EndOfSupportStatus? EndOfSupportStatus { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the FirstSeenOn value preserved from the previous public API surface.
        /// </summary>
        public System.DateTimeOffset? FirstSeenOn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the NumberOfKnownVulnerabilities value preserved from the previous public API surface.
        /// </summary>
        public int? NumberOfKnownVulnerabilities { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the OSPlatform value preserved from the previous public API surface.
        /// </summary>
        public string OSPlatform { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the SoftwareName value preserved from the previous public API surface.
        /// </summary>
        public string SoftwareName { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the Vendor value preserved from the previous public API surface.
        /// </summary>
        public string Vendor { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the Version value preserved from the previous public API surface.
        /// </summary>
        public string Version { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.SoftwareInventoryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.SoftwareInventoryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
