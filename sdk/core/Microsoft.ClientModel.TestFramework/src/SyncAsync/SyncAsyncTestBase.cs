// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework.Mocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework;

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
    protected MockPipelineTransport CreateMockTransport(Func<MockPipelineMessage, MockPipelineResponse> responseFactory)
    {
        return new MockPipelineTransport(responseFactory)
        {
            ExpectSyncPipeline = !IsAsync
        };
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    protected Stream WrapStream(Stream stream)
    {
        return new AsyncValidatingStream(IsAsync, stream);
    }
}
