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
    // The current TypeSpec shape renamed this GA model to AzureDevOpsScopeEnvironmentInfo. Keep this hidden compatibility type and delegate wire operations to the generated replacement.
    /// <summary>
    /// Provides a compatibility shim for the AzureDevOpsScopeEnvironment class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AzureDevOpsScopeEnvironment : SecurityConnectorEnvironment, IJsonModel<AzureDevOpsScopeEnvironment>, IPersistableModel<AzureDevOpsScopeEnvironment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureDevOpsScopeEnvironment"/> type for compatibility with the previous public API surface.
        /// </summary>
        public AzureDevOpsScopeEnvironment() { }

        private static AzureDevOpsScopeEnvironmentInfo ToGenerated()
        {
            return new AzureDevOpsScopeEnvironmentInfo(EnvironmentType.AzureDevOpsScope, new Dictionary<string, BinaryData>());
        }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(((IPersistableModel<AzureDevOpsScopeEnvironmentInfo>)ToGenerated()).Write(options), ModelSerializationExtensions.JsonDocumentOptions);
            foreach (JsonProperty property in document.RootElement.EnumerateObject())
            {
                property.WriteTo(writer);
            }
        }
        AzureDevOpsScopeEnvironment IJsonModel<AzureDevOpsScopeEnvironment>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            _ = ((IJsonModel<AzureDevOpsScopeEnvironmentInfo>)new AzureDevOpsScopeEnvironmentInfo()).Create(ref reader, options);
            return new AzureDevOpsScopeEnvironment();
        }
        void IJsonModel<AzureDevOpsScopeEnvironment>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<AzureDevOpsScopeEnvironmentInfo>)ToGenerated()).Write(writer, options);
        AzureDevOpsScopeEnvironment IPersistableModel<AzureDevOpsScopeEnvironment>.Create(System.BinaryData data, ModelReaderWriterOptions options)
        {
            _ = ((IPersistableModel<AzureDevOpsScopeEnvironmentInfo>)new AzureDevOpsScopeEnvironmentInfo()).Create(data, options);
            return new AzureDevOpsScopeEnvironment();
        }
        string IPersistableModel<AzureDevOpsScopeEnvironment>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<AzureDevOpsScopeEnvironmentInfo>)new AzureDevOpsScopeEnvironmentInfo()).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<AzureDevOpsScopeEnvironment>.Write(ModelReaderWriterOptions options) => ((IPersistableModel<AzureDevOpsScopeEnvironmentInfo>)ToGenerated()).Write(options);
    }
}
