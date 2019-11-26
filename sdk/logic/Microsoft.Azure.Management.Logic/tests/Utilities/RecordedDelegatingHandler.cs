// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

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
