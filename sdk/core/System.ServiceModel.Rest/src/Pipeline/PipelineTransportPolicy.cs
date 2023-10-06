// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core.Pipeline;

internal class MessagePipelineTransportPolicy : PipelinePolicy
{
    private readonly MessagePipelineTransport _transport;

    public MessagePipelineTransportPolicy(MessagePipelineTransport transport)
    {
        _transport = transport;
    }

    public override void Process(PipelineMessage message, ReadOnlyMemory<PipelinePolicy> pipeline)
    {
        Debug.Assert(pipeline.Length == 0);

        _transport.Process(message);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, ReadOnlyMemory<PipelinePolicy> pipeline)
    {
        Debug.Assert(pipeline.Length == 0);

        await _transport.ProcessAsync(message).ConfigureAwait(false);
    }
}
