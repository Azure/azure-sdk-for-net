// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace ClientModel.Tests.Mocks;

public class MockRetryPolicy : ClientRetryPolicy
{
    public MockRetryPolicy() : this(3, new MockMessageDelay())
    {
    }

    public MockRetryPolicy(int maxRetries, PipelineMessageDelay delay)
        : base(maxRetries, delay)
    {
    }

    public Exception? LastException {  get; private set; }

    public bool ShouldRetryCalled { get; private set; }

    public bool OnRequestSentCalled {  get; private set; }

    public bool OnSendingRequestCalled { get; private set; }

    public void Reset()
    {
        LastException = null;

        ShouldRetryCalled = false;
        OnSendingRequestCalled = false;
        OnRequestSentCalled = false;
    }

    protected override bool ShouldRetryCore(PipelineMessage message, Exception? exception)
    {
        ShouldRetryCalled = true;
        LastException = exception;

        return base.ShouldRetryCore(message, exception);
    }

    protected override ValueTask<bool> ShouldRetryCoreAsync(PipelineMessage message, Exception? exception)
    {
        ShouldRetryCalled = true;
        LastException = exception;

        return base.ShouldRetryCoreAsync(message, exception);
    }

    protected override void OnRequestSent(PipelineMessage message)
    {
        OnRequestSentCalled = true;

        base.OnRequestSent(message);
    }

    protected override ValueTask OnRequestSentAsync(PipelineMessage message)
    {
        OnRequestSentCalled = true;

        return base.OnRequestSentAsync(message);
    }

    protected override void OnSendingRequest(PipelineMessage message)
    {
        OnSendingRequestCalled = true;

        base.OnSendingRequest(message);
    }

    protected override ValueTask OnSendingRequestAsync(PipelineMessage message)
    {
        OnSendingRequestCalled = true;

        return base.OnSendingRequestAsync(message);
    }
}
