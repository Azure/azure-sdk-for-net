// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Keep the GA environment model shape constructible: the generated discriminator hierarchy does not expose the previous public constructor needed for source compatibility.
    public partial class GithubScopeEnvironment : IPersistableModel<GithubScopeEnvironment>
    {
        /// <summary> Initializes a new instance of <see cref="GithubScopeEnvironment"/>. </summary>
        public GithubScopeEnvironment() : base(EnvironmentType.GithubScope, new ChangeTrackingDictionary<string, BinaryData>())
        {
        }

        void IJsonModel<GithubScopeEnvironment>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        GithubScopeEnvironment IJsonModel<GithubScopeEnvironment>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (GithubScopeEnvironment)JsonModelCreateCore(ref reader, options);
        BinaryData IPersistableModel<GithubScopeEnvironment>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        GithubScopeEnvironment IPersistableModel<GithubScopeEnvironment>.Create(BinaryData data, ModelReaderWriterOptions options) => (GithubScopeEnvironment)PersistableModelCreateCore(data, options);
        string IPersistableModel<GithubScopeEnvironment>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
