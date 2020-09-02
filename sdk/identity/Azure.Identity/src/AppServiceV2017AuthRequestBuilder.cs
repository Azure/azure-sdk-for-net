// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    internal class AppServiceV2017AuthRequestBuilder : IAuthRequestBuilder
    {
        // MSI Constants. Docs for MSI are available here https://docs.microsoft.com/en-us/azure/app-service/overview-managed-identity
        private const string AppServiceMsiApiVersion = "2017-09-01";
        private const string MsiEndpointInvalidUriError = "The environment variable MSI_ENDPOINT contains an invalid Uri.";

        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _secret;
        private readonly string _clientId;

        public static IAuthRequestBuilder TryCreate(HttpPipeline pipeline, string clientId)
        {
            string msiEndpoint = EnvironmentVariables.MsiEndpoint;
            string msiSecret = EnvironmentVariables.MsiSecret;

            // if BOTH the env vars MSI_ENDPOINT and MSI_SECRET are set the MsiType is AppService
            if (string.IsNullOrEmpty(msiEndpoint) || string.IsNullOrEmpty(msiSecret))
            {
                return default;
            }

            Uri endpointUri;
            try
            {
                endpointUri = new Uri(msiEndpoint);
            }
            catch (FormatException ex)
            {
                throw new AuthenticationFailedException(MsiEndpointInvalidUriError, ex);
            }

            return new AppServiceV2017AuthRequestBuilder(pipeline, endpointUri, msiSecret, clientId);
        }

        private AppServiceV2017AuthRequestBuilder(HttpPipeline pipeline, Uri endpoint, string secret, string clientId)
        {
            _pipeline = pipeline;
            _endpoint = endpoint;
            _secret = secret;
            _clientId = clientId;
        }

        public Request CreateRequest(string[] scopes)
        {
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = _pipeline.CreateRequest();

            request.Method = RequestMethod.Get;
            request.Headers.Add("secret", _secret);
            request.Uri.Reset(_endpoint);
            request.Uri.AppendQuery("api-version", AppServiceMsiApiVersion);
            request.Uri.AppendQuery("resource", resource);

            if (!string.IsNullOrEmpty(_clientId))
            {
                request.Uri.AppendQuery("clientid", _clientId);
            }

            return request;
        }
    }
}
