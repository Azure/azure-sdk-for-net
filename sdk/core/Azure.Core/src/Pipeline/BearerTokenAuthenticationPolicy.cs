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
            _accessTokenCache = new AccessTokenCache(_credential.RefreshOffset.Offset);
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

            ValueTask<string?> headerValueTask = _accessTokenCache.GetTokenAsync();
            var headerValue = async
                ? await headerValueTask.AwaitWithCancellation(message.CancellationToken)
                : headerValueTask.IsCompleted ? headerValueTask.Result : WaitSynchronously(headerValueTask, message.CancellationToken);

            if (headerValue == null)
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

            static string? WaitSynchronously(ValueTask<string?> headerValueTask, CancellationToken cancellationToken)
            {
                Task<string?> task = headerValueTask.AsTask();
                try
                {
                    task.Wait(cancellationToken);
                }
                catch (AggregateException) { } // ignore exception here to rethrow it with EnsureCompleted
                return task.EnsureCompleted();
            }
        }

        private class AccessTokenCache
        {
            private readonly object _syncObj = new object();
            private readonly TimeSpan _tokenRefreshOffset;

            private TokenState _tokenState;
            private string? _headerValue;
            private TaskCompletionSource<string?>? _pendingTcs;
            private DateTimeOffset _refreshOn;
            private DateTimeOffset _expiresOn;

            public AccessTokenCache(TimeSpan tokenRefreshOffset)
            {
                _tokenRefreshOffset = tokenRefreshOffset;
            }

            public string? SaveToken(AccessToken token, Exception? exception)
            {
                string? headerValue;
                TaskCompletionSource<string?>? pendingTcs;

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

                if (pendingTcs == null)
                {
                    return headerValue;
                }

                if (headerValue != null)
                {
                    pendingTcs.SetResult(headerValue);
                }
                else
                {
                    pendingTcs.SetException(exception ?? new InvalidOperationException($"{nameof(TokenCredential)}.{nameof(TokenCredential.GetToken)} has failed with unknown error."));
                }

                return headerValue;
            }

            public ValueTask<string?> GetTokenAsync()
            {
                lock (_syncObj)
                {
                    if (DateTimeOffset.UtcNow >= _expiresOn && _tokenState != TokenState.Pending)
                    {
                        _tokenState = TokenState.Pending;
                        _headerValue = null;
                        return new ValueTask<string?>();
                    }

                    if (DateTimeOffset.UtcNow >= _refreshOn && _tokenState == TokenState.Valid)
                    {
                        _tokenState = TokenState.AboutToExpire;
                        return new ValueTask<string?>();
                    }

                    switch (_tokenState) {
                        case TokenState.Pending:
                            _pendingTcs ??= new TaskCompletionSource<string?>(TaskCreationOptions.RunContinuationsAsynchronously);
                            return new ValueTask<string?>(_pendingTcs.Task);
                        case TokenState.Valid:
                        case TokenState.AboutToExpire:
                            return new ValueTask<string?>(_headerValue);
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
