// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    internal class AppServiceV2019ManagedIdentitySource : ManagedIdentitySource
    {
        private const string AppServiceMsiApiVersion = "2019-08-01";
        private const string IdentityEndpointInvalidUriError = "The environment variable IDENTITY_ENDPOINT contains an invalid Uri.";

        private readonly Uri _endpoint;
        private readonly string _secret;
        private readonly string _clientId;

        public static ManagedIdentitySource TryCreate(CredentialPipeline pipeline, string clientId)
        {
            string identityEndpoint = EnvironmentVariables.IdentityEndpoint;
            string identityHeader = EnvironmentVariables.IdentityHeader;

            if (string.IsNullOrEmpty(identityEndpoint) || string.IsNullOrEmpty(identityHeader))
            {
                return default;
            }

            Uri endpointUri;
            try
            {
                endpointUri = new Uri(identityEndpoint);
            }
            catch (FormatException ex)
            {
                throw new AuthenticationFailedException(IdentityEndpointInvalidUriError, ex);
            }

            return new AppServiceV2019ManagedIdentitySource(pipeline, endpointUri, identityHeader, clientId);
        }

        private AppServiceV2019ManagedIdentitySource(CredentialPipeline pipeline, Uri endpoint, string secret, string clientId) : base(pipeline)
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
            request.Headers.Add("X-IDENTITY-HEADER", _secret);
            request.Uri.Reset(_endpoint);
            request.Uri.AppendQuery("api-version", AppServiceMsiApiVersion);
            request.Uri.AppendQuery("resource", resource);

            if (!string.IsNullOrEmpty(_clientId))
            {
                request.Uri.AppendQuery("client_id", _clientId);
            }

            return request;
        }
    }
}
