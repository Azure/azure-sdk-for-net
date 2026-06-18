// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec removed or reshaped this legacy model/member, so the generator cannot recreate the previous GA signature; keep a hidden shim for ApiCompat and throw because the wire shape is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the AzureDevOpsScopeEnvironment class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AzureDevOpsScopeEnvironment : SecurityConnectorEnvironment, IJsonModel<AzureDevOpsScopeEnvironment>, IPersistableModel<AzureDevOpsScopeEnvironment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureDevOpsScopeEnvironment"/> type for compatibility with the previous public API surface.
        /// </summary>
        public AzureDevOpsScopeEnvironment() { }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        AzureDevOpsScopeEnvironment IJsonModel<AzureDevOpsScopeEnvironment>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<AzureDevOpsScopeEnvironment>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        AzureDevOpsScopeEnvironment IPersistableModel<AzureDevOpsScopeEnvironment>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<AzureDevOpsScopeEnvironment>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<AzureDevOpsScopeEnvironment>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
