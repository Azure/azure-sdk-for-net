// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http.Json;
using System.Text.Json;
using Azure.AI.AgentServer.Core.Common.Http.Json;
using Azure.AI.AgentServer.Core.Tools.Exceptions;
using Azure.AI.AgentServer.Core.Tools.Models;
using Azure.AI.AgentServer.Core.Tools.Utilities;

namespace Azure.AI.AgentServer.Core.Tools.Operations;

/// <summary>
/// Handles operations for remote Azure AI Tools API.
/// </summary>
internal class RemoteToolsOperations
{
    private readonly HttpClient _httpClient;
    private readonly AzureAIToolClientOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="RemoteToolsOperations"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client for making requests.</param>
    /// <param name="options">The client options.</param>
    public RemoteToolsOperations(HttpClient httpClient, AzureAIToolClientOptions options)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    /// <summary>
    /// Resolves remote tools synchronously.
    /// </summary>
    /// <param name="existingNames">Set of existing tool names to avoid conflicts.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of remote tools.</returns>
    public IReadOnlyList<FoundryTool> ResolveTools(
        HashSet<string> existingNames,
        CancellationToken cancellationToken = default)
    {
        var request = BuildResolveToolsRequest();
        if (request == null)
        {
            return Array.Empty<FoundryTool>();
        }

        var response = SendRequest(request, cancellationToken);
        return ProcessResolveToolsResponse(response, existingNames);
    }

    /// <summary>
    /// Resolves remote tools asynchronously.
    /// </summary>
    /// <param name="existingNames">Set of existing tool names to avoid conflicts.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Task returning list of remote tools.</returns>
    public async Task<IReadOnlyList<FoundryTool>> ResolveToolsAsync(
        HashSet<string> existingNames,
        CancellationToken cancellationToken = default)
    {
        var request = BuildResolveToolsRequest();
        if (request == null)
        {
            return Array.Empty<FoundryTool>();
        }

        var response = await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
        return ProcessResolveToolsResponse(response, existingNames);
    }

    /// <summary>
    /// Invokes a remote tool synchronously.
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
    /// Invokes a remote tool asynchronously.
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

    private HttpRequestMessage? BuildResolveToolsRequest()
    {
        if (_options.ToolConfig.RemoteTools.Count == 0)
        {
            return null;
        }

        var remoteServers = _options.ToolConfig.RemoteTools
            .Select(td => new
            {
                projectConnectionId = td.ProjectConnectionId,
                protocol = td.Type.ToLowerInvariant()
            })
            .ToList();

        var content = new Dictionary<string, object?>
        {
            ["remoteservers"] = remoteServers
        };

        if (_options.User != null)
        {
            content["user"] = _options.User.ToDictionary();
        }

        var agentName = string.IsNullOrWhiteSpace(_options.AgentName) ? "$default" : _options.AgentName;
        // Use relative URL (without leading /) so it's appended to BaseAddress correctly
        var url = $"agents/{agentName}/tools/resolve?api-version={_options.ApiVersion}";

        return new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = JsonContent.Create(content, options: JsonExtensions.DefaultJsonSerializerOptions)
        };
    }

    private HttpRequestMessage BuildInvokeToolRequest(
        FoundryTool tool,
        IDictionary<string, object?> arguments)
    {
        var content = new Dictionary<string, object?>
        {
            ["toolName"] = tool.Name,
            ["arguments"] = arguments,
            ["remoteServer"] = new
            {
                projectConnectionId = tool.ToolDefinition?.ProjectConnectionId,
                protocol = tool.ToolDefinition?.Type.ToLowerInvariant()
            }
        };

        if (_options.User != null)
        {
            content["user"] = _options.User.ToDictionary();
        }

        var agentName = string.IsNullOrWhiteSpace(_options.AgentName) ? "$default" : _options.AgentName;
        // Use relative URL (without leading /) so it's appended to BaseAddress correctly
        var url = $"agents/{agentName}/tools/invoke?api-version={_options.ApiVersion}";

        return new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = JsonContent.Create(content, options: JsonExtensions.DefaultJsonSerializerOptions)
        };
    }

    private IReadOnlyList<FoundryTool> ProcessResolveToolsResponse(
        HttpResponseMessage response,
        HashSet<string> existingNames)
    {
        var jsonResponse = response.Content.ReadFromJsonAsync<JsonElement>(
            JsonExtensions.DefaultJsonSerializerOptions).Result;

        // Check for OAuth consent required
        CheckForOAuthConsent(jsonResponse);

        if (!jsonResponse.TryGetProperty("tools", out var toolsElement))
        {
            return Array.Empty<FoundryTool>();
        }

        var enrichedTools = ParseEnrichedTools(toolsElement, _options.ToolConfig.RemoteTools);

        return ToolDescriptorBuilder.BuildDescriptors(
            enrichedTools,
            ToolSource.RemoteTools,
            existingNames);
    }

    private object? ProcessInvokeToolResponse(HttpResponseMessage response)
    {
        var jsonResponse = response.Content.ReadFromJsonAsync<JsonElement>(
            JsonExtensions.DefaultJsonSerializerOptions).Result;

        // Check for OAuth consent required
        CheckForOAuthConsent(jsonResponse);

        if (!jsonResponse.TryGetProperty("toolResult", out var resultElement))
        {
            return null;
        }

        return JsonSerializer.Deserialize<object>(
            resultElement.GetRawText(),
            JsonExtensions.DefaultJsonSerializerOptions);
    }

    private void CheckForOAuthConsent(JsonElement jsonResponse)
    {
        if (jsonResponse.TryGetProperty("type", out var typeElement) &&
            typeElement.GetString() == "OAuthConsentRequired")
        {
            var result = jsonResponse.GetProperty("toolResult");
            var message = result.TryGetProperty("message", out var msgElement)
                ? msgElement.GetString()
                : "OAuth consent required";
            var consentUrl = result.TryGetProperty("consentUrl", out var urlElement)
                ? urlElement.GetString()
                : message;

            throw new OAuthConsentRequiredException(message ?? "OAuth consent required", consentUrl);
        }
    }

    private List<Dictionary<string, object?>> ParseEnrichedTools(
        JsonElement toolsElement,
        IReadOnlyList<ToolDefinition> toolDefinitions)
    {
        var enrichedTools = new List<Dictionary<string, object?>>();

        foreach (var toolEntry in toolsElement.EnumerateArray())
        {
            if (!toolEntry.TryGetProperty("remoteServer", out var remoteServer))
            {
                continue;
            }

            var projectConnectionId = remoteServer.GetProperty("projectConnectionId").GetString();
            var protocol = remoteServer.GetProperty("protocol").GetString();

            var toolDefinition = toolDefinitions.FirstOrDefault(td =>
                string.Equals(td.Type, protocol, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(td.ProjectConnectionId, projectConnectionId, StringComparison.OrdinalIgnoreCase));

            if (!toolEntry.TryGetProperty("manifest", out var manifestArray))
            {
                continue;
            }

            foreach (var manifest in manifestArray.EnumerateArray())
            {
                var enrichedTool = new Dictionary<string, object?>
                {
                    ["name"] = manifest.TryGetProperty("name", out var nameEl) ? nameEl.GetString() : null,
                    ["description"] = manifest.TryGetProperty("description", out var descEl) ? descEl.GetString() : null,
                    ["tool_definition"] = toolDefinition,
                    ["projectConnectionId"] = projectConnectionId,
                    ["protocol"] = protocol
                };

                if (manifest.TryGetProperty("parameters", out var parametersEl))
                {
                    enrichedTool["inputSchema"] = JsonSerializer.Deserialize<Dictionary<string, object?>>(
                        parametersEl.GetRawText(),
                        JsonExtensions.DefaultJsonSerializerOptions);
                }

                enrichedTools.Add(enrichedTool);
            }
        }

        return enrichedTools;
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
