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
            return new HttpClient(new HttpPipelineMessageHandler(_pipeline));
        }
    }
}
