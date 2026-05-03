// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
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
    /// <see cref="BearerTokenAuthenticationPolicy"/>. When <see cref="SessionMode.Enabled"/>,
    /// eligible blob download requests are authenticated with a session token (one cache entry
    /// per container, created on first access). When <see cref="SessionMode.Disabled"/>,
    /// all requests are delegated to the wrapped bearer token policy.
    /// </summary>
    internal class SessionAuthenticationPolicy : HttpPipelinePolicy
    {
        private readonly HttpPipelinePolicy _bearerTokenPolicy;
        private readonly Func<BlobServiceClient> _blobServiceClientFactory;
        private readonly SessionOptions _sessionOptions;

        /// <summary>
        /// Per-container session cache. One entry is created per container on first
        /// access when <see cref="SessionMode.Enabled"/>.
        /// </summary>
        private readonly ConcurrentDictionary<string, AutoRefreshingCache<SessionTokenInfo>> _sessionCaches
            = new ConcurrentDictionary<string, AutoRefreshingCache<SessionTokenInfo>>(StringComparer.OrdinalIgnoreCase);

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
        private const string SessionSchemeNotSupported = "Authentication scheme Session is not supported.";

        public SessionAuthenticationPolicy(
            HttpPipelinePolicy bearerTokenPolicy,
            Func<BlobServiceClient> blobServiceClientFactory,
            SessionOptions sessionOptions)
        {
            _bearerTokenPolicy = bearerTokenPolicy ?? throw Errors.ArgumentNull(nameof(bearerTokenPolicy));
            _blobServiceClientFactory = blobServiceClientFactory ?? throw Errors.ArgumentNull(nameof(blobServiceClientFactory));
            _sessionOptions = sessionOptions ?? new SessionOptions();

            // AccountName is required whenever sessions are used (needed to sign requests).
            if (_sessionOptions.SessionMode == SessionMode.Enabled
                && string.IsNullOrEmpty(_sessionOptions.AccountName))
            {
                throw BlobErrors.AccountNameRequiredForEnabledMode(sessionOptions);
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
            // 1. Analyze the request to determine eligibility for session authentication.
            AuthState state = AnalyzeRequest(message, out string containerName);

            SessionTokenInfo sentWith = default; // Tracks the token used in the most recent session request.

            // 2. Attempt first request with session authentication (if eligible).
            if (state == AuthState.UseSessionToken)
            {
                (state, sentWith) = await TryAcquireSignAndSendAsync(message, pipeline, async, containerName).ConfigureAwait(false);
            }

            // 3. Handle the first attempt's session response (may signal retry or fallback to bearer-token).
            if (state == AuthState.SentWithSession)
            {
                state = HandleFirstSessionResponse(message, containerName, sentWith);
            }

            // 4. Retry exactly one time (if eligible). Intentionally do not handle response on the retry.
            if (state == AuthState.UseSessionToken)
            {
                (state, sentWith) = await TryAcquireSignAndSendAsync(message, pipeline, async, containerName).ConfigureAwait(false);
            }

            // 5. Fallback to bearer-token (if eligible).
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
        /// When <see cref="SessionMode.Enabled"/>, any container is eligible for session-token
        /// authentication. When <see cref="SessionMode.Disabled"/>, all requests fall back to
        /// bearer token.
        /// </summary>
        /// <returns>
        /// <see cref="AuthState.UseSessionToken"/> if the request is eligible for session-token
        /// authentication; <see cref="AuthState.UseBearerToken"/> otherwise.
        /// </returns>
        private AuthState AnalyzeRequest(HttpMessage message, out string containerName)
        {
            containerName = null;

            // Check if Sessions is disabled.
            if (_sessionOptions.SessionMode == SessionMode.Disabled)
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
            if (!string.IsNullOrEmpty(uriBuilder.Query)
                && new UriQueryParamsCollection(uriBuilder.Query).ContainsKey(Constants.UriQueryParameters.Comp))
            {
                return AuthState.UseBearerToken;
            }

            containerName = uriBuilder.BlobContainerName;
            return AuthState.UseSessionToken;
        }

        /// <summary>
        /// Acquires a session token from the cache, signs the request, and sends
        /// it through the pipeline. If session acquisition fails with a service
        /// error, returns <see cref="AuthState.UseBearerToken"/> so the caller can
        /// re-issue the request via the bearer token policy.
        /// </summary>
        /// <returns>
        /// A tuple containing the resulting <see cref="AuthState"/> and, when the
        /// state is <see cref="AuthState.SentWithSession"/>, the
        /// <see cref="SessionTokenInfo"/> that was used to sign the request.
        /// The token is <c>default</c> when the state is
        /// <see cref="AuthState.UseBearerToken"/>.
        /// </returns>
        private async ValueTask<(AuthState State, SessionTokenInfo SentWith)> TryAcquireSignAndSendAsync(
            HttpMessage message,
            ReadOnlyMemory<HttpPipelinePolicy> pipeline,
            bool async,
            string containerName)
        {
            AutoRefreshingCache<SessionTokenInfo> cache = GetOrCreateCache(containerName);

            SessionTokenInfo sessionInfo;
            try
            {
                sessionInfo = await cache.GetAsync(async, message.CancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException ex) when (ShouldFallbackCreateSessionFailure(ex))
            {
                // Session creation failed with a service error — signal bearer fallback.
                return (AuthState.UseBearerToken, default);
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

            return (AuthState.SentWithSession, sessionInfo);
        }

        /// <summary>
        /// Classifies the first session-authenticated response. Not invoked for the retry's response.
        /// </summary>
        /// <returns>
        /// <see cref="AuthState.SentWithSession"/> to return the response as-is;
        /// <see cref="AuthState.UseBearerToken"/> to fall back to bearer auth;
        /// <see cref="AuthState.UseSessionToken"/> to re-acquire a session and retry once.
        /// </returns>
        private AuthState HandleFirstSessionResponse(HttpMessage message, string containerName, SessionTokenInfo sentWith)
        {
            int statusCode = message.Response.Status;

            // --- 401 Unauthorized ---
            if (statusCode == (int)HttpStatusCode.Unauthorized)
            {
                // Dispose the content stream to free up a connection before re-sending.
                message.Response.ContentStream?.Dispose();

                // Only clear the cache if it still holds the token we just used.
                GetOrCreateCache(containerName).InvalidateIfCurrent(sentWith);

                // Signal to retry with a new session token.
                return AuthState.UseSessionToken;
            }

            // --- 403 "Authentication scheme Session is not supported." ---
            if (statusCode == (int)HttpStatusCode.Forbidden
                && string.Equals(message.Response.ReasonPhrase, SessionSchemeNotSupported, StringComparison.OrdinalIgnoreCase))
            {
                // Dispose the content stream to free up a connection.
                message.Response.ContentStream?.Dispose();

                // Signal to fall back to bearer token.
                return AuthState.UseBearerToken;
            }

            // --- 503 SessionOperationsTemporarilyUnavailable ---
            if (statusCode == (int)HttpStatusCode.ServiceUnavailable
                && message.Response.Headers.TryGetValue(Constants.HeaderNames.ErrorCode, out string errorCode)
                && string.Equals(errorCode, SessionsUnavailable, StringComparison.OrdinalIgnoreCase))
            {
                // Dispose the content stream to free up a connection.
                message.Response.ContentStream?.Dispose();

                // Signal to fall back to bearer token.
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
        /// Returns the per-container cache, creating it on first access. The acquire
        /// delegate captures <paramref name="containerName"/> so each cache only
        /// mints sessions for its own container.
        /// </summary>
        private AutoRefreshingCache<SessionTokenInfo> GetOrCreateCache(string containerName)
        {
            return _sessionCaches.GetOrAdd(
                containerName,
                name => new AutoRefreshingCache<SessionTokenInfo>(
                    acquire: (async, ct) => AcquireSessionAsync(name, async, ct),
                    backgroundAcquireTimeout: BackgroundAcquireTimeout));
        }

        /// <summary>
        /// Acquire delegate called by <see cref="AutoRefreshingCache{TValue}"/> to create
        /// a new session via the Container REST API.
        /// </summary>
        private async ValueTask<SessionTokenInfo> AcquireSessionAsync(
            string containerName, bool async, CancellationToken cancellationToken)
        {
            BlobContainerClient containerClient = _blobServiceClientFactory().GetBlobContainerClient(containerName);
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

            // Set x-ms-date header (same as StorageSharedKeyPipelinePolicy does).
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
        internal readonly struct SessionTokenInfo : IExpiringValue, IEquatable<SessionTokenInfo>
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

            public bool Equals(SessionTokenInfo other) =>
                string.Equals(SessionToken, other.SessionToken);
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
