// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    internal class ImdsManagedIdentityProbeSource : ManagedIdentitySource
    {
        // IMDS constants. Docs for IMDS are available at https://learn.microsoft.com/entra/identity/managed-identities-azure-resources/how-to-use-vm-token#get-a-token-using-http
        internal static readonly Uri s_imdsEndpoint = new Uri("http://169.254.169.254/metadata/identity/oauth2/token");
        internal const string imddsTokenPath = "/metadata/identity/oauth2/token";
        internal const string metadataHeaderName = "Metadata";
        private const string ImdsApiVersion = "2018-02-01";

        internal const string IdentityUnavailableError = "ManagedIdentityCredential authentication unavailable. The requested identity has not been assigned to this resource.";
        internal const string NoResponseError = "ManagedIdentityCredential authentication unavailable. No response received from the managed identity endpoint.";
        internal const string TimeoutError = "ManagedIdentityCredential authentication unavailable. The request to the managed identity endpoint timed out.";
        internal const string GatewayError = "ManagedIdentityCredential authentication unavailable. The request failed due to a gateway error.";
        internal const string AggregateError = "ManagedIdentityCredential authentication unavailable. Multiple attempts failed to obtain a token from the managed identity endpoint.";
        internal const string UnknownError = "ManagedIdentityCredential authentication unavailable. An unexpected error has occurred.";

        private readonly ManagedIdentityId _managedIdentityId;
        private readonly Uri _imdsEndpoint;
        private TimeSpan? _imdsNetworkTimeout;
        private bool _isChainedCredential;
        private MsalManagedIdentityClient _client;

        internal ImdsManagedIdentityProbeSource(ManagedIdentityClientOptions options, MsalManagedIdentityClient client) : base(options.Pipeline)
        {
            _client = client;
            _managedIdentityId = options.ManagedIdentityId;
            _imdsNetworkTimeout = options.InitialImdsConnectionTimeout;
            _isChainedCredential = options.Options?.IsChainedCredential ?? false;
            _imdsEndpoint = GetImdsUri();
        }

        internal static Uri GetImdsUri()
        {
            if (!string.IsNullOrEmpty(EnvironmentVariables.PodIdentityEndpoint))
            {
                var builder = new UriBuilder(EnvironmentVariables.PodIdentityEndpoint)
                {
                    Path = imddsTokenPath
                };
                return builder.Uri;
            }
            else
            {
                return s_imdsEndpoint;
            }
        }

        protected override Request CreateRequest(string[] scopes)
        {
            // convert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = Pipeline.HttpPipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            // Don't add the Metadata endpoint for the probe request
            request.Uri.Reset(_imdsEndpoint);
            request.Uri.AppendQuery("api-version", ImdsApiVersion);

            request.Uri.AppendQuery("resource", resource);

            string idQueryParam = _managedIdentityId?._idType switch
            {
                ManagedIdentityIdType.ClientId => Constants.ManagedIdentityClientId,
                ManagedIdentityIdType.ResourceId => "msi-res-id",
                ManagedIdentityIdType.ObjectId => "object_id",
                _ => null
            };

            if (idQueryParam != null)
            {
                request.Uri.AppendQuery(idQueryParam, _managedIdentityId._userAssignedId);
            }

            return request;
        }

        protected override HttpMessage CreateHttpMessage(Request request)
        {
            HttpMessage message = base.CreateHttpMessage(request);

            if (_isChainedCredential)
            {
                message.NetworkTimeout = _imdsNetworkTimeout;
            }

            return message;
        }

        public async override ValueTask<AccessToken> AuthenticateAsync(bool async, TokenRequestContext context, CancellationToken cancellationToken)
        {
            bool continueIMDSRequestAfterProbe;
            try
            {
                return await base.AuthenticateAsync(async, context, cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException e) when (e.Status == 0)
            {
                if (e.InnerException is TaskCanceledException)
                {
                    throw;
                }
                else
                {
                    throw new CredentialUnavailableException(NoResponseError, e);
                }
            }
            catch (TaskCanceledException e)
            {
                throw new CredentialUnavailableException(NoResponseError, e);
            }
            catch (AggregateException e)
            {
                throw new CredentialUnavailableException(AggregateError, e);
            }
            catch (CredentialUnavailableException)
            {
                throw;
            }
            catch (ProbeRequestResponseException)
            {
                // This was an expected response from the IMDS endpoint without the Metadata header set.
                // Fall-through to the code below to re-issue the request through MsalManagedIdentityClient.
                continueIMDSRequestAfterProbe = true;
            }

            if (continueIMDSRequestAfterProbe)
            {
                try
                {
#pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                    var authResult = await _client.AcquireTokenForManagedIdentityAsync(context, cancellationToken).ConfigureAwait(false);
#pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                    return authResult.ToAccessToken();
                }
                catch (MsalServiceException e)
                {
                    if (e.Message.Contains("unavailable"))
                    {
                        throw new CredentialUnavailableException(IdentityUnavailableError, e);
                    }
                    throw new CredentialUnavailableException(UnknownError, e);
                }
            }
            throw new CredentialUnavailableException(UnknownError);
        }

        protected override async ValueTask<AccessToken> HandleResponseAsync(bool async, TokenRequestContext context, HttpMessage message, CancellationToken cancellationToken)
        {
            Response response = message.Response;
            // if we got a response from IMDS we can stop limiting the network timeout
            _imdsNetworkTimeout = null;

            // handle error status codes indicating managed identity is not available
            string baseMessage = response.Status switch
            {
                400 when IsRetriableProbeRequest(message) => throw new ProbeRequestResponseException(),
                400 => IdentityUnavailableError,
                502 => GatewayError,
                504 => GatewayError,
                _ => default
            };

            if (baseMessage != null)
            {
                string content = new RequestFailedException(response, null, new ImdsRequestFailedDetailsParser(baseMessage)).Message;

                var errorContentMessage = await GetMessageFromResponse(response, async, cancellationToken).ConfigureAwait(false);

                if (errorContentMessage != null)
                {
                    content = content + Environment.NewLine + errorContentMessage;
                }

                throw new CredentialUnavailableException(content);
            }

            var token = await base.HandleResponseAsync(async, context, message, cancellationToken).ConfigureAwait(false);
            return token;
        }

        public static bool IsRetriableProbeRequest(HttpMessage message)
            => message.Request.Uri.Host == s_imdsEndpoint.Host &&
                message.Request.Uri.Path == s_imdsEndpoint.AbsolutePath &&
                !message.Request.Headers.TryGetValue(metadataHeaderName, out _) &&
                (message.Response.Content?.ToString().IndexOf("Identity not found", StringComparison.InvariantCulture) < 0);

        public static bool IsProbRequest(HttpMessage message)
            => message.Request.Uri.Host == s_imdsEndpoint.Host &&
                message.Request.Uri.Path == s_imdsEndpoint.AbsolutePath &&
                !message.Request.Headers.TryGetValue(metadataHeaderName, out _);

        private class ImdsRequestFailedDetailsParser : RequestFailedDetailsParser
        {
            private readonly string _baseMessage;

            public ImdsRequestFailedDetailsParser(string baseMessage)
            {
                _baseMessage = baseMessage;
            }

            public override bool TryParse(Response response, out ResponseError error, out IDictionary<string, string> data)
            {
                error = new ResponseError(null, _baseMessage);
                data = null;
                return true;
            }
        }

        internal class ProbeRequestResponseException : Exception
        { }
    }
}
