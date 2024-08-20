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
        private ManagedIdentityId _managedIdentityId;

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

                pipeline = new CredentialPipeline(customSslHttpPipline, pipeline.Diagnostics);
            }

            return new ServiceFabricManagedIdentitySource(pipeline, endpointUri, identityHeader, options);
        }

        internal static HttpClientTransport GetServiceFabricMITransport()
        {
            var httpHandler = new HttpClientHandler();

            httpHandler.ServerCertificateCustomValidationCallback = ValidateMsiServerCertificate;

            return new HttpClientTransport(httpHandler);
        }

        internal ServiceFabricManagedIdentitySource(CredentialPipeline pipeline, Uri endpoint, string identityHeaderValue, ManagedIdentityClientOptions options) : base(pipeline)
        {
            _endpoint = endpoint;
            _identityHeaderValue = identityHeaderValue;
            _managedIdentityId = options.ManagedIdentityId;
            if (options.ManagedIdentityId._idType != ManagedIdentityIdType.SystemAssigned)
            {
                AzureIdentityEventSource.Singleton.ServiceFabricManagedIdentityRuntimeConfigurationNotSupported();
            }
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

            string idQueryParam = _managedIdentityId?._idType switch
            {
                ManagedIdentityIdType.ClientId => Constants.ManagedIdentityClientId,
                ManagedIdentityIdType.ResourceId => Constants.ManagedIdentityResourceId,
                _ => null
            };

            if (idQueryParam != null)
            {
                request.Uri.AppendQuery(idQueryParam, _managedIdentityId._userAssignedId);
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
