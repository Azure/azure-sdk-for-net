// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System.Threading;

namespace System.TypeSpec.Tests;

public class DemoClient
{
    private readonly HttpPipeline _pipeline;

    public DemoClient()
    {
    }

    public Result<FooModel> GetSetting(CancellationToken cancellationToken = default)
    {
        HttpMessage message = _pipeline.CreateMessage();
        _pipeline.Send(message, cancellationToken);
        return new Result<FooModel>(message.Response);
    }
}

public class FooModel
{
}
