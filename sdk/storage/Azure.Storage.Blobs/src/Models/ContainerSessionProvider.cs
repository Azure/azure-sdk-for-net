// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// A <see cref="SessionProvider"/> that mints session tokens using a
    /// <see cref="TokenCredential"/> (OAuth/bearer) and caches them per container.
    /// This provider is for <see cref="TokenCredential"/> authentication only; clients
    /// using shared key or SAS credentials do not use it.
    /// <para>
    /// The service URI passed to the constructor is expected to be a
    /// blob service endpoint (for example, https://{account}.blob.core.windows.net);
    /// session creation uses the blob Create Session API.
    /// </para>
    /// </summary>
    public class ContainerSessionProvider : SessionProvider
    {
        /// <summary>
        /// Buffer before the session's expiry at which a proactive background refresh is initiated.
        /// </summary>
        private static readonly TimeSpan SessionRefreshBuffer = TimeSpan.FromSeconds(30);

        /// <summary>
        /// Maximum time allowed for a background session refresh before falling back
        /// to the current (still-valid) session token.
        /// </summary>
        private static readonly TimeSpan BackgroundAcquireTimeout = TimeSpan.FromSeconds(30);

        /// <summary>
        /// Cooldown applied to the fallback-to-bearer sentinel after any fallback-eligible
        /// CreateSession failure (5xx, 403, or 400 FeatureNotEnabled).
        /// </summary>
        private static readonly TimeSpan FallbackCooldown = TimeSpan.FromMinutes(5);

        private const string FeatureNotEnabled = "FeatureNotEnabled";

        /// <summary>
        /// Per-container session cache. One entry is created per container on first access.
        /// </summary>
        private readonly ConcurrentDictionary<string, AutoRefreshingCache<SessionTokenInfo>> _sessionCaches
            = new ConcurrentDictionary<string, AutoRefreshingCache<SessionTokenInfo>>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// The single, session-free <see cref="BlobServiceClient"/> used to mint sessions.
        /// Built once (thread-safe) on first use and reused for the provider's lifetime.
        /// </summary>
        private readonly Lazy<BlobServiceClient> _serviceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerSessionProvider"/> class.
        /// </summary>
        /// <param name="serviceUri">
        /// A <see cref="Uri"/> belonging to the target storage account.
        /// The URI is reduced to the account's blob service endpoint, following
        /// this format: <c>https://{account}.blob.core.windows.net</c>.
        /// </param>
        /// <param name="credential">The token credential used to mint sessions.</param>
        /// <param name="options">
        /// Optional client options applied to the internal <see cref="BlobServiceClient"/>
        /// used to issue Create Session requests. When null, default options are used.
        /// </param>
        public ContainerSessionProvider(Uri serviceUri, TokenCredential credential, BlobClientOptions options = null)
        {
            if (serviceUri == null)
            {
                throw Errors.ArgumentNull(nameof(serviceUri));
            }
            if (credential == null)
            {
                throw Errors.ArgumentNull(nameof(credential));
            }
            Uri endpoint = GetServiceEndpoint(serviceUri);

            _serviceClient = new Lazy<BlobServiceClient>(
                () => CreateServiceClient(endpoint, credential, options),
                LazyThreadSafetyMode.ExecutionAndPublication);
        }

        /// <inheritdoc />
        internal override ValueTask<SessionTokenInfo> GetSessionAsync(HttpMessage message, bool async)
            => GetOrCreateCache(GetContainerName(message)).GetAsync(async, message.CancellationToken);

        /// <inheritdoc />
        internal override void InvalidateSession(HttpMessage message, SessionTokenInfo current)
            => GetOrCreateCache(GetContainerName(message)).InvalidateIfCurrent(current);

        /// <inheritdoc />
        internal override bool IsRequestEligible(HttpMessage message)
        {
            // Only GET blob requests are eligible for session tokens.
            if (message.Request.Method != RequestMethod.Get)
            {
                return false;
            }

            BlobUriBuilder uriBuilder = new BlobUriBuilder(message.Request.Uri.ToUri());

            // Service-level request (no container in path).
            if (string.IsNullOrEmpty(uriBuilder.BlobContainerName))
            {
                return false;
            }

            // Container-level request (no blob in path).
            if (string.IsNullOrEmpty(uriBuilder.BlobName))
            {
                return false;
            }

            // Request with a "comp" query parameter.
            if (!string.IsNullOrEmpty(uriBuilder.Query)
                && new UriQueryParamsCollection(uriBuilder.Query).ContainsKey(Constants.UriQueryParameters.Comp))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Reduces <paramref name="uri"/> to the account's blob service endpoint, discarding
        /// container and blob path segments along with every query-string component.
        /// </summary>
        private static Uri GetServiceEndpoint(Uri uri)
            => new BlobUriBuilder(uri)
            {
                BlobContainerName = null,
                BlobName = null,
                Snapshot = null,
                VersionId = null,
                Sas = null,
                Query = null,
            }.ToUri();

        /// <summary>
        /// Builds the <see cref="BlobServiceClient"/> used to issue Create Session
        /// requests, honoring the caller's <see cref="BlobClientOptions"/> when provided.
        /// Create Session is a container-level request and is never session-eligible,
        /// so the client's session configuration (if any) never affects this path.
        /// </summary>
        private static BlobServiceClient CreateServiceClient(
            Uri serviceUri, TokenCredential credential, BlobClientOptions options)
            => new BlobServiceClient(serviceUri, credential, options ?? new BlobClientOptions());

        /// <summary>
        /// Parses the container name that scopes the session cache from the request URI.
        /// </summary>
        private static string GetContainerName(HttpMessage message)
            => new BlobUriBuilder(message.Request.Uri.ToUri()).BlobContainerName;

        /// <summary>
        /// Returns the per-container cache, creating it on first access. The acquire
        /// delegate captures <paramref name="containerName"/> so each cache only
        /// mints sessions for its own container. The value factory is intentionally
        /// side-effect-free (it does not itself call CreateSession), so a benign race
        /// that constructs an extra cache object never causes a duplicate CreateSession.
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
        /// Acquire delegate called by <see cref="AutoRefreshingCache{TValue}"/> to create a
        /// new session via the Container REST API. Fallback-eligible failures are converted
        /// to a fallback-to-bearer sentinel.
        /// </summary>
        private async ValueTask<SessionTokenInfo> AcquireSessionAsync(
            string containerName, bool async, CancellationToken cancellationToken)
        {
            BlobContainerClient containerClient = _serviceClient.Value.GetBlobContainerClient(containerName);
            CreateSessionConfiguration config = new CreateSessionConfiguration(AuthenticationType.Hmac);

            Response<CreateSessionResponse> response;
            try
            {
                response = async
                    ? await containerClient.CreateSessionAsync(config: config, cancellationToken: cancellationToken).ConfigureAwait(false)
                    : containerClient.CreateSession(config: config, cancellationToken: cancellationToken);
            }
            catch (RequestFailedException ex) when (TryGetFallbackCooldown(ex, out TimeSpan cooldown))
            {
                return SessionTokenInfo.CreateFallbackToBearer(cooldown);
            }

            CreateSessionResponse session = response.Value;
            DateTimeOffset expiresOn = session.Expiration.Value;
            DateTimeOffset refreshOn = expiresOn - SessionRefreshBuffer;

            return new SessionTokenInfo(
                sessionToken: session.Credentials.SessionToken,
                sessionKey: session.Credentials.SessionKey,
                expiresOn: expiresOn,
                refreshOn: refreshOn,
                isFallbackToBearer: false);
        }

        /// <summary>
        /// Determines whether a CreateSession failure is eligible for fallback-to-bearer,
        /// and if so, the cooldown for which the fallback is cached. Transient server
        /// errors (5xx) and permission/feature-level failures (403, or 400 FeatureNotEnabled)
        /// all use the same cooldown.
        /// </summary>
        private static bool TryGetFallbackCooldown(RequestFailedException ex, out TimeSpan cooldown)
        {
            // 5xx, 403 Forbidden, or 400 FeatureNotEnabled -> fallback to bearer.
            if (ex.Status >= (int)HttpStatusCode.InternalServerError
                || ex.Status == (int)HttpStatusCode.Forbidden
                || (ex.Status == (int)HttpStatusCode.BadRequest
                    && string.Equals(ex.ErrorCode, FeatureNotEnabled, StringComparison.OrdinalIgnoreCase)))
            {
                cooldown = FallbackCooldown;
                return true;
            }

            cooldown = default;
            return false;
        }
    }
}
