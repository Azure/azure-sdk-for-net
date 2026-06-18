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
    /// Provides a compatibility shim for the DefenderForDatabasesAwsOfferingRds class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DefenderForDatabasesAwsOfferingRds : IJsonModel<DefenderForDatabasesAwsOfferingRds>, IPersistableModel<DefenderForDatabasesAwsOfferingRds>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefenderForDatabasesAwsOfferingRds"/> type for compatibility with the previous public API surface.
        /// </summary>
        public DefenderForDatabasesAwsOfferingRds() { }
        /// <summary>
        /// Gets or sets the CloudRoleArn value preserved from the previous public API surface.
        /// </summary>
        public string CloudRoleArn { get; set; }
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
        DefenderForDatabasesAwsOfferingRds IJsonModel<DefenderForDatabasesAwsOfferingRds>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<DefenderForDatabasesAwsOfferingRds>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        DefenderForDatabasesAwsOfferingRds IPersistableModel<DefenderForDatabasesAwsOfferingRds>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<DefenderForDatabasesAwsOfferingRds>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<DefenderForDatabasesAwsOfferingRds>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
