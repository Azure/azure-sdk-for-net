// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientModel.Tests.PagingClient;

// Mocks a page result enumerator a client would have for paged endpoints when
// those endpoints only have protocol methods on the client.
internal class ValuesPageResultEnumerator : PageResultEnumerator
{
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;

    private readonly string? _order;
    private readonly int? _pageSize;

    // This one is special - it keep track of which page we're on.
    private int? _offset;

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
        _offset += _pageSize;
        return result;
    }

    public override Task<ClientResult> GetFirstAsync()
    {
        throw new NotImplementedException();
    }

    public override ClientResult GetNext(ClientResult result)
    {
        ClientResult pageResult = GetValuesPage(_order, _pageSize, _offset);
        _offset += _pageSize;
        return pageResult;
    }

    public override Task<ClientResult> GetNextAsync(ClientResult result)
    {
        throw new NotImplementedException();
    }

    public override bool HasNext(ClientResult result)
    {
        return _offset < MockPagingData.Count;
    }

    // In a real client implementation, thes would be the generated protocol
    // method used to obtain a page of items.
    internal virtual ClientResult GetValuesPage(
        string? order,
        int? pageSize,
        int? offset,
        RequestOptions? options = default)
    {
        IEnumerable<ValueItem> values = MockPagingData.GetValues(order, pageSize, offset);
        return MockPagingData.GetPageResult(values);
    }
}
