// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Models;

namespace Azure.AI.AgentServer.Core.Tools.Runtime.Facade;

/// <summary>
/// Factory for creating FoundryTool instances from various input types.
/// Supports discriminator-based dispatch for flexible tool definition formats.
/// </summary>
public static class FoundryToolFactory
{
    /// <summary>
    /// Creates a FoundryTool from an object input.
    /// Dispatches to the appropriate overload based on the runtime type.
    /// </summary>
    /// <param name="tool">
    /// The tool input, which can be:
    /// <list type="bullet">
    /// <item>A FoundryTool instance (returned as-is)</item>
    /// <item>A dictionary with a "type" discriminator field</item>
    /// </list>
    /// </param>
    /// <returns>A strongly-typed FoundryTool instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown when tool is null.</exception>
    /// <exception cref="ArgumentException">
    /// Thrown when the tool type is not supported or format is invalid.
    /// </exception>
    public static FoundryTool Create(object tool)
    {
        if (tool == null)
        {
            throw new ArgumentNullException(nameof(tool));
        }

        // Dispatch to specific overloads based on runtime type
        return tool switch
        {
            FoundryTool foundryTool => Create(foundryTool),
            IDictionary<string, object?> facade => Create(facade),
            _ => throw new ArgumentException(
                $"Unsupported tool type. Expected FoundryTool or IDictionary<string, object?>, but got: {tool.GetType().Name}",
                nameof(tool))
        };
    }

    /// <summary>
    /// Creates a FoundryTool from a FoundryTool instance (passthrough).
    /// </summary>
    /// <param name="tool">The FoundryTool instance.</param>
    /// <returns>The same FoundryTool instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown when tool is null.</exception>
    public static FoundryTool Create(FoundryTool tool)
    {
        return tool ?? throw new ArgumentNullException(nameof(tool));
    }

    /// <summary>
    /// Creates a FoundryTool from a dictionary-based facade with a "type" discriminator field.
    /// </summary>
    /// <param name="facade">
    /// A dictionary containing tool definition with required "type" field.
    /// The "type" field can be:
    /// <list type="bullet">
    /// <item>A protocol name (e.g., "MCP", "A2A") - creates a FoundryConnectedTool (requires "project_connection_id")</item>
    /// <item>A custom string - creates a FoundryHostedMcpTool with the string as the tool name</item>
    /// </list>
    /// </param>
    /// <returns>
    /// A strongly-typed FoundryTool instance:
    /// <list type="bullet">
    /// <item>FoundryConnectedTool if type matches a known protocol</item>
    /// <item>FoundryHostedMcpTool for custom tool names</item>
    /// </list>
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when facade is null.</exception>
    /// <exception cref="ArgumentException">
    /// Thrown when:
    /// <list type="bullet">
    /// <item>The facade is missing the required "type" field</item>
    /// <item>The "type" field is not a string or is empty</item>
    /// <item>A protocol type is used but "project_connection_id" is missing or empty</item>
    /// </list>
    /// </exception>
    public static FoundryTool Create(IDictionary<string, object?> facade)
    {
        if (facade == null)
        {
            throw new ArgumentNullException(nameof(facade));
        }

        // Extract and validate the "type" field
        if (!facade.TryGetValue("type", out var typeValue) ||
            typeValue is not string type ||
            string.IsNullOrEmpty(type))
        {
            throw new ArgumentException(
                "Tool facade must have a valid 'type' field of type string.",
                nameof(facade));
        }

        // Extract additional properties (excluding "type" and known fields)
        var additionalProperties = ExtractAdditionalProperties(facade);

        // Try to parse as protocol (MCP, A2A)
        if (Enum.TryParse<FoundryToolProtocol>(type, ignoreCase: true, out var protocol))
        {
            // Protocol tools require a project_connection_id
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

    /// <summary>
    /// Extracts additional properties from the facade dictionary, excluding known fields.
    /// </summary>
    /// <param name="facade">The input dictionary.</param>
    /// <returns>
    /// A read-only dictionary of additional properties, or null if no additional properties exist.
    /// </returns>
    private static IReadOnlyDictionary<string, object?>? ExtractAdditionalProperties(
        IDictionary<string, object?> facade)
    {
        var additionalProps = facade
            .Where(kv => kv.Key != "type" && kv.Key != "project_connection_id")
            .ToDictionary(kv => kv.Key, kv => kv.Value);

        return additionalProps.Count > 0 ? additionalProps : null;
    }
}
