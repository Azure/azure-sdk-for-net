using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Core.Common;

/// <summary>
/// Provides a singleton implementation of <see cref="IOptionsMonitor{TOptions}"/> that always returns the same options instance.
/// </summary>
/// <typeparam name="TOptions">The type of options being monitored.</typeparam>
/// <param name="options">The options instance to return.</param>
public class SingletonOptionsMonitor<TOptions>(TOptions options) : IOptionsMonitor<TOptions>, IOptionsSnapshot<TOptions>
    where TOptions : class
{
    /// <summary>
    /// Gets the options instance with the specified name.
    /// </summary>
    /// <param name="name">The name of the options instance (ignored in this implementation).</param>
    /// <returns>The configured options instance.</returns>
    public TOptions Get(string? name) => this.CurrentValue;

    /// <summary>
    /// Registers a change listener (no-op in this implementation).
    /// </summary>
    /// <param name="listener">The listener to register.</param>
    /// <returns>A disposable object that represents the registration (no-op).</returns>
    public IDisposable? OnChange(Action<TOptions, string?> listener)
    {
        return NoopChangeNotification.Instance;
    }

    /// <summary>
    /// Gets the current options value.
    /// </summary>
    public TOptions CurrentValue { get; } = options;

    /// <summary>
    /// Gets the options value.
    /// </summary>
    public TOptions Value => this.CurrentValue;

    private sealed class NoopChangeNotification : IDisposable
    {
        private NoopChangeNotification()
        {
        }

        public static NoopChangeNotification Instance { get; } = new();

        public void Dispose()
        {
        }
    }
}
