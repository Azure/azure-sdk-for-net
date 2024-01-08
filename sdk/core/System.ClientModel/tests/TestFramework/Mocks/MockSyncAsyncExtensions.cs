// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
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
}
