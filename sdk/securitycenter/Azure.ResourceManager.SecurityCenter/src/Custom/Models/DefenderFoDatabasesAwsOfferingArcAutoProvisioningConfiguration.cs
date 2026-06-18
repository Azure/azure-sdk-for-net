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
    /// Provides a compatibility shim for the DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration : IJsonModel<DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration>, IPersistableModel<DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration"/> type for compatibility with the previous public API surface.
        /// </summary>
        public DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration() { }
        /// <summary>
        /// Gets or sets the PrivateLinkScope value preserved from the previous public API surface.
        /// </summary>
        public string PrivateLinkScope { get; set; }
        /// <summary>
        /// Gets or sets the Proxy value preserved from the previous public API surface.
        /// </summary>
        public string Proxy { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration IJsonModel<DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration IPersistableModel<DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
