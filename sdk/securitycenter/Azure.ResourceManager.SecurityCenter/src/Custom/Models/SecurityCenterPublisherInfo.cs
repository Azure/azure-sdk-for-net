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
    /// Provides a compatibility shim for the SecurityCenterPublisherInfo class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SecurityCenterPublisherInfo : IJsonModel<SecurityCenterPublisherInfo>, IPersistableModel<SecurityCenterPublisherInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityCenterPublisherInfo"/> type for compatibility with the previous public API surface.
        /// </summary>
        public SecurityCenterPublisherInfo() { }
        /// <summary>
        /// Gets or sets the BinaryName value preserved from the previous public API surface.
        /// </summary>
        public string BinaryName { get; set; }
        /// <summary>
        /// Gets or sets the ProductName value preserved from the previous public API surface.
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Gets or sets the PublisherName value preserved from the previous public API surface.
        /// </summary>
        public string PublisherName { get; set; }
        /// <summary>
        /// Gets or sets the Version value preserved from the previous public API surface.
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityCenterPublisherInfo IJsonModel<SecurityCenterPublisherInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<SecurityCenterPublisherInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityCenterPublisherInfo IPersistableModel<SecurityCenterPublisherInfo>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<SecurityCenterPublisherInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<SecurityCenterPublisherInfo>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
