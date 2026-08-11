// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Net;
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
        private readonly HttpPipelinePolicy _fallbackAuthPolicy;
        private readonly SessionProvider _sessionProvider;
        private readonly SessionOptions _sessionOptions;

        public SessionAuthenticationPolicy(
            HttpPipelinePolicy fallbackAuthPolicy,
            SessionProvider sessionProvider,
            SessionOptions sessionOptions)
        {
            _fallbackAuthPolicy = fallbackAuthPolicy ?? throw Errors.ArgumentNull(nameof(fallbackAuthPolicy));
            _sessionProvider = sessionProvider ?? throw Errors.ArgumentNull(nameof(sessionProvider));
            _sessionOptions = sessionOptions?.Clone() ?? new SessionOptions();
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
            AuthState state = AnalyzeRequest(message);

            // 2. Attempt request with session authentication (if eligible).
            SessionProvider.SessionTokenInfo sentWith = default;
            if (state == AuthState.UseSessionToken)
            {
                (state, sentWith) = await TryAcquireSignAndSendAsync(message, pipeline, async).ConfigureAwait(false);
            }

            // 3. Handle the session response (may signal fallback to bearer-token).
            if (state == AuthState.SentWithSession)
            {
                state = HandleSessionResponse(message, sentWith);
            }

            // 4. Fallback to bearer-token (if eligible).
            if (state == AuthState.UseBearerToken)
            {
                if (async)
                {
                    await _fallbackAuthPolicy.ProcessAsync(message, pipeline).ConfigureAwait(false);
                }
                else
                {
                    _fallbackAuthPolicy.Process(message, pipeline);
                }
            }
        }

        /// <summary>
        /// Analyzes the request to determine whether a session token or bearer token should be used.
        /// When <see cref="SessionMode.Disabled"/>, all requests fall back to bearer token. Otherwise
        /// eligibility is delegated to <see cref="SessionProvider.IsRequestEligible"/>.
        /// </summary>
        /// <returns>
        /// <see cref="AuthState.UseSessionToken"/> if the request is eligible for session-token
        /// authentication; <see cref="AuthState.UseBearerToken"/> otherwise.
        /// </returns>
        private AuthState AnalyzeRequest(HttpMessage message)
        {
            // Check if Sessions is disabled.
            if (_sessionOptions.SessionMode.ResolveAuto() == SessionMode.Disabled)
            {
                return AuthState.UseBearerToken;
            }

            return _sessionProvider.IsRequestEligible(message)
                ? AuthState.UseSessionToken
                : AuthState.UseBearerToken;
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
        /// session token that was used to sign the request.
        /// The token is default when the state is <see cref="AuthState.UseBearerToken"/>.
        /// </returns>
        private async ValueTask<(AuthState State, SessionProvider.SessionTokenInfo SentWith)> TryAcquireSignAndSendAsync(
            HttpMessage message,
            ReadOnlyMemory<HttpPipelinePolicy> pipeline,
            bool async)
        {
            SessionProvider.SessionTokenInfo sessionInfo = await _sessionProvider.GetSessionAsync(message, async).ConfigureAwait(false);
            if (sessionInfo.IsFallbackToBearer)
            {
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
        /// Classifies the session-authenticated response.
        /// </summary>
        /// <returns>
        /// <see cref="AuthState.SentWithSession"/> to return the response as-is;
        /// <see cref="AuthState.UseBearerToken"/> to fall back to bearer auth.
        /// </returns>
        private AuthState HandleSessionResponse(HttpMessage message, SessionProvider.SessionTokenInfo sentWith)
        {
            int statusCode = message.Response.Status;

            // --- 401 Unauthorized ---
            if (statusCode == (int)HttpStatusCode.Unauthorized)
            {
                // Dispose the content stream to free up a connection before re-sending.
                message.Response.ContentStream?.Dispose();

                // Remove the session-scheme Authorization header and the signing date so
                // they don't leak into the bearer token attempt.
                ClearSessionAuthHeaders(message);

                // Only clear the cache if it still holds the token we just used.
                // The next request will re-acquire a fresh session.
                _sessionProvider.InvalidateSession(message, sentWith);

                // Signal to fall back to bearer token for this request.
                return AuthState.UseBearerToken;
            }

            return AuthState.SentWithSession;
        }

        /// <summary>
        /// Signs the request using the same Shared Key protocol as
        /// <see cref="StorageSharedKeyPipelinePolicy"/>, then sets the
        /// Authorization header with the Session scheme.
        /// </summary>
        private void SignRequestAndSetAuthHeader(HttpMessage message, SessionProvider.SessionTokenInfo sessionInfo)
        {
            string accountName = _sessionOptions.AccountName;
            if (string.IsNullOrEmpty(accountName))
            {
                // Fall back to deriving the account name from the request URL.
                accountName = new BlobUriBuilder(message.Request.Uri.ToUri()).AccountName;
                if (string.IsNullOrEmpty(accountName))
                {
                    throw BlobErrors.AccountNameRequiredForSessionSigning();
                }
            }

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
        /// Removes the headers set by <see cref="SignRequestAndSetAuthHeader"/> so a
        /// subsequent authentication attempt starts from a clean request.
        /// </summary>
        private static void ClearSessionAuthHeaders(HttpMessage message)
        {
            message.Request.Headers.Remove(HttpHeader.Names.Authorization);
            message.Request.Headers.Remove(Constants.HeaderNames.Date);
        }

        /// <summary>
        /// Represents the authentication state of the request as it moves through
        /// <see cref="ProcessInternal"/>. Each step transitions the state toward
        /// a final value of <see cref="SentWithSession"/> or <see cref="UseBearerToken"/>.
        /// </summary>
        private enum AuthState
        {
            /// <summary>Caller should attempt session-token authentication for this request.</summary>
            UseSessionToken,

            /// <summary>Request was sent with a session token; response is on the message.</summary>
            SentWithSession,

            /// <summary>Caller should invoke the bearer token policy for this request.</summary>
            UseBearerToken,
        }
    }
}
