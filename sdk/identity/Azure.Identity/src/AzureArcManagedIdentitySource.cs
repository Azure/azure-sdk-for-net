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
        private const string UserAssignedNotSupportedErrorMessage = "User-assigned managed identity is not supported by the Azure Arc Managed Identity Endpoint. To authenticate with the system-assigned managed identity, omit the client ID when constructing the ManagedIdentityCredential, or if authenticating with DefaultAzureCredential, ensure the AZURE_CLIENT_ID environment variable is not set.";
        private const string ArcApiVersion = "2019-11-01";

        private readonly ManagedIdentityId _managedIdentityId;
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

            return new AzureArcManagedIdentitySource(endpointUri, options);
        }

        internal AzureArcManagedIdentitySource(Uri endpoint, ManagedIdentityClientOptions options) : base(options.Pipeline)
        {
            _endpoint = endpoint;
            _managedIdentityId = options.ManagedIdentityId;
            if (options.ManagedIdentityId._idType != ManagedIdentityIdType.SystemAssigned)
            {
                AzureIdentityEventSource.Singleton.UserAssignedManagedIdentityNotSupported("Azure Arc");
            }
        }

        protected override Request CreateRequest(string[] scopes)
        {
            // arc MI endpoint doesn't support user assigned identities so if client id was specified throw AuthenticationFailedException
            if (_managedIdentityId._idType != ManagedIdentityIdType.SystemAssigned)
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

        protected override async ValueTask<AccessToken> HandleResponseAsync(bool async, TokenRequestContext context, HttpMessage message, CancellationToken cancellationToken)
        {
            Response response = message.Response;
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
                string filePath = splitChallenge[1];

                ValidatePath(filePath);
                var authHeaderValue = "Basic " + File.ReadAllText(splitChallenge[1]);

                using Request request = CreateRequest(context.Scopes);

                request.Headers.Add("Authorization", authHeaderValue);

                var challengeResponseMessage = Pipeline.HttpPipeline.CreateMessage();
                challengeResponseMessage.Request.Method = request.Method;
                challengeResponseMessage.Request.Uri.Reset(request.Uri.ToUri());
                foreach (var header in request.Headers)
                {
                    challengeResponseMessage.Request.Headers.Add(header.Name, header.Value);
                }

                challengeResponseMessage.Response = async
                    ? await Pipeline.HttpPipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false)
                    : Pipeline.HttpPipeline.SendRequest(request, cancellationToken);

                return await base.HandleResponseAsync(async, context, challengeResponseMessage, cancellationToken).ConfigureAwait(false);
            }

            return await base.HandleResponseAsync(async, context, message, cancellationToken).ConfigureAwait(false);
        }

        private void ValidatePath(string filePath)
        {
            // check that the file ends with '.key'
            if (!filePath.EndsWith(".key"))
            {
                throw new AuthenticationFailedException("The secret key file failed validation. File name is invalid.");
            }
            // if the current platform is windows check that the file is in the path %ProgramData%\AzureConnectedMachineAgent\Tokens
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                var programData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var expectedPath = Path.Combine(programData, "AzureConnectedMachineAgent", "Tokens");
                if (!filePath.StartsWith(expectedPath))
                {
                    throw new AuthenticationFailedException("The secret key file failed validation. File path is invalid.");
                }
            }

            // if the current platform is linux check that the file is in the path /var/opt/azcmagent/tokens
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                var expectedPath = Path.Combine("/", "var", "opt", "azcmagent", "tokens");
                if (!filePath.StartsWith(expectedPath))
                {
                    throw new AuthenticationFailedException("The secret key file failed validation. File path is invalid.");
                }
            }

            // Check that the file length is no larger than 4096 bytes
            if (new FileInfo(filePath).Length > 4096)
            {
                throw new AuthenticationFailedException("The secret key file failed validation. File is too large.");
            }
        }
    }
}
