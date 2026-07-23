// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable OPENAI001 // CreateResponseOptions is the OpenAI request model AgentServer extends.

using System.ClientModel.Primitives;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.Extensions.OpenAI;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// JSON converter for the AgentServer create-response request wrapper.
/// </summary>
internal sealed class CreateResponseJsonConverter : JsonConverter<CreateResponse>
{
    /// <inheritdoc/>
    public override CreateResponse? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        JsonObject normalizedRequest = NormalizeRequest(document.RootElement);
        BinaryData rawRequest = BinaryData.FromString(normalizedRequest.ToJsonString());
        CreateResponseOptions openAIOptions = ModelReaderWriter.Read<CreateResponseOptions>(
            rawRequest,
            ModelReaderWriterOptions.Json,
            OpenAIContext.Default) ?? new CreateResponseOptions();

        CreateResponse request = new();
        CopyOpenAIOptions(openAIOptions, request);
        if (document.RootElement.TryGetProperty("metadata", out JsonElement metadataElement)
            && metadataElement.ValueKind == JsonValueKind.Object)
        {
            request.Metadata.Clear();
            foreach (JsonProperty metadataProperty in metadataElement.EnumerateObject())
            {
                if (metadataProperty.Value.ValueKind == JsonValueKind.String)
                {
                    request.Metadata[metadataProperty.Name] = metadataProperty.Value.GetString()!;
                }
            }
        }

        if (document.RootElement.TryGetProperty("input", out JsonElement inputElement))
        {
            request.Input = BinaryData.FromString(inputElement.GetRawText());
        }

        if (document.RootElement.TryGetProperty("conversation", out JsonElement conversationElement))
        {
            request.Conversation = BinaryData.FromString(conversationElement.GetRawText());
        }

        if (document.RootElement.TryGetProperty("agent_reference", out JsonElement agentReferenceElement)
            && agentReferenceElement.ValueKind != JsonValueKind.Null)
        {
            request.AgentReference = ReadAgentReference(agentReferenceElement);
        }

        if (document.RootElement.TryGetProperty("agent_session_id", out JsonElement agentSessionIdElement)
            && agentSessionIdElement.ValueKind == JsonValueKind.String)
        {
            request.AgentSessionId = agentSessionIdElement.GetString();
        }

        return request;
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, CreateResponse value, JsonSerializerOptions options)
    {
        BinaryData serializedOpenAIOptions = ModelReaderWriter.Write(
            (CreateResponseOptions)value,
            ModelReaderWriterOptions.Json,
            OpenAIContext.Default);

        using JsonDocument document = JsonDocument.Parse(serializedOpenAIOptions);
        writer.WriteStartObject();
        foreach (JsonProperty property in document.RootElement.EnumerateObject())
        {
            property.WriteTo(writer);
        }

        if (value.AgentReference is not null)
        {
            writer.WritePropertyName("agent_reference"u8);
            JsonSerializer.Serialize(writer, value.AgentReference, options);
        }

        if (value.AgentSessionId is not null)
        {
            writer.WriteString("agent_session_id"u8, value.AgentSessionId);
        }

        writer.WriteEndObject();
    }

    private static AgentReference ReadAgentReference(JsonElement element)
    {
        string? name = element.TryGetProperty("name", out JsonElement nameElement)
            ? nameElement.GetString()
            : null;
        string? version = element.TryGetProperty("version", out JsonElement versionElement)
            ? versionElement.GetString()
            : null;

        return new AgentReference(name ?? string.Empty, version);
    }

    private static JsonObject NormalizeRequest(JsonElement rootElement)
    {
        JsonObject root = JsonNode.Parse(rootElement.GetRawText())!.AsObject();

        if (root.TryGetPropertyValue("input", out JsonNode? inputNode))
        {
            root["input"] = NormalizeInput(inputNode);
        }

        root.Remove("conversation");
        root.Remove("agent_reference");
        root.Remove("agent_session_id");

        return root;
    }

    private static JsonNode? NormalizeInput(JsonNode? inputNode)
    {
        if (inputNode is JsonValue inputValue
            && inputValue.TryGetValue<string>(out string? inputString))
        {
            return new JsonArray(CreateMessageNode("user", inputString));
        }

        if (inputNode is JsonArray inputArray)
        {
            var normalizedArray = new JsonArray();
            foreach (JsonNode? item in inputArray)
            {
                normalizedArray.Add(NormalizeInputItem(item));
            }

            return normalizedArray;
        }

        return inputNode?.DeepClone();
    }

    private static JsonNode? NormalizeInputItem(JsonNode? itemNode)
    {
        if (itemNode is not JsonObject itemObject)
        {
            return itemNode?.DeepClone();
        }

        JsonObject normalizedItem = (JsonObject)itemObject.DeepClone();
        string? type = normalizedItem.TryGetPropertyValue("type", out JsonNode? typeNode)
            && typeNode is JsonValue typeValue
            && typeValue.TryGetValue<string>(out string? typeValueString)
                ? typeValueString
                : null;

        if (type is null && normalizedItem.ContainsKey("role"))
        {
            type = "message";
            normalizedItem["type"] = type;
        }

        if (type == "message" && normalizedItem.TryGetPropertyValue("content", out JsonNode? contentNode))
        {
            normalizedItem["content"] = NormalizeMessageContent(contentNode);
        }
        else if (type == "function_call_output"
            && normalizedItem.TryGetPropertyValue("output", out JsonNode? outputNode)
            && outputNode is JsonArray or JsonObject)
        {
            normalizedItem["output"] = outputNode.ToJsonString();
        }

        return normalizedItem;
    }

    private static JsonNode? NormalizeMessageContent(JsonNode? contentNode)
    {
        if (contentNode is JsonValue contentValue
            && contentValue.TryGetValue<string>(out string? contentString))
        {
            return new JsonArray(CreateInputTextContentNode(contentString));
        }

        if (contentNode is JsonArray contentArray)
        {
            var normalizedArray = new JsonArray();
            foreach (JsonNode? partNode in contentArray)
            {
                normalizedArray.Add(NormalizeMessageContentPart(partNode));
            }

            return normalizedArray;
        }

        return contentNode?.DeepClone();
    }

    private static JsonNode? NormalizeMessageContentPart(JsonNode? partNode)
    {
        if (partNode is not JsonObject partObject)
        {
            return partNode?.DeepClone();
        }

        JsonObject normalizedPart = (JsonObject)partObject.DeepClone();
        if (normalizedPart.TryGetPropertyValue("type", out JsonNode? typeNode)
            && typeNode is JsonValue typeValue
            && typeValue.TryGetValue<string>(out string? type)
            && type == "input_image"
            && !normalizedPart.ContainsKey("detail"))
        {
            normalizedPart["detail"] = "auto";
        }

        return normalizedPart;
    }

    private static JsonObject CreateMessageNode(string role, string content)
    {
        return new JsonObject
        {
            ["type"] = "message",
            ["role"] = role,
            ["content"] = new JsonArray(CreateInputTextContentNode(content)),
        };
    }

    private static JsonObject CreateInputTextContentNode(string text)
    {
        return new JsonObject
        {
            ["type"] = "input_text",
            ["text"] = text,
        };
    }

    private static void CopyOpenAIOptions(CreateResponseOptions source, CreateResponse target)
    {
        foreach (PropertyInfo property in typeof(CreateResponseOptions).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (property.Name == "Patch")
            {
                continue;
            }

            object? sourceValue = property.GetValue(source);
            object? targetValue = property.GetValue(target);

            if (property.CanWrite)
            {
                property.SetValue(target, sourceValue);
            }
            else if (sourceValue is IEnumerable sourceEnumerable && targetValue is IList targetList)
            {
                foreach (object? item in sourceEnumerable)
                {
                    targetList.Add(item);
                }
            }
            else if (sourceValue is IEnumerable genericSourceEnumerable && sourceValue is not IDictionary && targetValue is not null)
            {
                MethodInfo? addMethod = targetValue.GetType()
                    .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                    .FirstOrDefault(method => method.Name == "Add" && method.GetParameters().Length == 1);
                if (addMethod is not null)
                {
                    foreach (object? item in genericSourceEnumerable)
                    {
                        addMethod.Invoke(targetValue, [item]);
                    }
                }
            }
            else if (sourceValue is IDictionary sourceDictionary && targetValue is IDictionary targetDictionary)
            {
                foreach (DictionaryEntry entry in sourceDictionary)
                {
                    targetDictionary[entry.Key] = entry.Value;
                }
            }
        }
    }
}
