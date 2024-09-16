// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientModel.Tests.Collections;

// A reference implementation that illustrates client patterns for streaming
// service endpoints for clients that have both convenience and protocol methods.
public class StreamedCollectionClient
{
    public StreamedCollectionClient(StreamedCollectionClientOptions? options = default)
    {
    }

    public virtual AsyncCollectionResult<ValueItem> GetValuesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public virtual CollectionResult<ValueItem> GetValues(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public virtual AsyncCollectionResult GetValuesAsync(RequestOptions? options)
    {
        throw new NotImplementedException();
    }

    public virtual CollectionResult GetValues(RequestOptions? options)
    {
        throw new NotImplementedException();
    }
}
