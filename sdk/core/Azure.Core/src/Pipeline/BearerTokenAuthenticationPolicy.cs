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
            : this(credential, scopes, TimeSpan.FromMinutes(5)) { }

        internal BearerTokenAuthenticationPolicy(TokenCredential credential, IEnumerable<string> scopes, TimeSpan tokenRefreshOffset) {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(scopes, nameof(scopes));

            _credential = credential;
            _scopes = scopes.ToArray();
            _accessTokenCache = new AccessTokenCache(tokenRefreshOffset);
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

            (string? headerValue, bool scheduleRefreshToken) = await _accessTokenCache.GetHeaderValueAsync(async, message.CancellationToken);
            if (headerValue == null)
            {
                headerValue = await GetHeaderValueFromCredentialAsync(message, async);
            }
            else if (scheduleRefreshToken)
            {
                _ = Task.Run(() => GetHeaderValueFromCredentialAsync(message, true));
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

            private TokenState _tokenState;
            private string? _headerValue;
            private TaskCompletionSource<string>? _pendingTcs;
            private DateTimeOffset _refreshOn;
            private DateTimeOffset _expiresOn;

            public AccessTokenCache(TimeSpan tokenRefreshOffset)
            {
                _tokenRefreshOffset = tokenRefreshOffset;
            }

            public async ValueTask<(string? headerValue, bool scheduleRefreshToken)> GetHeaderValueAsync(bool async, CancellationToken cancellationToken)
            {
                (string? headerValue, Task<string>? pendingTask, bool scheduleRefreshToken) = GetHeaderValue();
                if (pendingTask == null)
                {
                    return (headerValue, scheduleRefreshToken);
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

                string headerValue;
                TaskCompletionSource<string>? pendingTcs;

                lock (_syncObj)
                {
                    _headerValue = "Bearer " + token.Token;
                    _refreshOn = token.ExpiresOn - _tokenRefreshOffset;
                    _expiresOn = token.ExpiresOn;
                    _tokenState = TokenState.Valid;

                     pendingTcs = _pendingTcs;
                    headerValue = _headerValue;
                    _pendingTcs = null;
                }

                pendingTcs?.SetResult(headerValue);
                return headerValue;
            }

            public void ResetTokenIfExpired(Exception exception)
            {
                TaskCompletionSource<string>? pendingTcs = default;

                lock (_syncObj)
                {
                    if (DateTimeOffset.UtcNow >= _expiresOn)
                    {
                        _headerValue = default;
                        _refreshOn = default;
                        _expiresOn = default;
                        _tokenState = TokenState.Invalid;

                        pendingTcs = _pendingTcs;
                        _pendingTcs = null;
                    }
                    else if (_tokenState == TokenState.AboutToExpire)
                    {
                        _tokenState = TokenState.Valid;
                        if (_pendingTcs != default)
                        {
                            exception = new InvalidOperationException($"{nameof(GetHeaderValueAsync)} shouldn't wait in {TokenState.AboutToExpire} state.", exception);
                        }
                    }
                }

                pendingTcs?.SetException(exception);
            }

            private (string? headerValue, Task<string>? pendingTask, bool scheduleRefreshToken) GetHeaderValue()
            {
                lock (_syncObj)
                {
                    if (DateTimeOffset.UtcNow >= _expiresOn && _tokenState != TokenState.Pending)
                    {
                        _tokenState = TokenState.Pending;
                        _headerValue = default;
                        return (default, default, false);
                    }

                    if (DateTimeOffset.UtcNow >= _refreshOn && _tokenState == TokenState.Valid)
                    {
                        _tokenState = TokenState.AboutToExpire;
                        return (_headerValue, default, true);
                    }

                    switch (_tokenState)
                    {
                        case TokenState.Pending:
                            _pendingTcs ??= new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
                            return (default, _pendingTcs.Task, false);
                        case TokenState.Valid:
                        case TokenState.AboutToExpire:
                            return (_headerValue, default, false);
                        default:
                            throw new InvalidOperationException("Unexpected value");
                    }
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
