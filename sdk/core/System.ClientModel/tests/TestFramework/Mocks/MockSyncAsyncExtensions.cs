// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

    public static async Task DelaySyncOrAsync(this MessageDelay delay, PipelineMessage message, bool isAsync)
    {
        if (isAsync)
        {
            await delay.DelayAsync(message, default).ConfigureAwait(false);
        }
        else
        {
            delay.Delay(message, default);
        }
    }
}
