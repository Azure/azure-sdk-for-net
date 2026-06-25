// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated code only emits models and members described by the current TypeSpec shape; this previous GA signature was removed, renamed, or folded into a different model, so there is no generated backing member or serialization path to implement it. Keep a hidden ApiCompat shim and fail unsupported wire operations explicitly.
    /// <summary>
    /// Provides a compatibility shim for the CustomAssessmentAutomationCreateOrUpdateContent class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
    public partial class CustomAssessmentAutomationCreateOrUpdateContent : ResourceData, IJsonModel<CustomAssessmentAutomationCreateOrUpdateContent>, IPersistableModel<CustomAssessmentAutomationCreateOrUpdateContent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomAssessmentAutomationCreateOrUpdateContent"/> type for compatibility with the previous public API surface.
        /// </summary>
        public CustomAssessmentAutomationCreateOrUpdateContent() { }
        /// <summary>
        /// Gets or sets the CompressedQuery value preserved from the previous public API surface.
        /// </summary>
        public string CompressedQuery { get; set; }
        /// <summary>
        /// Gets or sets the Description value preserved from the previous public API surface.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the DisplayName value preserved from the previous public API surface.
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets the RemediationDescription value preserved from the previous public API surface.
        /// </summary>
        public string RemediationDescription { get; set; }
        /// <summary>
        /// Gets or sets the Severity value preserved from the previous public API surface.
        /// </summary>
        public CustomAssessmentSeverity? Severity { get; set; }
        /// <summary>
        /// Gets or sets the SupportedCloud value preserved from the previous public API surface.
        /// </summary>
        public CustomAssessmentAutomationSupportedCloud? SupportedCloud { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        CustomAssessmentAutomationCreateOrUpdateContent IJsonModel<CustomAssessmentAutomationCreateOrUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<CustomAssessmentAutomationCreateOrUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        CustomAssessmentAutomationCreateOrUpdateContent IPersistableModel<CustomAssessmentAutomationCreateOrUpdateContent>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<CustomAssessmentAutomationCreateOrUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<CustomAssessmentAutomationCreateOrUpdateContent>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
