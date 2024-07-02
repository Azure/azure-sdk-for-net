// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;

namespace ClientModel.Tests.PagingClient;

// A mock client implementation that illustrates paging patterns for client
// endpoints that have both convenience and protocol methods.
public class PagingClient
{
    private readonly ClientPipeline _pipeline;

    public PagingClient(ClientPipeline pipeline)
    {
        _pipeline = pipeline;
    }

    public virtual AsyncPageCollection<ValueItem> GetValuesAsync(CancellationToken cancellationToken = default)
    {
        ValuesPageEnumerator enumerator = new ValuesPageEnumerator(_pipeline, cancellationToken.ToRequestOptions());
        return PageCollectionHelpers.CreateAsync(enumerator);
    }

    public virtual AsyncPageCollection<ValueItem> GetValuesAsync(
        ContinuationToken firstPageToken,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(firstPageToken, nameof(firstPageToken));

        ValuesPageToken pageToken = ValuesPageToken.FromToken(firstPageToken);

        ValuesPageEnumerator enumerator = new ValuesPageEnumerator(_pipeline, cancellationToken.ToRequestOptions());
        return PageCollectionHelpers.CreateAsync(enumerator);
    }

    public virtual IEnumerable<ClientResult> GetValues(CancellationToken cancellationToken = default)
    {
        ValuesPageEnumerator enumerator = new ValuesPageEnumerator(_pipeline, cancellationToken.ToRequestOptions());
        return PageCollectionHelpers.Create(enumerator);
    }

    public virtual PageCollection<ValueItem> GetValues(
        ContinuationToken firstPageToken,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(firstPageToken, nameof(firstPageToken));

        ValuesPageToken pageToken = ValuesPageToken.FromToken(firstPageToken);

        ValuesPageEnumerator enumerator = new ValuesPageEnumerator(_pipeline, cancellationToken.ToRequestOptions());
        return PageCollectionHelpers.Create(enumerator);
    }

    public virtual IAsyncEnumerable<ClientResult> GetValuesAsync(RequestOptions options)
    {
        PageResultEnumerator enumerator = new ValuesPageEnumerator(_pipeline, options);
        return PageCollectionHelpers.CreateAsync(enumerator);
    }

    public virtual IEnumerable<ClientResult> GetValues(RequestOptions options)
    {
        PageResultEnumerator enumerator = new ValuesPageEnumerator(_pipeline, options);
        return PageCollectionHelpers.Create(enumerator);
    }
}
