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
    internal class CloudShellManagedIdentitySource : ManagedIdentitySource
    {
        private readonly Uri _endpoint;
        private readonly string _clientId;
        private const string MsiEndpointInvalidUriError = "The environment variable MSI_ENDPOINT contains an invalid Uri.";

        public static ManagedIdentitySource TryCreate(ManagedIdentityClientOptions options)
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

            return new CloudShellManagedIdentitySource(options.Pipeline, endpointUri, options.ClientId);
        }

        private CloudShellManagedIdentitySource(CredentialPipeline pipeline, Uri endpoint, string clientId) : base(pipeline)
        {
            _endpoint = endpoint;
            _clientId = clientId;
        }

        protected override Request CreateRequest(string[] scopes)
        {
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = Pipeline.HttpPipeline.CreateRequest();

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
    }
}
