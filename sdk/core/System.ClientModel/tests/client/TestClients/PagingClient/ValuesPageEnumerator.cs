// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace ClientModel.Tests.PagingClient;

internal class ValuesPageEnumerator<T> : PageEnumerator<T>
{
    private readonly ClientPipeline _pipeline;
    private readonly RequestOptions _options;

    public ValuesPageEnumerator(
        ClientPipeline pipeline,
        RequestOptions options)
    {
        _pipeline = pipeline;
        _options = options;
    }

    public override PageResult<T> GetPageFromResult(ClientResult result)
    {
        throw new NotImplementedException();
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
