// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
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

    public static async Task WaitSyncOrAsync(this PipelineMessageDelay delay, PipelineMessage message, bool isAsync)
    {
        if (isAsync)
        {
            await delay.WaitAsync(message, default).ConfigureAwait(false);
        }
        else
        {
            delay.Wait(message, default);
        }
    }
}
