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
    // The latest TypeSpec removed or reshaped this legacy model/member, so the generator cannot recreate the previous GA signature; keep a hidden shim for ApiCompat and throw because the wire shape is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the ConnectionToIPNotAllowed class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ConnectionToIPNotAllowed : AllowlistCustomAlertRule, IJsonModel<ConnectionToIPNotAllowed>, IPersistableModel<ConnectionToIPNotAllowed>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionToIPNotAllowed"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="isEnabled">The value preserved for API compatibility.</param>
        /// <param name="allowlistValues">The value preserved for API compatibility.</param>
        public ConnectionToIPNotAllowed(bool isEnabled, IEnumerable<string> allowlistValues) : base(default(bool), default(IEnumerable<string>)) { }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        ConnectionToIPNotAllowed IJsonModel<ConnectionToIPNotAllowed>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<ConnectionToIPNotAllowed>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        ConnectionToIPNotAllowed IPersistableModel<ConnectionToIPNotAllowed>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<ConnectionToIPNotAllowed>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<ConnectionToIPNotAllowed>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
