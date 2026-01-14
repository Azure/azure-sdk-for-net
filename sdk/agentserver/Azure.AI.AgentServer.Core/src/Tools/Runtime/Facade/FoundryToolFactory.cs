// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Core.Tools.Models;

namespace Azure.AI.AgentServer.Core.Tools.Runtime.Facade;

/// <summary>
/// Factory for creating FoundryTool instances from various input types.
/// Supports discriminator-based dispatch for flexible tool definition formats.
/// </summary>
public static class FoundryToolFactory
{
    /// <summary>
    /// Creates a FoundryTool from various input types.
    /// </summary>
    /// <param name="tool">
    /// The tool input, which can be:
    /// <list type="bullet">
    /// <item>A FoundryTool instance (returned as-is)</item>
    /// <item>A dictionary with a "type" discriminator field</item>
    /// <item>A JsonElement with a "type" property</item>
    /// </list>
    /// </param>
    /// <returns>A strongly-typed FoundryTool instance.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when the tool format is invalid or missing required fields.
    /// </exception>
    public static FoundryTool Create(object tool)
    {
        // If already a FoundryTool, return as-is
        if (tool is FoundryTool foundryTool)
        {
            return foundryTool;
        }

        // Handle JsonElement
        if (tool is JsonElement jsonElement)
        {
            return CreateFromJsonElement(jsonElement);
        }

        // Handle dictionary-based facade
        if (tool is IDictionary<string, object?> facade)
        {
            return CreateFromDictionary(facade);
        }

        throw new ArgumentException(
            $"Tool must be a FoundryTool, JsonElement, or dictionary with 'type' field. Got: {tool?.GetType().Name ?? "null"}",
            nameof(tool));
    }

    private static FoundryTool CreateFromJsonElement(JsonElement jsonElement)
    {
        if (jsonElement.ValueKind != JsonValueKind.Object)
        {
            throw new ArgumentException(
                "JsonElement tool must be an object.",
                nameof(jsonElement));
        }

        if (!jsonElement.TryGetProperty("type", out var typeProperty) ||
            typeProperty.ValueKind != JsonValueKind.String)
        {
            throw new ArgumentException(
                "Tool JsonElement must have a 'type' property of type string.",
                nameof(jsonElement));
        }

        var type = typeProperty.GetString();
        if (string.IsNullOrEmpty(type))
        {
            throw new ArgumentException(
                "Tool 'type' property cannot be empty.",
                nameof(jsonElement));
        }

        // Extract additional properties (excluding "type" and known fields)
        var additionalProperties = ExtractAdditionalPropertiesFromJson(jsonElement);

        // Try to parse as protocol (MCP, A2A)
        if (Enum.TryParse<FoundryToolProtocol>(type, ignoreCase: true, out var protocol))
        {
            if (!jsonElement.TryGetProperty("project_connection_id", out var connIdProperty) ||
                connIdProperty.ValueKind != JsonValueKind.String ||
                string.IsNullOrEmpty(connIdProperty.GetString()))
            {
                throw new ArgumentException(
                    $"'project_connection_id' is required for tool protocol '{protocol}'.",
                    nameof(jsonElement));
            }

            return new FoundryConnectedTool(
                protocol,
                connIdProperty.GetString()!,
                additionalProperties);
        }

        // Otherwise treat as hosted MCP tool with type as name
        return new FoundryHostedMcpTool(type, additionalProperties);
    }

    private static FoundryTool CreateFromDictionary(IDictionary<string, object?> facade)
    {
        if (!facade.TryGetValue("type", out var typeValue) ||
            typeValue is not string type ||
            string.IsNullOrEmpty(type))
        {
            throw new ArgumentException(
                "Tool facade must have a valid 'type' field of type string.",
                nameof(facade));
        }

        // Extract additional properties (excluding "type" and known fields)
        var additionalProperties = ExtractAdditionalPropertiesFromDictionary(facade);

        // Try to parse as protocol (MCP, A2A)
        if (Enum.TryParse<FoundryToolProtocol>(type, ignoreCase: true, out var protocol))
        {
            if (!facade.TryGetValue("project_connection_id", out var connIdValue) ||
                connIdValue is not string projectConnectionId ||
                string.IsNullOrEmpty(projectConnectionId))
            {
                throw new ArgumentException(
                    $"'project_connection_id' is required for tool protocol '{protocol}'.",
                    nameof(facade));
            }

            return new FoundryConnectedTool(
                protocol,
                projectConnectionId,
                additionalProperties);
        }

        // Otherwise treat as hosted MCP tool with type as name
        return new FoundryHostedMcpTool(type, additionalProperties);
    }

    private static IReadOnlyDictionary<string, object?>? ExtractAdditionalPropertiesFromDictionary(
        IDictionary<string, object?> facade)
    {
        var additionalProps = facade
            .Where(kv => kv.Key != "type" && kv.Key != "project_connection_id")
            .ToDictionary(kv => kv.Key, kv => kv.Value);

        return additionalProps.Count > 0 ? additionalProps : null;
    }

    private static IReadOnlyDictionary<string, object?>? ExtractAdditionalPropertiesFromJson(
        JsonElement jsonElement)
    {
        var additionalProps = new Dictionary<string, object?>();

        foreach (var property in jsonElement.EnumerateObject())
        {
            if (property.Name == "type" || property.Name == "project_connection_id")
            {
                continue;
            }

            additionalProps[property.Name] = ConvertJsonElementToObject(property.Value);
        }

        return additionalProps.Count > 0 ? additionalProps : null;
    }

    private static object? ConvertJsonElementToObject(JsonElement element)
    {
        return element.ValueKind switch
        {
            JsonValueKind.String => element.GetString(),
            JsonValueKind.Number => element.TryGetInt64(out var l) ? l : element.GetDouble(),
            JsonValueKind.True => true,
            JsonValueKind.False => false,
            JsonValueKind.Null => null,
            JsonValueKind.Array => element.EnumerateArray()
                .Select(ConvertJsonElementToObject)
                .ToArray(),
            JsonValueKind.Object => element.EnumerateObject()
                .ToDictionary(p => p.Name, p => ConvertJsonElementToObject(p.Value)),
            _ => element.GetRawText()
        };
    }
}
