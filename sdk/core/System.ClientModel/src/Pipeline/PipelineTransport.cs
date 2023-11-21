// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal.Primitives;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

public abstract class PipelineTransport : PipelinePolicy, IDisposable
{
    public static PipelineTransport Create(HttpClient client)
        => new HttpClientPipelineTransport(client);

    /// <summary>
    /// TBD: needed for inheritdoc.
    /// </summary>
    /// <param name="message"></param>
    public abstract void Process(PipelineMessage message);

    /// <summary>
    /// TBD: needed for inheritdoc.
    /// </summary>
    /// <param name="message"></param>
    public abstract ValueTask ProcessAsync(PipelineMessage message);

    /// <summary>
    /// TBD: needed for inheritdoc.
    /// </summary>
    public abstract PipelineMessage CreateMessage();

    // These methods from PipelinePolicy just say "you've reached the end
    // of the line", i.e. they stop the invocation of the policy chain.
    public override void Process(PipelineMessage message, PipelineProcessor pipeline)
    {
        Debug.Assert(pipeline.Length == 0);

        Process(message);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, PipelineProcessor pipeline)
    {
        Debug.Assert(pipeline.Length == 0);

        await ProcessAsync(message).ConfigureAwait(false);
    }

    protected virtual void OnSendingRequest(PipelineMessage message) { }

    protected virtual void OnReceivedResponse(PipelineMessage message) { }

    /// <inheritdoc/>
    public abstract void Dispose();
}
