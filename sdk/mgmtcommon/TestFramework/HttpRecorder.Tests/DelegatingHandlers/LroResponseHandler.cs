// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace HttpRecorder.Tests.DelegatingHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    internal class LroResponseHandler : RecordedDelegatingHandler
    {
        private readonly List<HttpResponseMessage> _responses;

        private int _counter;

        public List<HttpRequestMessage> Requests { get; private set; }

        public LroResponseHandler()
        {
            _responses = new List<HttpResponseMessage>();
            Requests = new List<HttpRequestMessage>();
            _counter = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="responses"></param>
        public LroResponseHandler(IEnumerable<HttpResponseMessage> responses) :
            this()
        {
            _responses.AddRange(responses);
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            Requests.Add(request);
            Debug.Assert(_counter < _responses.Count);
            HttpResponseMessage res = _responses[_counter++];
            res.RequestMessage = request;
            return await Task.Run<HttpResponseMessage>(() => { return res; });
        }
    }
}
