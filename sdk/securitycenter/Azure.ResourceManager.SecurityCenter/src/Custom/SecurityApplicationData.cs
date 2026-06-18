// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // The latest TypeSpec split the application data shape by scope, so the generator cannot emit the previous shared GA model. Keep a hidden stateful shim for ApiCompat.
    /// <summary>
    /// Provides a compatibility shim for the SecurityApplicationData class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SecurityApplicationData : SecurityConnectorApplicationData, IJsonModel<SecurityApplicationData>, IPersistableModel<SecurityApplicationData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityApplicationData"/> type for compatibility with the previous public API surface.
        /// </summary>
        public SecurityApplicationData() { }
        /// <summary>
        /// Gets the ConditionSets value preserved from the previous public API surface.
        /// </summary>
        public new IList<System.BinaryData> ConditionSets { get; } = new List<System.BinaryData>();
        /// <summary>
        /// Gets or sets the Description value preserved from the previous public API surface.
        /// </summary>
        public new string Description { get; set; }
        /// <summary>
        /// Gets or sets the DisplayName value preserved from the previous public API surface.
        /// </summary>
        public new string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets the SourceResourceType value preserved from the previous public API surface.
        /// </summary>
        public new ApplicationSourceResourceType? SourceResourceType { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityApplicationData IJsonModel<SecurityApplicationData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<SecurityApplicationData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityApplicationData IPersistableModel<SecurityApplicationData>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<SecurityApplicationData>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<SecurityApplicationData>.Write(ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
