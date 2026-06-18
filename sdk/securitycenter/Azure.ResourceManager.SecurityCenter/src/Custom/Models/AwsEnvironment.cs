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
    /// Provides a compatibility shim for the AwsEnvironment class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AwsEnvironment : SecurityConnectorEnvironment, IJsonModel<AwsEnvironment>, IPersistableModel<AwsEnvironment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AwsEnvironment"/> type for compatibility with the previous public API surface.
        /// </summary>
        public AwsEnvironment() { }
        /// <summary>
        /// Gets the AccountName value preserved from the previous public API surface.
        /// </summary>
        public string AccountName { get; }
        /// <summary>
        /// Gets or sets the OrganizationalData value preserved from the previous public API surface.
        /// </summary>
        public AwsOrganizationalInfo OrganizationalData { get; set; }
        /// <summary>
        /// Gets the Regions value preserved from the previous public API surface.
        /// </summary>
        public IList<string> Regions { get; } = new List<string>();
        /// <summary>
        /// Gets or sets the ScanInterval value preserved from the previous public API surface.
        /// </summary>
        public long? ScanInterval { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        AwsEnvironment IJsonModel<AwsEnvironment>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<AwsEnvironment>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        AwsEnvironment IPersistableModel<AwsEnvironment>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<AwsEnvironment>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<AwsEnvironment>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
