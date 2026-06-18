// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter
{
    // The latest TypeSpec removed this legacy resource or operation path, so the generator cannot emit the previous GA management-plane method; keep a hidden shim for ApiCompat and throw because the service path is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the SecurityApplicationData class.
    /// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SecurityApplicationData : Azure.ResourceManager.SecurityCenter.SecurityConnectorApplicationData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SecurityApplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SecurityApplicationData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityApplicationData"/> type for compatibility with the previous public API surface.
        /// </summary>
        public SecurityApplicationData() { }
        /// <summary>
        /// Gets the ConditionSets value preserved from the previous public API surface.
        /// </summary>
        public new System.Collections.Generic.IList<System.BinaryData> ConditionSets { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the Description value preserved from the previous public API surface.
        /// </summary>
        public new string Description { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the DisplayName value preserved from the previous public API surface.
        /// </summary>
        public new string DisplayName { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the SourceResourceType value preserved from the previous public API surface.
        /// </summary>
        public new Azure.ResourceManager.SecurityCenter.Models.ApplicationSourceResourceType? SourceResourceType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.SecurityApplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SecurityApplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SecurityApplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.SecurityApplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SecurityApplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SecurityApplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SecurityApplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
