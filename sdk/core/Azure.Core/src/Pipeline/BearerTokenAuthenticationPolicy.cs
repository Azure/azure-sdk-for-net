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
#pragma warning disable CA1001 // Types that own disposable fields should be disposable
    public class BearerTokenAuthenticationPolicy : HttpPipelinePolicy
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        private readonly object _syncObj;

        private readonly TokenCredential _credential;

        private readonly string[] _scopes;

        private TokenState _tokenState;

        private string? _headerValue;
        private SemaphoreSlim? _headerSemaphore;
        private DateTimeOffset _refreshOn;
        private DateTimeOffset _expiresOn;

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
            _syncObj = new object();
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

            (string? headerValue, SemaphoreSlim? semaphore) = UpdateTokenState();
            if (headerValue == default)
            {
                if (semaphore != null)
                {
                    if (async)
                    {
                        await semaphore.WaitAsync(message.CancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        semaphore.Wait(message.CancellationToken);
                    }

                    headerValue = GetConcurrentlySetHeaderValue();
                }
                else
                {
                    AccessToken token = async
                        ? await _credential.GetTokenAsync(new TokenRequestContext(_scopes, message.Request.ClientRequestId), message.CancellationToken).ConfigureAwait(false)
                        : _credential.GetToken(new TokenRequestContext(_scopes, message.Request.ClientRequestId), message.CancellationToken);

                    headerValue = SetHeaderValue(token);
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

        private string? GetConcurrentlySetHeaderValue()
        {
            lock (_syncObj)
            {
                _headerSemaphore?.Release(1);
                return _headerValue;
            }
        }

        private string? SetHeaderValue(in AccessToken token)
        {
            var offset = _credential.TokenRefreshOffset;
            lock (_syncObj)
            {
                _headerValue = "Bearer " + token.Token;
                _refreshOn = token.ExpiresOn - offset;
                _expiresOn = token.ExpiresOn;
                _tokenState = TokenState.Valid;

                _headerSemaphore?.Release(1);
                return _headerValue;
            }
        }

        private (string? headerValue, SemaphoreSlim? semaphore) UpdateTokenState()
        {
            lock (_syncObj)
            {
                switch (_tokenState) {
                    case TokenState.Invalid:
                        _tokenState = TokenState.Pending;
                        ResetSemaphore(_headerSemaphore);
                        return (null, null);
                    case TokenState.Pending:
                        _headerSemaphore ??= new SemaphoreSlim(0, 1);
                        return (null, _headerSemaphore);
                    case TokenState.Valid when DateTimeOffset.UtcNow >= _refreshOn:
                        _tokenState = DateTimeOffset.UtcNow >= _expiresOn ? TokenState.Pending : TokenState.AboutToExpire;
                        ResetSemaphore(_headerSemaphore);
                        return (null, null);
                    case TokenState.Valid:
                        return (_headerValue, null);
                    case TokenState.AboutToExpire when DateTimeOffset.UtcNow >= _expiresOn:
                        _tokenState = TokenState.Pending;
                        _headerValue = null;
                        ResetSemaphore(_headerSemaphore);
                        return (null, null);
                    case TokenState.AboutToExpire:
                        return (_headerValue, null);
                    default:
                        throw new InvalidOperationException();
                }
            }

            static void ResetSemaphore(SemaphoreSlim? semaphore)
            {
                if (semaphore != null && semaphore.CurrentCount == 1)
                {
                    semaphore.Wait();
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
