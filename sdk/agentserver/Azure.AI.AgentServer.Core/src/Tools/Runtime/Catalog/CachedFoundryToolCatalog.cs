// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    private readonly SemaphoreSlim _cacheLock;

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
        _cacheLock = new SemaphoreSlim(1, 1);
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
        ArgumentNullException.ThrowIfNull(tools);

        var foundryTools = tools.Select(FoundryToolFactory.Create).ToList();
        if (foundryTools.Count == 0)
        {
            return Array.Empty<ResolvedFoundryTool>();
        }

        // Get user context for cache key generation
        var userInfo = await GetUserContextAsync(cancellationToken).ConfigureAwait(false);

        var resolvingTasks = new Dictionary<string, Task<IReadOnlyList<FoundryToolDetails>>>(StringComparer.Ordinal);
        var toolsToFetch = new Dictionary<object, FoundryTool>();

        foreach (var tool in foundryTools)
        {
            var cacheKey = GetCacheKey(userInfo, tool);

            if (_cache.TryGetValue<Task<IReadOnlyList<FoundryToolDetails>>>(cacheKey, out var cachedTask) &&
                cachedTask != null)
            {
                resolvingTasks[tool.Id] = cachedTask;
            }
            else
            {
                toolsToFetch[cacheKey] = tool;
            }
        }

        var createdTasks = new Dictionary<object, FoundryTool>();
        if (toolsToFetch.Count > 0)
        {
            using (await AcquireCacheLockAsync(_cacheLock, cancellationToken).ConfigureAwait(false))
            {
                foreach (var (cacheKey, tool) in toolsToFetch)
                {
                    if (_cache.TryGetValue<Task<IReadOnlyList<FoundryToolDetails>>>(cacheKey, out var cachedTask) &&
                        cachedTask != null)
                    {
                        resolvingTasks[tool.Id] = cachedTask;
                    }
                    else
                    {
                        createdTasks[cacheKey] = tool;
                    }
                }

                if (createdTasks.Count > 0)
                {
                    var fetchTask = FetchToolsAsync(createdTasks.Values.ToList(), userInfo, cancellationToken);
                    foreach (var (cacheKey, tool) in createdTasks)
                    {
                        var resolvingTask = ResolveToolDetailsAsync(tool.Id, fetchTask);
                        resolvingTasks[tool.Id] = resolvingTask;

                        _ = _cache.Set(cacheKey, resolvingTask, new MemoryCacheEntryOptions
                        {
                            AbsoluteExpirationRelativeToNow = _cacheTtl,
                            Size = 1
                        });
                    }
                }
            }
        }

        if (resolvingTasks.Count == 0)
        {
            return Array.Empty<ResolvedFoundryTool>();
        }

        try
        {
            await Task.WhenAll(resolvingTasks.Values).WaitAsync(cancellationToken).ConfigureAwait(false);
        }
        catch
        {
            foreach (var cacheKey in createdTasks.Keys)
            {
                _cache.Remove(cacheKey);
            }

            throw;
        }

        var resolvedTools = new List<ResolvedFoundryTool>();
        foreach (var tool in foundryTools)
        {
            if (!resolvingTasks.TryGetValue(tool.Id, out var resolvingTask))
            {
                continue;
            }

            var detailsList = await resolvingTask.ConfigureAwait(false);
            foreach (var details in detailsList)
            {
                resolvedTools.Add(new ResolvedFoundryTool
                {
                    Definition = tool,
                    Details = details
                });
            }
        }

        return resolvedTools;
    }

    /// <summary>
    /// Fetches tool details from the underlying source.
    /// Derived classes must implement this method to provide the actual tool data.
    /// </summary>
    /// <param name="tools">The tools to fetch.</param>
    /// <param name="userInfo">The user context for fetching tools (used for connected tools).</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// A dictionary mapping each tool Id to its resolved details.
    /// Tools that could not be resolved should be omitted.
    /// </returns>
    protected abstract Task<IReadOnlyDictionary<string, IReadOnlyList<FoundryToolDetails>>> FetchToolsAsync(
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
        var toolKey = tool.Id;
        return tool.Source == FoundryToolSource.HOSTED_MCP
            ? toolKey // Global cache for hosted MCP
            : (userInfo, toolKey); // Per-user cache for connected tools
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
            _cacheLock.Dispose();
        }
    }

    private static async Task<IReadOnlyList<FoundryToolDetails>> ResolveToolDetailsAsync(
        string toolId,
        Task<IReadOnlyDictionary<string, IReadOnlyList<FoundryToolDetails>>> fetchTask)
    {
        var fetched = await fetchTask.ConfigureAwait(false);
        return fetched.TryGetValue(toolId, out var details)
            ? details
            : Array.Empty<FoundryToolDetails>();
    }

    private static async Task<IDisposable> AcquireCacheLockAsync(
        SemaphoreSlim semaphore,
        CancellationToken cancellationToken)
    {
        await semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        return new SemaphoreReleaser(semaphore);
    }

    private sealed class SemaphoreReleaser : IDisposable
    {
        private SemaphoreSlim? _semaphore;

        public SemaphoreReleaser(SemaphoreSlim semaphore)
        {
            _semaphore = semaphore ?? throw new ArgumentNullException(nameof(semaphore));
        }

        public void Dispose()
        {
            var semaphore = Interlocked.Exchange(ref _semaphore, null);
            if (semaphore != null)
            {
                semaphore.Release();
            }
        }
    }
}
