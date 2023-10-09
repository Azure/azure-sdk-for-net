// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ServiceModel.Rest.Core;
using System.Threading;

namespace System.ServiceModel.Rest;

/// <summary>
/// Controls the end-to-end duration of the service method call, including
/// the message being sent down the pipeline.  For the duration of pipeline.Send,
/// this may change some behaviors in various pipeline policies and the transport.
/// </summary>
// TODO: Make options freezable
// TODO: This was RequestOptions, I'm changing it for now, we can change it back if
// if we want.
public class InvocationOptions
{
    // Default is yes, buffer the response.
    private bool _bufferResponse = true;

    public virtual ErrorBehavior ErrorBehavior { get; set; } = ErrorBehavior.Default;

    // Moving CancellationToken here because it's needed for Pipeline.Send
    public virtual CancellationToken CancellationToken { get; set; } = DefaultCancellationToken;

    public virtual ResponseErrorClassifier ResponseClassifier { get; set; } = DefaultResponseClassifier;

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
    public virtual bool BufferResponse
    {
        get => _bufferResponse;
        set => _bufferResponse = value;
    }

    public virtual TimeSpan? NetworkTimeout { get; set; }

    #endregion

    public static CancellationToken DefaultCancellationToken { get; set; } = CancellationToken.None;

    public static ResponseErrorClassifier DefaultResponseClassifier { get; set; } = new ResponseErrorClassifier();
}
