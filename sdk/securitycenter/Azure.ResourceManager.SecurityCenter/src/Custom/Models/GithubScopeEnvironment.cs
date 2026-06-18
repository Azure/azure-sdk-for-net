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
    // The current TypeSpec shape renamed this GA model to GithubScopeEnvironmentInfo. Keep this hidden compatibility type and delegate wire operations to the generated replacement.
    /// <summary>
    /// Provides a compatibility shim for the GithubScopeEnvironment class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class GithubScopeEnvironment : SecurityConnectorEnvironment, IJsonModel<GithubScopeEnvironment>, IPersistableModel<GithubScopeEnvironment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GithubScopeEnvironment"/> type for compatibility with the previous public API surface.
        /// </summary>
        public GithubScopeEnvironment() { }

        private static GithubScopeEnvironmentInfo ToGenerated()
        {
            return new GithubScopeEnvironmentInfo(EnvironmentType.GithubScope, new Dictionary<string, BinaryData>());
        }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(((IPersistableModel<GithubScopeEnvironmentInfo>)ToGenerated()).Write(options), ModelSerializationExtensions.JsonDocumentOptions);
            foreach (JsonProperty property in document.RootElement.EnumerateObject())
            {
                property.WriteTo(writer);
            }
        }
        GithubScopeEnvironment IJsonModel<GithubScopeEnvironment>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            _ = ((IJsonModel<GithubScopeEnvironmentInfo>)new GithubScopeEnvironmentInfo()).Create(ref reader, options);
            return new GithubScopeEnvironment();
        }
        void IJsonModel<GithubScopeEnvironment>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<GithubScopeEnvironmentInfo>)ToGenerated()).Write(writer, options);
        GithubScopeEnvironment IPersistableModel<GithubScopeEnvironment>.Create(System.BinaryData data, ModelReaderWriterOptions options)
        {
            _ = ((IPersistableModel<GithubScopeEnvironmentInfo>)new GithubScopeEnvironmentInfo()).Create(data, options);
            return new GithubScopeEnvironment();
        }
        string IPersistableModel<GithubScopeEnvironment>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<GithubScopeEnvironmentInfo>)new GithubScopeEnvironmentInfo()).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<GithubScopeEnvironment>.Write(ModelReaderWriterOptions options) => ((IPersistableModel<GithubScopeEnvironmentInfo>)ToGenerated()).Write(options);
    }
}
