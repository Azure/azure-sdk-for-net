// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;

namespace ClientModel.Tests.Collections;

// A reference implementation that illustrates client patterns for streaming
// service endpoints for clients that have both convenience and protocol methods.
public class StreamedCollectionClient
{
    public StreamedCollectionClient(StreamedCollectionClientOptions? options = default)
    {
    }

    public virtual AsyncCollectionResult<StreamedValue> GetValuesAsync(CancellationToken cancellationToken = default)
    {
        return new AsyncStreamedValueCollectionResult(cancellationToken.ToRequestOptions());
    }

    public virtual CollectionResult<StreamedValue> GetValues(CancellationToken cancellationToken = default)
    {
        return new StreamedValueCollectionResult(cancellationToken.ToRequestOptions());
    }

    public virtual AsyncCollectionResult GetValuesAsync(RequestOptions? options)
    {
        return new AsyncStreamedValueCollectionResult(options);
    }

    public virtual CollectionResult GetValues(RequestOptions? options)
    {
        return new StreamedValueCollectionResult(options);
    }
}
