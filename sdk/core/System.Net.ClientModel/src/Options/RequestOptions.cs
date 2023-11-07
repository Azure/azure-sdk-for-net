// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel.Core;
using System.Threading;

namespace System.Net.ClientModel;

/// <summary>
/// Controls the end-to-end duration of the service method call, including
/// the message being sent down the pipeline.  For the duration of pipeline.Send,
/// this may change some behaviors in various pipeline policies and the transport.
/// </summary>
public class RequestOptions
{
    private MessagePipeline? _requestPipeline;

    public RequestOptions() : this(new PipelineOptions())
    {
    }

    public RequestOptions(PipelineOptions pipelineOptions)
    {
        PipelineOptions = pipelineOptions;
        ErrorBehavior = ErrorBehavior.Default;
        CancellationToken = CancellationToken.None;
    }

    protected internal virtual void Apply(ClientMessage message)
    {
        // Wire up options on message
        message.CancellationToken = CancellationToken;
        message.MessageClassifier = PipelineOptions.MessageClassifier ?? MessageClassifier.Default;

        // TODO: note that this is a lot of *ways* to set values on the
        // message, policy, etc.  Let's get clear on how many ways we need and why
        // and when we use what, etc., then simplify it back to that per reasons.
        if (PipelineOptions.NetworkTimeout.HasValue)
        {
            ResponseBufferingPolicy.SetNetworkTimeout(message, PipelineOptions.NetworkTimeout.Value);
        }
    }

    public PipelineOptions PipelineOptions { get; }

    public virtual ErrorBehavior ErrorBehavior { get; set; }

    public virtual CancellationToken CancellationToken { get; set; }

    public MessagePipeline GetPipeline()
    {
        if (_requestPipeline is not null)
        {
            return _requestPipeline;
        }

        // TODO: what is the logic where we set _requestPipeline to cache it?
        _requestPipeline = default;

        return PipelineOptions.GetPipeline();
    }
}
