// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity
{
    internal class AzureArcManagedIdentitySource : ManagedIdentitySource
    {
        private const string IdentityEndpointInvalidUriError = "The environment variable IDENTITY_ENDPOINT contains an invalid Uri.";
        private const string NoChallengeErrorMessage = "Did not receive expected WWW-Authenticate header in the response from Azure Arc Managed Identity Endpoint.";
        private const string InvalidChallangeErrorMessage = "The WWW-Authenticate header in the response from Azure Arc Managed Identity Endpoint did not match the expected format.";
        private const string UserAssignedNotSupportedErrorMessage = "User assigned identity is not supported by the Azure Arc Managed Identity Endpoint. To authenticate with the system assigned identity omit the client id when constructing the ManagedIdentityCredential, or if authenticating with the DefaultAzureCredential ensure the AZURE_CLIENT_ID environment variable is not set.";
        private const string ArcApiVersion = "2019-11-01";

        private readonly string _clientId;
        private readonly Uri _endpoint;

        public static ManagedIdentitySource TryCreate(ManagedIdentityClientOptions options)
        {
            string identityEndpoint = EnvironmentVariables.IdentityEndpoint;
            string imdsEndpoint = EnvironmentVariables.ImdsEndpoint;

            // if BOTH the env vars IDENTITY_ENDPOINT and IMDS_ENDPOINT are set the MsiType is Azure Arc
            if (string.IsNullOrEmpty(identityEndpoint) || string.IsNullOrEmpty(imdsEndpoint))
            {
                return default;
            }

            if (!Uri.TryCreate(identityEndpoint, UriKind.Absolute, out Uri endpointUri))
            {
                throw new AuthenticationFailedException(IdentityEndpointInvalidUriError);
            }

            return new AzureArcManagedIdentitySource(options.Pipeline, endpointUri, options.ClientId);
        }

        private AzureArcManagedIdentitySource(CredentialPipeline pipeline, Uri endpoint, string clientId) : base(pipeline)
        {
            _endpoint = endpoint;
            _clientId = clientId;
        }

        protected override Request CreateRequest(string[] scopes)
        {
            // arc MI endpoint doesn't support user assigned identities so if client id was specified throw AuthenticationFailedException
            if (!string.IsNullOrEmpty(_clientId))
            {
                throw new AuthenticationFailedException(UserAssignedNotSupportedErrorMessage);
            }

            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);
            Request request = Pipeline.HttpPipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Headers.Add("Metadata", "true");

            request.Uri.Reset(_endpoint);
            request.Uri.AppendQuery("api-version", ArcApiVersion);

            request.Uri.AppendQuery("resource", resource);

            return request;
        }

        protected override async ValueTask<AccessToken> HandleResponseAsync(bool async, TokenRequestContext context, Response response, CancellationToken cancellationToken)
        {
            if (response.Status == 401)
            {
                if (!response.Headers.TryGetValue("WWW-Authenticate", out string challenge))
                {
                    throw new AuthenticationFailedException(NoChallengeErrorMessage);
                }

                var splitChallenge = challenge.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                if (splitChallenge.Length != 2)
                {
                    throw new AuthenticationFailedException(InvalidChallangeErrorMessage);
                }

                var authHeaderValue = "Basic " + File.ReadAllText(splitChallenge[1]);

                using Request request = CreateRequest(context.Scopes);

                request.Headers.Add("Authorization", authHeaderValue);

                response = async
                    ? await Pipeline.HttpPipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false)
                    : Pipeline.HttpPipeline.SendRequest(request, cancellationToken);

                return await base.HandleResponseAsync(async, context, response, cancellationToken).ConfigureAwait(false);
            }

            return await base.HandleResponseAsync(async, context, response, cancellationToken).ConfigureAwait(false);
        }
    }
}
