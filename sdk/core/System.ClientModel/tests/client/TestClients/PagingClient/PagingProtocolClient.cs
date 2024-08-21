// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace ClientModel.Tests.Paging;

// A mock client implementation that illustrates paging patterns for client
// endpoints that only have protocol methods.
public class PagingProtocolClient
{
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;

    public PagingProtocolClient(PagingClientOptions options)
    {
        _pipeline = ClientPipeline.Create(options);
        _endpoint = new Uri("https://www.paging.com");
    }

    public virtual IAsyncEnumerable<ClientResult> GetValuesAsync(
        string? order,
        int? pageSize,
        int? offset,
        RequestOptions? options = default)
    {
        PageableResult enumerator = new ValuesPageResultEnumerator(
            _pipeline,
            _endpoint,
            order,
            pageSize,
            offset,
            options);
        return enumerator.ToAsyncEnumerable();
    }

    public virtual IEnumerable<ClientResult> GetValues(
        string? order,
        int? pageSize,
        int? offset,
        RequestOptions? options = default)
    {
        PageableResult enumerator = new ValuesPageResultEnumerator(
            _pipeline,
            _endpoint,
            order,
            pageSize,
            offset,
            options);
        return enumerator.ToEnumerable();
    }
}
