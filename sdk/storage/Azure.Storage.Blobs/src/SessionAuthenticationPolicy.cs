// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// A pipeline policy that selects between session token and bearer token authentication.
    /// This policy occupies the authentication policy slot in the pipeline, wrapping the
    /// <see cref="BearerTokenAuthenticationPolicy"/>. For eligible blob GET requests targeting
    /// the cached container, the policy authenticates with a session token. For all other
    /// requests, it delegates to the wrapped bearer token policy.
    /// </summary>
    internal class SessionAuthenticationPolicy : HttpPipelinePolicy
    {
        private readonly HttpPipelinePolicy _bearerTokenPolicy;
        private readonly Func<BlobServiceClient> _blobServiceClientFactory;
        private readonly SessionOptions _sessionOptions;
        private readonly AutoRefreshingCache<SessionTokenInfo> _sessionCache;

        /// <summary>
        /// Buffer before <see cref="SessionTokenInfo.ExpiresOn"/> at which a proactive
        /// background refresh is initiated.
        /// </summary>
        private static readonly TimeSpan SessionRefreshBuffer = TimeSpan.FromSeconds(30);

        /// <summary>
        /// Maximum time allowed for a background session refresh before falling back
        /// to the current (still-valid) session token.
        /// </summary>
        private static readonly TimeSpan BackgroundAcquireTimeout = TimeSpan.FromSeconds(30);

        private const string SessionsUnavailable = "SessionOperationsTemporarilyUnavailable";
        private const string FeatureNotEnabled = "FeatureNotEnabled";

        public SessionAuthenticationPolicy(
            HttpPipelinePolicy bearerTokenPolicy,
            Func<BlobServiceClient> blobServiceClientFactory,
            SessionOptions sessionOptions)
        {
            _bearerTokenPolicy = bearerTokenPolicy ?? throw Errors.ArgumentNull(nameof(bearerTokenPolicy));
            _blobServiceClientFactory = blobServiceClientFactory ?? throw Errors.ArgumentNull(nameof(blobServiceClientFactory));
            _sessionOptions = sessionOptions ?? new SessionOptions();

            _sessionCache = new AutoRefreshingCache<SessionTokenInfo>(
                acquire: AcquireSessionAsync,
                backgroundAcquireTimeout: BackgroundAcquireTimeout);

            if (_sessionOptions.SessionMode == SessionMode.SingleSpecifiedContainer
                && string.IsNullOrEmpty(_sessionOptions.AccountName))
            {
                throw new ArgumentException(
                    $"{nameof(SessionOptions.AccountName)} must be set when {nameof(SessionOptions.SessionMode)} is {nameof(SessionMode.SingleSpecifiedContainer)}.",
                    nameof(sessionOptions));
            }

            if (_sessionOptions.SessionMode == SessionMode.SingleSpecifiedContainer
                && string.IsNullOrEmpty(_sessionOptions.ContainerName))
            {
                throw new ArgumentException(
                    $"{nameof(SessionOptions.ContainerName)} must be set when {nameof(SessionOptions.SessionMode)} is {nameof(SessionMode.SingleSpecifiedContainer)}.",
                    nameof(sessionOptions));
            }
        }

        /// <inheritdoc />
        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            => ProcessInternal(message, pipeline, async: true);

        /// <inheritdoc />
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            => ProcessInternal(message, pipeline, async: false).EnsureCompleted();

        private async ValueTask ProcessInternal(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            AuthState state = AnalyzeRequest(message);

            // If session-eligible, try to acquire a session, sign, and send.
            if (state == AuthState.UseSessionToken)
            {
                state = await TryAcquireSignAndSendAsync(message, pipeline, async).ConfigureAwait(false);
            }

            // If the session-authenticated request was sent, inspect the response.
            if (state == AuthState.SentWithSession)
            {
                state = await HandleSessionResponseAsync(message, pipeline, async).ConfigureAwait(false);
            }

            // Fallback to bearer-token.
            if (state == AuthState.UseBearerToken)
            {
                if (async)
                {
                    await _bearerTokenPolicy.ProcessAsync(message, pipeline).ConfigureAwait(false);
                }
                else
                {
                    _bearerTokenPolicy.Process(message, pipeline);
                }
            }
        }

        /// <summary>
        /// Analyzes the request to determine whether a session token or bearer token should be used.
        /// Session tokens are only used for blob GET operations in <see cref="SessionMode.SingleSpecifiedContainer"/>
        /// mode targeting the configured container.
        /// </summary>
        /// <returns>
        /// <see cref="AuthState.UseSessionToken"/> if the request is eligible for session-token
        /// authentication (a GET against a blob in the configured container, with no comp
        /// query parameter, while in <see cref="SessionMode.SingleSpecifiedContainer"/> mode);
        /// <see cref="AuthState.UseBearerToken"/> otherwise.
        /// </returns>
        private AuthState AnalyzeRequest(HttpMessage message)
        {
            // Check if Sessions is disabled.
            if (_sessionOptions.SessionMode == SessionMode.None)
            {
                return AuthState.UseBearerToken;
            }

            // Only GET blob requests are eligible for session tokens.
            if (message.Request.Method != RequestMethod.Get)
            {
                return AuthState.UseBearerToken;
            }

            BlobUriBuilder uriBuilder = new BlobUriBuilder(message.Request.Uri.ToUri());

            // If Service-level request (no container in path).
            if (string.IsNullOrEmpty(uriBuilder.BlobContainerName))
            {
                return AuthState.UseBearerToken;
            }

            // If Container-level request (no blob in path).
            if (string.IsNullOrEmpty(uriBuilder.BlobName))
            {
                return AuthState.UseBearerToken;
            }

            // If request with a "comp" query parameter.
            if (uriBuilder.Query?.Contains("comp=") == true)
            {
                return AuthState.UseBearerToken;
            }

            // Only the configured container is eligible for session tokens.
            if (!string.Equals(uriBuilder.BlobContainerName, _sessionOptions.ContainerName, StringComparison.OrdinalIgnoreCase))
            {
                return AuthState.UseBearerToken;
            }

            return AuthState.UseSessionToken;
        }

        /// <summary>
        /// Acquires a session token from the cache, signs the request, and sends
        /// it through the pipeline. If session acquisition fails with a service
        /// error (5xx, 403, or 400/FeatureNotEnabled), returns
        /// <see cref="AuthState.UseBearerToken"/> so the caller can re-issue
        /// the request via the bearer token policy.
        /// </summary>
        /// <returns>
        /// <see cref="AuthState.SentWithSession"/> if the request was sent with a
        /// session token (response is on <paramref name="message"/>);
        /// <see cref="AuthState.UseBearerToken"/> if the caller should invoke
        /// the bearer token policy.
        /// </returns>
        private async ValueTask<AuthState> TryAcquireSignAndSendAsync(
            HttpMessage message,
            ReadOnlyMemory<HttpPipelinePolicy> pipeline,
            bool async)
        {
            SessionTokenInfo sessionInfo;
            try
            {
                sessionInfo = await _sessionCache.GetAsync(async, message.CancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException ex) when (ShouldFallbackCreateSessionFailure(ex))
            {
                // Session creation failed with a service error — signal bearer fallback.
                return AuthState.UseBearerToken;
            }

            SignRequestAndSetAuthHeader(message, sessionInfo);

            // Send the request with the session token.
            if (async)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
            }

            return AuthState.SentWithSession;
        }

        /// <summary>
        /// Inspects the response after a request was sent with a session token and takes
        /// the appropriate action based on the status code and response headers.
        /// </summary>
        /// <returns>
        /// <see cref="AuthState.SentWithSession"/> if no further action is required;
        /// <see cref="AuthState.UseBearerToken"/> if the caller should re-issue
        /// the request via the bearer token policy.
        /// </returns>
        private async ValueTask<AuthState> HandleSessionResponseAsync(
            HttpMessage message,
            ReadOnlyMemory<HttpPipelinePolicy> pipeline,
            bool async)
        {
            int statusCode = message.Response.Status;

            // --- 401 Unauthorized ---
            if (statusCode == (int)HttpStatusCode.Unauthorized)
            {
                // Invalidate cache and retry.
                _sessionCache.Invalidate();
                return await TryAcquireSignAndSendAsync(message, pipeline, async).ConfigureAwait(false);
            }

            // --- 503 SessionOperationsTemporarilyUnavailable ---
            if (statusCode == (int)HttpStatusCode.ServiceUnavailable
                && message.Response.Headers.TryGetValue(Constants.HeaderNames.ErrorCode, out string errorCode)
                && string.Equals(errorCode, SessionsUnavailable, StringComparison.OrdinalIgnoreCase))
            {
                // Fallback to bearer-token.
                return AuthState.UseBearerToken;
            }

            return AuthState.SentWithSession;
        }

        private static bool ShouldFallbackCreateSessionFailure(RequestFailedException ex) =>
            ex.Status >= (int)HttpStatusCode.InternalServerError
            || ex.Status == (int)HttpStatusCode.Forbidden
            || (ex.Status == (int)HttpStatusCode.BadRequest
                && string.Equals(ex.ErrorCode, FeatureNotEnabled, StringComparison.OrdinalIgnoreCase));

        /// <summary>
        /// Acquire delegate called by <see cref="AutoRefreshingCache{TValue}"/> to create
        /// a new session via the Container REST API.
        /// </summary>
        private async ValueTask<SessionTokenInfo> AcquireSessionAsync(bool async, CancellationToken cancellationToken)
        {
            BlobContainerClient containerClient = _blobServiceClientFactory().GetBlobContainerClient(_sessionOptions.ContainerName);
            CreateSessionConfiguration config = new CreateSessionConfiguration(AuthenticationType.Hmac);

            Response<CreateSessionResponse> response = async
                ? await containerClient.CreateSessionAsync(config: config, cancellationToken: cancellationToken).ConfigureAwait(false)
                : containerClient.CreateSession(config: config, cancellationToken: cancellationToken);

            CreateSessionResponse session = response.Value;
            DateTimeOffset expiresOn = session.Expiration ?? DateTimeOffset.UtcNow.AddMinutes(5);
            DateTimeOffset refreshOn = expiresOn - SessionRefreshBuffer;

            return new SessionTokenInfo(
                sessionToken: session.Credentials.SessionToken,
                sessionKey: session.Credentials.SessionKey,
                expiresOn: expiresOn,
                refreshOn: refreshOn);
        }

        /// <summary>
        /// Signs the request using the same Shared Key protocol as
        /// <see cref="StorageSharedKeyPipelinePolicy"/>, then sets the
        /// Authorization header with the Session scheme.
        /// </summary>
        private void SignRequestAndSetAuthHeader(HttpMessage message, SessionTokenInfo sessionInfo)
        {
            string accountName = _sessionOptions.AccountName;
            var credential = new StorageSharedKeyCredential(accountName, sessionInfo.SessionKey);
            var sharedKeyPolicy = new StorageSharedKeyPipelinePolicy(credential);

            // Set x-ms-date header (same as StorageSharedKeyPipelinePolicy.OnSendingRequest does).
            // This ensures that the string-to-sign is constructed with the correct date value.
            var date = DateTimeOffset.UtcNow.ToString("r", CultureInfo.InvariantCulture);
            message.Request.Headers.SetValue(Constants.HeaderNames.Date, date);

            // Build the string-to-sign and compute the HMAC signature directly.
            string stringToSign = sharedKeyPolicy.BuildStringToSign(message);
            string signature = StorageSharedKeyCredentialInternals.ComputeSasSignature(credential, stringToSign);

            message.Request.Headers.SetValue(
                HttpHeader.Names.Authorization,
                $"Session {sessionInfo.SessionToken}:{signature}");
        }

        /// <summary>
        /// Cached session token information returned by the Create Session API.
        /// </summary>
        internal readonly struct SessionTokenInfo : IExpiringValue
        {
            public string SessionToken { get; }
            public string SessionKey { get; }
            public DateTimeOffset ExpiresOn { get; }
            public DateTimeOffset RefreshOn { get; }

            public SessionTokenInfo(string sessionToken, string sessionKey, DateTimeOffset expiresOn, DateTimeOffset refreshOn)
            {
                SessionToken = sessionToken;
                SessionKey = sessionKey;
                ExpiresOn = expiresOn;
                RefreshOn = refreshOn;
            }

            public IExpiringValue WithRefreshOn(DateTimeOffset refreshOn) =>
                new SessionTokenInfo(SessionToken, SessionKey, ExpiresOn, refreshOn);
        }

        /// <summary>
        /// Represents the authentication state of the request as it moves through
        /// <see cref="ProcessInternal"/>. Each step transitions the state toward
        /// a final value of <see cref="SentWithSession"/> or <see cref="UseBearerToken"/>.
        /// </summary>
        private enum AuthState
        {
            /// <summary>Request is eligible for session-token auth; not yet attempted.</summary>
            UseSessionToken,

            /// <summary>Request was sent with a session token; response is on the message.</summary>
            SentWithSession,

            /// <summary>Caller should invoke the bearer token policy for this request.</summary>
            UseBearerToken,
        }
    }
}
