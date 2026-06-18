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

namespace Azure.ResourceManager.Monitor
{
    /// <summary> A class representing a DiagnosticSetting resource and its operations. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public partial class DiagnosticSettingResource : ArmResource, IJsonModel<DiagnosticSettingData>, IPersistableModel<DiagnosticSettingData>
    {
        /// <summary> The resource type for diagnostic setting resources. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Insights/diagnosticSettings";

        /// <summary> Initializes a new instance of the <see cref="DiagnosticSettingResource"/> class for mocking. </summary>
        protected DiagnosticSettingResource()
        {
        }

        /// <summary> Gets the resource data. </summary>
        public virtual DiagnosticSettingData Data => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets whether the resource has data. </summary>
        public virtual bool HasData => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Creates a resource identifier for a diagnostic setting resource. </summary>
        /// <param name="resourceUri"> The resource URI. </param>
        /// <param name="name"> The diagnostic setting name. </param>
        /// <returns> A resource identifier. </returns>
        public static ResourceIdentifier CreateResourceIdentifier(string resourceUri, string name) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets the diagnostic setting. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The diagnostic setting resource. </returns>
        public virtual Response<DiagnosticSettingResource> Get(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets the diagnostic setting. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The diagnostic setting resource. </returns>
        public virtual Task<Response<DiagnosticSettingResource>> GetAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Deletes the diagnostic setting. </summary>
        /// <param name="waitUntil"> Completion behavior for the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The delete operation. </returns>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Deletes the diagnostic setting. </summary>
        /// <param name="waitUntil"> Completion behavior for the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The delete operation. </returns>
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Updates the diagnostic setting. </summary>
        /// <param name="waitUntil"> Completion behavior for the operation. </param>
        /// <param name="data"> The diagnostic setting data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The update operation. </returns>
        public virtual ArmOperation<DiagnosticSettingResource> Update(WaitUntil waitUntil, DiagnosticSettingData data, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Updates the diagnostic setting. </summary>
        /// <param name="waitUntil"> Completion behavior for the operation. </param>
        /// <param name="data"> The diagnostic setting data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The update operation. </returns>
        public virtual Task<ArmOperation<DiagnosticSettingResource>> UpdateAsync(WaitUntil waitUntil, DiagnosticSettingData data, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<DiagnosticSettingData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        DiagnosticSettingData IJsonModel<DiagnosticSettingData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        BinaryData IPersistableModel<DiagnosticSettingData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        DiagnosticSettingData IPersistableModel<DiagnosticSettingData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<DiagnosticSettingData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
