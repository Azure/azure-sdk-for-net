// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;

namespace ClientModel.Tests.Mocks;

public class MockErrorResult<T> : ClientResult<T?>
{
    private readonly ClientResultException _exception;

    public MockErrorResult(PipelineResponse response, ClientResultException exception)
        : base(default, response)
    {
        _exception = exception;
    }

    public override T? Value { get => throw _exception; }
}
