//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

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
