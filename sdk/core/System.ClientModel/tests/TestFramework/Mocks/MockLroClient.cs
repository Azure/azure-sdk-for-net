// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using Azure.Core.TestFramework;

namespace ClientModel.Tests.Mocks;

public class MockLroClient
{
    public virtual PollableResult<MockJsonModel> GetModelLater(ReturnWhen returnWhen, string content)
    {
        throw new NotImplementedException();
    }

    public virtual ClientResult GetModelLater(string content, RequestOptions? options = default)
    {
        throw new NotImplementedException();
    }
}
