// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.AI.AgentServer.Core.Tools.Models;
using Azure.AI.AgentServer.Core.Tools.Operations;

namespace Azure.AI.AgentServer.Core.Tools;

/// <summary>
/// Asynchronous client for aggregating tools from Azure AI MCP and Tools APIs.
/// This is the primary client for production use.
/// </summary>
#pragma warning disable AZC0015
public class AzureAIToolClient : IAsyncDisposable
{
    private readonly HttpClient _httpClient;
    private readonly AzureAIToolClientOptions _options;
    private readonly TokenCredential _credential;
    private readonly MCPToolsOperations _mcpTools;
    private readonly RemoteToolsOperations _remoteTools;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="AzureAIToolClient"/> class for mocking.
    /// </summary>
    protected AzureAIToolClient()
    {
        _httpClient = null!;
        _options = null!;
        _credential = null!;
        _mcpTools = null!;
        _remoteTools = null!;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AzureAIToolClient"/> class.
    /// </summary>
    /// <param name="endpoint">The Azure AI endpoint URL.</param>
    /// <param name="credential">The token credential for authentication.</param>
    /// <param name="options">Optional client options.</param>
    public AzureAIToolClient(
        Uri endpoint,
        TokenCredential credential,
        AzureAIToolClientOptions? options = null)
    {
        ArgumentNullException.ThrowIfNull(endpoint);
        ArgumentNullException.ThrowIfNull(credential);

        _credential = credential;
        _options = options ?? new AzureAIToolClientOptions();
        _options.ValidateAndParse();

        _httpClient = CreateHttpClient(endpoint);
        _mcpTools = new MCPToolsOperations(_httpClient, _options);
        _remoteTools = new RemoteToolsOperations(_httpClient, _options);
    }

    /// <summary>
    /// Lists all available tools from configured sources synchronously.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of available tools.</returns>
    /// <exception cref="Exceptions.OAuthConsentRequiredException">OAuth consent required.</exception>
    /// <exception cref="Exceptions.MCPToolApprovalRequiredException">Tool approval required.</exception>
    public virtual IReadOnlyList<FoundryTool> ListTools(CancellationToken cancellationToken = default)
    {
        // Refresh token before making requests
        RefreshToken(cancellationToken);

        var existingNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var tools = new List<FoundryTool>();

        if (_options.ToolConfig.NamedMcpTools.Count > 0)
        {
            tools.AddRange(_mcpTools.ListTools(existingNames, cancellationToken));
        }

        if (_options.ToolConfig.RemoteTools.Count > 0)
        {
            tools.AddRange(_remoteTools.ResolveTools(existingNames, cancellationToken));
        }

        // Attach sync + async invokers
        foreach (var tool in tools)
        {
            tool.Invoker = args => InvokeTool(tool, args, cancellationToken);
            tool.AsyncInvoker = args => InvokeToolAsync(tool, args, cancellationToken);
        }

        return tools;
    }

    /// <summary>
    /// Lists all available tools from configured sources asynchronously.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Task returning list of available tools.</returns>
    /// <exception cref="Exceptions.OAuthConsentRequiredException">OAuth consent required.</exception>
    /// <exception cref="Exceptions.MCPToolApprovalRequiredException">Tool approval required.</exception>
    public virtual async Task<IReadOnlyList<FoundryTool>> ListToolsAsync(CancellationToken cancellationToken = default)
    {
        // Refresh token before making requests
        await RefreshTokenAsync(cancellationToken).ConfigureAwait(false);

        var existingNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var tools = new List<FoundryTool>();

        // Parallel execution for better performance
        var tasks = new List<Task<IReadOnlyList<FoundryTool>>>();

        if (_options.ToolConfig.NamedMcpTools.Count > 0)
        {
            tasks.Add(_mcpTools.ListToolsAsync(existingNames, cancellationToken));
        }

        if (_options.ToolConfig.RemoteTools.Count > 0)
        {
            tasks.Add(_remoteTools.ResolveToolsAsync(existingNames, cancellationToken));
        }

        if (tasks.Count > 0)
        {
            var results = await Task.WhenAll(tasks).ConfigureAwait(false);

            foreach (var result in results)
            {
                tools.AddRange(result);
            }
        }

        // Attach async invokers
        foreach (var tool in tools)
        {
            tool.Invoker = args => InvokeTool(tool, args, cancellationToken);
            tool.AsyncInvoker = args => InvokeToolAsync(tool, args, cancellationToken);
        }

        return tools;
    }

    /// <summary>
    /// Invokes a tool by name synchronously.
    /// </summary>
    /// <param name="toolName">The tool name.</param>
    /// <param name="arguments">Optional tool arguments.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The tool invocation result.</returns>
    public virtual object? InvokeTool(
        string toolName,
        IDictionary<string, object?>? arguments = null,
        CancellationToken cancellationToken = default)
    {
        var descriptor = ResolveToolDescriptor(toolName, cancellationToken);
        return InvokeTool(descriptor, arguments, cancellationToken);
    }

    /// <summary>
    /// Invokes a tool by name asynchronously.
    /// </summary>
    /// <param name="toolName">The tool name.</param>
    /// <param name="arguments">Optional tool arguments.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Task returning the tool invocation result.</returns>
    public virtual async Task<object?> InvokeToolAsync(
        string toolName,
        IDictionary<string, object?>? arguments = null,
        CancellationToken cancellationToken = default)
    {
        var descriptor = await ResolveToolDescriptorAsync(toolName, cancellationToken).ConfigureAwait(false);
        return await InvokeToolAsync(descriptor, arguments, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Invokes a tool by descriptor synchronously.
    /// </summary>
    /// <param name="tool">The tool descriptor.</param>
    /// <param name="arguments">Optional tool arguments.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The tool invocation result.</returns>
    public virtual object? InvokeTool(
        FoundryTool tool,
        IDictionary<string, object?>? arguments = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(tool);

        // Refresh token before invocation
        RefreshToken(cancellationToken);

        var payload = arguments ?? new Dictionary<string, object?>();

        return tool.Source switch
        {
            ToolSource.McpTools => _mcpTools.InvokeTool(tool, payload, cancellationToken),
            ToolSource.RemoteTools => _remoteTools.InvokeTool(tool, payload, cancellationToken),
            _ => throw new InvalidOperationException($"Unsupported tool source: {tool.Source}")
        };
    }

    /// <summary>
    /// Invokes a tool by descriptor asynchronously.
    /// </summary>
    /// <param name="tool">The tool descriptor.</param>
    /// <param name="arguments">Optional tool arguments.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Task returning the tool invocation result.</returns>
    public virtual async Task<object?> InvokeToolAsync(
        FoundryTool tool,
        IDictionary<string, object?>? arguments = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(tool);

        // Refresh token before invocation
        await RefreshTokenAsync(cancellationToken).ConfigureAwait(false);

        var payload = arguments ?? new Dictionary<string, object?>();

        return tool.Source switch
        {
            ToolSource.McpTools => await _mcpTools.InvokeToolAsync(tool, payload, cancellationToken)
                .ConfigureAwait(false),
            ToolSource.RemoteTools => await _remoteTools.InvokeToolAsync(tool, payload, cancellationToken)
                .ConfigureAwait(false),
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

    private async Task<FoundryTool> ResolveToolDescriptorAsync(string toolName, CancellationToken cancellationToken)
    {
        var tools = await ListToolsAsync(cancellationToken).ConfigureAwait(false);
        return tools.FirstOrDefault(t =>
            string.Equals(t.Name, toolName, StringComparison.OrdinalIgnoreCase) ||
            string.Equals(t.Key, toolName, StringComparison.OrdinalIgnoreCase))
            ?? throw new KeyNotFoundException($"Unknown tool: {toolName}");
    }

    private HttpClient CreateHttpClient(Uri endpoint)
    {
        // Ensure BaseAddress ends with '/' so relative URIs are appended correctly
        var baseUri = endpoint.ToString().EndsWith("/")
            ? endpoint
            : new Uri(endpoint.ToString() + "/");
        var client = new HttpClient { BaseAddress = baseUri };
        return client;
    }

    private async Task RefreshTokenAsync(CancellationToken cancellationToken)
    {
        var token = await _credential.GetTokenAsync(
            new TokenRequestContext(_options.CredentialScopes.ToArray()),
            cancellationToken).ConfigureAwait(false);

        _httpClient.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Token);
    }

    private void RefreshToken(CancellationToken cancellationToken)
    {
        var token = _credential.GetToken(
            new TokenRequestContext(_options.CredentialScopes.ToArray()),
            cancellationToken);

        _httpClient.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Token);
    }

    /// <summary>
    /// Disposes the client and releases resources synchronously.
    /// </summary>
    public virtual void Dispose()
    {
        if (!_disposed)
        {
            _httpClient?.Dispose();
            _disposed = true;
        }

        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Disposes the client and releases resources asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous dispose operation.</returns>
    public virtual async ValueTask DisposeAsync()
    {
        if (!_disposed)
        {
            _httpClient?.Dispose();
            _disposed = true;
        }

        await Task.CompletedTask.ConfigureAwait(false);
        GC.SuppressFinalize(this);
    }
}
