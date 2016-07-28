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

﻿using Microsoft.Azure.Batch.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AsyncTask = System.Threading.Tasks.Task;
using System.Net;
using Newtonsoft.Json;

namespace Microsoft.Azure.Batch.Conventions.Files.IntegrationTests.Utilities
{
    public sealed class FakeBatchServiceClient : BatchServiceClient
    {
        public FakeBatchServiceClient(Func<HttpRequestMessage, HttpResponseMessage> impl)
            : base(new FakingHandler(impl))
        {
        }

        public FakeBatchServiceClient(object responseBody)
            : this(_ => FakeResponse(responseBody))
        {
        }

        public FakeBatchServiceClient()
            : this(_ => { throw new InvalidOperationException("FakeBatchServiceClient not configured with any responses"); })
        {
        }

        public static HttpResponseMessage FakeResponse(object responseBody)
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseBody)),
            };
        }

        private class FakingHandler : DelegatingHandler
        {
            private readonly Func<HttpRequestMessage, HttpResponseMessage> _impl;

            public FakingHandler(Func<HttpRequestMessage, HttpResponseMessage> impl)
            {
                _impl = impl;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return AsyncTask.FromResult(_impl(request));
            }
        }
    }
}
