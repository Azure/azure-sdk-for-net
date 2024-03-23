// Copyright (c) Microsoft Corporation. All rights reserved.
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
        private static readonly Uri s_imdsEndpoint = new Uri("http://169.254.169.254/metadata/identity/oauth2/token");
        internal const string imddsTokenPath = "/metadata/identity/oauth2/token";

        private const string ImdsApiVersion = "2018-02-01";

        internal const string IdentityUnavailableError = "ManagedIdentityCredential authentication unavailable. The requested identity has not been assigned to this resource.";
        internal const string NoResponseError = "ManagedIdentityCredential authentication unavailable. No response received from the managed identity endpoint.";
        internal const string TimeoutError = "ManagedIdentityCredential authentication unavailable. The request to the managed identity endpoint timed out.";
        internal const string GatewayError = "ManagedIdentityCredential authentication unavailable. The request failed due to a gateway error.";
        internal const string AggregateError = "ManagedIdentityCredential authentication unavailable. Multiple attempts failed to obtain a token from the managed identity endpoint.";

        private readonly string _clientId;
        private readonly string _resourceId;
        private readonly Uri _imdsEndpoint;

        private TimeSpan? _imdsNetworkTimeout;

        internal ImdsManagedIdentitySource(ManagedIdentityClientOptions options) : base(options.Pipeline)
        {
            _clientId = options.ClientId;
            _resourceId = options.ResourceIdentifier?.ToString();
            _imdsNetworkTimeout = options.InitialImdsConnectionTimeout;

            if (!string.IsNullOrEmpty(EnvironmentVariables.PodIdentityEndpoint))
            {
                var builder = new UriBuilder(EnvironmentVariables.PodIdentityEndpoint);
                builder.Path = imddsTokenPath;
                _imdsEndpoint = builder.Uri;
            }
            else
            {
                _imdsEndpoint = s_imdsEndpoint;
            }
        }

        protected override Request CreateRequest(string[] scopes)
        {
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = Pipeline.HttpPipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Headers.Add("Metadata", "true");
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

            message.NetworkTimeout = _imdsNetworkTimeout;

            return message;
        }

        public async override ValueTask<AccessToken> AuthenticateAsync(bool async, TokenRequestContext context, CancellationToken cancellationToken)
        {
            try
            {
                return await base.AuthenticateAsync(async, context, cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException e) when (e.Status == 200)
            {
                // This is a rare case where the request times out but the response was successful.
                throw new RequestFailedException("Response from IMDS was successful, but the operation timed out prior to completion.", e.InnerException);
            }
            catch (RequestFailedException e) when (e.Status == 0)
            {
                throw new CredentialUnavailableException(NoResponseError, e);
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
        }

        protected override async ValueTask<AccessToken> HandleResponseAsync(bool async, TokenRequestContext context, Response response, CancellationToken cancellationToken)
        {
            // if we got a response from IMDS we can stop limiting the network timeout
            _imdsNetworkTimeout = null;

            // handle error status codes indicating managed identity is not available
            var baseMessage = response.Status switch
            {
                400 => IdentityUnavailableError,
                502 => GatewayError,
                504 => GatewayError,
                _ => default(string)
            };

            if (baseMessage != null)
            {
                string message = new RequestFailedException(response, null, new ImdsRequestFailedDetailsParser(baseMessage)).Message;

                var errorContentMessage = await GetMessageFromResponse(response, async, cancellationToken).ConfigureAwait(false);

                if (errorContentMessage != null)
                {
                    message = message + Environment.NewLine + errorContentMessage;
                }

                throw new CredentialUnavailableException(message);
            }

            return await base.HandleResponseAsync(async, context, response, cancellationToken).ConfigureAwait(false);
        }

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
    }
}
