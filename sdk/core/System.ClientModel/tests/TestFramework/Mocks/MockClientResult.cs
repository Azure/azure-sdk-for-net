// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;

namespace ClientModel.Tests.Mocks;

public class MockClientResult : ClientResult
{
    public MockClientResult(PipelineResponse response) : base(response)
    {
    }
}
