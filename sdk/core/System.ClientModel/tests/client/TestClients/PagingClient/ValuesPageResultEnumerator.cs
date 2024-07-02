// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace ClientModel.Tests.PagingClient;

// Mocks a page result enumerator a client would have for paged endpoints when
// those endpoints only have protocol methods on the client.
internal class ValuesPageResultEnumerator : PageResultEnumerator
{
    private readonly ClientPipeline _pipeline;
    private readonly RequestOptions _options;

    public ValuesPageResultEnumerator(
        ClientPipeline pipeline,
        RequestOptions options)
    {
        _pipeline = pipeline;
        _options = options;
    }

    public override ClientResult GetFirst()
    {
        throw new NotImplementedException();
    }

    public override Task<ClientResult> GetFirstAsync()
    {
        throw new NotImplementedException();
    }

    public override ClientResult GetNext(ClientResult result)
    {
        throw new NotImplementedException();
    }

    public override Task<ClientResult> GetNextAsync(ClientResult result)
    {
        throw new NotImplementedException();
    }

    public override bool HasNext(ClientResult result)
    {
        throw new NotImplementedException();
    }
}
