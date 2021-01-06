// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.MixedReality.Authentication
{
    /// <summary>
    /// Represents the Mixed Reality STS client for retrieving STS tokens used to access Mixed Reality services.
    /// </summary>
    public class MixedRealityStsClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;

        private readonly HttpPipeline _pipeline;

        private readonly MixedRealityStsRestClient _restClient;

        /// <summary>
        /// Gets the Mixed Reality service account identifier.
        /// </summary>
        public string AccountId { get; }

        /// <summary>
        /// The Mixed Reality STS service endpoint.
        /// </summary>
        public Uri Endpoint { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRealityStsClient" /> class.
        /// </summary>
        /// <param name="accountId">The Mixed Reality service account identifier.</param>
        /// <param name="accountDomain">The Mixed Reality service account domain.</param>
        /// <param name="keyCredential">The Mixed Reality service account primary or secondary key credential.</param>
        /// <param name="options">The options.</param>
        public MixedRealityStsClient(string accountId, string accountDomain, AzureKeyCredential keyCredential, MixedRealityStsClientOptions? options = null)
            : this(accountId, ConstructStsEndpointUrl(accountDomain), new MixedRealityAccountKeyCredential(accountId, keyCredential), options) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRealityStsClient" /> class.
        /// </summary>
        /// <param name="accountId">The Mixed Reality service account identifier.</param>
        /// <param name="endpoint">The Mixed Reality STS service endpoint.</param>
        /// <param name="keyCredential">The Mixed Reality service account primary or secondary key credential.</param>
        /// <param name="options">The options.</param>
        public MixedRealityStsClient(string accountId, Uri endpoint, AzureKeyCredential keyCredential, MixedRealityStsClientOptions? options = null)
            : this(accountId, endpoint, new MixedRealityAccountKeyCredential(accountId, keyCredential), options) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRealityStsClient" /> class.
        /// </summary>
        /// <param name="accountId">The Mixed Reality service account identifier.</param>
        /// <param name="accountDomain">The Mixed Reality service account domain.</param>
        /// <param name="credential">The credential used to access the Mixed Reality service.</param>
        /// <param name="options">The options.</param>
        public MixedRealityStsClient(string accountId, string accountDomain, TokenCredential credential, MixedRealityStsClientOptions? options = null)
            : this(accountId, ConstructStsEndpointUrl(accountDomain), credential, options) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRealityStsClient" /> class.
        /// </summary>
        /// <param name="accountId">The Mixed Reality service account identifier.</param>
        /// <param name="endpoint">The Mixed Reality STS service endpoint.</param>
        /// <param name="credential">The credential used to access the Mixed Reality service.</param>
        /// <param name="options">The options.</param>
        public MixedRealityStsClient(string accountId, Uri endpoint, TokenCredential credential, MixedRealityStsClientOptions? options = null)
        {
            Argument.AssertNotNull(accountId, nameof(accountId));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new MixedRealityStsClientOptions();

            AccountId = accountId;
            Endpoint = endpoint;
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, GetDefaultScope(endpoint)));
            _restClient = new MixedRealityStsRestClient(_clientDiagnostics, _pipeline, endpoint, options.Version);
        }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRealityStsClient"/> class.
        /// </summary>
        /// <remarks>
        /// Required for mocking.
        /// </remarks>
        protected MixedRealityStsClient()
        {
        }

#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

        /// <summary>
        /// Retrieve a token from the STS service for the specified account identifier.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><see cref="Response{AccessToken}"/>.</returns>
        public virtual Response<AccessToken> GetToken(CancellationToken cancellationToken = default)
        {
            MixedRealityTokenRequestOptions headerOptions = MixedRealityTokenRequestOptions.GenerateNew();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MixedRealityStsClient)}.{nameof(GetToken)}");
            scope.AddAttribute(nameof(headerOptions.ClientRequestId), headerOptions.ClientRequestId);
            scope.Start();

            try
            {
                ResponseWithHeaders<StsTokenResponseMessage, MixedRealityStsGetTokenHeaders> response = _restClient.GetToken(AccountId, headerOptions, cancellationToken);

                return ResponseWithHeaders.FromValue(response.Value.ToAccessToken(), response.Headers, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieve a token from the STS service for the specified account identifier asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><see cref="Response{AccessToken}"/>.</returns>
        public virtual async Task<Response<AccessToken>> GetTokenAsync(CancellationToken cancellationToken = default)
        {
            MixedRealityTokenRequestOptions headerOptions = MixedRealityTokenRequestOptions.GenerateNew();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MixedRealityStsClient)}.{nameof(GetToken)}");
            scope.AddAttribute(nameof(headerOptions.ClientRequestId), headerOptions.ClientRequestId);
            scope.Start();

            try
            {
                ResponseWithHeaders<StsTokenResponseMessage, MixedRealityStsGetTokenHeaders> response = await _restClient.GetTokenAsync(AccountId, headerOptions, cancellationToken).ConfigureAwait(false);

                return ResponseWithHeaders.FromValue(response.Value.ToAccessToken(), response.Headers, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        internal static Uri ConstructStsEndpointUrl(string accountDomain)
        {
            Argument.AssertNotNullOrWhiteSpace(accountDomain, nameof(accountDomain));

            if (!Uri.TryCreate($"https://sts.{accountDomain}", UriKind.Absolute, out Uri result))
            {
                throw new ArgumentException("The value could not be used to construct a valid endpoint.", nameof(accountDomain));
            }

            return result;
        }

        private static string GetDefaultScope(Uri uri)
            => $"{uri.GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped)}/.default";
    }
}
