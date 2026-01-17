// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Models;
using Azure.AI.AgentServer.Core.Tools.Runtime.User;

namespace Azure.AI.AgentServer.Core.Tools.Runtime.Catalog;

/// <summary>
/// Default implementation of <see cref="IFoundryToolCatalog"/> with TTL-based caching.
/// Uses <see cref="FoundryToolClient"/> to fetch tool metadata from Azure AI services.
/// </summary>
public class DefaultFoundryToolCatalog : CachedFoundryToolCatalog
{
    private readonly FoundryToolClient _client;
    private readonly IUserProvider? _userProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultFoundryToolCatalog"/> class.
    /// </summary>
    /// <param name="client">The Foundry tool client for fetching tool metadata.</param>
    /// <param name="userProvider">Optional user provider for resolving user context.</param>
    /// <param name="cacheTtl">
    /// The time-to-live for cached tool metadata. Defaults to 10 minutes (600 seconds).
    /// </param>
    /// <param name="maxCacheEntries">
    /// The maximum number of entries to cache. Defaults to 1024.
    /// </param>
    public DefaultFoundryToolCatalog(
        FoundryToolClient client,
        IUserProvider? userProvider = null,
        TimeSpan? cacheTtl = null,
        long maxCacheEntries = 1024)
        : base(cacheTtl, maxCacheEntries)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _userProvider = userProvider;
    }

    /// <summary>
    /// Fetches tool metadata from Azure AI services using the Foundry tool client.
    /// </summary>
    protected override async Task<IReadOnlyDictionary<FoundryTool, ResolvedFoundryTool?>> FetchToolsAsync(
        IReadOnlyList<FoundryTool> tools,
        UserInfo? userInfo,
        CancellationToken cancellationToken)
    {
        // For now, we'll use the client's ListToolsAsync method which fetches all tools
        // This is not optimal for single-tool lookups, but matches current behavior
        // TODO: In future, add granular fetch APIs to FoundryToolClient operations
        var allTools = await _client.ListToolsAsync(cancellationToken).ConfigureAwait(false);

        // Map requested tools to resolved tools
        var results = new Dictionary<FoundryTool, ResolvedFoundryTool?>();

        foreach (var requestedTool in tools)
        {
            // Match by tool definition
            var resolved = allTools.FirstOrDefault(t => ToolMatches(t, requestedTool));
            results[requestedTool] = resolved;
        }

        return results;
    }

    /// <summary>
    /// Gets the user context for the current request from the user provider.
    /// </summary>
    protected override async Task<UserInfo?> GetUserContextAsync(CancellationToken cancellationToken)
    {
        if (_userProvider == null)
        {
            return null;
        }

        return await _userProvider.GetUserAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Determines if a resolved tool matches a requested tool definition.
    /// </summary>
    private static bool ToolMatches(ResolvedFoundryTool resolved, FoundryTool requested)
    {
        // Match by comparing the tool definitions
        if (resolved.Definition == null)
        {
            return false;
        }

        // For hosted MCP tools, match by name
        if (requested is FoundryHostedMcpTool hostedMcp &&
            resolved.Definition is FoundryHostedMcpTool resolvedHostedMcp)
        {
            return string.Equals(
                hostedMcp.Name,
                resolvedHostedMcp.Name,
                StringComparison.OrdinalIgnoreCase);
        }

        // For connected tools, match by protocol and connection ID
        if (requested is FoundryConnectedTool connected &&
            resolved.Definition is FoundryConnectedTool resolvedConnected)
        {
            return connected.Protocol == resolvedConnected.Protocol &&
                   string.Equals(
                       connected.ProjectConnectionId,
                       resolvedConnected.ProjectConnectionId,
                       StringComparison.OrdinalIgnoreCase);
        }

        return false;
    }
}
