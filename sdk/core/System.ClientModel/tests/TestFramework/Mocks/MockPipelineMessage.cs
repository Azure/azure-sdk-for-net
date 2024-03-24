// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientModel.Tests.Mocks;

public class MockPipelineMessage : PipelineMessage
{
    public MockPipelineMessage() : this(new MockPipelineRequest())
    {
    }

    public MockPipelineMessage(PipelineRequest request) : base(request)
    {
    }

    public void SetResponse(PipelineResponse response)
        => this.Response = response;
}
