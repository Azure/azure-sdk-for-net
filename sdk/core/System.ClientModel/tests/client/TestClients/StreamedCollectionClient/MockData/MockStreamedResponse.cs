// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ClientModel.Tests.Collections;

public class MockStreamedResponse : PipelineResponse
{
    public MockStreamedResponse(string content)
    {
        Content = BinaryData.FromString(content);
    }

    public override int Status => 200;

    public override string ReasonPhrase => "OK";

    public override Stream? ContentStream
    {
        get => null;
        set => throw new NotImplementedException();
    }

    public override BinaryData Content { get; }

    public bool IsDisposed { get; private set; }

    protected override PipelineResponseHeaders HeadersCore
        => throw new NotImplementedException();

    public override BinaryData BufferContent(CancellationToken cancellationToken = default)
        => Content;

    public override ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default)
        => new(Content);

    public override void Dispose()
    {
        IsDisposed = true;
    }
}
