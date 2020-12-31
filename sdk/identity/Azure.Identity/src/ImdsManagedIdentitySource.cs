// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    internal class ImdsManagedIdentitySource : ManagedIdentitySource
    {
        // IMDS constants. Docs for IMDS are available here https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/how-to-use-vm-token#get-a-token-using-http
        private static readonly Uri s_imdsEndpoint = new Uri("http://169.254.169.254/metadata/identity/oauth2/token");
        private static readonly IPAddress s_imdsHostIp = IPAddress.Parse("169.254.169.254");
        private const int s_imdsPort = 80;
        private const int ImdsAvailableTimeoutMs = 1000;
        private const string ImdsApiVersion = "2018-02-01";

        internal const string IdentityUnavailableError = "ManagedIdentityCredential authentication unavailable. The requested identity has not been assigned to this resource.";

        private readonly string _clientId;

        private string _identityUnavailableErrorMessage;

        public static async ValueTask<ManagedIdentitySource> TryCreateAsync(ManagedIdentityClientOptions options, bool async, CancellationToken cancellationToken)
        {
            AzureIdentityEventSource.Singleton.ProbeImdsEndpoint(s_imdsEndpoint);

            bool available;
            // try to create a TCP connection to the IMDS IP address. If the connection can be established
            // we assume that IMDS is available. If connecting times out or fails to connect assume that
            // IMDS is not available in this environment.
            try
            {
                using var client = new TcpClient();
                Task connectTask = client.ConnectAsync(s_imdsHostIp, s_imdsPort);

                if (async)
                {
                    using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

                    cts.CancelAfter(ImdsAvailableTimeoutMs);
                    await connectTask.AwaitWithCancellation(cts.Token);
                    available = client.Connected;
                }
                else
                {
                    available = connectTask.Wait(ImdsAvailableTimeoutMs, cancellationToken) && client.Connected;
                }
            }
            catch
            {
                available = false;
            }

            if (available)
            {
                AzureIdentityEventSource.Singleton.ImdsEndpointFound(s_imdsEndpoint);
            }
            else
            {
                AzureIdentityEventSource.Singleton.ImdsEndpointUnavailable(s_imdsEndpoint);
            }

            return available ? new ImdsManagedIdentitySource(options.Pipeline, options.ClientId) : default;
        }

        internal ImdsManagedIdentitySource(CredentialPipeline pipeline, string clientId) : base(pipeline)
        {
            _clientId = clientId;
        }

        protected override Request CreateRequest(string[] scopes)
        {
            if (_identityUnavailableErrorMessage != default)
            {
                throw new CredentialUnavailableException(_identityUnavailableErrorMessage);
            }

            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = Pipeline.HttpPipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Headers.Add("Metadata", "true");
            request.Uri.Reset(s_imdsEndpoint);
            request.Uri.AppendQuery("api-version", ImdsApiVersion);

            request.Uri.AppendQuery("resource", resource);

            if (!string.IsNullOrEmpty(_clientId))
            {
                request.Uri.AppendQuery("client_id", _clientId);
            }

            return request;
        }

        protected override async ValueTask<AccessToken> HandleResponseAsync(bool async, TokenRequestContext context, Response response, CancellationToken cancellationToken)
        {
            if (response.Status == 400)
            {
                string message = _identityUnavailableErrorMessage ?? await Pipeline.Diagnostics
                    .CreateRequestFailedMessageAsync(response, IdentityUnavailableError, null, null, async)
                    .ConfigureAwait(false);

                Interlocked.CompareExchange(ref _identityUnavailableErrorMessage, message, null);
                throw new CredentialUnavailableException(message);
            }

            return await base.HandleResponseAsync(async, context, response, cancellationToken).ConfigureAwait(false);
        }
    }
}
