// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using Azure.AI.AgentServer.Core.Tools.Models;
using Azure.AI.AgentServer.Core.Tools.Runtime.Facade;
using Microsoft.Extensions.Caching.Memory;

namespace Azure.AI.AgentServer.Core.Tools.Runtime.Catalog;

/// <summary>
/// Base implementation of <see cref="IFoundryToolCatalog"/> with TTL-based caching.
/// Provides concurrency-safe tool metadata caching to optimize repeated tool lookups.
/// </summary>
public abstract class CachedFoundryToolCatalog : IFoundryToolCatalog, IDisposable
{
    private readonly IMemoryCache _cache;
    private readonly TimeSpan _cacheTtl;
    private readonly ConcurrentDictionary<object, SemaphoreSlim> _fetchLocks;

    /// <summary>
    /// Initializes a new instance of the <see cref="CachedFoundryToolCatalog"/> class.
    /// </summary>
    /// <param name="cacheTtl">
    /// The time-to-live for cached tool metadata. Defaults to 10 minutes (600 seconds).
    /// </param>
    /// <param name="maxCacheEntries">
    /// The maximum number of entries to cache. Defaults to 1024.
    /// </param>
    protected CachedFoundryToolCatalog(
        TimeSpan? cacheTtl = null,
        long maxCacheEntries = 1024)
    {
        _cacheTtl = cacheTtl ?? TimeSpan.FromMinutes(10);
        _cache = new MemoryCache(new MemoryCacheOptions
        {
            SizeLimit = maxCacheEntries
        });
        _fetchLocks = new ConcurrentDictionary<object, SemaphoreSlim>();
    }

    /// <summary>
    /// Gets a single resolved tool by its definition.
    /// </summary>
    public async Task<ResolvedFoundryTool?> GetAsync(
        object tool,
        CancellationToken cancellationToken = default)
    {
        var tools = await ListAsync(new[] { tool }, cancellationToken).ConfigureAwait(false);
        return tools.FirstOrDefault();
    }

    /// <summary>
    /// Lists multiple resolved tools by their definitions.
    /// Uses Task-based deduplication to prevent concurrent fetches of the same tool.
    /// </summary>
    public async Task<IReadOnlyList<ResolvedFoundryTool>> ListAsync(
        IEnumerable<object> tools,
        CancellationToken cancellationToken = default)
    {
        var foundryTools = tools.Select(FoundryToolFactory.Create).ToList();

        // Get user context for cache key generation
        var userInfo = await GetUserContextAsync(cancellationToken).ConfigureAwait(false);

        // Separate cached vs uncached tools
        var cachedResults = new Dictionary<FoundryTool, ResolvedFoundryTool>();
        var toolsToFetch = new List<FoundryTool>();

        foreach (var tool in foundryTools)
        {
            var cacheKey = GetCacheKey(userInfo, tool);

            if (_cache.TryGetValue<ResolvedFoundryTool>(cacheKey, out var cachedTool) && cachedTool != null)
            {
                cachedResults[tool] = cachedTool;
            }
            else
            {
                toolsToFetch.Add(tool);
            }
        }

        // If all tools are cached, return immediately
        if (toolsToFetch.Count == 0)
        {
            return cachedResults.Values.ToList();
        }

        // Fetch uncached tools with concurrency control
        var fetchedResults = await FetchAndCacheToolsAsync(
            toolsToFetch,
            userInfo,
            cancellationToken).ConfigureAwait(false);

        // Combine cached and fetched results, preserving order
        var results = new List<ResolvedFoundryTool>();
        foreach (var tool in foundryTools)
        {
            if (cachedResults.TryGetValue(tool, out var cachedTool))
            {
                results.Add(cachedTool);
            }
            else if (fetchedResults.TryGetValue(tool, out var fetchedTool))
            {
                results.Add(fetchedTool);
            }
        }

        return results;
    }

    /// <summary>
    /// Fetches tools from the underlying source and caches the results.
    /// Uses per-tool locking to prevent concurrent fetches of the same tool.
    /// </summary>
    private async Task<Dictionary<FoundryTool, ResolvedFoundryTool>> FetchAndCacheToolsAsync(
        IReadOnlyList<FoundryTool> tools,
        UserInfo? userInfo,
        CancellationToken cancellationToken)
    {
        var results = new Dictionary<FoundryTool, ResolvedFoundryTool>();

        // Group tools by whether they need locking (to prevent duplicate fetches)
        foreach (var tool in tools)
        {
            var cacheKey = GetCacheKey(userInfo, tool);
            var lockKey = cacheKey;

            // Get or create a semaphore for this cache key
            var semaphore = _fetchLocks.GetOrAdd(lockKey, _ => new SemaphoreSlim(1, 1));

            await semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                // Double-check cache after acquiring lock
                if (_cache.TryGetValue<ResolvedFoundryTool>(cacheKey, out var cachedTool) && cachedTool != null)
                {
                    results[tool] = cachedTool;
                    continue;
                }

                // Fetch from underlying source (batch fetch for efficiency)
                var fetchedTools = await FetchToolsAsync(new[] { tool }, userInfo, cancellationToken)
                    .ConfigureAwait(false);

                if (fetchedTools.TryGetValue(tool, out var resolvedTool) && resolvedTool != null)
                {
                    // Cache the result
                    _cache.Set(cacheKey, resolvedTool, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = _cacheTtl,
                        Size = 1
                    });

                    results[tool] = resolvedTool;
                }
            }
            finally
            {
                semaphore.Release();

                // Clean up semaphore if no longer needed
                if (semaphore.CurrentCount == 1)
                {
                    _fetchLocks.TryRemove(lockKey, out _);
                }
            }
        }

        return results;
    }

    /// <summary>
    /// Fetches tool metadata from the underlying source.
    /// Derived classes must implement this method to provide the actual tool data.
    /// </summary>
    /// <param name="tools">The tools to fetch.</param>
    /// <param name="userInfo">The user context for fetching tools (used for connected tools).</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// A dictionary mapping each tool to its resolved metadata.
    /// Tools that could not be resolved should have null values.
    /// </returns>
    protected abstract Task<IReadOnlyDictionary<FoundryTool, ResolvedFoundryTool?>> FetchToolsAsync(
        IReadOnlyList<FoundryTool> tools,
        UserInfo? userInfo,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets the user context for the current request.
    /// Derived classes may override this to provide custom user resolution.
    /// Default implementation returns null.
    /// </summary>
    protected virtual Task<UserInfo?> GetUserContextAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult<UserInfo?>(null);
    }

    /// <summary>
    /// Generates a cache key for a tool.
    /// Hosted MCP tools use a global cache key (tool only).
    /// Connected tools use a per-user cache key (user + tool).
    /// </summary>
    private object GetCacheKey(UserInfo? userInfo, FoundryTool tool)
    {
        return tool.Source == FoundryToolSource.HOSTED_MCP
            ? (object)tool // Global cache for hosted MCP
            : (userInfo, tool); // Per-user cache for connected tools
    }

    /// <summary>
    /// Clears all cached tool metadata.
    /// Useful for testing or manual cache invalidation.
    /// </summary>
    public void ClearCache()
    {
        if (_cache is MemoryCache memoryCache)
        {
            memoryCache.Compact(1.0); // Compact 100% = clear all
        }
    }

    /// <summary>
    /// Disposes the catalog and releases resources.
    /// </summary>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Disposes the catalog and releases resources.
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _cache?.Dispose();

            foreach (var semaphore in _fetchLocks.Values)
            {
                semaphore?.Dispose();
            }

            _fetchLocks.Clear();
        }
    }
}
