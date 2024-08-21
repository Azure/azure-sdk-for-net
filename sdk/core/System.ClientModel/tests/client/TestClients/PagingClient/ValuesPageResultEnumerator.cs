// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientModel.Tests.Paging;

// Mocks a page result enumerator a client would have for paged endpoints when
// those endpoints only have protocol methods on the client.
internal class ValuesPageResultEnumerator : PageableResult
{
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;

    private readonly string? _order;
    private readonly int? _pageSize;

    // This one is special - it keeps track of which page we're on.
    private int? _offset;

    // We need two offsets to be able to create both page tokens.
    private int _nextOffset;

    private readonly RequestOptions? _options;

    public ValuesPageResultEnumerator(
        ClientPipeline pipeline,
        Uri endpoint,
        string? order,
        int? pageSize,
        int? offset,
        RequestOptions? options)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;

        _order = order;
        _pageSize = pageSize;
        _offset = offset;

        _options = options;
    }

    public override ClientResult GetNextPage(ClientResult? result, RequestOptions options)
    {
        if (result is null)
        {
            return GetFirst(options);
        }
        else
        {
            return GetNext(result, options);
        }
    }

    public override Task<ClientResult> GetNextPageAsync(ClientResult? result, RequestOptions options)
    {
        if (result is null)
        {
            return GetFirstAsync(options);
        }
        else
        {
            return GetNextAsync(result, options);
        }
    }

    public override bool HasNext(ClientResult result)
    {
        return _nextOffset < MockPagingData.Count;
    }

    private ClientResult GetFirst(RequestOptions options)
    {
        ClientResult result = GetValuesPage(_order, _pageSize, _offset);

        _nextOffset = GetNextOffset(_offset, _pageSize);

        return result;
    }

    private async Task<ClientResult> GetFirstAsync(RequestOptions options)
    {
        ClientResult result = await GetValuesPageAsync(_order, _pageSize, _offset).ConfigureAwait(false);

        _nextOffset = GetNextOffset(_offset, _pageSize);

        return result;
    }

    private ClientResult GetNext(ClientResult result, RequestOptions options)
    {
        _offset = _nextOffset;

        ClientResult pageResult = GetValuesPage(_order, _pageSize, _offset);

        _nextOffset = GetNextOffset(_offset, _pageSize);

        return pageResult;
    }

    private async Task<ClientResult> GetNextAsync(ClientResult result, RequestOptions options)
    {
        _offset = _nextOffset;

        ClientResult pageResult = await GetValuesPageAsync(_order, _pageSize, _offset).ConfigureAwait(false);

        _nextOffset = GetNextOffset(_offset, _pageSize);

        return pageResult;
    }

    // In a real client implementation, these would be the generated protocol
    // method used to obtain a page of items.
    internal virtual async Task<ClientResult> GetValuesPageAsync(
        string? order,
        int? pageSize,
        int? offset,
        RequestOptions? options = default)
    {
        await Task.Delay(0);
        IEnumerable<ValueItem> values = MockPagingData.GetValues(order, pageSize, offset);
        return MockPagingData.GetPageResult(values);
    }

    internal virtual ClientResult GetValuesPage(
        string? order,
        int? pageSize,
        int? offset,
        RequestOptions? options = default)
    {
        IEnumerable<ValueItem> values = MockPagingData.GetValues(order, pageSize, offset);
        return MockPagingData.GetPageResult(values);
    }

    // This helper method is specific to this mock enumerator implementation
    private static int GetNextOffset(int? offset, int? pageSize)
    {
        offset ??= MockPagingData.DefaultOffset;
        pageSize ??= MockPagingData.DefaultPageSize;
        return offset.Value + pageSize.Value;
    }
}
