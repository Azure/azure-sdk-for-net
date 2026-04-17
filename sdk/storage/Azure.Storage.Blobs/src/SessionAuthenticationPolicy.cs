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

        private const string CreateNewSession = "Please create a new session";
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

            if (_sessionOptions.SessionMode == SessionMode.SingleContainer
                && string.IsNullOrEmpty(_sessionOptions.AccountName))
            {
                throw new ArgumentException(
                    $"{nameof(SessionOptions.AccountName)} must be set when {nameof(SessionOptions.SessionMode)} is {nameof(SessionMode.SingleContainer)}.",
                    nameof(sessionOptions));
            }

            if (_sessionOptions.SessionMode == SessionMode.SingleContainer
                && string.IsNullOrEmpty(_sessionOptions.ContainerName))
            {
                throw new ArgumentException(
                    $"{nameof(SessionOptions.ContainerName)} must be set when {nameof(SessionOptions.SessionMode)} is {nameof(SessionMode.SingleContainer)}.",
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
            AuthStrategy strategy = AnalyzeRequest(message);

            if (strategy == AuthStrategy.UseBearerToken)
            {
                // Delegate to the bearer token policy which will authenticate and call ProcessNext.
                if (async)
                {
                    await _bearerTokenPolicy.ProcessAsync(message, pipeline).ConfigureAwait(false);
                }
                else
                {
                    _bearerTokenPolicy.Process(message, pipeline);
                }
                return;
            }

            // Acquire session, sign, and send. Falls back to bearer token if
            // session acquisition fails with service error (other errors will propagate).
            if (!await TryGetSessionAndSendAsync(message, pipeline, async).ConfigureAwait(false))
            {
                // If fallen back to bearer token
                return;
            }

            // Handle the response from the session-authenticated request.
            await HandleSessionResponseAsync(message, pipeline, async).ConfigureAwait(false);
        }

        /// <summary>
        /// Analyzes the request to determine whether a session token or bearer token should be used.
        /// Session tokens are only used for blob GET operations in <see cref="SessionMode.SingleContainer"/>
        /// mode targeting the configured container.
        /// </summary>
        private AuthStrategy AnalyzeRequest(HttpMessage message)
        {
            // Check if Sessions is disabled.
            if (_sessionOptions.SessionMode == SessionMode.None)
            {
                return AuthStrategy.UseBearerToken;
            }

            // Only GET blob requests are eligible for session tokens.
            if (message.Request.Method != RequestMethod.Get)
            {
                return AuthStrategy.UseBearerToken;
            }

            BlobUriBuilder uriBuilder = new BlobUriBuilder(message.Request.Uri.ToUri());

            // Service-level request (no container in path).
            if (string.IsNullOrEmpty(uriBuilder.BlobContainerName))
            {
                return AuthStrategy.UseBearerToken;
            }

            // Container-level request (no blob in path).
            if (string.IsNullOrEmpty(uriBuilder.BlobName))
            {
                return AuthStrategy.UseBearerToken;
            }

            // Only the configured container is eligible for session tokens.
            if (!string.Equals(uriBuilder.BlobContainerName, _sessionOptions.ContainerName, StringComparison.InvariantCultureIgnoreCase))
            {
                return AuthStrategy.UseBearerToken;
            }

            return AuthStrategy.UseSessionToken;
        }

        /// <summary>
        /// Acquires a session token from the cache, signs the request, and sends
        /// it through the pipeline.  If session acquisition fails with a
        /// service error (5xx, 403, or 400/FeatureNotEnabled), falls back to
        /// bearer token authentication instead.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the request was sent with a session token and the
        /// response should be inspected by the caller; <c>false</c> if bearer
        /// fallback was used and no further session handling is needed.
        /// </returns>
        private async ValueTask<bool> TryGetSessionAndSendAsync(
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
                // Session creation failed with service error — fall back to bearer token.
                if (async)
                {
                    await _bearerTokenPolicy.ProcessAsync(message, pipeline).ConfigureAwait(false);
                }
                else
                {
                    _bearerTokenPolicy.Process(message, pipeline);
                }
                return false;
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

            return true;
        }

        /// <summary>
        /// Inspects the response after a request was sent with a session token and takes
        /// the appropriate action based on the status code and response headers.
        /// </summary>
        private async ValueTask HandleSessionResponseAsync(
            HttpMessage message,
            ReadOnlyMemory<HttpPipelinePolicy> pipeline,
            bool async)
        {
            int statusCode = message.Response.Status;

            // --- 401 Unauthorized ("Please create a new session") ---
            if (statusCode == (int)HttpStatusCode.Unauthorized
                && message.Response.Headers.TryGetValue(HttpHeader.Names.WwwAuthenticate, out string wwwAuth))
            {
                if (wwwAuth.IndexOf(CreateNewSession, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    // Invalidate cache and retry
                    _sessionCache.Invalidate();
                    await TryGetSessionAndSendAsync(message, pipeline, async).ConfigureAwait(false);
                }
                return;
            }

            // --- 503 SessionOperationsTemporarilyUnavailable ---
            if (statusCode == (int)HttpStatusCode.ServiceUnavailable
                && message.Response.Headers.TryGetValue(Constants.HeaderNames.ErrorCode, out string errorCode)
                && string.Equals(errorCode, SessionsUnavailable, StringComparison.OrdinalIgnoreCase))
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

        private static bool ShouldFallbackCreateSessionFailure(RequestFailedException ex) =>
            ex.Status >= (int)HttpStatusCode.InternalServerError
            || ex.Status == (int)HttpStatusCode.Forbidden
            || (ex.Status == (int)HttpStatusCode.BadRequest
                && string.Equals(ex.ErrorCode, FeatureNotEnabled, StringComparison.InvariantCultureIgnoreCase));

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

        private enum AuthStrategy
        {
            UseBearerToken,
            UseSessionToken
        }
    }
}
