// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Microsoft.Identity.Client;
using System.Net.Http;
using Azure.Core;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace Azure.Identity
{
    /// <summary>
    /// This class is an HttpClient factory which creates an HttpClient which delegates it's transport to an HttpPipeline, to enable MSAL to send requests through an Azure.Core HttpPipeline.
    /// </summary>
    internal class HttpPipelineClientFactory : IMsalSFHttpClientFactory
    {
        private readonly HttpPipeline _pipeline;
        private readonly ClientOptions _options;

        public HttpPipelineClientFactory(HttpPipeline pipeline, ClientOptions options = null)
        {
            _pipeline = pipeline;
            _options = options ?? new TokenCredentialOptions();
        }

        public HttpClient GetHttpClient()
        {
            return new HttpClient(new HttpPipelineMessageHandler(_pipeline));
        }

        public HttpClient GetHttpClient(Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> validateServerCert)
        {
            var pipeline = HttpPipelineBuilder.Build(new HttpPipelineOptions(_options) { RequestFailedDetailsParser = new ManagedIdentityRequestFailedDetailsParser() },
                new HttpPipelineTransportOptions()
                {
                    ServerCertificateCustomValidationCallback = (args) => validateServerCert(null, args.Certificate, args.CertificateAuthorityChain, args.SslPolicyErrors)
                });
            return new HttpClient(new HttpPipelineMessageHandler(pipeline));
        }
    }
}
