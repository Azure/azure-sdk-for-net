// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec removed or reshaped this legacy model/member, so the generator cannot recreate the previous GA signature; keep a hidden shim for ApiCompat and throw because the wire shape is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the ConnectionToIPNotAllowed class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ConnectionToIPNotAllowed : Azure.ResourceManager.SecurityCenter.Models.AllowlistCustomAlertRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ConnectionToIPNotAllowed>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ConnectionToIPNotAllowed>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionToIPNotAllowed"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="isEnabled">The value preserved for API compatibility.</param>
        /// <param name="allowlistValues">The value preserved for API compatibility.</param>
        public ConnectionToIPNotAllowed(bool isEnabled, System.Collections.Generic.IEnumerable<string> allowlistValues) : base(default(bool), default(System.Collections.Generic.IEnumerable<string>)) { }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.ConnectionToIPNotAllowed System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ConnectionToIPNotAllowed>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ConnectionToIPNotAllowed>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.ConnectionToIPNotAllowed System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ConnectionToIPNotAllowed>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ConnectionToIPNotAllowed>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ConnectionToIPNotAllowed>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
