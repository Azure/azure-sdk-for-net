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
    /// <summary> ResponseCustomToolCallOutputItem. </summary>
    public partial class OutputItemCustomToolCallOutput : ResponseItem, IJsonModel<OutputItemCustomToolCallOutput>
    {
        /// <summary> Initializes a new instance of <see cref="OutputItemCustomToolCallOutput"/> for deserialization. </summary>
        internal OutputItemCustomToolCallOutput() : base("custom_tool_call_output")
        {
        }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override ResponseItem PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<OutputItemCustomToolCallOutput>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeOutputItemCustomToolCallOutput(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(OutputItemCustomToolCallOutput)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<OutputItemCustomToolCallOutput>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureAIAgentServerResponsesContext.Default);
                default:
                    throw new FormatException($"The model {nameof(OutputItemCustomToolCallOutput)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<OutputItemCustomToolCallOutput>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        OutputItemCustomToolCallOutput IPersistableModel<OutputItemCustomToolCallOutput>.Create(BinaryData data, ModelReaderWriterOptions options) => (OutputItemCustomToolCallOutput)PersistableModelCreateCore(data, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<OutputItemCustomToolCallOutput>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<OutputItemCustomToolCallOutput>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<OutputItemCustomToolCallOutput>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OutputItemCustomToolCallOutput)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            writer.WritePropertyName("call_id"u8);
            writer.WriteStringValue(CallId);
            writer.WritePropertyName("output"u8);
#if NET6_0_OR_GREATER
            writer.WriteRawValue(Output);
#else
            using (JsonDocument document = JsonDocument.Parse(Output))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
            writer.WritePropertyName("status"u8);
            writer.WriteStringValue(Status.ToSerialString());
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
        OutputItemCustomToolCallOutput IJsonModel<OutputItemCustomToolCallOutput>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (OutputItemCustomToolCallOutput)JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override ResponseItem JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<OutputItemCustomToolCallOutput>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OutputItemCustomToolCallOutput)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeOutputItemCustomToolCallOutput(document.RootElement, options);
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static OutputItemCustomToolCallOutput DeserializeOutputItemCustomToolCallOutput(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResponseItemKind @type = "custom_tool_call_output";
            BinaryData createdBy = default;
            AgentReference agentReference = default;
            string responseId = default;
            string id = default;
            string callId = default;
            BinaryData output = default;
            FunctionCallOutputStatusEnum status = default;
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
                if (prop.NameEquals("output"u8))
                {
                    output = BinaryData.FromString(prop.Value.GetRawText());
                    continue;
                }
                if (prop.NameEquals("status"u8))
                {
                    status = prop.Value.GetString().ToFunctionCallOutputStatusEnum();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            var item = new OutputItemCustomToolCallOutput(
                @type,
                id,
                callId,
                output,
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
