// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated code only emits models and members described by the current TypeSpec shape; this previous GA signature was removed, renamed, or folded into a different model, so there is no generated backing member or serialization path to implement it. Keep a hidden ApiCompat shim and fail unsupported wire operations explicitly.
    /// <summary>
    /// Provides a compatibility shim for the HybridComputeSettingsProperties class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
    public partial class HybridComputeSettingsProperties : IJsonModel<HybridComputeSettingsProperties>, IPersistableModel<HybridComputeSettingsProperties>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HybridComputeSettingsProperties"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="autoProvision">The value preserved for API compatibility.</param>
        public HybridComputeSettingsProperties(AutoProvisionState autoProvision) { }
        /// <summary>
        /// Gets or sets the AutoProvision value preserved from the previous public API surface.
        /// </summary>
        public AutoProvisionState AutoProvision { get; set; }
        /// <summary>
        /// Gets the HybridComputeProvisioningState value preserved from the previous public API surface.
        /// </summary>
        public HybridComputeProvisioningState? HybridComputeProvisioningState { get; }
        /// <summary>
        /// Gets or sets the ProxyServer value preserved from the previous public API surface.
        /// </summary>
        public ProxyServerProperties ProxyServer { get; set; }
        /// <summary>
        /// Gets or sets the Region value preserved from the previous public API surface.
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// Gets or sets the ResourceGroupName value preserved from the previous public API surface.
        /// </summary>
        public string ResourceGroupName { get; set; }
        /// <summary>
        /// Gets or sets the ServicePrincipal value preserved from the previous public API surface.
        /// </summary>
        public ServicePrincipalProperties ServicePrincipal { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        HybridComputeSettingsProperties IJsonModel<HybridComputeSettingsProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<HybridComputeSettingsProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        HybridComputeSettingsProperties IPersistableModel<HybridComputeSettingsProperties>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<HybridComputeSettingsProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<HybridComputeSettingsProperties>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
