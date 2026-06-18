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
        /// Gets or sets the Custom value preserved from the previous public API surface.
        /// </summary>
        public bool? Custom { get; set; }
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
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityInformationTypeInfo IJsonModel<SecurityInformationTypeInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<SecurityInformationTypeInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        SecurityInformationTypeInfo IPersistableModel<SecurityInformationTypeInfo>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<SecurityInformationTypeInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<SecurityInformationTypeInfo>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
