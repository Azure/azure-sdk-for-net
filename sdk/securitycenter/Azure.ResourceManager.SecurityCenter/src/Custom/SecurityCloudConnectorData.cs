// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated resource data now follows the current TypeSpec model, constructor, and property graph; this previous GA data shape is no longer described, so the generator cannot emit its old public setters and constructor. Keep a hidden stateful shim for ApiCompat.
    /// <summary>
    /// Provides a compatibility shim for the SecurityCloudConnectorData class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SecurityCloudConnectorData : ResourceData, IJsonModel<SecurityCloudConnectorData>, IPersistableModel<SecurityCloudConnectorData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityCloudConnectorData"/> type for compatibility with the previous public API surface.
        /// </summary>
        public SecurityCloudConnectorData() { }
        /// <summary>
        /// Gets or sets the AuthenticationDetails value preserved from the previous public API surface.
        /// </summary>
        public AuthenticationDetailsProperties AuthenticationDetails { get; set; }
        /// <summary>
        /// Gets or sets the HybridComputeSettings value preserved from the previous public API surface.
        /// </summary>
        public HybridComputeSettingsProperties HybridComputeSettings { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityCloudConnectorData IJsonModel<SecurityCloudConnectorData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<SecurityCloudConnectorData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityCloudConnectorData IPersistableModel<SecurityCloudConnectorData>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<SecurityCloudConnectorData>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<SecurityCloudConnectorData>.Write(ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
