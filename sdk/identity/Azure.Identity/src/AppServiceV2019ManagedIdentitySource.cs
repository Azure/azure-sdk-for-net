// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    internal class AppServiceV2019ManagedIdentitySource : IManagedIdentitySource
    {
        private const string AppServiceMsiApiVersion = "2019-08-01";
        private const string IdentityEndpointInvalidUriError = "The environment variable IDENTITY_ENDPOINT contains an invalid Uri.";

        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _secret;
        private readonly string _clientId;

        public static IManagedIdentitySource TryCreate(HttpPipeline pipeline, string clientId)
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

        private AppServiceV2019ManagedIdentitySource(HttpPipeline pipeline, Uri endpoint, string secret, string clientId)
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

        public AccessToken GetAccessTokenFromJson(in JsonElement jsonAccessToken, in JsonElement jsonExpiresOn)
        {
            // the seconds from epoch may be returned as a Json number or a Json string which is a number
            // depending on the environment.  If neither of these are the case we throw an AuthException.
            if (jsonExpiresOn.ValueKind == JsonValueKind.Number && jsonExpiresOn.TryGetInt64(out long expiresOnSec) ||
                jsonExpiresOn.ValueKind == JsonValueKind.String && long.TryParse(jsonExpiresOn.GetString(), out expiresOnSec))
            {
                return new AccessToken(jsonAccessToken.GetString(), DateTimeOffset.FromUnixTimeSeconds(expiresOnSec));
            }

            throw new AuthenticationFailedException(ManagedIdentityClient.AuthenticationResponseInvalidFormatError);
        }

        public ValueTask HandleFailedRequestAsync(Response response, ClientDiagnostics diagnostics, bool async) => new ValueTask();
    }
}
