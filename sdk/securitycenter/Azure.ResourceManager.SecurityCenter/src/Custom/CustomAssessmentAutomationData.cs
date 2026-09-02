// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated resource data now follows the current TypeSpec model, constructor, and property graph; this previous GA data shape is no longer described, so the generator cannot emit its old public setters and constructor. Keep a hidden stateful shim for ApiCompat.
    /// <summary>
    /// Provides a compatibility shim for the CustomAssessmentAutomationData class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class CustomAssessmentAutomationData : ResourceData, IJsonModel<CustomAssessmentAutomationData>, IPersistableModel<CustomAssessmentAutomationData>
    {
        private const string UnsupportedMessage = "This API is no longer supported by the service. No direct replacement is available.";

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomAssessmentAutomationData"/> type for compatibility with the previous public API surface.
        /// </summary>
        public CustomAssessmentAutomationData() { }
        /// <summary>
        /// Gets or sets the AssessmentKey value preserved from the previous public API surface.
        /// </summary>
        public string AssessmentKey
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the CompressedQuery value preserved from the previous public API surface.
        /// </summary>
        public string CompressedQuery
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the Description value preserved from the previous public API surface.
        /// </summary>
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the DisplayName value preserved from the previous public API surface.
        /// </summary>
        public string DisplayName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the RemediationDescription value preserved from the previous public API surface.
        /// </summary>
        public string RemediationDescription
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the Severity value preserved from the previous public API surface.
        /// </summary>
        public CustomAssessmentSeverity? Severity
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the SupportedCloud value preserved from the previous public API surface.
        /// </summary>
        public CustomAssessmentAutomationSupportedCloud? SupportedCloud
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
        CustomAssessmentAutomationData IJsonModel<CustomAssessmentAutomationData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<CustomAssessmentAutomationData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        CustomAssessmentAutomationData IPersistableModel<CustomAssessmentAutomationData>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<CustomAssessmentAutomationData>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<CustomAssessmentAutomationData>.Write(ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
