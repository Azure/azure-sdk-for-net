// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ClientModel.Tests.Mocks;

public class MockHttpClientHandler : HttpMessageHandler
{
    private readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _onSend;

    public MockHttpClientHandler(Action<HttpRequestMessage> onSend)
    {
        _onSend = (req, _) =>
        {
            onSend(req);
            return Task.FromResult<HttpResponseMessage>(null!);
        };
    }

    public MockHttpClientHandler(Func<HttpRequestMessage, Task<HttpResponseMessage>> onSend)
        : this((request, _) => onSend(request))
    {
    }

    public MockHttpClientHandler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> onSend)
    {
        _onSend = onSend;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await _onSend(request, cancellationToken);

        return response ?? new HttpResponseMessage((HttpStatusCode)200);
    }

#if NET5_0_OR_GREATER
    protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = _onSend(request, cancellationToken).GetAwaiter().GetResult();

        return response ?? new HttpResponseMessage((HttpStatusCode)200);
    }
#endif
}
