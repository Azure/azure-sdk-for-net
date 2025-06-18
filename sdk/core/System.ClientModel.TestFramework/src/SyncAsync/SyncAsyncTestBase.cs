// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ClientModel.TestFramework.Mocking;
using System.IO;

namespace System.ClientModel.TestFramework;

/// <summary>
/// TODO.
/// </summary>
public class SyncAsyncTestBase
{
    /// <summary>
    /// TODO.
    /// </summary>
    public bool IsAsync { get; }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="isAsync"></param>
    public SyncAsyncTestBase(bool isAsync)
    {
        IsAsync = isAsync;
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <returns></returns>
    protected MockPipelineTransport CreateMockTransport()
    {
        return new MockPipelineTransport()
        {
            ExpectSyncPipeline = !IsAsync
        };
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="responseFactory"></param>
    /// <returns></returns>
    protected MockPipelineTransport CreateMockTransport(Func<PipelineMessage, MockPipelineResponse> responseFactory)
    {
        return new MockPipelineTransport("", responseFactory)
        {
            ExpectSyncPipeline = !IsAsync
        };
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="responses"></param>
    /// <returns></returns>
    protected MockPipelineTransport CreateMockTransport(params MockPipelineResponse[] responses)
    {
        return new MockPipelineTransport("", _ => responses[0])
        {
            ExpectSyncPipeline = !IsAsync
        };
    }

    ///// <summary>
    ///// TODO.
    ///// </summary>
    ///// <param name="stream"></param>
    ///// <returns></returns>
    //protected Stream WrapStream(Stream stream)
    //{
    //    return new AsyncValidatingStream(IsAsync, stream);
    //}
}
