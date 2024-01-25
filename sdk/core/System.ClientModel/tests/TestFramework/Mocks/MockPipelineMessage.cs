// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

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
        => Response = response;
}
