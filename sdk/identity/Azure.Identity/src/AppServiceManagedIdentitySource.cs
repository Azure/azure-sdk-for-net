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
    internal  class AppServiceManagedIdentitySource : ManagedIdentitySource
    {
        // MSI Constants. Docs for MSI are available here https://docs.microsoft.com/azure/app-service/overview-managed-identity
        protected virtual string AppServiceMsiApiVersion { get; }
        private const string MsiEndpointInvalidUriError = "The environment variable MSI_ENDPOINT contains an invalid Uri.";

        protected readonly Uri _endpoint;
        protected readonly string _secret;
        protected readonly string _clientId;

        protected static (Uri MsiEndpoint, string MsiSecret) ValidateEnvVars()
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

            return (endpointUri, msiSecret);
        }

        protected AppServiceManagedIdentitySource(CredentialPipeline pipeline, Uri endpoint, string secret, string clientId) : base(pipeline)
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
