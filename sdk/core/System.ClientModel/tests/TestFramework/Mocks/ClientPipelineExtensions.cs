// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace ClientModel.Tests.Mocks;

public static class ClientPipelineExtensions
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
}
