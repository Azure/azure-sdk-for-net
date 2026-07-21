// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientModel.Tests.Collections;

public class JsonlStreamedValueResult : StreamingClientResult<StreamedValue>
{
    public JsonlStreamedValueResult(PipelineResponse response)
        : base(response)
    {
    }

    protected override IEnumerable<StreamedValue> GetValues()
    {
        PipelineResponse response = GetRawResponse();
        Stream contentStream = response.ContentStream ?? response.Content.ToStream();
        using StreamReader reader = new(contentStream, Encoding.UTF8);

        while (reader.ReadLine() is string line)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                yield return StreamedValue.FromJson(Encoding.UTF8.GetBytes(line));
            }
        }
    }
}

public class AsyncJsonlStreamedValueResult :
    AsyncStreamingClientResult<StreamedValue>
{
    public AsyncJsonlStreamedValueResult(PipelineResponse response)
        : base(response)
    {
    }

    protected override async IAsyncEnumerable<StreamedValue> GetValuesAsync(
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        PipelineResponse response = GetRawResponse();
        Stream contentStream = response.ContentStream ?? response.Content.ToStream();
        using StreamReader reader = new(contentStream, Encoding.UTF8);

        while (await reader.ReadLineAsync().ConfigureAwait(false) is string line)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (!string.IsNullOrWhiteSpace(line))
            {
                yield return StreamedValue.FromJson(Encoding.UTF8.GetBytes(line));
            }
        }
    }
}
