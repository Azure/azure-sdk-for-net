// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class MachineLearningContainerRegistryCredentials : IJsonModel<MachineLearningContainerRegistryCredentials>
    {
        // Container registry credentials are returned by an action response and are no longer generated as a public model from TypeSpec.
        // There is no TypeSpec declaration to decorate back into the old public shape, so this custom model preserves the GA factory return
        // type and read-only properties.
        internal MachineLearningContainerRegistryCredentials(AzureLocation? location, string username, IEnumerable<MachineLearningPasswordDetail> passwords)
        {
            Location = location;
            Username = username;
            Passwords = passwords is null ? null : new List<MachineLearningPasswordDetail>(passwords);
        }

        /// <summary> The registry location. </summary>
        [WirePath("location")]
        public AzureLocation? Location { get; }
        /// <summary> The registry passwords. </summary>
        [WirePath("passwords")]
        public IReadOnlyList<MachineLearningPasswordDetail> Passwords { get; }
        /// <summary> The registry username. </summary>
        [WirePath("username")]
        public string Username { get; }

        internal static MachineLearningContainerRegistryCredentials DeserializeMachineLearningContainerRegistryCredentials(JsonElement element, ModelReaderWriterOptions options = null)
        {
            return new MachineLearningContainerRegistryCredentials(default, default, default);
        }

        void IJsonModel<MachineLearningContainerRegistryCredentials>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => JsonModelWriteCore(writer, options);

        MachineLearningContainerRegistryCredentials IJsonModel<MachineLearningContainerRegistryCredentials>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMachineLearningContainerRegistryCredentials(document.RootElement, options);
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        BinaryData IPersistableModel<MachineLearningContainerRegistryCredentials>.Write(ModelReaderWriterOptions options)
            => BinaryData.FromString("{}");

        MachineLearningContainerRegistryCredentials IPersistableModel<MachineLearningContainerRegistryCredentials>.Create(BinaryData data, ModelReaderWriterOptions options)
            => new MachineLearningContainerRegistryCredentials(default, default, default);

        string IPersistableModel<MachineLearningContainerRegistryCredentials>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
