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
    /// Provides a compatibility shim for the InformationProtectionAwsOffering class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class InformationProtectionAwsOffering : SecurityCenterCloudOffering, IJsonModel<InformationProtectionAwsOffering>, IPersistableModel<InformationProtectionAwsOffering>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InformationProtectionAwsOffering"/> type for compatibility with the previous public API surface.
        /// </summary>
        public InformationProtectionAwsOffering() { }
        /// <summary>
        /// Gets or sets the InformationProtectionCloudRoleArn value preserved from the previous public API surface.
        /// </summary>
        public string InformationProtectionCloudRoleArn { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        InformationProtectionAwsOffering IJsonModel<InformationProtectionAwsOffering>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<InformationProtectionAwsOffering>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        InformationProtectionAwsOffering IPersistableModel<InformationProtectionAwsOffering>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<InformationProtectionAwsOffering>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<InformationProtectionAwsOffering>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
