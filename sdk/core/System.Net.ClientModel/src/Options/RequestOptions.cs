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
// TODO: Make options freezable
public class RequestOptions : PipelineOptions
{
    public RequestOptions()
    {
        ErrorBehavior = ErrorBehavior.Default;
        CancellationToken = CancellationToken.None;
    }

    public virtual void Apply(ClientMessage message)
    {
        // Wire up options on message
        message.CancellationToken = CancellationToken;
        message.MessageClassifier = MessageClassifier ?? MessageClassifier.Default;

        // TODO: note that this is a lot of *ways* to set values on the
        // message, policy, etc.  Let's get clear on how many ways we need and why
        // and when we use what, etc., then simplify it back to that per reasons.
        if (NetworkTimeout.HasValue)
        {
            ResponseBufferingPolicy.SetNetworkTimeout(message, NetworkTimeout.Value);
        }
    }

    public virtual ErrorBehavior ErrorBehavior { get; set; }

    public virtual CancellationToken CancellationToken { get; set; }
}
