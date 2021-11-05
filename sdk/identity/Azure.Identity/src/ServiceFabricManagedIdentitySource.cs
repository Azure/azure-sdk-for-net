// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    internal class ServiceFabricManagedIdentitySource : ManagedIdentitySource
    {
        private const string ServiceFabricMsiApiVersion = "2019-07-01-preview";
        private const string IdentityEndpointInvalidUriError = "The environment variable IDENTITY_ENDPOINT contains an invalid Uri.";

        private readonly Uri _endpoint;
        private readonly string _identityHeaderValue;
        private readonly string _clientId;

        public static ManagedIdentitySource TryCreate(ManagedIdentityClientOptions options)
        {
            string identityEndpoint = EnvironmentVariables.IdentityEndpoint;
            string identityHeader = EnvironmentVariables.IdentityHeader;
            string identityServerThumbprint = EnvironmentVariables.IdentityServerThumbprint;

            if (string.IsNullOrEmpty(identityEndpoint) || string.IsNullOrEmpty(identityHeader) || string.IsNullOrEmpty(identityServerThumbprint))
            {
                return default;
            }

            if (!Uri.TryCreate(identityEndpoint, UriKind.Absolute, out Uri endpointUri))
            {
                throw new AuthenticationFailedException(IdentityEndpointInvalidUriError);
            }

            var pipeline = options.Pipeline;

            if (!options.PreserveTransport)
            {
                var customSslHttpPipline = HttpPipelineBuilder.Build(new TokenCredentialOptions { Transport = GetServiceFabricMITransport() });

                pipeline = new CredentialPipeline(pipeline.AuthorityHost, customSslHttpPipline, pipeline.Diagnostics);
            }

            return new ServiceFabricManagedIdentitySource(pipeline, endpointUri, identityHeader, options.ClientId);
        }

        internal static HttpClientTransport GetServiceFabricMITransport()
        {
            var httpHandler = new HttpClientHandler();

            httpHandler.ServerCertificateCustomValidationCallback = ValidateMsiServerCertificate;

            return new HttpClientTransport(httpHandler);
        }

        private ServiceFabricManagedIdentitySource(CredentialPipeline pipeline, Uri endpoint, string identityHeaderValue, string clientId) : base(pipeline)
        {
            _endpoint = endpoint;
            _identityHeaderValue = identityHeaderValue;
            _clientId = clientId;
        }

        protected override Request CreateRequest(string[] scopes)
        {
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = Pipeline.HttpPipeline.CreateRequest();

            request.Method = RequestMethod.Get;
            request.Headers.Add("secret", _identityHeaderValue);
            request.Uri.Reset(_endpoint);
            request.Uri.AppendQuery("api-version", ServiceFabricMsiApiVersion);
            request.Uri.AppendQuery("resource", resource);

            if (!string.IsNullOrEmpty(_clientId))
            {
                request.Uri.AppendQuery("client_id", _clientId);
            }

            return request;
        }

        private static bool ValidateMsiServerCertificate(HttpRequestMessage message, X509Certificate2 cert, X509Chain certChain, SslPolicyErrors policyErrors)
        {
            // Do any additional validation here
            if (policyErrors == SslPolicyErrors.None)
            {
                return true;
            }

            return 0 == string.Compare(cert.GetCertHashString(), EnvironmentVariables.IdentityServerThumbprint, StringComparison.OrdinalIgnoreCase);
        }
    }
}
