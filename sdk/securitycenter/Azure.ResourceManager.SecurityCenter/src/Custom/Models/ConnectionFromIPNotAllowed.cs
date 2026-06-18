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
    /// Provides a compatibility shim for the ConnectionFromIPNotAllowed class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ConnectionFromIPNotAllowed : AllowlistCustomAlertRule, IJsonModel<ConnectionFromIPNotAllowed>, IPersistableModel<ConnectionFromIPNotAllowed>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionFromIPNotAllowed"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="isEnabled">The value preserved for API compatibility.</param>
        /// <param name="allowlistValues">The value preserved for API compatibility.</param>
        public ConnectionFromIPNotAllowed(bool isEnabled, IEnumerable<string> allowlistValues) : base(default(bool), default(IEnumerable<string>)) { }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        ConnectionFromIPNotAllowed IJsonModel<ConnectionFromIPNotAllowed>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<ConnectionFromIPNotAllowed>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        ConnectionFromIPNotAllowed IPersistableModel<ConnectionFromIPNotAllowed>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<ConnectionFromIPNotAllowed>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<ConnectionFromIPNotAllowed>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
