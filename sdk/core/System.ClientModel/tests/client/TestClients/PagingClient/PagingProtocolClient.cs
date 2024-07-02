// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace ClientModel.Tests.PagingClient;

// A mock client implementation that illustrates paging patterns for client
// endpoints that only have protocol methods.
public class PagingProtocolClient
{
    private readonly ClientPipeline _pipeline;

    public PagingProtocolClient(ClientPipeline pipeline)
    {
        _pipeline = pipeline;
    }

    public virtual IAsyncEnumerable<ClientResult> GetValuesAsync(RequestOptions options)
    {
        PageResultEnumerator enumerator = new ValuesPageResultEnumerator(_pipeline, options);
        return PageCollectionHelpers.CreateAsync(enumerator);
    }

    public virtual IEnumerable<ClientResult> GetValues(RequestOptions options)
    {
        PageResultEnumerator enumerator = new ValuesPageResultEnumerator(_pipeline, options);
        return PageCollectionHelpers.Create(enumerator);
    }
}
