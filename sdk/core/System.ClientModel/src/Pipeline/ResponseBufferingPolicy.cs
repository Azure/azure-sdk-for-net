// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

/// <summary>
/// Pipeline policy to buffer response content or add a timeout to response content
/// managed by the client.
/// </summary>
public class ResponseBufferingPolicy : PipelinePolicy
{
    internal static readonly ResponseBufferingPolicy Default = new();

    public ResponseBufferingPolicy()
    {
    }

    public sealed override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        => ProcessSyncOrAsync(message, pipeline, currentIndex, async: false).EnsureCompleted();

    public sealed override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        => await ProcessSyncOrAsync(message, pipeline, currentIndex, async: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex, bool async)
    {
        if (async)
        {
            await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
        }
        else
        {
            ProcessNext(message, pipeline, currentIndex);
        }
    }

    /// <summary>Throws a cancellation exception if cancellation has been requested via <paramref name="originalToken"/> or <paramref name="timeoutToken"/>.</summary>
    /// <param name="originalToken">The customer provided token.</param>
    /// <param name="timeoutToken">The linked token that is cancelled on timeout provided token.</param>
    /// <param name="inner">The inner exception to use.</param>
    /// <param name="timeout">The timeout used for the operation.</param>
#pragma warning disable CA1068 // Cancellation token has to be the last parameter
    internal static void ThrowIfCancellationRequestedOrTimeout(CancellationToken originalToken, CancellationToken timeoutToken, Exception? inner, TimeSpan timeout)
#pragma warning restore CA1068
    {
        CancellationHelper.ThrowIfCancellationRequested(originalToken);

        if (timeoutToken.IsCancellationRequested)
        {
            throw CancellationHelper.CreateOperationCanceledException(
                inner,
                timeoutToken,
                $"The operation was cancelled because it exceeded the configured timeout of {timeout:g}. ");
        }
    }
}
