// <copyright file="SseResultExtensions.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

using System.Runtime.CompilerServices;

using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Core.Common.Http.ServerSentEvent;

public static class SseResultExtensions
{
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
