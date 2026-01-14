// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.AI.AgentServer.Core.Tools.Runtime.Catalog;
using Azure.AI.AgentServer.Core.Tools.Runtime.Invocation;
using Azure.AI.AgentServer.Core.Tools.Runtime.User;

namespace Azure.AI.AgentServer.Core.Tools.Runtime;

/// <summary>
/// Default implementation of <see cref="IFoundryToolRuntime"/> that provides
/// access to tool catalog and invocation capabilities with caching.
/// </summary>
public class FoundryToolRuntime : IFoundryToolRuntime
{
    private readonly FoundryToolClient _client;
    private readonly IFoundryToolCatalog _catalog;
    private readonly IFoundryToolInvocationResolver _invocation;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="FoundryToolRuntime"/> class.
    /// </summary>
    /// <param name="endpoint">The Azure AI endpoint URL.</param>
    /// <param name="credential">The token credential for authentication.</param>
    /// <param name="options">Optional client options.</param>
    /// <param name="userProvider">Optional user provider for resolving user context.</param>
    /// <param name="cacheTtl">Optional cache TTL for tool metadata. Defaults to 10 minutes.</param>
    public FoundryToolRuntime(
        Uri endpoint,
        TokenCredential credential,
        FoundryToolClientOptions? options = null,
        IUserProvider? userProvider = null,
        TimeSpan? cacheTtl = null)
    {
        ArgumentNullException.ThrowIfNull(endpoint);
        ArgumentNullException.ThrowIfNull(credential);

        // Create the tool client
        _client = new FoundryToolClient(endpoint, credential, options);

        // Create the catalog with caching
        _catalog = new DefaultFoundryToolCatalog(
            _client,
            userProvider,
            cacheTtl);

        // Create the invocation resolver
        _invocation = new DefaultFoundryToolInvocationResolver(_catalog, _client);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FoundryToolRuntime"/> class
    /// with custom catalog and invocation resolver.
    /// </summary>
    /// <param name="client">The Foundry tool client.</param>
    /// <param name="catalog">The tool catalog.</param>
    /// <param name="invocation">The tool invocation resolver.</param>
    public FoundryToolRuntime(
        FoundryToolClient client,
        IFoundryToolCatalog catalog,
        IFoundryToolInvocationResolver invocation)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
        _invocation = invocation ?? throw new ArgumentNullException(nameof(invocation));
    }

    /// <summary>
    /// Gets the tool catalog for listing and resolving tools.
    /// </summary>
    public IFoundryToolCatalog Catalog => _catalog;

    /// <summary>
    /// Gets the tool invocation resolver for invoking tools.
    /// </summary>
    public IFoundryToolInvocationResolver Invocation => _invocation;

    /// <summary>
    /// Convenience method to invoke a tool directly by its definition.
    /// </summary>
    public async Task<object?> InvokeAsync(
        object tool,
        IDictionary<string, object?>? arguments = null,
        CancellationToken cancellationToken = default)
    {
        var invoker = await _invocation.ResolveAsync(tool, cancellationToken).ConfigureAwait(false);
        return await invoker.InvokeAsync(arguments, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Disposes the runtime and releases resources.
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        if (_disposed)
        {
            return;
        }

        // Dispose catalog if it's disposable
        if (_catalog is IDisposable disposableCatalog)
        {
            disposableCatalog.Dispose();
        }
        else if (_catalog is IAsyncDisposable asyncDisposableCatalog)
        {
            await asyncDisposableCatalog.DisposeAsync().ConfigureAwait(false);
        }

        // Dispose client
        if (_client is IAsyncDisposable asyncDisposableClient)
        {
            await asyncDisposableClient.DisposeAsync().ConfigureAwait(false);
        }
        else if (_client is IDisposable disposableClient)
        {
            disposableClient.Dispose();
        }

        _disposed = true;
    }
}
