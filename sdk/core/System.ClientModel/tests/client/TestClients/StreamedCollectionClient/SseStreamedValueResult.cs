// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ClientModel.Tests.Collections;

public class SseStreamedValueResult : StreamingClientResult<SseItem<StreamedValue>>
{
    public SseStreamedValueResult(PipelineResponse response)
        : base(response)
    {
    }

    protected override IEnumerable<SseItem<StreamedValue>> GetValues()
    {
        PipelineResponse response = GetRawResponse();
        Stream contentStream = response.ContentStream ?? response.Content.ToStream();
        SseParser<byte[]> parser =
            SseParser.Create(contentStream, (_, bytes) => bytes.ToArray());

        foreach (SseItem<byte[]> item in parser.Enumerate())
        {
            if (!MockStreamedData.IsTerminalEvent(item.Data))
            {
                yield return new SseItem<StreamedValue>(
                    StreamedValue.FromJson(item.Data),
                    item.EventType)
                {
                    EventId = item.EventId,
                    ReconnectionInterval = item.ReconnectionInterval
                };
            }
        }
    }
}

public class AsyncSseStreamedValueResult :
    AsyncStreamingClientResult<SseItem<StreamedValue>>
{
    public AsyncSseStreamedValueResult(PipelineResponse response)
        : base(response)
    {
    }

    protected override async IAsyncEnumerable<SseItem<StreamedValue>> GetValuesAsync(
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        PipelineResponse response = GetRawResponse();
        Stream contentStream = response.ContentStream ?? response.Content.ToStream();
        SseParser<byte[]> parser =
            SseParser.Create(contentStream, (_, bytes) => bytes.ToArray());

        await foreach (SseItem<byte[]> item in
            parser.EnumerateAsync(cancellationToken))
        {
            if (!MockStreamedData.IsTerminalEvent(item.Data))
            {
                yield return new SseItem<StreamedValue>(
                    StreamedValue.FromJson(item.Data),
                    item.EventType)
                {
                    EventId = item.EventId,
                    ReconnectionInterval = item.ReconnectionInterval
                };
            }
        }
    }
}
