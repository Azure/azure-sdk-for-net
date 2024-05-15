// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics;
using System.Linq;
using Azure.Core.TestFramework;
using ClientModel.Tests.Internal;

namespace ClientModel.Tests.Mocks;

public class MockPageableClient
{
    public bool ProtocolMethodCalled { get; private set; }

    // mock convenience method - sync
    public virtual PageableCollection<MockJsonModel> GetModels(string[] pageContents)
    {
        PipelineResponse? lastResponse = default;

        // The contract for this pageable implementation is that the last seen
        // value id (where the id is StringValue) provides the continuation token
        // for the page.

        int pageNumber = 0;
        JsonModelList<MockJsonModel> values = new();

        ResultPage<MockJsonModel> firstPageFunc(int? pageSize)
        {
            ClientResult result = GetModels(pageContents[pageNumber++], options: null);
            lastResponse = result.GetRawResponse();
            values = ModelReaderWriter.Read<JsonModelList<MockJsonModel>>(lastResponse.Content)!;
            string? continuationToken = pageNumber < pageContents.Length ? values[values.Count - 1].StringValue : null;
            return new ResultPage<MockJsonModel>(values, continuationToken, lastResponse);
        }

        ResultPage<MockJsonModel> nextPageFunc(string? continuationToken, int? pageSize)
        {
            bool atRequestedPage = values.Count > 0 && values.Last().StringValue == continuationToken;
            while (!atRequestedPage && pageNumber < pageContents.Length)
            {
                BinaryData content = BinaryData.FromString(pageContents[pageNumber++]);
                JsonModelList<MockJsonModel> pageValues = ModelReaderWriter.Read<JsonModelList<MockJsonModel>>(content)!;
                atRequestedPage = pageValues[pageValues.Count - 1].StringValue == continuationToken;
            }

            Debug.Assert(atRequestedPage is true);

            ClientResult result = GetModels(pageContents[pageNumber++], options: null);
            lastResponse = result.GetRawResponse();
            values = ModelReaderWriter.Read<JsonModelList<MockJsonModel>>(lastResponse.Content)!;
            continuationToken = pageNumber < pageContents.Length ? values[values.Count - 1].StringValue : null;
            return new ResultPage<MockJsonModel>(values, continuationToken, lastResponse);
        }

        return PageableResultHelpers.Create(firstPageFunc, nextPageFunc);
    }

    // mock protocol method
    public virtual ClientResult GetModels(string pageContent, RequestOptions? options = default)
    {
        MockPipelineResponse response = new(200);
        response.SetContent(pageContent);

        ProtocolMethodCalled = true;

        return ClientResult.FromResponse(response);
    }
}
