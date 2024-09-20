// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Net.ServerSentEvents;
using System.Threading.Tasks;

namespace ClientModel.Tests.Collections;

// This type is public to enable test scenarios - in a real client it would be
// an internal type.
public class AsyncStreamedValueCollectionResult : AsyncCollectionResult<StreamedValue>
{
    private readonly RequestOptions? _options;

    public AsyncStreamedValueCollectionResult(RequestOptions? options)
    {
        _options = options;
    }

    public override ContinuationToken? GetContinuationToken(ClientResult page)
        // continuation not supported in this mock implentation
        => null;

    public override async IAsyncEnumerable<ClientResult> GetRawPagesAsync()
    {
        await Task.Delay(0, _options?.CancellationToken ?? default);

        // Only one response holds all the streamed data in this mock implementation
        PipelineResponse response = new MockStreamedResponse(MockStreamedData.DefaultMockContent);
        yield return ClientResult.FromResponse(response);
    }

    // The following method is added for observability of the response
    // in ResponseStreamisDisposedTest
    public IAsyncEnumerable<StreamedValue> GetPageValuesAsync(ClientResult page)
    {
        return GetValuesFromPageAsync(page);
    }

    protected override async IAsyncEnumerable<StreamedValue> GetValuesFromPageAsync(ClientResult page)
    {
        using PipelineResponse response = page.GetRawResponse();
        Stream contentStream = response.ContentStream ?? response.Content.ToStream();

        SseParser<byte[]> parser = SseParser.Create(contentStream, (_, bytes) => bytes.ToArray());
        IAsyncEnumerable<SseItem<byte[]>> enumerable = parser.EnumerateAsync();
        await foreach (SseItem<byte[]> item in enumerable)
        {
            if (!MockStreamedData.IsTerminalEvent(item.Data))
            {
                yield return StreamedValue.FromJson(item.Data);
            }
        }
    }
}
