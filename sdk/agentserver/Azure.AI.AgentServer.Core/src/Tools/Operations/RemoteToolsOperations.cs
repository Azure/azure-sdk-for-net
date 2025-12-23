// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;
using Azure.Core.Pipeline;
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
    private readonly IToolOperationsInvoker _invoker;
    private readonly AzureAIToolClientOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="RemoteToolsOperations"/> class.
    /// </summary>
    /// <param name="invoker">The service invoker.</param>
    /// <param name="options">The client options.</param>
    public RemoteToolsOperations(IToolOperationsInvoker invoker, AzureAIToolClientOptions options)
    {
        _invoker = invoker ?? throw new ArgumentNullException(nameof(invoker));
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    /// <summary>
    /// Resolves remote tools synchronously.
    /// </summary>
    /// <param name="existingNames">Set of existing tool names to avoid conflicts.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of remote tools.</returns>
    public Response<IReadOnlyList<FoundryTool>> ResolveTools(
        HashSet<string> existingNames,
        CancellationToken cancellationToken = default)
    {
        var message = CreateResolveToolsMessage(cancellationToken);
        using (message)
        {
            var response = _invoker.SendRequest(message, cancellationToken);
            var tools = ProcessResolveToolsResponse(response, existingNames);
            return Response.FromValue<IReadOnlyList<FoundryTool>>(tools, response);
        }
    }

    /// <summary>
    /// Resolves remote tools asynchronously.
    /// </summary>
    /// <param name="existingNames">Set of existing tool names to avoid conflicts.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Task returning list of remote tools.</returns>
    public async Task<Response<IReadOnlyList<FoundryTool>>> ResolveToolsAsync(
        HashSet<string> existingNames,
        CancellationToken cancellationToken = default)
    {
        var message = CreateResolveToolsMessage(cancellationToken);
        using (message)
        {
            var response = await _invoker.SendRequestAsync(message, cancellationToken).ConfigureAwait(false);
            var tools = await ProcessResolveToolsResponseAsync(response, existingNames, cancellationToken)
                .ConfigureAwait(false);
            return Response.FromValue<IReadOnlyList<FoundryTool>>(tools, response);
        }
    }

    /// <summary>
    /// Invokes a remote tool synchronously.
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
    /// Invokes a remote tool asynchronously.
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

    private HttpMessage CreateResolveToolsMessage(CancellationToken cancellationToken)
    {
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
            content["user"] = _options.User.Properties;
        }

        var agentName = string.IsNullOrWhiteSpace(_options.AgentName) ? "$default" : _options.AgentName;

        var relativeUri = $"agents/{Uri.EscapeDataString(agentName)}/tools/resolve?api-version={Uri.EscapeDataString(_options.ApiVersion)}";
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
            content["user"] = _options.User.Properties;
        }

        var agentName = string.IsNullOrWhiteSpace(_options.AgentName) ? "$default" : _options.AgentName;

        var relativeUri = $"agents/{Uri.EscapeDataString(agentName)}/tools/invoke?api-version={Uri.EscapeDataString(_options.ApiVersion)}";
        return _invoker.CreatePostMessage(
            relativeUri,
            BinaryData.FromObjectAsJson(content, JsonExtensions.DefaultJsonSerializerOptions),
            cancellationToken);
    }

    private IReadOnlyList<FoundryTool> ProcessResolveToolsResponse(
        Response response,
        HashSet<string> existingNames)
    {
        if (response.ContentStream == null)
        {
            return Array.Empty<FoundryTool>();
        }

        using var document = JsonDocument.Parse(response.ContentStream);
        var jsonResponse = document.RootElement;

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

    private async Task<IReadOnlyList<FoundryTool>> ProcessResolveToolsResponseAsync(
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

    private object? ProcessInvokeToolResponse(Response response)
    {
        if (response.ContentStream == null)
        {
            return null;
        }

        using var document = JsonDocument.Parse(response.ContentStream);
        var jsonResponse = document.RootElement;

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

    private async Task<object?> ProcessInvokeToolResponseAsync(Response response, CancellationToken cancellationToken)
    {
        if (response.ContentStream == null)
        {
            return null;
        }

        using var document = await JsonDocument.ParseAsync(response.ContentStream, cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        var jsonResponse = document.RootElement;

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
}
