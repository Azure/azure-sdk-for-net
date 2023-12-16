// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace ClientModel.Tests.Mocks;

public class MockRetryPolicy : RequestRetryPolicy
{
    public MockRetryPolicy() : this(3, new MockMessageDelay())
    {
    }

    public MockRetryPolicy(int maxRetries, MessageDelay delay)
        : base(maxRetries, delay)
    {
    }

    public bool ShouldRetryCalled { get; private set; }
    public Exception? LastException {  get; private set; }

    public void Reset()
    {
        ShouldRetryCalled = false;
        LastException = null;
    }

    public bool ShouldRetry(PipelineMessage message, Exception? exception)
        => ShouldRetryCore(message, exception);

    public async Task<bool> ShouldRetryAsync(PipelineMessage message, Exception? exception)
        => await ShouldRetryCoreAsync(message, exception).ConfigureAwait(false);

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
}
