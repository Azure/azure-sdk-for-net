// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated resource data now follows the current TypeSpec model, constructor, and property graph; this previous GA data shape is no longer described, so the generator cannot emit its old public setters and constructor. Keep a hidden stateful shim for ApiCompat.
    /// <summary>
    /// Provides a compatibility shim for the CustomEntityStoreAssignmentData class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class CustomEntityStoreAssignmentData : ResourceData, IJsonModel<CustomEntityStoreAssignmentData>, IPersistableModel<CustomEntityStoreAssignmentData>
    {
        private const string UnsupportedMessage = "This API is no longer supported by the service. No direct replacement is available.";

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomEntityStoreAssignmentData"/> type for compatibility with the previous public API surface.
        /// </summary>
        public CustomEntityStoreAssignmentData() { }
        /// <summary>
        /// Gets or sets the EntityStoreDatabaseLink value preserved from the previous public API surface.
        /// </summary>
        public string EntityStoreDatabaseLink
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the Principal value preserved from the previous public API surface.
        /// </summary>
        public string Principal
        {
            get;
            set;
        }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        CustomEntityStoreAssignmentData IJsonModel<CustomEntityStoreAssignmentData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<CustomEntityStoreAssignmentData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        CustomEntityStoreAssignmentData IPersistableModel<CustomEntityStoreAssignmentData>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<CustomEntityStoreAssignmentData>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<CustomEntityStoreAssignmentData>.Write(ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
