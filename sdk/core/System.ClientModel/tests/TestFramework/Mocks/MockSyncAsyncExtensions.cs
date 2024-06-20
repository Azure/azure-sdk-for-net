// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ClientModel.Tests.Mocks;

public static class MockSyncAsyncExtensions
{
    public static async Task SendSyncOrAsync(this ClientPipeline pipeline, PipelineMessage message, bool isAsync)
    {
        if (isAsync)
        {
            await pipeline.SendAsync(message).ConfigureAwait(false);
        }
        else
        {
            pipeline.Send(message);
        }
    }

    public static async Task WriteToSyncOrAsync(this BinaryContent content, Stream stream, CancellationToken cancellationToken, bool isAsync)
    {
        if (isAsync)
        {
            await content.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
        }
        else
        {
            content.WriteTo(stream, cancellationToken);
        }
    }

    public static async Task ProcessSyncOrAsync(this PipelinePolicy policy, PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex, bool isAsync)
    {
        if (isAsync)
        {
            await policy.ProcessAsync(message, pipeline, currentIndex).ConfigureAwait(false);
        }
        else
        {
            policy.Process(message, pipeline, currentIndex);
        }
    }

    public static async Task ProcessNextSyncOrAsync(this MockPipelinePolicy policy, PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex, bool isAsync)
    {
        if (isAsync)
        {
            await policy.ProcessNextAsync(message, pipeline, currentIndex, isAsync).ConfigureAwait(false);
        }
        else
        {
            policy.ProcessNext(message, pipeline, currentIndex, isAsync);
        }
    }

    public static async Task ProcessSyncOrAsync(this HttpClientPipelineTransport transport, PipelineMessage message, bool isAsync)
    {
        if (isAsync)
        {
            await transport.ProcessAsync(message).ConfigureAwait(false);
        }
        else
        {
            transport.Process(message);
        }
    }

    public static async Task WaitSyncOrAsync(this MockRetryPolicy policy, TimeSpan delay, CancellationToken cancellationToken, bool isAsync)
    {
        if (isAsync)
        {
            await policy.DoWaitAsync(delay, cancellationToken).ConfigureAwait(false);
        }
        else
        {
            policy.DoWait(delay, cancellationToken);
        }
    }

    public static async Task<BinaryData> BufferContentSyncOrAsync(this PipelineResponse response, CancellationToken cancellationToken, bool isAsync)
    {
        if (isAsync)
        {
            return await response.BufferContentAsync(cancellationToken).ConfigureAwait(false);
        }
        else
        {
            return response.BufferContent(cancellationToken);
        }
    }
}
