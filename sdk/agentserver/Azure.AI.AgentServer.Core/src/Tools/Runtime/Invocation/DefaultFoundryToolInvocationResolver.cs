// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Runtime.Catalog;

namespace Azure.AI.AgentServer.Core.Tools.Runtime.Invocation;

/// <summary>
/// Default implementation of <see cref="IFoundryToolInvocationResolver"/> that uses
/// a tool catalog to resolve tools and creates invokers.
/// </summary>
public class DefaultFoundryToolInvocationResolver : IFoundryToolInvocationResolver
{
    private readonly IFoundryToolCatalog _catalog;
    private readonly FoundryToolClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultFoundryToolInvocationResolver"/> class.
    /// </summary>
    /// <param name="catalog">The tool catalog for resolving tool metadata.</param>
    /// <param name="client">The Foundry tool client for executing tool invocations.</param>
    public DefaultFoundryToolInvocationResolver(
        IFoundryToolCatalog catalog,
        FoundryToolClient client)
    {
        _catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    /// <summary>
    /// Resolves a tool definition to an invoker capable of executing it.
    /// </summary>
    public async Task<IFoundryToolInvoker> ResolveAsync(
        object tool,
        CancellationToken cancellationToken = default)
    {
        // Use the catalog to resolve the tool
        var resolvedTool = await _catalog.GetAsync(tool, cancellationToken).ConfigureAwait(false);

        if (resolvedTool == null)
        {
            throw new InvalidOperationException(
                $"Unable to resolve tool invocation for tool: {tool}. " +
                "The tool may not be configured or accessible.");
        }

        // Create an invoker for the resolved tool
        return new DefaultFoundryToolInvoker(resolvedTool, _client);
    }
}
