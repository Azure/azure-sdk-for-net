// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// A policy that sends an <see cref="AccessToken"/> provided by a <see cref="TokenCredential"/> as an Authentication header.
    /// </summary>
    public class BearerTokenAuthenticationPolicy : HttpPipelinePolicy
    {
        private readonly TokenCredential _credential;

        private readonly string[] _scopes;

        private readonly AccessTokenCache _accessTokenCache;

        /// <summary>
        /// Creates a new instance of <see cref="BearerTokenAuthenticationPolicy"/> using provided token credential and scope to authenticate for.
        /// </summary>
        /// <param name="credential">The token credential to use for authentication.</param>
        /// <param name="scope">The scope to authenticate for.</param>
        public BearerTokenAuthenticationPolicy(TokenCredential credential, string scope) : this(credential, new[] { scope }) { }

        /// <summary>
        /// Creates a new instance of <see cref="BearerTokenAuthenticationPolicy"/> using provided token credential and scopes to authenticate for.
        /// </summary>
        /// <param name="credential">The token credential to use for authentication.</param>
        /// <param name="scopes">Scopes to authenticate for.</param>
        public BearerTokenAuthenticationPolicy(TokenCredential credential, IEnumerable<string> scopes)
            : this(credential, scopes, TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(30)) { }

        internal BearerTokenAuthenticationPolicy(TokenCredential credential, IEnumerable<string> scopes, TimeSpan tokenRefreshOffset, TimeSpan tokenRefreshRetryTimeout) {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(scopes, nameof(scopes));

            _credential = credential;
            _scopes = scopes.ToArray();
            _accessTokenCache = new AccessTokenCache(tokenRefreshOffset, tokenRefreshRetryTimeout);
        }

        /// <inheritdoc />
        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            return ProcessAsync(message, pipeline, true);
        }

        /// <inheritdoc />
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        /// <inheritdoc />
        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            if (message.Request.Uri.Scheme != Uri.UriSchemeHttps)
            {
                throw new InvalidOperationException("Bearer token authentication is not permitted for non TLS protected (https) endpoints.");
            }

            (string? headerValue, bool accessTokenAboutToExpire) = await _accessTokenCache.GetHeaderValueAsync(async, message.CancellationToken);
            if (headerValue == null)
            {
                headerValue = await GetHeaderValueFromCredentialAsync(message, async);
            }
            else if (accessTokenAboutToExpire)
            {
                _ = Task.Run(() => GetHeaderValueFromCredentialAsync(message, async));
            }

            message.Request.SetHeader(HttpHeader.Names.Authorization, headerValue);

            if (async)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
            }
        }

        private async ValueTask<string> GetHeaderValueFromCredentialAsync(HttpMessage message, bool async)
        {
            try
            {
                var requestContext = new TokenRequestContext(_scopes, message.Request.ClientRequestId);
                AccessToken token = async
                    ? await _credential.GetTokenAsync(requestContext, message.CancellationToken).ConfigureAwait(false)
                    : _credential.GetToken(requestContext, message.CancellationToken);

                return _accessTokenCache.SaveToken(token);
            }
            catch (Exception e)
            {
                _accessTokenCache.ResetTokenIfExpired(e);
                throw;
            }
        }

        private class AccessTokenCache
        {
            private readonly object _syncObj = new object();
            private readonly TimeSpan _tokenRefreshOffset;
            private readonly TimeSpan _tokenRefreshRetryTimeout;

            private bool _isGettingToken;
            private string? _headerValue;
            private TaskCompletionSource<string>? _pendingTcs;
            private DateTimeOffset _refreshOn;
            private DateTimeOffset _expiresOn;

            public AccessTokenCache(TimeSpan tokenRefreshOffset, TimeSpan tokenRefreshRetryTimeout)
            {
                _tokenRefreshOffset = tokenRefreshOffset;
                _tokenRefreshRetryTimeout = tokenRefreshRetryTimeout;
            }

            public async ValueTask<(string? headerValue, bool refreshTokenAboutToExpire)> GetHeaderValueAsync(bool async, CancellationToken cancellationToken)
            {
                (string? headerValue, Task<string>? pendingTask, bool accessTokenAboutToExpire) = GetHeaderValue();
                if (pendingTask == null)
                {
                    return (headerValue, accessTokenAboutToExpire);
                }

                if (async)
                {
                    return (await pendingTask.AwaitWithCancellation(cancellationToken), false);
                }

                try
                {
                    pendingTask.Wait(cancellationToken);
                }
                catch (AggregateException) { } // ignore exception here to rethrow it with EnsureCompleted

                return (pendingTask.EnsureCompleted(), false);
            }

            public string SaveToken(AccessToken token)
            {
                if (string.IsNullOrEmpty(token.Token))
                {
                    var exception = new InvalidOperationException($"{nameof(TokenCredential)}.{nameof(TokenCredential.GetToken)} has failed with unknown error.");
                    ResetTokenIfExpired(exception);
                    throw exception;
                }

                string headerValue = "Bearer " + token.Token;
                TaskCompletionSource<string>? pendingTcs = UpdateHeaderValue(headerValue, token.ExpiresOn - _tokenRefreshOffset, token.ExpiresOn);
                pendingTcs?.SetResult(headerValue);
                return headerValue;
            }

            public void ResetTokenIfExpired(Exception exception)
            {
                DateTimeOffset now = DateTimeOffset.UtcNow;
                TaskCompletionSource<string>? pendingTcs;

                lock (_syncObj)
                {
                    if (now >= _expiresOn)
                    {
                        pendingTcs = UpdateHeaderValue(default, default, default);
                    }
                    else
                    {
                        pendingTcs = UpdateHeaderValue(_headerValue, now + _tokenRefreshRetryTimeout, _expiresOn);
                        if (pendingTcs != default)
                        {
                            exception = new InvalidOperationException($"{nameof(GetHeaderValueAsync)} shouldn't wait in {TokenState.AboutToExpire} state.", exception);
                        }
                    }
                }

                pendingTcs?.SetException(exception);
            }

            /// <summary>
            /// Returns stored headerValue (if any), task that can be used to await for headerValue (if GetTokenAsync is in progress),
            /// and if token should be refreshed in background.
            /// </summary>
            private (string? headerValue, Task<string>? pendingTask, bool refreshTokenAboutToExpire) GetHeaderValue()
            {
                lock (_syncObj)
                {
                    switch (GetTokenState(_expiresOn, _refreshOn, _isGettingToken))
                    {
                        case TokenState.Invalid:
                            _headerValue = default;
                            _isGettingToken = true;
                            return (default, default, false);
                        case TokenState.Pending:
                            _pendingTcs ??= new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
                            return (default, _pendingTcs.Task, false);
                        case TokenState.Valid:
                            return (_headerValue, default, false);
                        case TokenState.AboutToExpire:
                            _isGettingToken = true;
                            return (_headerValue, default, true);
                        default:
                            throw new InvalidOperationException("Unexpected value");
                    }
                }

                static TokenState GetTokenState(DateTimeOffset expiresOn, DateTimeOffset refreshOn, bool isGettingToken)
                {
                    DateTimeOffset now = DateTimeOffset.UtcNow;
                    if (now >= expiresOn)
                    {
                        return isGettingToken ? TokenState.Pending : TokenState.Invalid;
                    }

                    if (now >= refreshOn)
                    {
                        return isGettingToken ? TokenState.Valid : TokenState.AboutToExpire;
                    }

                    return TokenState.Valid;
                }
            }

            private TaskCompletionSource<string>? UpdateHeaderValue(string? headerValue, DateTimeOffset refreshOn, DateTimeOffset expiresOn)
            {
                lock (_syncObj)
                {
                    _headerValue = headerValue;
                    _refreshOn = refreshOn;
                    _expiresOn = expiresOn;
                    _isGettingToken = false;

                    TaskCompletionSource<string>? pendingTcs = _pendingTcs;
                    _pendingTcs = null;
                    return pendingTcs;
                }
            }

            private enum TokenState
            {
                Invalid,
                Pending,
                Valid,
                AboutToExpire,
            }
        }
    }
}
