// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Hand-written: these items derive from OpenAI.Responses.ResponseItem, whose only
// accessible constructor is `protected internal ResponseItem(ResponseItemKind)`. The
// emitter cannot produce a subclass that also forwards this package's Azure attribution
// fields, so the type is maintained here and mapped away in client.tsp via @@alternateType.
// The attribution fields are carried over JsonPatch, as they are for every other item type.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.AgentServer.Responses;
using Azure.AI.Extensions.OpenAI;
using OpenAI.Responses;

namespace Azure.AI.AgentServer.Responses.Models
{
    /// <summary> ResponseCustomToolCallItem. </summary>
    public partial class OutputItemCustomToolCall : ResponseItem, IJsonModel<OutputItemCustomToolCall>
    {
        /// <summary> Initializes a new instance of <see cref="OutputItemCustomToolCall"/> for deserialization. </summary>
        internal OutputItemCustomToolCall() : base("custom_tool_call")
        {
        }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override ResponseItem PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<OutputItemCustomToolCall>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeOutputItemCustomToolCall(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(OutputItemCustomToolCall)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<OutputItemCustomToolCall>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureAIAgentServerResponsesContext.Default);
                default:
                    throw new FormatException($"The model {nameof(OutputItemCustomToolCall)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<OutputItemCustomToolCall>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        OutputItemCustomToolCall IPersistableModel<OutputItemCustomToolCall>.Create(BinaryData data, ModelReaderWriterOptions options) => (OutputItemCustomToolCall)PersistableModelCreateCore(data, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<OutputItemCustomToolCall>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<OutputItemCustomToolCall>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<OutputItemCustomToolCall>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OutputItemCustomToolCall)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            writer.WritePropertyName("call_id"u8);
            writer.WriteStringValue(CallId);
            if (Optional.IsDefined(Namespace))
            {
                writer.WritePropertyName("namespace"u8);
                writer.WriteStringValue(Namespace);
            }
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("input"u8);
            writer.WriteStringValue(Input);
            writer.WritePropertyName("status"u8);
            writer.WriteStringValue(Status switch
            {
                global::OpenAI.Responses.FunctionCallStatus.InProgress => "in_progress",
                global::OpenAI.Responses.FunctionCallStatus.Completed => "completed",
                global::OpenAI.Responses.FunctionCallStatus.Incomplete => "incomplete",
                _ => Status.ToString(),
            });
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        OutputItemCustomToolCall IJsonModel<OutputItemCustomToolCall>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (OutputItemCustomToolCall)JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override ResponseItem JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<OutputItemCustomToolCall>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OutputItemCustomToolCall)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeOutputItemCustomToolCall(document.RootElement, options);
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static OutputItemCustomToolCall DeserializeOutputItemCustomToolCall(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResponseItemKind @type = "custom_tool_call";
            BinaryData createdBy = default;
            AgentReference agentReference = default;
            string responseId = default;
            string id = default;
            string callId = default;
            string @namespace = default;
            string name = default;
            string input = default;
            global::OpenAI.Responses.FunctionCallStatus status = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("type"u8))
                {
                    @type = new ResponseItemKind(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("created_by"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    createdBy = BinaryData.FromString(prop.Value.GetRawText());
                    continue;
                }
                if (prop.NameEquals("agent_reference"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    agentReference = ModelReaderWriter.Read<AgentReference>(prop.Value.GetUtf8Bytes(), ModelSerializationExtensions.WireOptions, AzureAIAgentServerResponsesContext.Default);
                    continue;
                }
                if (prop.NameEquals("response_id"u8))
                {
                    responseId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("id"u8))
                {
                    id = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("call_id"u8))
                {
                    callId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("namespace"u8))
                {
                    @namespace = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("input"u8))
                {
                    input = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("status"u8))
                {
                    status = prop.Value.GetString() switch
                    {
                        "in_progress" => global::OpenAI.Responses.FunctionCallStatus.InProgress,
                        "completed" => global::OpenAI.Responses.FunctionCallStatus.Completed,
                        "incomplete" => global::OpenAI.Responses.FunctionCallStatus.Incomplete,
                        _ => default,
                    };
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            var item = new OutputItemCustomToolCall(
                @type,
                id,
                callId,
                @namespace,
                name,
                input,
                status,
                additionalBinaryDataProperties);
            if (createdBy is not null)
            {
                item.Patch.Set("$.created_by"u8, createdBy.ToArray());
            }

            if (agentReference is not null)
            {
                item.Patch.Set(
                    "$.agent_reference"u8,
                    ModelReaderWriter.Write(agentReference, ModelSerializationExtensions.WireOptions, AzureAIAgentServerResponsesContext.Default).ToArray());
            }

            if (responseId is not null)
            {
                item.Patch.Set("$.response_id"u8, responseId);
            }

            return item;
        }
    }
}
