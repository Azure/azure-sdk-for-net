// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Models;

namespace Azure.AI.AgentServer.Core.Tools.Runtime.Invocation;

/// <summary>
/// Default implementation of <see cref="IFoundryToolInvoker"/> that wraps a resolved tool
/// and provides invocation capability through the tool client.
/// </summary>
public class DefaultFoundryToolInvoker : IFoundryToolInvoker
{
    private readonly FoundryToolClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultFoundryToolInvoker"/> class.
    /// </summary>
    /// <param name="resolvedTool">The resolved tool to invoke.</param>
    /// <param name="client">The Foundry tool client for executing tool invocations.</param>
    public DefaultFoundryToolInvoker(
        ResolvedFoundryTool resolvedTool,
        FoundryToolClient client)
    {
        ResolvedTool = resolvedTool ?? throw new ArgumentNullException(nameof(resolvedTool));
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    /// <summary>
    /// Gets the resolved tool definition associated with this invoker.
    /// </summary>
    public ResolvedFoundryTool ResolvedTool { get; }

    /// <summary>
    /// Invokes the tool with the given arguments.
    /// </summary>
    public async Task<object?> InvokeAsync(
        IDictionary<string, object?>? arguments = null,
        CancellationToken cancellationToken = default)
    {
        // Use the tool client to invoke the tool
        return await _client.InvokeToolAsync(
            ResolvedTool,
            arguments,
            cancellationToken).ConfigureAwait(false);
    }
}
