// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated code only emits models and members described by the current TypeSpec shape; this previous GA signature was removed, renamed, or folded into a different model, so there is no generated backing member or serialization path to implement it. Keep a hidden ApiCompat shim and fail unsupported wire operations explicitly.
    /// <summary>
    /// Provides a compatibility shim for the SecurityAlertSyncSettings class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SecurityAlertSyncSettings : Azure.ResourceManager.SecurityCenter.SecuritySettingData, IJsonModel<SecurityAlertSyncSettings>, IPersistableModel<SecurityAlertSyncSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityAlertSyncSettings"/> type for compatibility with the previous public API surface.
        /// </summary>
        public SecurityAlertSyncSettings() { }
        /// <summary>
        /// Gets or sets the IsEnabled value preserved from the previous public API surface.
        /// </summary>
        public bool? IsEnabled { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityAlertSyncSettings IJsonModel<SecurityAlertSyncSettings>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<SecurityAlertSyncSettings>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityAlertSyncSettings IPersistableModel<SecurityAlertSyncSettings>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<SecurityAlertSyncSettings>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<SecurityAlertSyncSettings>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
