// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.AI.AgentServer.Core.Tools.Models;
using Azure.AI.AgentServer.Core.Tools.Operations;

namespace Azure.AI.AgentServer.Core.Tools;

/// <summary>
/// Synchronous client for aggregating tools from Azure AI MCP and Tools APIs.
/// </summary>
#pragma warning disable AZC0005
public class AzureAIToolClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly AzureAIToolClientOptions _options;
    private readonly MCPToolsOperations _mcpTools;
    private readonly RemoteToolsOperations _remoteTools;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="AzureAIToolClient"/> class.
    /// </summary>
    /// <param name="endpoint">The Azure AI endpoint URL.</param>
    /// <param name="credential">The token credential for authentication.</param>
    /// <param name="options">Optional client options.</param>
#pragma warning disable AZC0007
    public AzureAIToolClient(
        Uri endpoint,
        TokenCredential credential,
        AzureAIToolClientOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(endpoint);
        ArgumentNullException.ThrowIfNull(credential);

        _options = options ?? new AzureAIToolClientOptions();
        _options.ValidateAndParse();

        _httpClient = CreateHttpClient(endpoint, credential);
        _mcpTools = new MCPToolsOperations(_httpClient, _options);
        _remoteTools = new RemoteToolsOperations(_httpClient, _options);
    }

    /// <summary>
    /// Lists all available tools from configured sources.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of available tools.</returns>
    /// <exception cref="Exceptions.OAuthConsentRequiredException">OAuth consent required.</exception>
    /// <exception cref="Exceptions.MCPToolApprovalRequiredException">Tool approval required.</exception>
    public IReadOnlyList<FoundryTool> ListTools(CancellationToken cancellationToken = default)
    {
        var existingNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var tools = new List<FoundryTool>();

        // Fetch MCP tools
        if (_options.ToolConfig.NamedMcpTools.Count > 0)
        {
            var mcpTools = _mcpTools.ListTools(existingNames, cancellationToken);
            tools.AddRange(mcpTools);
        }

        // Fetch remote tools
        if (_options.ToolConfig.RemoteTools.Count > 0)
        {
            var remoteTools = _remoteTools.ResolveTools(existingNames, cancellationToken);
            tools.AddRange(remoteTools);
        }

        // Attach invokers
        foreach (var tool in tools)
        {
            tool.Invoker = args => InvokeTool(tool, args, cancellationToken);
        }

        return tools;
    }

    /// <summary>
    /// Invokes a tool by name.
    /// </summary>
    /// <param name="toolName">The tool name.</param>
    /// <param name="arguments">Optional tool arguments.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The tool invocation result.</returns>
    public object? InvokeTool(
        string toolName,
        IDictionary<string, object?>? arguments = null,
        CancellationToken cancellationToken = default)
    {
        var descriptor = ResolveToolDescriptor(toolName, cancellationToken);
        return InvokeTool(descriptor, arguments, cancellationToken);
    }

    /// <summary>
    /// Invokes a tool by descriptor.
    /// </summary>
    /// <param name="tool">The tool descriptor.</param>
    /// <param name="arguments">Optional tool arguments.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The tool invocation result.</returns>
    public object? InvokeTool(
        FoundryTool tool,
        IDictionary<string, object?>? arguments = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(tool);

        var payload = arguments ?? new Dictionary<string, object?>();

        return tool.Source switch
        {
            ToolSource.McpTools => _mcpTools.InvokeTool(tool, payload, cancellationToken),
            ToolSource.RemoteTools => _remoteTools.InvokeTool(tool, payload, cancellationToken),
            _ => throw new InvalidOperationException($"Unsupported tool source: {tool.Source}")
        };
    }

    private FoundryTool ResolveToolDescriptor(string toolName, CancellationToken cancellationToken)
    {
        var tools = ListTools(cancellationToken);
        return tools.FirstOrDefault(t =>
            string.Equals(t.Name, toolName, StringComparison.OrdinalIgnoreCase) ||
            string.Equals(t.Key, toolName, StringComparison.OrdinalIgnoreCase))
            ?? throw new KeyNotFoundException($"Unknown tool: {toolName}");
    }

    private HttpClient CreateHttpClient(Uri endpoint, TokenCredential credential)
    {
        // Ensure BaseAddress ends with '/' so relative URIs are appended correctly
        var baseUri = endpoint.ToString().EndsWith("/")
            ? endpoint
            : new Uri(endpoint.ToString() + "/");
        var client = new HttpClient { BaseAddress = baseUri };

        // Add authentication - simplified version
        // In production, use Azure.Core.Pipeline.HttpPipelinePolicy for proper token refresh
        var token = credential.GetToken(new TokenRequestContext(_options.CredentialScopes.ToArray()), default);
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Token);

        return client;
    }

    /// <summary>
    /// Disposes the client and releases resources.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Disposes the client.
    /// </summary>
    /// <param name="disposing">True if disposing managed resources.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _httpClient?.Dispose();
            }
            _disposed = true;
        }
    }
}
