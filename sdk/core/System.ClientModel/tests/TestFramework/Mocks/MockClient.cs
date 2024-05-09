// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using Azure.Core.TestFramework;

namespace ClientModel.Tests.Mocks;

public class MockClient
{
    public bool StreamingProtocolMethodCalled { get; private set; }

    public virtual ClientResult<MockJsonModel> GetModel(int intValue, string stringValue)
    {
        MockPipelineResponse response = new(200);
        MockJsonModel model = new MockJsonModel(intValue, stringValue);
        return ClientResult.FromValue(model, response);
    }

    public virtual ClientResult<MockJsonModel?> GetOptionalModel(int intValue, string stringValue, bool hasValue)
    {
        if (hasValue)
        {
            MockPipelineResponse response = new(200);
            MockJsonModel model = new MockJsonModel(intValue, stringValue);
            return ClientResult.FromOptionalValue(model, response);
        }
        else
        {
            MockPipelineResponse response = new(404);
            return ClientResult.FromOptionalValue<MockJsonModel?>(default, response);
        }
    }

    public virtual ClientResult<int> GetCount(int count)
    {
        MockPipelineResponse response = new(200);
        return ClientResult.FromValue(count, response);
    }

    public virtual ClientResult<int?> GetOptionalCount(int count, bool hasValue)
    {
        if (hasValue)
        {
            MockPipelineResponse response = new(200);
            return ClientResult.FromOptionalValue<int?>(count, response);
        }
        else
        {
            MockPipelineResponse response = new(404);
            return ClientResult.FromOptionalValue<int?>(default, response);
        }
    }
}
