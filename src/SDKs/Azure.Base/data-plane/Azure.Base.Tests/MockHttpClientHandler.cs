﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Base.Tests
{
    internal class MockHttpClientHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, Task<HttpResponseMessage>> _onSend;

        public MockHttpClientHandler(Action<HttpRequestMessage> onSend)
        {
            _onSend = req => {
                onSend(req);
                return Task.FromResult<HttpResponseMessage>(null);
            };
        }

        public MockHttpClientHandler(Func<HttpRequestMessage, Task<HttpResponseMessage>> onSend)
        {
            _onSend = onSend;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await _onSend(request);

            return response ?? new HttpResponseMessage((HttpStatusCode)200);
        }
    }
}