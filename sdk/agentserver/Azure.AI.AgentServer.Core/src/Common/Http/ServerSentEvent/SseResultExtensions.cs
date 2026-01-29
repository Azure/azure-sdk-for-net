// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;

using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Core.Common.Http.ServerSentEvent;

/// <summary>
/// Provides extension methods for creating Server-Sent Events results.
/// </summary>
public static class SseResultExtensions
{
    /// <summary>
    /// Converts an async enumerable source to an SSE result with frame transformation.
    /// </summary>
    /// <typeparam name="T">The type of items in the source sequence.</typeparam>
    /// <param name="source">The source async enumerable.</param>
    /// <param name="frameTransformer">Function to transform source items to SSE frames.</param>
    /// <param name="logger">Logger for diagnostic information.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <param name="keepAliveInterval">Optional keep-alive interval.</param>
    /// <returns>An SSE result that can be returned from an endpoint.</returns>
    public static SseResult ToSseResult<T>(this IAsyncEnumerable<T> source, Func<T, SseFrame> frameTransformer,
        ILogger logger,
        CancellationToken ct = default,
        TimeSpan? keepAliveInterval = null)
    {
        var frames = TransformToSseFrames(source, frameTransformer, logger, ct);
        return new SseResult(frames, keepAliveInterval);
    }

    private static async IAsyncEnumerable<SseFrame> TransformToSseFrames<T>(this IAsyncEnumerable<T> source,
        Func<T, SseFrame> frameTransformer,
        ILogger logger,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await foreach (var item in source.WithCancellation(ct))
        {
            yield return frameTransformer(item);
        }
        logger.LogInformation("Completed streaming response.");
    }
}
