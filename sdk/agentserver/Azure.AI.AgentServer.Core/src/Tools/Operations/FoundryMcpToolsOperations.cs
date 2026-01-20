// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.AI.AgentServer.Core.Common.Http.Json;
using Azure.AI.AgentServer.Core.Tools.Models;

namespace Azure.AI.AgentServer.Core.Tools.Operations;

/// <summary>
/// Handles operations for MCP (Model Context Protocol) tools.
/// </summary>
internal partial class FoundryMcpToolsOperations
{
    // Use relative path (without leading /) so it's appended to BaseAddress correctly
    private const string McpEndpointPath = "mcp_tools";
    private readonly IToolOperationsInvoker _invoker;
    private readonly FoundryToolClientOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="FoundryMcpToolsOperations"/> class.
    /// </summary>
    /// <param name="invoker">The service invoker.</param>
    /// <param name="options">The client options.</param>
    public FoundryMcpToolsOperations(IToolOperationsInvoker invoker, FoundryToolClientOptions options)
    {
        _invoker = invoker ?? throw new ArgumentNullException(nameof(invoker));
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    /// <summary>
    /// Lists MCP tools synchronously.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of MCP tools.</returns>
    public Response<IReadOnlyList<ResolvedFoundryTool>> ListTools(
        CancellationToken cancellationToken = default)
    {
        using HttpMessage message = CreateListToolsMessage(cancellationToken);
        var response = _invoker.SendRequest(message, cancellationToken);
        var tools = ProcessListToolsResponse(response);
        return Response.FromValue<IReadOnlyList<ResolvedFoundryTool>>(tools, response);
    }

    /// <summary>
    /// Lists MCP tools asynchronously.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Task returning list of MCP tools.</returns>
    public async Task<Response<IReadOnlyList<ResolvedFoundryTool>>> ListToolsAsync(
        CancellationToken cancellationToken = default)
    {
        using HttpMessage message = CreateListToolsMessage(cancellationToken);
        var response = await _invoker.SendRequestAsync(message, cancellationToken).ConfigureAwait(false);
        var tools = await ProcessListToolsResponseAsync(response, cancellationToken)
            .ConfigureAwait(false);
        return Response.FromValue<IReadOnlyList<ResolvedFoundryTool>>(tools, response);
    }

    /// <summary>
    /// Invokes an MCP tool synchronously.
    /// </summary>
    /// <param name="tool">The tool to invoke.</param>
    /// <param name="arguments">The tool arguments.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The tool invocation result.</returns>
    public Response<object?> InvokeTool(
        ResolvedFoundryTool tool,
        IDictionary<string, object?> arguments,
        CancellationToken cancellationToken = default)
    {
        using HttpMessage message = CreateInvokeToolMessage(tool, arguments, cancellationToken);
        var response = _invoker.SendRequest(message, cancellationToken);
        var result = ProcessInvokeToolResponse(response);
        return Response.FromValue(result, response);
    }

    /// <summary>
    /// Invokes an MCP tool asynchronously.
    /// </summary>
    /// <param name="tool">The tool to invoke.</param>
    /// <param name="arguments">The tool arguments.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Task returning the tool invocation result.</returns>
    public async Task<Response<object?>> InvokeToolAsync(
        ResolvedFoundryTool tool,
        IDictionary<string, object?> arguments,
        CancellationToken cancellationToken = default)
    {
        using HttpMessage message = CreateInvokeToolMessage(tool, arguments, cancellationToken);
        var response = await _invoker.SendRequestAsync(message, cancellationToken).ConfigureAwait(false);
        var result = await ProcessInvokeToolResponseAsync(response, cancellationToken).ConfigureAwait(false);
        return Response.FromValue(result, response);
    }

    private HttpMessage CreateListToolsMessage(CancellationToken cancellationToken)
    {
        var content = new
        {
            jsonrpc = "2.0",
            id = 1,
            method = "tools/list",
            @params = new { }
        };

        var relativeUri = $"{McpEndpointPath}?api-version={Uri.EscapeDataString(_options.ApiVersion)}";
        return _invoker.CreatePostMessage(
            relativeUri,
            BinaryData.FromObjectAsJson(content, JsonExtensions.DefaultJsonSerializerOptions),
            cancellationToken);
    }

    private HttpMessage CreateInvokeToolMessage(
        ResolvedFoundryTool tool,
        IDictionary<string, object?> arguments,
        CancellationToken cancellationToken)
    {
        var parameters = new Dictionary<string, object?>
        {
            ["name"] = tool.Name,
            ["arguments"] = arguments
        };

        // Add _meta if tool definition exists and metadata schema is present
        if (tool.Definition != null)
        {
            var metaConfig = PrepareMetadataConfig(
                tool.Metadata,
                tool.Definition,
                GetToolPropertyOverrides(tool.Name));

            if (metaConfig.Count > 0)
            {
                parameters["_meta"] = metaConfig;
            }
        }

        var content = new
        {
            jsonrpc = "2.0",
            id = 2,
            method = "tools/call",
            @params = parameters
        };

        var relativeUri = $"{McpEndpointPath}?api-version={Uri.EscapeDataString(_options.ApiVersion)}";
        return _invoker.CreatePostMessage(
            relativeUri,
            BinaryData.FromObjectAsJson(content, JsonExtensions.DefaultJsonSerializerOptions),
            cancellationToken);
    }

    private IReadOnlyDictionary<string, string>? GetToolPropertyOverrides(string toolName)
    {
        // Tool-specific property key overrides
        return toolName.ToLowerInvariant() switch
        {
            "image_generation" => new Dictionary<string, string>
            {
                ["model"] = "imagegen_model_deployment_name"
            },
            _ => null
        };
    }

    private IReadOnlyList<ResolvedFoundryTool> ProcessListToolsResponse(Response response)
    {
        if (response.ContentStream == null)
        {
            return Array.Empty<ResolvedFoundryTool>();
        }

        using var document = JsonDocument.Parse(response.ContentStream);
        var jsonResponse = document.RootElement;

        if (!jsonResponse.TryGetProperty("result", out var resultElement) ||
            !resultElement.TryGetProperty("tools", out var toolsElement))
        {
            return Array.Empty<ResolvedFoundryTool>();
        }

        var tools = ParseHostedMcpTools(toolsElement, _options.ToolConfig.HostedMcpTools);
        return BuildResolvedTools(tools);
    }

    private async Task<IReadOnlyList<ResolvedFoundryTool>> ProcessListToolsResponseAsync(
        Response response,
        CancellationToken cancellationToken)
    {
        if (response.ContentStream == null)
        {
            return Array.Empty<ResolvedFoundryTool>();
        }

        using var document = await JsonDocument.ParseAsync(response.ContentStream, cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        var jsonResponse = document.RootElement;

        if (!jsonResponse.TryGetProperty("result", out var resultElement) ||
            !resultElement.TryGetProperty("tools", out var toolsElement))
        {
            return Array.Empty<ResolvedFoundryTool>();
        }

        var tools = ParseHostedMcpTools(toolsElement, _options.ToolConfig.HostedMcpTools);
        return BuildResolvedTools(tools);
    }

    private object? ProcessInvokeToolResponse(Response response)
    {
        if (response.ContentStream == null)
        {
            return null;
        }

        using var document = JsonDocument.Parse(response.ContentStream);
        var jsonResponse = document.RootElement;

        if (!jsonResponse.TryGetProperty("result", out var resultElement))
        {
            return null;
        }

        return JsonSerializer.Deserialize<object>(
            resultElement.GetRawText(),
            JsonExtensions.DefaultJsonSerializerOptions);
    }

    private async Task<object?> ProcessInvokeToolResponseAsync(Response response, CancellationToken cancellationToken)
    {
        if (response.ContentStream == null)
        {
            return null;
        }

        using var document = await JsonDocument.ParseAsync(response.ContentStream, cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        var jsonResponse = document.RootElement;

        if (!jsonResponse.TryGetProperty("result", out var resultElement))
        {
            return null;
        }

        return JsonSerializer.Deserialize<object>(
            resultElement.GetRawText(),
            JsonExtensions.DefaultJsonSerializerOptions);
    }

    private static IReadOnlyList<FoundryToolDetails> ParseHostedMcpTools(
        JsonElement toolsElement,
        IReadOnlyList<FoundryHostedMcpTool> hostedMcpTools)
    {
        if (hostedMcpTools.Count == 0)
        {
            return Array.Empty<FoundryToolDetails>();
        }

        var toolsByName = hostedMcpTools
            .GroupBy(tool => tool.Name, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(group => group.Key, group => group.First(), StringComparer.OrdinalIgnoreCase);

        var parsedTools = new List<FoundryToolDetails>();

        foreach (var toolElement in toolsElement.EnumerateArray())
        {
            var name = toolElement.TryGetProperty("name", out var nameElement)
                ? nameElement.GetString()
                : null;
            if (string.IsNullOrWhiteSpace(name) ||
                !toolsByName.TryGetValue(name, out var foundryTool))
            {
                continue;
            }

            var description = toolElement.TryGetProperty("description", out var descriptionElement)
                ? descriptionElement.GetString()
                : null;
            var inputSchema = TryDeserializeSchema(toolElement, "inputSchema", "input_schema", "schema", "parameters");

            var metadata = JsonSerializer.Deserialize<Dictionary<string, object?>>(
                toolElement.GetRawText(),
                JsonExtensions.DefaultJsonSerializerOptions) ?? new Dictionary<string, object?>();
            metadata["foundry_tool"] = foundryTool;

            parsedTools.Add(new FoundryToolDetails(
                name,
                description ?? string.Empty,
                metadata,
                inputSchema));
        }

        return parsedTools;
    }

    private static IReadOnlyDictionary<string, object?>? TryDeserializeSchema(
        JsonElement element,
        params string[] propertyNames)
    {
        foreach (var propertyName in propertyNames)
        {
            if (element.TryGetProperty(propertyName, out var schemaElement))
            {
                return JsonSerializer.Deserialize<Dictionary<string, object?>>(
                    schemaElement.GetRawText(),
                    JsonExtensions.DefaultJsonSerializerOptions);
            }
        }

        return null;
    }

    private static IReadOnlyList<ResolvedFoundryTool> BuildResolvedTools(IReadOnlyList<FoundryToolDetails> tools)
    {
        if (tools.Count == 0)
        {
            return Array.Empty<ResolvedFoundryTool>();
        }

        var descriptors = new List<ResolvedFoundryTool>(tools.Count);

        foreach (var tool in tools)
        {
            descriptors.Add(new ResolvedFoundryTool
            {
                Definition = GetDefinition(tool.Metadata),
                Details = tool
            });
        }

        return descriptors;
    }

    private static FoundryTool? GetDefinition(IReadOnlyDictionary<string, object?> metadata)
    {
        if (metadata.TryGetValue("foundry_tool", out var definition) && definition is FoundryTool foundryTool)
        {
            return foundryTool;
        }

        return null;
    }
}
