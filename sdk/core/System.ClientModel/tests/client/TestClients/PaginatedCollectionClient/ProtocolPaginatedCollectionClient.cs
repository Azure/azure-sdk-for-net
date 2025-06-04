// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;

namespace ClientModel.Tests.Collections;

// A reference implementation that illustrates client patterns for paginated
// service endpoints for clients that have only protocol methods.
public class ProtocolPaginatedCollectionClient
{
    public ProtocolPaginatedCollectionClient(PaginatedCollectionClientOptions? options = default)
    {
    }

    public virtual AsyncCollectionResult GetValuesAsync(
        int? pageSize = default,
        RequestOptions? options = default)
    {
        return new AsyncProtocolValueCollectionResult(pageSize, offset: default, options);
    }
    public virtual AsyncCollectionResult GetValuesAsync(
        ContinuationToken continuationToken,
        RequestOptions? options = default)
    {
        ValueCollectionPageToken token = ValueCollectionPageToken.FromToken(continuationToken);

        return new AsyncProtocolValueCollectionResult(token.PageSize, token.Offset, options);
    }
    public virtual CollectionResult GetValues(
        int? pageSize = default,
        RequestOptions? options = default)
    {
        return new ProtocolValueCollectionResult(pageSize, offset: default, options);
    }
    public virtual CollectionResult GetValues(
        ContinuationToken continuationToken,
        RequestOptions? options = default)
    {
        ValueCollectionPageToken token = ValueCollectionPageToken.FromToken(continuationToken);

        return new ProtocolValueCollectionResult(token.PageSize, token.Offset, options);
    }
}
