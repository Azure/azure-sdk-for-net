// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Runtime;

namespace Azure.AI.AgentServer.Core.Server;

/// <summary>
/// Provides singleton access to application-level services and context.
/// This context is initialized once at application startup and provides
/// access to shared resources like the tool runtime.
/// </summary>
public sealed class AgentServerContext : IAsyncDisposable
{
    private static AgentServerContext? _instance;
    private static readonly object _lock = new();
    private readonly IFoundryToolRuntime _toolRuntime;

    /// <summary>
    /// Initializes a new instance of the <see cref="AgentServerContext"/> class.
    /// </summary>
    /// <param name="toolRuntime">The tool runtime for accessing and invoking tools.</param>
    internal AgentServerContext(IFoundryToolRuntime toolRuntime)
    {
        _toolRuntime = toolRuntime ?? throw new ArgumentNullException(nameof(toolRuntime));

        lock (_lock)
        {
            _instance = this;
        }
    }

    /// <summary>
    /// Gets the singleton instance of the agent server context.
    /// </summary>
    /// <returns>The current agent server context instance.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the context has not been initialized.
    /// This typically means AgentServerApplication.RunAsync has not been called.
    /// </exception>
    public static AgentServerContext Get()
    {
        lock (_lock)
        {
            return _instance ?? throw new InvalidOperationException(
                "AgentServerContext has not been initialized. " +
                "Ensure AgentServerApplication.RunAsync is called before accessing the context.");
        }
    }

    /// <summary>
    /// Gets the tool runtime for accessing and invoking Foundry tools.
    /// </summary>
    public IFoundryToolRuntime Tools => _toolRuntime;

    /// <summary>
    /// Disposes the agent server context and its resources.
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        if (_toolRuntime != null)
        {
            await _toolRuntime.DisposeAsync().ConfigureAwait(false);
        }

        lock (_lock)
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }
    }
}
