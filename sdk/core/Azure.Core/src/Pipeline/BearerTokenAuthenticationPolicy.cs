// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public BearerTokenAuthenticationPolicy(TokenCredential credential, string scope) : this(credential, new[] { scope })
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="BearerTokenAuthenticationPolicy"/> using provided token credential and scopes to authenticate for.
        /// </summary>
        /// <param name="credential">The token credential to use for authentication.</param>
        /// <param name="scopes">Scopes to authenticate for.</param>
        public BearerTokenAuthenticationPolicy(TokenCredential credential, IEnumerable<string> scopes)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(scopes, nameof(scopes));

            _credential = credential;
            _scopes = scopes.ToArray();
            _accessTokenCache = new AccessTokenCache(_credential.TokenRefreshOffset.Offset);
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

            (string? headerValue, Task<string>? pending) = _accessTokenCache.UpdateTokenState();
            if (headerValue == default)
            {
                if (pending != null)
                {
                    headerValue = async
                        ? await pending.WithCancellation(message.CancellationToken)
                        : pending.WaitWithCancellation(message.CancellationToken);
                }
                else
                {
                    try
                    {
                        AccessToken token = async
                            ? await _credential.GetTokenAsync(new TokenRequestContext(_scopes, message.Request.ClientRequestId), message.CancellationToken).ConfigureAwait(false)
                            : _credential.GetToken(new TokenRequestContext(_scopes, message.Request.ClientRequestId), message.CancellationToken);

                        headerValue = _accessTokenCache.SaveToken(token, default);
                    }
                    catch (Exception e)
                    {
                        _accessTokenCache.SaveToken(default, e);
                        throw;
                    }
                }
            }

            if (headerValue != null)
            {
                message.Request.SetHeader(HttpHeader.Names.Authorization, headerValue);
            }

            if (async)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
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

            public string? SaveToken(AccessToken token, Exception? exception)
            {
                string? headerValue;
                TaskCompletionSource<string>? pendingTcs;

                lock (_syncObj)
                {
                    if (!string.IsNullOrEmpty(token.Token))
                    {
                        _headerValue = "Bearer " + token.Token;
                        _refreshOn = token.ExpiresOn - _tokenRefreshOffset;
                        _expiresOn = token.ExpiresOn;
                        _tokenState = TokenState.Valid;
                    }
                    else
                    {
                        _headerValue = default;
                        _refreshOn = default;
                        _expiresOn = default;
                        _tokenState = TokenState.Invalid;
                    }

                    pendingTcs = _pendingTcs;
                    headerValue = _headerValue;
                    _pendingTcs = null;
                }

                if (pendingTcs != null)
                {
                    if (headerValue != null)
                    {
                        pendingTcs.SetResult(headerValue);
                    }
                    else
                    {
                        pendingTcs.SetException(exception ?? new InvalidOperationException());
                    }
                }

                return headerValue;
            }

            public (string? headerValue, Task<string>? pendingTask) UpdateTokenState()
            {
                lock (_syncObj)
                {
                    if (DateTimeOffset.UtcNow >= _expiresOn && _tokenState != TokenState.Pending)
                    {
                        _tokenState = TokenState.Pending;
                        _headerValue = null;
                        return (null, null);
                    }

                    if (DateTimeOffset.UtcNow >= _refreshOn && _tokenState == TokenState.Valid)
                    {
                        _tokenState = TokenState.AboutToExpire;
                        return (null, null);
                    }

                    switch (_tokenState) {
                        case TokenState.Pending:
                            _pendingTcs ??= new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
                            return (null, _pendingTcs.Task);
                        case TokenState.Valid:
                            return (_headerValue, null);
                        case TokenState.AboutToExpire:
                            return (_headerValue, null);
                        default:
                            throw new InvalidOperationException("Unexpected value");
                    }
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
