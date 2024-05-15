// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
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

        int pageNumber = 0;
        ClientPage<MockJsonModel> firstPageFunc(int? pageSize)
        {
            ClientResult result = GetModels(pageContents[pageNumber++], options: null);
            lastResponse = result.GetRawResponse();
            JsonModelList<MockJsonModel> values = ModelReaderWriter.Read<JsonModelList<MockJsonModel>>(lastResponse.Content)!;
            return PageableResultHelpers.CreatePage(values, values[values.Count - 1].StringValue, lastResponse);
        }

        ClientPage<MockJsonModel> nextPageFunc(string? continuationToken, int? pageSize)
        {
            if (pageNumber >= pageContents.Length)
            {
                return PageableResultHelpers.CreatePage(Array.Empty<MockJsonModel>(), continuationToken: null, lastResponse!);
            }

            ClientResult result = GetModels(pageContents[pageNumber++], options: null);
            lastResponse = result.GetRawResponse();
            JsonModelList<MockJsonModel> values = ModelReaderWriter.Read<JsonModelList<MockJsonModel>>(lastResponse.Content)!;
            return PageableResultHelpers.CreatePage(values, values[values.Count - 1].StringValue, lastResponse);
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
