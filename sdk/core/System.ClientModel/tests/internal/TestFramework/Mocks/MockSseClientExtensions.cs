// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;

namespace ClientModel.Tests.Internal.Mocks;

public static class MockSseClientExtensions
{
    public static AsyncResultCollection<BinaryData> EnumerateDataEvents(this PipelineResponse response)
    {
        if (response.ContentStream is null)
        {
            throw new ArgumentException("Unable to create result collection from PipelineResponse with null ContentStream", nameof(response));
        }

        return new AsyncSseDataEventCollection(response, "[DONE]");
    }
}
