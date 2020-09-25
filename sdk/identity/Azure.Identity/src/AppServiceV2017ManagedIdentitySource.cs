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
    internal class AppServiceV2017ManagedIdentitySource : IManagedIdentitySource
    {
        // MSI Constants. Docs for MSI are available here https://docs.microsoft.com/en-us/azure/app-service/overview-managed-identity
        private const string AppServiceMsiApiVersion = "2017-09-01";
        private const string MsiEndpointInvalidUriError = "The environment variable MSI_ENDPOINT contains an invalid Uri.";

        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _secret;
        private readonly string _clientId;

        public static IManagedIdentitySource TryCreate(HttpPipeline pipeline, string clientId)
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

            return new AppServiceV2017ManagedIdentitySource(pipeline, endpointUri, msiSecret, clientId);
        }

        private AppServiceV2017ManagedIdentitySource(HttpPipeline pipeline, Uri endpoint, string secret, string clientId)
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

        public AccessToken GetAccessTokenFromJson(in JsonElement jsonAccessToken, in JsonElement jsonExpiresOn)
        {
            // AppService version 2017-09-01 sends expires_on as a string formatted datetimeoffset
            if (DateTimeOffset.TryParse(jsonExpiresOn.GetString(), CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTimeOffset expiresOn))
            {
                return new AccessToken(jsonAccessToken.GetString(), expiresOn);
            }

            throw new AuthenticationFailedException(ManagedIdentityClient.AuthenticationResponseInvalidFormatError);
        }

        public ValueTask HandleFailedRequestAsync(Response response, ClientDiagnostics diagnostics, bool async) => new ValueTask();
    }
}
