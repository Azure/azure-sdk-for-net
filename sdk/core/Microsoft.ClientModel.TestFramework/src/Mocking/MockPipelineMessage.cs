// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Mocks;

/// <summary>
/// TODO.
/// </summary>
public class MockPipelineMessage : PipelineMessage
{
    /// <summary>
    /// TODO.
    /// </summary>
    public MockPipelineMessage() : this(new MockPipelineRequest())
    {
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="request"></param>
    public MockPipelineMessage(PipelineRequest request) : base(request)
    {
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="response"></param>
    public void SetResponse(PipelineResponse response)
        => this.Response = response;
}
