// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics;
using System.Reflection;

namespace OpenAI.TestFramework.Utils;

/// <summary>
/// Represents a retry policy to be used when testing clients.
/// </summary>
public class TestClientRetryPolicy : ClientRetryPolicy
{
    private Func<PipelineMessage, int> _getRetries;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestClientRetryPolicy"/> class.
    /// </summary>
    /// <param name="maxRetries">The maximum number of retries.</param>
    /// <param name="delay">The delay between retries.</param>
    /// <param name="exponentialDelay">Indicates whether the delay should be exponential.</param>
    public TestClientRetryPolicy(int maxRetries = Utils.Default.MaxRequestRetries, TimeSpan? delay = null, bool exponentialDelay = false)
        : base(maxRetries)
    {
        MaxRetries = MaxRetries;
        Delay = delay ?? Utils.Default.RequestRetryDelay;
        IsExponentialDelay = exponentialDelay;

        // Of course, even reading the number of retries property on the PipelineMessage is internal only.
        // So reflection it is
        _getRetries = (Func<PipelineMessage, int>)
            (typeof(PipelineMessage).GetProperty("RetryCount", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
            ?.GetGetMethod(true)
            ?.CreateDelegate(typeof(Func<PipelineMessage, int>))
            ?? throw new InvalidOperationException("Failed to get RetryCount property"));
    }

    /// <summary>
    /// Gets the maximum number of retries.
    /// </summary>
    public int MaxRetries { get; }

    /// <summary>
    /// Gets the delay between retries.
    /// </summary>
    public TimeSpan Delay { get; }

    /// <summary>
    /// Gets a value indicating whether the delay should be exponential.
    /// </summary>
    public bool IsExponentialDelay { get; }

    /// <inheritdoc />
    protected override TimeSpan GetNextDelay(PipelineMessage message, int tryCount)
    {
        TimeSpan delay = IsExponentialDelay
            ? TimeSpan.FromMilliseconds((1 << tryCount - 1) * Delay.TotalMilliseconds)
            : Delay;

        return delay;
    }

    /// <inheritdoc />
    protected override bool ShouldRetry(PipelineMessage message, Exception? exception)
    {
        if (_getRetries(message) >= MaxRetries)
        {
            return false;
        }

        if (!message.ResponseClassifier.TryClassify(message, exception, out bool isRetriable)
            && !PipelineMessageClassifier.Default.TryClassify(message, exception, out isRetriable))
        {
            Debug.Assert(false, "Failed to classify message");
        }

        return isRetriable;
    }

    /// <inheritdoc />
    protected override ValueTask<bool> ShouldRetryAsync(PipelineMessage message, Exception? exception)
        => new ValueTask<bool>(ShouldRetry(message, exception));
}
