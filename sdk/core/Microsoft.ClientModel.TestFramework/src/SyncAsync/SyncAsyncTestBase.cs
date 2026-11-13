// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework.Mocks;
using System;
using System.IO;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Base class for tests that need to run both synchronously and asynchronously.
/// Provides utilities for creating mock transports and validating streams based on the execution mode.
/// </summary>
public class SyncAsyncTestBase
{
    /// <summary>
    /// Gets a value indicating whether the current test execution is asynchronous.
    /// </summary>
    public bool IsAsync { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SyncAsyncTestBase"/> class.
    /// </summary>
    /// <param name="isAsync">true if the test should run asynchronously; otherwise, false for synchronous execution.</param>
    public SyncAsyncTestBase(bool isAsync)
    {
        IsAsync = isAsync;
    }

    /// <summary>
    /// Creates a mock pipeline transport configured for the current execution mode (sync or async).
    /// </summary>
    /// <returns>A <see cref="MockPipelineTransport"/> instance configured for the appropriate pipeline mode.</returns>
    protected MockPipelineTransport CreateMockTransport()
    {
        return new MockPipelineTransport()
        {
            ExpectSyncPipeline = !IsAsync
        };
    }

    /// <summary>
    /// Creates a mock pipeline transport with a custom response factory, configured for the current execution mode (sync or async).
    /// </summary>
    /// <param name="responseFactory">A function that creates mock responses based on incoming requests.</param>
    /// <returns>A <see cref="MockPipelineTransport"/> instance with the specified response factory and appropriate pipeline mode.</returns>
    protected MockPipelineTransport CreateMockTransport(Func<MockPipelineMessage, MockPipelineResponse> responseFactory)
    {
        return new MockPipelineTransport(responseFactory)
        {
            ExpectSyncPipeline = !IsAsync
        };
    }

    /// <summary>
    /// Wraps a stream with validation to ensure proper sync/async usage based on the current execution mode.
    /// </summary>
    /// <param name="stream">The stream to wrap with validation.</param>
    /// <returns>An <see cref="AsyncValidatingStream"/> that validates sync/async usage of the underlying stream.</returns>
    protected Stream WrapStream(Stream stream)
    {
        return new AsyncValidatingStream(IsAsync, stream);
    }
}
