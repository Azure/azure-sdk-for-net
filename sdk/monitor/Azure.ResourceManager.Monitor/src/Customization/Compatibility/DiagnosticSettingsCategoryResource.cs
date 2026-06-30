// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Monitor
{
    /// <summary> A class representing a DiagnosticSettingsCategory resource and its operations. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is no longer supported.", false)]
    public partial class DiagnosticSettingsCategoryResource : ArmResource, IJsonModel<DiagnosticSettingsCategoryData>, IPersistableModel<DiagnosticSettingsCategoryData>
    {
        /// <summary> The resource type for diagnostic settings category resources. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Insights/diagnosticSettingsCategories";

        /// <summary> Initializes a new instance of the <see cref="DiagnosticSettingsCategoryResource"/> class for mocking. </summary>
        protected DiagnosticSettingsCategoryResource()
        {
        }

        // The old diagnostic-settings category resource is no longer generated, so there is no backing data to return.
        // Keep property getters non-throwing because reflection and HasData guards may call them unexpectedly.
        /// <summary> Gets the resource data. </summary>
        public virtual DiagnosticSettingsCategoryData Data { get; }

        /// <summary> Gets whether the resource has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Creates a resource identifier for a diagnostic settings category resource. </summary>
        /// <param name="resourceUri"> The resource URI. </param>
        /// <param name="name"> The diagnostic settings category name. </param>
        /// <returns> A resource identifier. </returns>
        public static ResourceIdentifier CreateResourceIdentifier(string resourceUri, string name) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets the diagnostic settings category. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The diagnostic settings category resource. </returns>
        public virtual Response<DiagnosticSettingsCategoryResource> Get(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets the diagnostic settings category. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The diagnostic settings category resource. </returns>
        public virtual Task<Response<DiagnosticSettingsCategoryResource>> GetAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<DiagnosticSettingsCategoryData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        DiagnosticSettingsCategoryData IJsonModel<DiagnosticSettingsCategoryData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        BinaryData IPersistableModel<DiagnosticSettingsCategoryData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        DiagnosticSettingsCategoryData IPersistableModel<DiagnosticSettingsCategoryData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<DiagnosticSettingsCategoryData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
