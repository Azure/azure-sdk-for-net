// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.AI.AgentServer.Core.Common.Http.Json;
using Azure.AI.AgentServer.Core.Tools.Models;
using Azure.AI.AgentServer.Core.Tools.Utilities;

namespace Azure.AI.AgentServer.Core.Tools.Operations;

/// <summary>
/// Handles operations for MCP (Model Context Protocol) tools.
/// </summary>
internal class MCPToolsOperations
{
    // Use relative path (without leading /) so it's appended to BaseAddress correctly
    private const string McpEndpointPath = "mcp_tools";
    private readonly IToolOperationsInvoker _invoker;
    private readonly AzureAIToolClientOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="MCPToolsOperations"/> class.
    /// </summary>
    /// <param name="invoker">The service invoker.</param>
    /// <param name="options">The client options.</param>
    public MCPToolsOperations(IToolOperationsInvoker invoker, AzureAIToolClientOptions options)
    {
        _invoker = invoker ?? throw new ArgumentNullException(nameof(invoker));
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    /// <summary>
    /// Lists MCP tools synchronously.
    /// </summary>
    /// <param name="existingNames">Set of existing tool names to avoid conflicts.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of MCP tools.</returns>
    public Response<IReadOnlyList<FoundryTool>> ListTools(
        HashSet<string> existingNames,
        CancellationToken cancellationToken = default)
    {
        using HttpMessage message = CreateListToolsMessage(cancellationToken);
        var response = _invoker.SendRequest(message, cancellationToken);
        var tools = ProcessListToolsResponse(response, existingNames);
        return Response.FromValue<IReadOnlyList<FoundryTool>>(tools, response);
    }

    /// <summary>
    /// Lists MCP tools asynchronously.
    /// </summary>
    /// <param name="existingNames">Set of existing tool names to avoid conflicts.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Task returning list of MCP tools.</returns>
    public async Task<Response<IReadOnlyList<FoundryTool>>> ListToolsAsync(
        HashSet<string> existingNames,
        CancellationToken cancellationToken = default)
    {
        using HttpMessage message = CreateListToolsMessage(cancellationToken);
        var response = await _invoker.SendRequestAsync(message, cancellationToken).ConfigureAwait(false);
        var tools = await ProcessListToolsResponseAsync(response, existingNames, cancellationToken)
            .ConfigureAwait(false);
        return Response.FromValue<IReadOnlyList<FoundryTool>>(tools, response);
    }

    /// <summary>
    /// Invokes an MCP tool synchronously.
    /// </summary>
    /// <param name="tool">The tool to invoke.</param>
    /// <param name="arguments">The tool arguments.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The tool invocation result.</returns>
    public Response<object?> InvokeTool(
        FoundryTool tool,
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
        FoundryTool tool,
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
        FoundryTool tool,
        IDictionary<string, object?> arguments,
        CancellationToken cancellationToken)
    {
        var parameters = new Dictionary<string, object?>
        {
            ["name"] = tool.Name,
            ["arguments"] = arguments
        };

        // Add _meta if tool definition exists and metadata schema is present
        if (tool.ToolDefinition != null)
        {
            var metaSchema = ToolMetadataExtractor.ExtractMetadataSchema(tool.Metadata);
            if (metaSchema != null)
            {
                var metaConfig = MetadataMapper.PrepareMetadataDict(
                    tool.Metadata,
                    tool.ToolDefinition,
                    GetToolPropertyOverrides(tool.Name));

                if (metaConfig.Count > 0)
                {
                    parameters["_meta"] = metaConfig;
                }
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

    private IReadOnlyList<FoundryTool> ProcessListToolsResponse(
        Response response,
        HashSet<string> existingNames)
    {
        if (response.ContentStream == null)
        {
            return Array.Empty<FoundryTool>();
        }

        using var document = JsonDocument.Parse(response.ContentStream);
        var jsonResponse = document.RootElement;

        if (!jsonResponse.TryGetProperty("result", out var resultElement) ||
            !resultElement.TryGetProperty("tools", out var toolsElement))
        {
            return Array.Empty<FoundryTool>();
        }

        var rawTools = JsonSerializer.Deserialize<List<Dictionary<string, object?>>>(
            toolsElement.GetRawText(),
            JsonExtensions.DefaultJsonSerializerOptions) ?? new List<Dictionary<string, object?>>();

        return ToolDescriptorBuilder.BuildDescriptors(
            rawTools,
            ToolSource.McpTools,
            existingNames);
    }

    private async Task<IReadOnlyList<FoundryTool>> ProcessListToolsResponseAsync(
        Response response,
        HashSet<string> existingNames,
        CancellationToken cancellationToken)
    {
        if (response.ContentStream == null)
        {
            return Array.Empty<FoundryTool>();
        }

        using var document = await JsonDocument.ParseAsync(response.ContentStream, cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        var jsonResponse = document.RootElement;

        if (!jsonResponse.TryGetProperty("result", out var resultElement) ||
            !resultElement.TryGetProperty("tools", out var toolsElement))
        {
            return Array.Empty<FoundryTool>();
        }

        var rawTools = JsonSerializer.Deserialize<List<Dictionary<string, object?>>>(
            toolsElement.GetRawText(),
            JsonExtensions.DefaultJsonSerializerOptions) ?? new List<Dictionary<string, object?>>();

        return ToolDescriptorBuilder.BuildDescriptors(
            rawTools,
            ToolSource.McpTools,
            existingNames);
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
}
