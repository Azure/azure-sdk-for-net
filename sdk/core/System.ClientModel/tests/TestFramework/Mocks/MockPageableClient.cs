// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests.Internal;

namespace ClientModel.Tests.Mocks;

public class MockPageableClient
{
    public bool ProtocolMethodCalled { get; private set; }
    public int? RequestedPageSize { get; private set; }

    // mock convenience method - async
    public virtual AsyncPageableCollection<MockJsonModel> GetModelsAsync(string[] pageContents)
    {
        PipelineResponse? lastResponse = default;

        // The contract for this pageable implementation is that the last seen
        // value id (where the id is StringValue) provides the continuation token
        // for the page.

        int pageNumber = 0;
        JsonModelList<MockJsonModel> values = new();

        async Task<PageResult<MockJsonModel>> firstPageFuncAsync(string? pageToken = default)
        {
            ClientResult result = await GetModelsAsync(pageContents[pageNumber++], options: null).ConfigureAwait(false);
            lastResponse = result.GetRawResponse();
            values = ModelReaderWriter.Read<JsonModelList<MockJsonModel>>(lastResponse.Content)!;
            pageToken = pageNumber < pageContents.Length ? values[values.Count - 1].StringValue : null;
            return PageResult<MockJsonModel>.Create(values, pageToken, lastResponse);
        }

        async Task<PageResult<MockJsonModel>> nextPageFuncAsync(string? pageToken)
        {
            bool atRequestedPage = values.Count > 0 && values.Last().StringValue == pageToken;
            while (!atRequestedPage && pageNumber < pageContents.Length)
            {
                BinaryData content = BinaryData.FromString(pageContents[pageNumber++]);
                JsonModelList<MockJsonModel> pageValues = ModelReaderWriter.Read<JsonModelList<MockJsonModel>>(content)!;
                atRequestedPage = pageValues[pageValues.Count - 1].StringValue == pageToken;
            }

            Debug.Assert(atRequestedPage is true);

            ClientResult result = await GetModelsAsync(pageContents[pageNumber++], options: null).ConfigureAwait(false);
            lastResponse = result.GetRawResponse();
            values = ModelReaderWriter.Read<JsonModelList<MockJsonModel>>(lastResponse.Content)!;
            pageToken = pageNumber < pageContents.Length ? values[values.Count - 1].StringValue : null;
            return PageResult<MockJsonModel>.Create(values, pageToken, lastResponse);
        }

        return PageableResultHelpers.Create(firstPageFuncAsync, nextPageFuncAsync);
    }

    // mock convenience method - sync
    public virtual PageableCollection<MockJsonModel> GetModels(string[] pageContents)
    {
        PipelineResponse? lastResponse = default;

        // The contract for this pageable implementation is that the last seen
        // value id (where the id is StringValue) provides the continuation token
        // for the page.

        int pageNumber = 0;
        JsonModelList<MockJsonModel> values = new();

        PageResult<MockJsonModel> firstPageFunc(string? pageToken = default)
        {
            ClientResult result = GetModels(pageContents[pageNumber++], options: null);
            lastResponse = result.GetRawResponse();
            values = ModelReaderWriter.Read<JsonModelList<MockJsonModel>>(lastResponse.Content)!;
            pageToken = pageNumber < pageContents.Length ? values[values.Count - 1].StringValue : null;
            return PageResult<MockJsonModel>.Create(values, pageToken, lastResponse);
        }

        PageResult<MockJsonModel> nextPageFunc(string? pageToken)
        {
            bool atRequestedPage = values.Count > 0 && values.Last().StringValue == pageToken;
            while (!atRequestedPage && pageNumber < pageContents.Length)
            {
                BinaryData content = BinaryData.FromString(pageContents[pageNumber++]);
                JsonModelList<MockJsonModel> pageValues = ModelReaderWriter.Read<JsonModelList<MockJsonModel>>(content)!;
                atRequestedPage = pageValues[pageValues.Count - 1].StringValue == pageToken;
            }

            Debug.Assert(atRequestedPage is true);

            ClientResult result = GetModels(pageContents[pageNumber++], options: null);
            lastResponse = result.GetRawResponse();
            values = ModelReaderWriter.Read<JsonModelList<MockJsonModel>>(lastResponse.Content)!;
            pageToken = pageNumber < pageContents.Length ? values[values.Count - 1].StringValue : null;
            return PageResult<MockJsonModel>.Create(values, pageToken, lastResponse);
        }

        return PageableResultHelpers.Create(firstPageFunc, nextPageFunc);
    }

    // mock protocol method - async
    public virtual async Task<ClientResult> GetModelsAsync(string pageContent, RequestOptions? options = default)
    {
        await Task.Delay(0);

        MockPipelineResponse response = new(200);
        response.SetContent(pageContent);

        ProtocolMethodCalled = true;

        return ClientResult.FromResponse(response);
    }

    // mock protocol method - sync
    public virtual ClientResult GetModels(string pageContent, RequestOptions? options = default)
    {
        MockPipelineResponse response = new(200);
        response.SetContent(pageContent);

        ProtocolMethodCalled = true;

        return ClientResult.FromResponse(response);
    }
}
