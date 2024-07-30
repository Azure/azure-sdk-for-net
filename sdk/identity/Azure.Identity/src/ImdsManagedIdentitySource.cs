﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity
{
    internal class ImdsManagedIdentitySource : ManagedIdentitySource
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

        private readonly string _clientId;
        private readonly string _resourceId;
        private readonly Uri _imdsEndpoint;
        private bool _isFirstRequest = true;
        private TimeSpan? _imdsNetworkTimeout;
        private bool _isChainedCredential;

        internal ImdsManagedIdentitySource(ManagedIdentityClientOptions options) : base(options.Pipeline)
        {
            _clientId = options.ClientId;
            _resourceId = options.ResourceIdentifier?.ToString();
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
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = Pipeline.HttpPipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            // Don't add the Metadata endpoint for the probe request
            if (!_isFirstRequest || !_isChainedCredential)
            {
                SetNonProbeRequest(request);
            }
            request.Uri.Reset(_imdsEndpoint);
            request.Uri.AppendQuery("api-version", ImdsApiVersion);

            request.Uri.AppendQuery("resource", resource);

            if (!string.IsNullOrEmpty(_clientId))
            {
                request.Uri.AppendQuery(Constants.ManagedIdentityClientId, _clientId);
            }
            if (!string.IsNullOrEmpty(_resourceId))
            {
                request.Uri.AppendQuery(Constants.ManagedIdentityResourceId, _resourceId);
            }

            return request;
        }

        protected override HttpMessage CreateHttpMessage(Request request)
        {
            HttpMessage message = base.CreateHttpMessage(request);

            if (_isFirstRequest && _isChainedCredential)
            {
                message.NetworkTimeout = _imdsNetworkTimeout;
            }

            return message;
        }

        public async override ValueTask<AccessToken> AuthenticateAsync(bool async, TokenRequestContext context, CancellationToken cancellationToken)
        {
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
                // Re-issue the request (CreateRequest will add the appropriate header).
                return await base.AuthenticateAsync(async, context, cancellationToken).ConfigureAwait(false);
            }
        }

        protected override async ValueTask<AccessToken> HandleResponseAsync(bool async, TokenRequestContext context, HttpMessage message, CancellationToken cancellationToken)
        {
            Response response = message.Response;
            // if we got a response from IMDS we can stop limiting the network timeout
            _imdsNetworkTimeout = null;

            // Mark that the first request has been made
            _isFirstRequest = false;

            // handle error status codes indicating managed identity is not available
            string baseMessage = response.Status switch
            {
                400 when IsProbRequest(message) => throw new ProbeRequestResponseException(),
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

        public static bool IsProbRequest(HttpMessage message)
            => message.Request.Uri.Host == s_imdsEndpoint.Host &&
                message.Request.Uri.Path == s_imdsEndpoint.AbsolutePath &&
                !message.Request.Headers.TryGetValue(metadataHeaderName, out _);

        public static void SetNonProbeRequest(Request request)
            => request.Headers.Add(metadataHeaderName, "true");

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
