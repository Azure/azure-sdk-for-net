// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Microsoft.ClientModel.TestFramework.Mocks;

/// <summary>
/// A mock of <see cref="PipelineMessage"/> to use for testing.
/// </summary>
public class MockPipelineMessage : PipelineMessage
{
    /// <summary>
    /// Creates a new instance of <see cref="MockPipelineMessage"/>.
    /// </summary>
    public MockPipelineMessage() : this(new MockPipelineRequest())
    {
    }

    /// <summary>
    /// Creates a new instance of <see cref="MockPipelineMessage"/>.
    /// </summary>
    /// <param name="request">The <see cref="PipelineRequest"/> to associate with this message.</param>
    public MockPipelineMessage(PipelineRequest request) : base(request)
    {
    }

    /// <summary>
    /// Sets the response for this pipeline message.
    /// </summary>
    /// <param name="response">The <see cref="PipelineResponse"/> to set for this message.</param>
    public void SetResponse(PipelineResponse response)
        => Response = response;
}
