// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec removed or reshaped this legacy model/member, so the generator cannot recreate the previous GA signature; keep a hidden shim for ApiCompat and throw because the wire shape is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the SecurityCenterFileProtectionMode class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SecurityCenterFileProtectionMode : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterFileProtectionMode>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterFileProtectionMode>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityCenterFileProtectionMode"/> type for compatibility with the previous public API surface.
        /// </summary>
        public SecurityCenterFileProtectionMode() { }
        /// <summary>
        /// Gets or sets the Exe value preserved from the previous public API surface.
        /// </summary>
        public Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode? Exe { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the Executable value preserved from the previous public API surface.
        /// </summary>
        public Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode? Executable { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the Msi value preserved from the previous public API surface.
        /// </summary>
        public Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode? Msi { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the Script value preserved from the previous public API surface.
        /// </summary>
        public Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode? Script { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.SecurityCenterFileProtectionMode System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterFileProtectionMode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterFileProtectionMode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.SecurityCenterFileProtectionMode System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterFileProtectionMode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterFileProtectionMode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterFileProtectionMode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
