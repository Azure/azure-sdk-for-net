// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Models;

namespace Azure.AI.AgentServer.Core.Tools.Utilities;

/// <summary>
/// Maps tool metadata from _meta schema to tool configuration.
/// </summary>
internal static class MetadataMapper
{
    /// <summary>
    /// Default key mapping from meta schema keys to output keys.
    /// </summary>
    private static readonly Dictionary<string, string> DefaultKeyMapping = new()
    {
        ["imagegen_model_deployment_name"] = "model_deployment_name",
        ["model_deployment_name"] = "model",
        ["deployment_name"] = "model"
    };

    /// <summary>
    /// Prepares metadata dictionary from tool metadata and definition.
    /// </summary>
    /// <param name="toolMetadataRaw">The raw tool metadata.</param>
    /// <param name="foundryTool">The tool definition.</param>
    /// <param name="keyOverrides">Optional key overrides for mapping.</param>
    /// <returns>A dictionary with mapped metadata configuration.</returns>
    public static IReadOnlyDictionary<string, object?> PrepareMetadataDict(
        IReadOnlyDictionary<string, object?> toolMetadataRaw,
        FoundryTool? foundryTool,
        IReadOnlyDictionary<string, string>? keyOverrides = null)
    {
        var metaSchema = ToolMetadataExtractor.ExtractMetadataSchema(toolMetadataRaw);
        if (metaSchema == null)
        {
            return new Dictionary<string, object?>();
        }

        return ExtractMetadataConfig(metaSchema, foundryTool, keyOverrides);
    }

    /// <summary>
    /// Extracts metadata configuration from _meta schema and tool definition.
    /// </summary>
    /// <param name="metaSchema">The _meta schema containing property definitions.</param>
    /// <param name="foundryTool">The tool definition containing actual values.</param>
    /// <param name="keyOverrides">Mapping from tool definition keys to _meta schema keys.</param>
    /// <returns>Dictionary with mapped metadata configuration.</returns>
    private static IReadOnlyDictionary<string, object?> ExtractMetadataConfig(
        IReadOnlyDictionary<string, object?> metaSchema,
        FoundryTool? foundryTool,
        IReadOnlyDictionary<string, string>? keyOverrides)
    {
        var result = new Dictionary<string, object?>();

        // Build reverse mapping: foundry_tool_key -> meta_property_name
        var toolToMetaMapping = DefaultKeyMapping.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
        if (keyOverrides != null)
        {
            foreach (var kvp in keyOverrides)
            {
                toolToMetaMapping[kvp.Key] = kvp.Value;
            }
        }

        if (!metaSchema.TryGetValue("properties", out var propsObj) ||
            propsObj is not Dictionary<string, object?> properties)
        {
            return result;
        }

        var required = metaSchema.TryGetValue("required", out var reqObj) &&
                      reqObj is List<object> reqList
            ? new HashSet<string>(reqList.Select(r => r.ToString() ?? string.Empty))
            : new HashSet<string>();

        foreach (var (metaPropName, propSchemaObj) in properties)
        {
            if (propSchemaObj is not Dictionary<string, object?> propSchema)
            {
                continue;
            }

            var isRequired = required.Contains(metaPropName);
            object? value = null;
            var valueFromDefinition = false;

            // Try to find value in tool definition
            if (foundryTool != null)
            {
                var toolDefDict = ConvertToDict(foundryTool);

                // Check exact match first
                if (toolDefDict.TryGetValue(metaPropName, out value))
                {
                    valueFromDefinition = true;
                }
                else
                {
                    // Check mapped keys
                    foreach (var (toolKey, mappedMetaKey) in toolToMetaMapping)
                    {
                        if (mappedMetaKey == metaPropName && toolDefDict.TryGetValue(toolKey, out value))
                        {
                            valueFromDefinition = true;
                            break;
                        }
                    }
                }
            }

            // Use default if no value from definition
            if (value == null && isRequired && propSchema.TryGetValue("default", out var defaultValue))
            {
                value = defaultValue;
            }

            // Only add if value from definition or required with default
            if (value != null && (valueFromDefinition || isRequired))
            {
                result[metaPropName] = value;
            }
        }

        return result;
    }

    private static Dictionary<string, object?> ConvertToDict(FoundryTool foundryTool)
    {
        var dict = new Dictionary<string, object?>();

        switch (foundryTool)
        {
            case FoundryConnectedTool connectedTool:
                dict["type"] = connectedTool.Type;
                dict["project_connection_id"] = connectedTool.ProjectConnectionId;
                break;
            case FoundryHostedMcpTool hostedTool:
                dict["name"] = hostedTool.Name;
                break;
        }

        if (foundryTool.AdditionalProperties != null)
        {
            foreach (var kvp in foundryTool.AdditionalProperties)
            {
                dict[kvp.Key] = kvp.Value;
            }
        }

        return dict;
    }
}
