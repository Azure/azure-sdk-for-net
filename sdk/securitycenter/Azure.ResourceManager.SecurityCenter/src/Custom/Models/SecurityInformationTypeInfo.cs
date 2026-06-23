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
    // Generated code only emits models and members described by the current TypeSpec shape; this previous GA signature was removed, renamed, or folded into a different model, so there is no generated backing member or serialization path to implement it. Keep a hidden ApiCompat shim and fail unsupported wire operations explicitly.
    /// <summary>
    /// Provides a compatibility shim for the SecurityInformationTypeInfo class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SecurityInformationTypeInfo : IJsonModel<SecurityInformationTypeInfo>, IPersistableModel<SecurityInformationTypeInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityInformationTypeInfo"/> type for compatibility with the previous public API surface.
        /// </summary>
        public SecurityInformationTypeInfo() { }
        /// <summary>
        /// Gets or sets whether the information type is custom.
        /// </summary>
        public bool? IsCustom { get; set; }
        /// <summary>
        /// Gets or sets the Description value preserved from the previous public API surface.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the DisplayName value preserved from the previous public API surface.
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets the IsEnabled value preserved from the previous public API surface.
        /// </summary>
        public bool? IsEnabled { get; set; }
        /// <summary>
        /// Gets the Keywords value preserved from the previous public API surface.
        /// </summary>
        public IList<InformationProtectionKeyword> Keywords { get; } = new List<InformationProtectionKeyword>();
        /// <summary>
        /// Gets or sets the Order value preserved from the previous public API surface.
        /// </summary>
        public int? Order { get; set; }
        /// <summary>
        /// Gets or sets the RecommendedLabelId value preserved from the previous public API surface.
        /// </summary>
        public System.Guid? RecommendedLabelId { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (IsCustom.HasValue)
            {
                writer.WritePropertyName("custom"u8);
                writer.WriteBooleanValue(IsCustom.Value);
            }
            if (Description is not null)
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
            }
            if (DisplayName is not null)
            {
                writer.WritePropertyName("displayName"u8);
                writer.WriteStringValue(DisplayName);
            }
            if (IsEnabled.HasValue)
            {
                writer.WritePropertyName("enabled"u8);
                writer.WriteBooleanValue(IsEnabled.Value);
            }
            if (Order.HasValue)
            {
                writer.WritePropertyName("order"u8);
                writer.WriteNumberValue(Order.Value);
            }
            if (RecommendedLabelId.HasValue)
            {
                writer.WritePropertyName("recommendedLabelId"u8);
                writer.WriteStringValue(RecommendedLabelId.Value);
            }
        }

        SecurityInformationTypeInfo IJsonModel<SecurityInformationTypeInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new SecurityInformationTypeInfo();

        void IJsonModel<SecurityInformationTypeInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        SecurityInformationTypeInfo IPersistableModel<SecurityInformationTypeInfo>.Create(System.BinaryData data, ModelReaderWriterOptions options) => new SecurityInformationTypeInfo();
        string IPersistableModel<SecurityInformationTypeInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        System.BinaryData IPersistableModel<SecurityInformationTypeInfo>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(this, options, AzureResourceManagerSecurityCenterContext.Default);
    }
}
