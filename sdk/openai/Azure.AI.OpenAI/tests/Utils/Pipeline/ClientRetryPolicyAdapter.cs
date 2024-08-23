// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;

namespace Azure.AI.OpenAI.Tests.Utils.Pipeline;

public class ClientRetryPolicyAdapter : ClientRetryPolicy
{
    private Func<PipelineMessage, int> _getRetries;

    public ClientRetryPolicyAdapter(Core.RetryOptions options)
        : base(options?.MaxRetries ?? 3)
    {
        Original = options ?? throw new ArgumentNullException(nameof(options));

        // Of course, even reading the number of retries property on the PipelineMessage is internal only.
        // So reflection it is
        _getRetries = (Func<PipelineMessage, int>)
            (typeof(PipelineMessage).GetProperty("RetryCount", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
            ?.GetGetMethod(true)
            ?.CreateDelegate(typeof(Func<PipelineMessage, int>))
            ?? throw new InvalidOperationException("Failed to get RetryCount property"));
    }

    public Core.RetryOptions Original { get; }

    protected override TimeSpan GetNextDelay(PipelineMessage message, int tryCount)
    {
        TimeSpan delay = Original.Mode switch
        {
            Core.RetryMode.Fixed => Original.Delay,
            Core.RetryMode.Exponential => TimeSpan.FromMilliseconds((1 << tryCount - 1) * Original.Delay.TotalMilliseconds),
            _ => throw new InvalidOperationException("Unknown retry mode")
        };

        return delay <= Original.MaxDelay ? delay : Original.MaxDelay;
    }

    protected override bool ShouldRetry(PipelineMessage message, Exception exception)
    {
        if (_getRetries(message) >= Original.MaxRetries)
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

    protected override ValueTask<bool> ShouldRetryAsync(PipelineMessage message, Exception exception)
        => new ValueTask<bool>(ShouldRetry(message, exception));
}
