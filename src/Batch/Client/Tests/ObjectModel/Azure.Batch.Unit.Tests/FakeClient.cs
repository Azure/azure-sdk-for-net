// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Azure.Batch.Protocol;

    public static class FakeClient
    {
        public static BatchServiceClient Create(Func<HttpMethod, Uri, Tuple<HttpStatusCode, string>> handler)
        {
            return new BatchServiceClient(new FakeCredential(), new FakeHttpHandler { HandlerFunc = handler });
        }

        public static BatchServiceClient Create(HttpStatusCode responseCode, Func<HttpMethod, Uri, string> bodyCreator)
        {
            return Create((m, uri) => Tuple.Create(responseCode, bodyCreator(m, uri)));
        }

        public static BatchServiceClient Create(HttpStatusCode responseCode, Func<Uri, string> bodyCreator)
        {
            return Create((m, uri) => Tuple.Create(responseCode, bodyCreator(uri)));
        }

        private class FakeHttpHandler : HttpClientHandler
        {
            public Func<HttpMethod, Uri, Tuple<HttpStatusCode, string>> HandlerFunc;

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var responseInfo = HandlerFunc(request.Method, request.RequestUri);
                var response = new HttpResponseMessage(responseInfo.Item1) { Content = new StringContent(responseInfo.Item2) };
                return Task.FromResult(response);
            }
        }

        private class FakeCredential : Microsoft.Azure.Batch.Protocol.BatchCredentials
        {
            public override Task SignRequestAsync(HttpRequestMessage httpRequest, CancellationToken cancellationToken)
            {
                return Task.Delay(0);
            }
        }
    }
}
