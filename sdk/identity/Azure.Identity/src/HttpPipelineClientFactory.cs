// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// This class is an HttpClient factory which creates an HttpClient which delegates it's transport to an HttpPipeline, to enable MSAL to send requests through an Azure.Core HttpPipeline.
    /// </summary>
    internal class HttpPipelineClientFactory : IMsalHttpClientFactory
    {
        private readonly HttpPipeline _pipeline;

        public HttpPipelineClientFactory(HttpPipeline pipeline)
        {
            _pipeline = pipeline;
        }

        public HttpClient GetHttpClient()
        {
            return new HttpClient(new PipelineHttpMessageHandler(_pipeline));
        }

        /// <summary>
        /// An HttpMessageHandler which delegates SendAsync to a specified HttpPipeline.
        /// </summary>
        private class PipelineHttpMessageHandler : HttpMessageHandler
        {
            private readonly HttpPipeline _pipeline;

            public PipelineHttpMessageHandler(HttpPipeline pipeline)
            {
                _pipeline = pipeline;
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Request pipelineRequest = await request.ToPipelineRequestAsync(_pipeline).ConfigureAwait(false);

                Response pipelineResponse = await _pipeline.SendRequestAsync(pipelineRequest, cancellationToken).ConfigureAwait(false);

                return pipelineResponse.ToHttpResponseMessage();
            }
        }
    }
}
