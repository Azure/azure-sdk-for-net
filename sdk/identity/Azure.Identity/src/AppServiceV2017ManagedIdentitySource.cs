// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    internal class AppServiceV2017ManagedIdentitySource : ManagedIdentitySource
    {
        // MSI Constants. Docs for MSI are available here https://docs.microsoft.com/en-us/azure/app-service/overview-managed-identity
        private const string AppServiceMsiApiVersion = "2017-09-01";
        private const string MsiEndpointInvalidUriError = "The environment variable MSI_ENDPOINT contains an invalid Uri.";

        private readonly Uri _endpoint;
        private readonly string _secret;
        private readonly string _clientId;

        public static ManagedIdentitySource TryCreate(ManagedIdentityClientOptions options)
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

            return new AppServiceV2017ManagedIdentitySource(options.Pipeline, endpointUri, msiSecret, options.ClientId);
        }

        private AppServiceV2017ManagedIdentitySource(CredentialPipeline pipeline, Uri endpoint, string secret, string clientId) : base(pipeline)
        {
            _endpoint = endpoint;
            _secret = secret;
            _clientId = clientId;
        }

        protected override Request CreateRequest(string[] scopes)
        {
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = Pipeline.HttpPipeline.CreateRequest();

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
