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
    /// Provides a compatibility shim for the SecurityCenterFileProtectionMode class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SecurityCenterFileProtectionMode : IJsonModel<SecurityCenterFileProtectionMode>, IPersistableModel<SecurityCenterFileProtectionMode>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityCenterFileProtectionMode"/> type for compatibility with the previous public API surface.
        /// </summary>
        public SecurityCenterFileProtectionMode() { }
        /// <summary>
        /// Gets or sets the Exe value preserved from the previous public API surface.
        /// </summary>
        public AdaptiveApplicationControlEnforcementMode? Exe { get; set; }
        /// <summary>
        /// Gets or sets the Executable value preserved from the previous public API surface.
        /// </summary>
        public AdaptiveApplicationControlEnforcementMode? Executable { get; set; }
        /// <summary>
        /// Gets or sets the Msi value preserved from the previous public API surface.
        /// </summary>
        public AdaptiveApplicationControlEnforcementMode? Msi { get; set; }
        /// <summary>
        /// Gets or sets the Script value preserved from the previous public API surface.
        /// </summary>
        public AdaptiveApplicationControlEnforcementMode? Script { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityCenterFileProtectionMode IJsonModel<SecurityCenterFileProtectionMode>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<SecurityCenterFileProtectionMode>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityCenterFileProtectionMode IPersistableModel<SecurityCenterFileProtectionMode>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<SecurityCenterFileProtectionMode>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<SecurityCenterFileProtectionMode>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
