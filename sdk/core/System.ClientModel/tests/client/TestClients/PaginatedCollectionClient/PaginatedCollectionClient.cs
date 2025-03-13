// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;

namespace ClientModel.Tests.Collections;

// A reference implementation that illustrates client patterns for paginated
// service endpoints for clients that have both convenience and protocol methods.
public class PaginatedCollectionClient
{
    public PaginatedCollectionClient(PaginatedCollectionClientOptions? options = default)
    {
    }

    public virtual AsyncCollectionResult<ValueItem> GetValuesAsync(
        int? pageSize = default,
        CancellationToken cancellationToken = default)
    {
        return new AsyncValueCollectionResult(pageSize, offset: default, cancellationToken.ToRequestOptions());
    }

    public virtual AsyncCollectionResult<ValueItem> GetValuesAsync(
        ContinuationToken continuationToken,
        CancellationToken cancellationToken = default)
    {
        ValueCollectionPageToken token = ValueCollectionPageToken.FromToken(continuationToken);

        return new AsyncValueCollectionResult(token.PageSize, token.Offset, cancellationToken.ToRequestOptions());
    }
    public virtual CollectionResult<ValueItem> GetValues(
        int? pageSize = default,
        CancellationToken cancellationToken = default)
    {
        return new ValueCollectionResult(pageSize, offset: default, cancellationToken.ToRequestOptions());
    }

    public virtual CollectionResult<ValueItem> GetValues(
        ContinuationToken continuationToken,
        CancellationToken cancellationToken = default)
    {
        ValueCollectionPageToken token = ValueCollectionPageToken.FromToken(continuationToken);

        return new ValueCollectionResult(token.PageSize, token.Offset, cancellationToken.ToRequestOptions());
    }
    public virtual AsyncCollectionResult GetValuesAsync(
        int? pageSize,
        RequestOptions? options)
    {
        return new AsyncValueCollectionResult(pageSize, offset: default, options);
    }

    public virtual AsyncCollectionResult GetValuesAsync(
        ContinuationToken continuationToken,
        RequestOptions? options)
    {
        ValueCollectionPageToken token = ValueCollectionPageToken.FromToken(continuationToken);

        return new AsyncValueCollectionResult(token.PageSize, token.Offset, options);
    }
    public virtual CollectionResult GetValues(
        int? pageSize,
        RequestOptions? options)
    {
        return new ValueCollectionResult(pageSize, offset: default, options);
    }

    public virtual CollectionResult GetValues(
        ContinuationToken continuationToken,
        RequestOptions? options)
    {
        ValueCollectionPageToken token = ValueCollectionPageToken.FromToken(continuationToken);

        return new ValueCollectionResult(token.PageSize, token.Offset, options);
    }
}
