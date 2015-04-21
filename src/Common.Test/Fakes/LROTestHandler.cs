// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Microsoft.Azure.Common.Test.Fakes
{
    public class LROTestHandler : DelegatingHandler
    {
        private readonly List<HttpResponseMessage> _responses;

        private int _counter;

        public List<HttpRequestMessage> Requests { get; private set; }

        public LROTestHandler()
        {
            _responses = new List<HttpResponseMessage>();
            Requests = new List<HttpRequestMessage>();
            _counter = 0;
        }

        public LROTestHandler(IEnumerable<HttpResponseMessage> responses) :
            this()
        {
            _responses.AddRange(responses);
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            Requests.Add(request);
            Debug.Assert(_counter < _responses.Count);
            return _responses[_counter++];
        }
    }
}
