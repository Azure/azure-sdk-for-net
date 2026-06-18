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
    /// Provides a compatibility shim for the DefenderForDatabasesAwsOfferingArcAutoProvisioning class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DefenderForDatabasesAwsOfferingArcAutoProvisioning : IJsonModel<DefenderForDatabasesAwsOfferingArcAutoProvisioning>, IPersistableModel<DefenderForDatabasesAwsOfferingArcAutoProvisioning>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefenderForDatabasesAwsOfferingArcAutoProvisioning"/> type for compatibility with the previous public API surface.
        /// </summary>
        public DefenderForDatabasesAwsOfferingArcAutoProvisioning() { }
        /// <summary>
        /// Gets or sets the CloudRoleArn value preserved from the previous public API surface.
        /// </summary>
        public string CloudRoleArn { get; set; }
        /// <summary>
        /// Gets or sets the Configuration value preserved from the previous public API surface.
        /// </summary>
        public DefenderFoDatabasesAwsOfferingArcAutoProvisioningConfiguration Configuration { get; set; }
        /// <summary>
        /// Gets or sets the IsEnabled value preserved from the previous public API surface.
        /// </summary>
        public bool? IsEnabled { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        DefenderForDatabasesAwsOfferingArcAutoProvisioning IJsonModel<DefenderForDatabasesAwsOfferingArcAutoProvisioning>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<DefenderForDatabasesAwsOfferingArcAutoProvisioning>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        DefenderForDatabasesAwsOfferingArcAutoProvisioning IPersistableModel<DefenderForDatabasesAwsOfferingArcAutoProvisioning>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<DefenderForDatabasesAwsOfferingArcAutoProvisioning>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<DefenderForDatabasesAwsOfferingArcAutoProvisioning>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
