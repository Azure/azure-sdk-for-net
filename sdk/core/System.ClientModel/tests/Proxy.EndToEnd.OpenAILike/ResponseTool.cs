// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace System.ClientModel.Tests.Proxy.OpenAILike
{
    /// <summary>
    /// Mock of an OpenAI-style discriminated "tool" type. The base library knows its own
    /// subtypes (selected by the "type" discriminator) and falls back to
    /// <see cref="UnknownResponseTool"/> for any discriminator it does not recognize. Third-party
    /// libraries extend this set by registering conditional proxies, without the base library
    /// knowing about them.
    /// </summary>
    [PersistableModelProxy(typeof(UnknownResponseTool))]
    public abstract class ResponseTool : IJsonModel<ResponseTool>
    {
        protected ResponseTool(string type, IDictionary<string, BinaryData>? rawData = null)
        {
            Type = type;
            RawData = rawData ?? new Dictionary<string, BinaryData>();
        }

        /// <summary>The discriminator value (e.g. "function", "azure_search", "bing_grounding").</summary>
        public string Type { get; }

        internal IDictionary<string, BinaryData> RawData { get; }

        void IJsonModel<ResponseTool>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type);
            WriteProperties(writer);
            writer.WriteEndObject();
        }

        /// <summary>Writes the subtype-specific properties (the discriminator is already written).</summary>
        protected abstract void WriteProperties(Utf8JsonWriter writer);

        ResponseTool IJsonModel<ResponseTool>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeResponseTool(doc.RootElement);
        }

        BinaryData IPersistableModel<ResponseTool>.Write(ModelReaderWriterOptions options)
            => ModelReaderWriter.Write(this, options);

        ResponseTool IPersistableModel<ResponseTool>.Create(BinaryData data, ModelReaderWriterOptions options)
            => DeserializeResponseTool(JsonDocument.Parse(data.ToString()).RootElement);

        string IPersistableModel<ResponseTool>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static ResponseTool DeserializeResponseTool(JsonElement element)
        {
            if (element.TryGetProperty("type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "function":
                        return FunctionTool.DeserializeFunctionTool(element);
                }
            }

            string type = element.TryGetProperty("type", out var t) ? t.GetString() ?? "unknown" : "unknown";
            return new UnknownResponseTool(type);
        }
    }
}
