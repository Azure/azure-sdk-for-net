// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.Agents;

public partial class AgentConversationReference : IJsonModel<AgentConversationReference>
{
    public string Id { get; set; }

    public AgentConversationReference(string id)
    {
        Id = id;
    }

    public static implicit operator AgentConversationReference(AgentConversation conversation) => new(conversation.Id);
    public static implicit operator AgentConversationReference(string conversationId) => new(conversationId);

    /// <param name="writer"> The JSON writer. </param>
    /// <param name="options"> The client options for reading and writing models. </param>
    void IJsonModel<AgentConversationReference>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        JsonModelWriteCore(writer, options);
        writer.WriteEndObject();
    }

    /// <param name="writer"> The JSON writer. </param>
    /// <param name="options"> The client options for reading and writing models. </param>
    protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        string format = options.Format == "W" ? ((IPersistableModel<AgentConversationReference>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(AgentConversationReference)} does not support writing '{format}' format.");
        }
        writer.WritePropertyName("id"u8);
        writer.WriteStringValue(Id);
    }

    /// <param name="reader"> The JSON reader. </param>
    /// <param name="options"> The client options for reading and writing models. </param>
    AgentConversationReference IJsonModel<AgentConversationReference>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

    /// <param name="reader"> The JSON reader. </param>
    /// <param name="options"> The client options for reading and writing models. </param>
    protected virtual AgentConversationReference JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        string format = options.Format == "W" ? ((IPersistableModel<AgentConversationReference>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(AgentConversationReference)} does not support reading '{format}' format.");
        }
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeAgentConversationReference(document.RootElement, options);
    }

    /// <param name="element"> The JSON element to deserialize. </param>
    /// <param name="options"> The client options for reading and writing models. </param>
    internal static AgentConversationReference DeserializeAgentConversationReference(JsonElement element, ModelReaderWriterOptions options)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        string id = default;
        foreach (var prop in element.EnumerateObject())
        {
            if (prop.NameEquals("id"u8))
            {
                id = prop.Value.GetString();
                continue;
            }
        }
        return new AgentConversationReference(id);
    }

    /// <param name="options"> The client options for reading and writing models. </param>
    BinaryData IPersistableModel<AgentConversationReference>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

    /// <param name="options"> The client options for reading and writing models. </param>
    protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
    {
        string format = options.Format == "W" ? ((IPersistableModel<AgentConversationReference>)this).GetFormatFromOptions(options) : options.Format;
        switch (format)
        {
            case "J":
                return ModelReaderWriter.Write(this, options, AzureAIAgentsContext.Default);
            default:
                throw new FormatException($"The model {nameof(AgentConversationReference)} does not support writing '{options.Format}' format.");
        }
    }

    /// <param name="data"> The data to parse. </param>
    /// <param name="options"> The client options for reading and writing models. </param>
    AgentConversationReference IPersistableModel<AgentConversationReference>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

    /// <param name="data"> The data to parse. </param>
    /// <param name="options"> The client options for reading and writing models. </param>
    protected virtual AgentConversationReference PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
    {
        string format = options.Format == "W" ? ((IPersistableModel<AgentConversationReference>)this).GetFormatFromOptions(options) : options.Format;
        switch (format)
        {
            case "J":
                using (JsonDocument document = JsonDocument.Parse(data))
                {
                    return DeserializeAgentConversationReference(document.RootElement, options);
                }
            default:
                throw new FormatException($"The model {nameof(AgentConversationReference)} does not support reading '{options.Format}' format.");
        }
    }

    /// <param name="options"> The client options for reading and writing models. </param>
    string IPersistableModel<AgentConversationReference>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
}
