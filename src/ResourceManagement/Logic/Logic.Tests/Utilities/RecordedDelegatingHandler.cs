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

namespace Test.Azure.Management.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class RecordedDelegatingHandler : DelegatingHandler
    {
        public List<HttpRequestMessage> Requests = new List<HttpRequestMessage>();

        public List<HttpResponseMessage> Responses = new List<HttpResponseMessage>();

        public HttpRequestMessage Request
        {
            get
            {
                switch (this.Requests.Count)
                {
                    case 0:
                        return null;

                    case 1:
                        return this.Requests[0];

                    default:
                        throw new InvalidOperationException("More than one request found.");
                }
            }
        }

        public HttpResponseMessage Response
        {
            get
            {
                switch (this.Responses.Count)
                {
                    case 0:
                        return null;

                    case 1:
                        return this.Responses[0];

                    default:
                        throw new InvalidOperationException("More than one response found.");
                }
            }

            set
            {
                if (this.Responses.Count != 0)
                {
                    throw new InvalidOperationException("Responses is already set.");
                }

                this.Responses.Add(value);
            }
        }

        public int Count { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            this.Count++;
            this.Requests.Add(request);

            if (this.Count <= this.Responses.Count)
            {
                return Task.FromResult(this.Responses[this.Count - 1]);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
