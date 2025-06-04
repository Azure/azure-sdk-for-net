// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Net.ServerSentEvents;

namespace ClientModel.Tests.Collections;

// This type is public to enable test scenarios - in a real client it would be
// an internal type.
public class StreamedValueCollectionResult : CollectionResult<StreamedValue>
{
    private readonly RequestOptions? _options;

    public StreamedValueCollectionResult(RequestOptions? options)
    {
        _options = options;
    }

    public override ContinuationToken? GetContinuationToken(ClientResult page)
        // continuation not supported in this mock implentation
        => null;

    public override IEnumerable<ClientResult> GetRawPages()
    {
        // Only one response holds all the streamed data in this mock implementation
        PipelineResponse response = new MockStreamedResponse(MockStreamedData.DefaultMockContent);
        yield return ClientResult.FromResponse(response);
    }

    // The following method is added for observability of the response
    // in ResponseStreamisDisposedTest
    public IEnumerable<StreamedValue> GetPageValues(ClientResult page)
    {
        return GetValuesFromPage(page);
    }

    protected override IEnumerable<StreamedValue> GetValuesFromPage(ClientResult page)
    {
        using PipelineResponse response = page.GetRawResponse();
        Stream contentStream = response.ContentStream ?? response.Content.ToStream();

        SseParser<byte[]> parser = SseParser.Create(contentStream, (_, bytes) => bytes.ToArray());
        IEnumerable<SseItem<byte[]>> enumerable = parser.Enumerate();

        foreach (SseItem<byte[]> item in enumerable)
        {
            if (!MockStreamedData.IsTerminalEvent(item.Data))
            {
                yield return StreamedValue.FromJson(item.Data);
            }
        }
    }
}
