// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    internal class CloudShellManagedIdentitySource : IManagedIdentitySource
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _clientId;
        private const string MsiEndpointInvalidUriError = "The environment variable MSI_ENDPOINT contains an invalid Uri.";

        public static IManagedIdentitySource TryCreate(HttpPipeline pipeline, string clientId)
        {
            string msiEndpoint = EnvironmentVariables.MsiEndpoint;

            // if ONLY the env var MSI_ENDPOINT is set the MsiType is CloudShell
            if (string.IsNullOrEmpty(msiEndpoint))
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

            return new CloudShellManagedIdentitySource(pipeline, endpointUri, clientId);
        }

        private CloudShellManagedIdentitySource(HttpPipeline pipeline, Uri endpoint, string clientId)
        {
            _pipeline = pipeline;
            _endpoint = endpoint;
            _clientId = clientId;
        }

        public Request CreateRequest(string[] scopes)
        {
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = _pipeline.CreateRequest();

            request.Method = RequestMethod.Post;

            request.Headers.Add(HttpHeader.Common.FormUrlEncodedContentType);

            request.Uri.Reset(_endpoint);

            request.Headers.Add("Metadata", "true");

            var bodyStr = $"resource={Uri.EscapeDataString(resource)}";

            if (!string.IsNullOrEmpty(_clientId))
            {
                bodyStr += $"&client_id={Uri.EscapeDataString(_clientId)}";
            }

            ReadOnlyMemory<byte> content = Encoding.UTF8.GetBytes(bodyStr).AsMemory();
            request.Content = RequestContent.Create(content);
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
