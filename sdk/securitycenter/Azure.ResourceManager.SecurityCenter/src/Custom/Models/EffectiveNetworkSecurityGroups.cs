// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    /// <summary>
    /// Provides a compatibility shim for the EffectiveNetworkSecurityGroups class.
    /// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class EffectiveNetworkSecurityGroups : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.EffectiveNetworkSecurityGroups>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.EffectiveNetworkSecurityGroups>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EffectiveNetworkSecurityGroups"/> type for compatibility with the previous public API surface.
        /// </summary>
        public EffectiveNetworkSecurityGroups() { }
        /// <summary>
        /// Gets or sets the NetworkInterface value preserved from the previous public API surface.
        /// </summary>
        public string NetworkInterface { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the NetworkSecurityGroups value preserved from the previous public API surface.
        /// </summary>
        public System.Collections.Generic.IList<string> NetworkSecurityGroups { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.EffectiveNetworkSecurityGroups System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.EffectiveNetworkSecurityGroups>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.EffectiveNetworkSecurityGroups>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.EffectiveNetworkSecurityGroups System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.EffectiveNetworkSecurityGroups>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.EffectiveNetworkSecurityGroups>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.EffectiveNetworkSecurityGroups>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
