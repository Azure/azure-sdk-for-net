// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class MachineLearningFqdnEndpointsProperties : IJsonModel<MachineLearningFqdnEndpointsProperties>
    {
        // The latest TypeSpec surface no longer generates the GA helper model used by the model factory for FQDN endpoint lists.
        // Because the model is custom-only in this generated SDK, decorators cannot restore its public properties; keep the minimal
        // read-only compatibility shape here.
        internal MachineLearningFqdnEndpointsProperties(string category, IEnumerable<MachineLearningFqdnEndpoint> endpoints)
        {
            Category = category;
            Endpoints = endpoints is null ? null : new List<MachineLearningFqdnEndpoint>(endpoints);
        }

        /// <summary> The endpoint category. </summary>
        [WirePath("category")]
        public string Category { get; }
        /// <summary> The endpoints. </summary>
        [WirePath("endpoints")]
        public IReadOnlyList<MachineLearningFqdnEndpoint> Endpoints { get; }

        void IJsonModel<MachineLearningFqdnEndpointsProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => JsonModelWriteCore(writer, options);

        MachineLearningFqdnEndpointsProperties IJsonModel<MachineLearningFqdnEndpointsProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return new MachineLearningFqdnEndpointsProperties(default, default);
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        BinaryData IPersistableModel<MachineLearningFqdnEndpointsProperties>.Write(ModelReaderWriterOptions options)
            => BinaryData.FromString("{}");

        MachineLearningFqdnEndpointsProperties IPersistableModel<MachineLearningFqdnEndpointsProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
            => new MachineLearningFqdnEndpointsProperties(default, default);

        string IPersistableModel<MachineLearningFqdnEndpointsProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
