// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace ClientModel.Tests.PagingClient;

// A mock client implementation that illustrates paging patterns
public class PagingClient
{
    private readonly ClientPipeline _pipeline;

    public PagingClient(ClientPipeline pipeline)
    {
        _pipeline = pipeline;
    }

    public virtual IAsyncEnumerable<ClientResult> GetValuesAsync(RequestOptions options)
    {
        PageResultEnumerator enumerator = new ValuesPageEnumerator(_pipeline);
        return PageCollectionHelpers.CreateAsync(enumerator);
    }

    public virtual IEnumerable<ClientResult> GetAssistants(RequestOptions options)
    {
        PageResultEnumerator enumerator = new GetValues(_pipeline);
        return PageCollectionHelpers.Create(enumerator);
    }
}
