// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientModel.Tests.Paging;

internal class MockValueItemPageResponse : PipelineResponse
{
    public MockValueItemPageResponse(IEnumerable<ValueItem> values)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("[");

        int count = 0;
        foreach (ValueItem value in values)
        {
            sb.AppendLine(value.ToJson());

            if (++count != values.Count())
            {
                sb.AppendLine(",");
            }
        }
        sb.AppendLine("]");

        Content = BinaryData.FromString(sb.ToString());
    }

    public override int Status => 200;

    public override string ReasonPhrase => "OK";

    public override Stream? ContentStream
    {
        get => null;
        set => throw new NotImplementedException();
    }

    public override BinaryData Content { get; }

    protected override PipelineResponseHeaders HeadersCore => throw new NotImplementedException();

    public override BinaryData BufferContent(CancellationToken cancellationToken = default)
        => Content;

    public override ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default)
        => new(Content);

    public override void Dispose() { }
}
