// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace CR.Azure.NetCore.Tests.Fakes
{
    /// <summary>
    /// Plays back specified HTTP messages
    /// </summary>
    public class PlaybackTestHandler : DelegatingHandler
    {
        private readonly List<HttpResponseMessage> _responses;

        private int _counter;

        public List<HttpRequestMessage> Requests { get; private set; }

        public PlaybackTestHandler()
        {
            _responses = new List<HttpResponseMessage>();
            Requests = new List<HttpRequestMessage>();
            _counter = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="responses"></param>
        public PlaybackTestHandler(IEnumerable<HttpResponseMessage> responses) :
            this()
        {
            _responses.AddRange(responses);
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            Requests.Add(request);
            Debug.Assert(_counter < _responses.Count);
            return await Task.Run<HttpResponseMessage>(() => { return _responses[_counter++]; });
        }
    }
}
