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
internal class ValuesPageResultEnumerator : PageResultEnumerator
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

    public override ClientResult GetFirst()
    {
        ClientResult result = GetValuesPage(_order, _pageSize, _offset);

        _nextOffset = GetNextOffset(_offset, _pageSize);

        return result;
    }

    public override async Task<ClientResult> GetFirstAsync()
    {
        ClientResult result = await GetValuesPageAsync(_order, _pageSize, _offset).ConfigureAwait(false);

        _nextOffset = GetNextOffset(_offset, _pageSize);

        return result;
    }

    public override ClientResult GetNext(ClientResult result)
    {
        _offset = _nextOffset;

        ClientResult pageResult = GetValuesPage(_order, _pageSize, _offset);

        _nextOffset = GetNextOffset(_offset, _pageSize);

        return pageResult;
    }

    public override async Task<ClientResult> GetNextAsync(ClientResult result)
    {
        _offset = _nextOffset;

        ClientResult pageResult = await GetValuesPageAsync(_order, _pageSize, _offset).ConfigureAwait(false);

        _nextOffset = GetNextOffset(_offset, _pageSize);

        return pageResult;
    }

    public override bool HasNext(ClientResult result)
    {
        return _nextOffset < MockPagingData.Count;
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
