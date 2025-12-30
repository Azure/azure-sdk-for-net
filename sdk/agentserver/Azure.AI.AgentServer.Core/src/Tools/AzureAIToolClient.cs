// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.AI.AgentServer.Core.Tools.Models;
using Azure.AI.AgentServer.Core.Tools.Operations;

namespace Azure.AI.AgentServer.Core.Tools;

/// <summary>
/// Asynchronous client for aggregating tools from Azure AI MCP and Tools APIs.
/// This is the primary client for production use.
/// </summary>
#pragma warning disable AZC0015
public class AzureAIToolClient : IAsyncDisposable, IDisposable
{
    private readonly AzureAIToolClientOptions _options;
    private readonly TokenCredential _credential;
    private readonly MCPToolsOperations _mcpTools;
    private readonly RemoteToolsOperations _remoteTools;

    /// <summary>
    /// Initializes a new instance of the <see cref="AzureAIToolClient"/> class for mocking.
    /// </summary>
    protected AzureAIToolClient()
    {
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

        var endpointWithSlash = EnsureTrailingSlash(endpoint);
        var pipeline = HttpPipelineBuilder.Build(
            _options,
            Array.Empty<HttpPipelinePolicy>(),
            new HttpPipelinePolicy[]
            {
                new BearerTokenAuthenticationPolicy(_credential, _options.CredentialScopes.ToArray())
            },
            new ResponseClassifier());
        var invoker = new ToolOperationsInvoker(pipeline, endpointWithSlash);
        _mcpTools = new MCPToolsOperations(invoker, _options);
        _remoteTools = new RemoteToolsOperations(invoker, _options);
    }

    /// <summary>
    /// Lists all available tools from configured sources synchronously.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The list of available tools.</returns>
    /// <exception cref="Exceptions.OAuthConsentRequiredException">OAuth consent required.</exception>
    /// <exception cref="Exceptions.MCPToolApprovalRequiredException">Tool approval required.</exception>
    public virtual IReadOnlyList<FoundryTool> ListTools(CancellationToken cancellationToken = default)
    {
        var existingNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var tools = new List<FoundryTool>();

        if (_options.ToolConfig.NamedMcpTools.Count > 0)
        {
            var response = _mcpTools.ListTools(existingNames, cancellationToken);
            tools.AddRange(response.Value);
        }

        if (_options.ToolConfig.RemoteTools.Count > 0)
        {
            var response = _remoteTools.ResolveTools(existingNames, cancellationToken);
            tools.AddRange(response.Value);
        }
        else if (_options.ToolConfig.NamedMcpTools.Count == 0)
        {
            var response = _mcpTools.ListTools(existingNames, cancellationToken);
            tools.AddRange(response.Value);
        }

        // Attach sync + async invokers
        foreach (var tool in tools)
        {
            tool.Invoker = args => InvokeTool(tool, args, cancellationToken);
            tool.AsyncInvoker = async args =>
                await InvokeToolAsync(tool, args, cancellationToken).ConfigureAwait(false);
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
        var existingNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var tools = new List<FoundryTool>();

        // Parallel execution for better performance
        var tasks = new List<Task<Response<IReadOnlyList<FoundryTool>>>>();

        if (_options.ToolConfig.NamedMcpTools.Count > 0)
        {
            tasks.Add(_mcpTools.ListToolsAsync(existingNames, cancellationToken));
        }

        if (_options.ToolConfig.RemoteTools.Count > 0)
        {
            tasks.Add(_remoteTools.ResolveToolsAsync(existingNames, cancellationToken));
        }
        else if (_options.ToolConfig.NamedMcpTools.Count == 0)
        {
            tasks.Add(_mcpTools.ListToolsAsync(existingNames, cancellationToken));
        }

        if (tasks.Count > 0)
        {
            var results = await Task.WhenAll(tasks).ConfigureAwait(false);

            foreach (var result in results)
            {
                tools.AddRange(result.Value);
            }
        }

        // Attach async invokers
        foreach (var tool in tools)
        {
            tool.Invoker = args => InvokeTool(tool, args, cancellationToken);
            tool.AsyncInvoker = async args =>
                await InvokeToolAsync(tool, args, cancellationToken).ConfigureAwait(false);
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

        var payload = arguments ?? new Dictionary<string, object?>();

        var response = tool.Source switch
        {
            ToolSource.McpTools => _mcpTools.InvokeTool(tool, payload, cancellationToken),
            ToolSource.RemoteTools => _remoteTools.InvokeTool(tool, payload, cancellationToken),
            _ => throw new InvalidOperationException($"Unsupported tool source: {tool.Source}")
        };

        return response.Value;
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

        var payload = arguments ?? new Dictionary<string, object?>();

        var response = tool.Source switch
        {
            ToolSource.McpTools => await _mcpTools.InvokeToolAsync(tool, payload, cancellationToken)
                .ConfigureAwait(false),
            ToolSource.RemoteTools => await _remoteTools.InvokeToolAsync(tool, payload, cancellationToken)
                .ConfigureAwait(false),
            _ => throw new InvalidOperationException($"Unsupported tool source: {tool.Source}")
        };

        return response.Value;
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

    private static Uri EnsureTrailingSlash(Uri endpoint)
    {
        var endpointText = endpoint.ToString();
        return endpointText.EndsWith("/", StringComparison.Ordinal)
            ? endpoint
            : new Uri(endpointText + "/");
    }

    void IDisposable.Dispose()
    {
        GC.SuppressFinalize(this);
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        await Task.CompletedTask.ConfigureAwait(false);
        GC.SuppressFinalize(this);
    }
}
