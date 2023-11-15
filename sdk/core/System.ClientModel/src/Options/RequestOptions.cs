// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;

namespace System.ClientModel;

/// <summary>
/// Controls the end-to-end duration of the service method call, including
/// the message being sent down the pipeline.  For the duration of pipeline.Send,
/// this may change some behaviors in various pipeline policies and the transport.
/// </summary>
// TODO: Make options freezable
// Note: I was calling this RequestOptions, but I'm changing it back to RequestOptions.
public class RequestOptions : PipelineOptions
{
    public RequestOptions()
    {
        RequestHeaders = new PipelineRequestHeaders();
    }

    public virtual void Apply(PipelineMessage message)
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

        // Add headers to message
        // TODO: improve this implementation
        // TODO: Add tests for this - that it adds all headers, including ones whose values aren't collections
        RequestHeaders.TryGetHeaders(out IEnumerable<KeyValuePair<string, string>> headers);
        foreach (var header in headers)
        {
            message.Request.Headers.Add(header.Key, header.Value);
        }
    }

    public virtual MessageHeaders RequestHeaders { get; }

    public virtual ErrorBehavior ErrorBehavior { get; set; } = ErrorBehavior.Default;

    // TODO: handle duplication across message and options

    public virtual CancellationToken CancellationToken { get; set; } = CancellationToken.None;

    #region Transport options - TODO: move to a subtype type?

    // TODO: Can we throw if someone gives us Transport options and transport isn't
    // in the pipeline?

    // TODO: do these (buffer response and network timeout) make more sense in
    // Invocation or Pipeline?
    // Note: right now invocation is about things that have broader scope than
    // just the pipeline.Send operation, but pipeline.Send is part of the invocation.

    // TODO: note that these pre-suppose that the response buffering policy is
    // present in the pipeline, and if they are not, they don't make sense to have.
    // We could feasibly add validation in the new libraries to tell people they've
    // set options the pipeline might not use, or back in required policies in the
    // pipeline, or somehow engineer it such that construction and invocation options
    // work together to make it so people can't do the wrong thing.

    #endregion
}
