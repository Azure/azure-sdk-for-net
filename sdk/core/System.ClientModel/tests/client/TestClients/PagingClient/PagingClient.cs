// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;

namespace ClientModel.Tests.Paging;

// A mock client implementation that illustrates paging patterns for client
// endpoints that have both convenience and protocol methods.
public class PagingClient
{
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;

    public PagingClient(PagingClientOptions options)
    {
        _pipeline = ClientPipeline.Create(options);
        _endpoint = new Uri("https://www.paging.com");
    }

    public virtual AsyncPageCollection<ValueItem> GetValuesAsync(
        string? order = default,
        int? pageSize = default,
        int? offset = default,
        CancellationToken cancellationToken = default)
    {
        ValuesPageEnumerator enumerator = new ValuesPageEnumerator(
            _pipeline,
            _endpoint,
            order: order,
            pageSize: pageSize,
            offset: offset,
            cancellationToken.ToRequestOptions());
        return PageCollectionHelpers.CreateAsync(enumerator);
    }

    public virtual AsyncPageCollection<ValueItem> GetValuesAsync(
        ContinuationToken firstPageToken,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(firstPageToken, nameof(firstPageToken));

        ValuesPageToken token = ValuesPageToken.FromToken(firstPageToken);
        ValuesPageEnumerator enumerator = new ValuesPageEnumerator(
            _pipeline,
            _endpoint,
            token.Order,
            token.PageSize,
            token.Offset,
            cancellationToken.ToRequestOptions());
        return PageCollectionHelpers.CreateAsync(enumerator);
    }

    public virtual PageCollection<ValueItem> GetValues(
        string? order = default,
        int? pageSize = default,
        int? offset = default,
        CancellationToken cancellationToken = default)
    {
        ValuesPageEnumerator enumerator = new ValuesPageEnumerator(
            _pipeline,
            _endpoint,
            order: order,
            pageSize: pageSize,
            offset: offset,
            cancellationToken.ToRequestOptions());
        return PageCollectionHelpers.Create(enumerator);
    }

    public virtual PageCollection<ValueItem> GetValues(
        ContinuationToken firstPageToken,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(firstPageToken, nameof(firstPageToken));

        ValuesPageToken token = ValuesPageToken.FromToken(firstPageToken);
        ValuesPageEnumerator enumerator = new ValuesPageEnumerator(
            _pipeline,
            _endpoint,
            token.Order,
            token.PageSize,
            token.Offset,
            cancellationToken.ToRequestOptions());
        return PageCollectionHelpers.Create(enumerator);
    }

    public virtual IAsyncEnumerable<ClientResult> GetValuesAsync(
        string? order,
        int? pageSize,
        int? offset,
        RequestOptions options)
    {
        ValuesPageEnumerator enumerator = new ValuesPageEnumerator(
            _pipeline,
            _endpoint,
            order: order,
            pageSize: pageSize,
            offset: offset,
            options);
        return PageCollectionHelpers.CreateAsync(enumerator);
    }

    public virtual IEnumerable<ClientResult> GetValues(
        string? order,
        int? pageSize,
        int? offset,
        RequestOptions options)
    {
        ValuesPageEnumerator enumerator = new ValuesPageEnumerator(
            _pipeline,
            _endpoint,
            order: order,
            pageSize: pageSize,
            offset: offset,
            options);
        return PageCollectionHelpers.Create(enumerator);
    }
}
