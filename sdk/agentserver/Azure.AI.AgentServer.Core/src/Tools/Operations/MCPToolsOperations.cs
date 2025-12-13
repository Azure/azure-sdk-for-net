// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http.Json;
using System.Text.Json;
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
    private readonly HttpClient _httpClient;
    private readonly AzureAIToolClientOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="MCPToolsOperations"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client for making requests.</param>
    /// <param name="options">The client options.</param>
    public MCPToolsOperations(HttpClient httpClient, AzureAIToolClientOptions options)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    /// <summary>
    /// Lists MCP tools synchronously.
    /// </summary>
    /// <param name="existingNames">Set of existing tool names to avoid conflicts.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of MCP tools.</returns>
    public IReadOnlyList<FoundryTool> ListTools(
        HashSet<string> existingNames,
        CancellationToken cancellationToken = default)
    {
        var request = BuildListToolsRequest();
        var response = SendRequest(request, cancellationToken);
        return ProcessListToolsResponse(response, existingNames);
    }

    /// <summary>
    /// Lists MCP tools asynchronously.
    /// </summary>
    /// <param name="existingNames">Set of existing tool names to avoid conflicts.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Task returning list of MCP tools.</returns>
    public async Task<IReadOnlyList<FoundryTool>> ListToolsAsync(
        HashSet<string> existingNames,
        CancellationToken cancellationToken = default)
    {
        var request = BuildListToolsRequest();
        var response = await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
        return ProcessListToolsResponse(response, existingNames);
    }

    /// <summary>
    /// Invokes an MCP tool synchronously.
    /// </summary>
    /// <param name="tool">The tool to invoke.</param>
    /// <param name="arguments">The tool arguments.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The tool invocation result.</returns>
    public object? InvokeTool(
        FoundryTool tool,
        IDictionary<string, object?> arguments,
        CancellationToken cancellationToken = default)
    {
        var request = BuildInvokeToolRequest(tool, arguments);
        var response = SendRequest(request, cancellationToken);
        return ProcessInvokeToolResponse(response);
    }

    /// <summary>
    /// Invokes an MCP tool asynchronously.
    /// </summary>
    /// <param name="tool">The tool to invoke.</param>
    /// <param name="arguments">The tool arguments.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Task returning the tool invocation result.</returns>
    public async Task<object?> InvokeToolAsync(
        FoundryTool tool,
        IDictionary<string, object?> arguments,
        CancellationToken cancellationToken = default)
    {
        var request = BuildInvokeToolRequest(tool, arguments);
        var response = await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
        return ProcessInvokeToolResponse(response);
    }

    private HttpRequestMessage BuildListToolsRequest()
    {
        var content = new
        {
            jsonrpc = "2.0",
            id = 1,
            method = "tools/list",
            @params = new { }
        };

        var url = $"{McpEndpointPath}?api-version={_options.ApiVersion}";
        return new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = JsonContent.Create(content, options: JsonExtensions.DefaultJsonSerializerOptions)
        };
    }

    private HttpRequestMessage BuildInvokeToolRequest(
        FoundryTool tool,
        IDictionary<string, object?> arguments)
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

        var url = $"{McpEndpointPath}?api-version={_options.ApiVersion}";
        return new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = JsonContent.Create(content, options: JsonExtensions.DefaultJsonSerializerOptions)
        };
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
        HttpResponseMessage response,
        HashSet<string> existingNames)
    {
        var jsonResponse = response.Content.ReadFromJsonAsync<JsonElement>(
            JsonExtensions.DefaultJsonSerializerOptions).Result;

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

    private object? ProcessInvokeToolResponse(HttpResponseMessage response)
    {
        var jsonResponse = response.Content.ReadFromJsonAsync<JsonElement>(
            JsonExtensions.DefaultJsonSerializerOptions).Result;

        if (!jsonResponse.TryGetProperty("result", out var resultElement))
        {
            return null;
        }

        return JsonSerializer.Deserialize<object>(
            resultElement.GetRawText(),
            JsonExtensions.DefaultJsonSerializerOptions);
    }

    private HttpResponseMessage SendRequest(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = _httpClient.Send(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        return response;
    }

    private async Task<HttpResponseMessage> SendRequestAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        return response;
    }
}
