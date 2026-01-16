// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Core.Common.Http.Json;
using Azure.AI.AgentServer.Core.Tools.Models;

namespace Azure.AI.AgentServer.Core.Tools.Operations;

internal partial class FoundryMcpToolsOperations
{
    private static readonly Dictionary<string, string> DefaultMetaKeyMapping = new()
    {
        ["imagegen_model_deployment_name"] = "model_deployment_name",
        ["model_deployment_name"] = "model",
        ["deployment_name"] = "model"
    };

    private static IReadOnlyDictionary<string, object?> PrepareMetadataConfig(
        IReadOnlyDictionary<string, object?> toolMetadata,
        FoundryTool foundryTool,
        IReadOnlyDictionary<string, string>? keyOverrides)
    {
        var metaSchema = ExtractMetadataSchema(toolMetadata);
        if (metaSchema == null)
        {
            return new Dictionary<string, object?>();
        }

        return ExtractMetadataConfig(metaSchema, foundryTool, keyOverrides);
    }

    private static IReadOnlyDictionary<string, object?>? ExtractMetadataSchema(
        IReadOnlyDictionary<string, object?> toolMetadata)
    {
        foreach (var key in new[] { "_meta", "metadata", "meta" })
        {
            if (!toolMetadata.TryGetValue(key, out var value))
            {
                continue;
            }

            if (value is Dictionary<string, object?> dict)
            {
                return dict;
            }

            if (value is JsonElement element && element.ValueKind == JsonValueKind.Object)
            {
                return JsonSerializer.Deserialize<Dictionary<string, object?>>(
                    element.GetRawText(),
                    JsonExtensions.DefaultJsonSerializerOptions);
            }
        }

        return null;
    }

    private static IReadOnlyDictionary<string, object?> ExtractMetadataConfig(
        IReadOnlyDictionary<string, object?> metaSchema,
        FoundryTool foundryTool,
        IReadOnlyDictionary<string, string>? keyOverrides)
    {
        var result = new Dictionary<string, object?>();

        var toolToMetaMapping = DefaultMetaKeyMapping.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
        if (keyOverrides != null)
        {
            foreach (var kvp in keyOverrides)
            {
                toolToMetaMapping[kvp.Key] = kvp.Value;
            }
        }

        if (!TryGetDictionary(metaSchema, "properties", out var properties))
        {
            return result;
        }

        var required = ExtractRequired(metaSchema);
        var toolDefinition = ConvertToDict(foundryTool);

        foreach (var (metaPropName, propSchemaObj) in properties)
        {
            var propSchema = ToDictionary(propSchemaObj);
            if (propSchema == null)
            {
                continue;
            }

            var isRequired = required.Contains(metaPropName);
            object? value = null;
            var valueFromDefinition = false;

            if (toolDefinition.TryGetValue(metaPropName, out value))
            {
                valueFromDefinition = true;
            }
            else
            {
                foreach (var (toolKey, mappedMetaKey) in toolToMetaMapping)
                {
                    if (mappedMetaKey == metaPropName && toolDefinition.TryGetValue(toolKey, out value))
                    {
                        valueFromDefinition = true;
                        break;
                    }
                }
            }

            if (value == null && isRequired && propSchema.TryGetValue("default", out var defaultValue))
            {
                value = defaultValue;
            }

            if (value != null && (valueFromDefinition || isRequired))
            {
                result[metaPropName] = value;
            }
        }

        return result;
    }

    private static HashSet<string> ExtractRequired(IReadOnlyDictionary<string, object?> metaSchema)
    {
        if (!metaSchema.TryGetValue("required", out var reqObj) || reqObj == null)
        {
            return new HashSet<string>();
        }

        if (reqObj is List<object> reqList)
        {
            return new HashSet<string>(reqList.Select(r => r.ToString() ?? string.Empty));
        }

        if (reqObj is JsonElement element && element.ValueKind == JsonValueKind.Array)
        {
            var required = new HashSet<string>();
            foreach (var item in element.EnumerateArray())
            {
                required.Add(item.ToString());
            }
            return required;
        }

        return new HashSet<string>();
    }

    private static bool TryGetDictionary(
        IReadOnlyDictionary<string, object?> source,
        string key,
        out Dictionary<string, object?> result)
    {
        result = new Dictionary<string, object?>();

        if (!source.TryGetValue(key, out var value))
        {
            return false;
        }

        var dict = ToDictionary(value);
        if (dict == null)
        {
            return false;
        }

        result = dict;
        return true;
    }

    private static Dictionary<string, object?>? ToDictionary(object? value)
    {
        switch (value)
        {
            case Dictionary<string, object?> dict:
                return dict;
            case IReadOnlyDictionary<string, object?> readOnlyDict:
                return new Dictionary<string, object?>(readOnlyDict);
            case JsonElement element when element.ValueKind == JsonValueKind.Object:
                return JsonSerializer.Deserialize<Dictionary<string, object?>>(
                    element.GetRawText(),
                    JsonExtensions.DefaultJsonSerializerOptions);
            default:
                return null;
        }
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
