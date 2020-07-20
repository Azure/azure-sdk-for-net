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

            _accessTokenCache = new AccessTokenCache(credential, scopes.ToArray(), tokenRefreshOffset, tokenRefreshRetryTimeout);
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

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            if (message.Request.Uri.Scheme != Uri.UriSchemeHttps)
            {
                throw new InvalidOperationException("Bearer token authentication is not permitted for non TLS protected (https) endpoints.");
            }

            string headerValue = await _accessTokenCache.GetHeaderValueAsync(message, async);
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

        private class AccessTokenCache
        {
            private static readonly Task<string> _emptyTask = Task.FromResult(string.Empty);
            private readonly object _syncObj = new object();
            private readonly TokenCredential _credential;
            private readonly string[] _scopes;
            private readonly TimeSpan _tokenRefreshOffset;
            private readonly TimeSpan _tokenRefreshRetryTimeout;

            private bool _isGettingToken;
            private string? _headerValue;
            private TaskCompletionSource<string>? _pendingTcs;
            private DateTimeOffset _refreshOn;
            private DateTimeOffset _expiresOn;

            public AccessTokenCache(TokenCredential credential, string[] scopes, TimeSpan tokenRefreshOffset, TimeSpan tokenRefreshRetryTimeout)
            {
                _credential = credential;
                _scopes = scopes;
                _tokenRefreshOffset = tokenRefreshOffset;
                _tokenRefreshRetryTimeout = tokenRefreshRetryTimeout;
            }

            public async ValueTask<string> GetHeaderValueAsync(HttpMessage message, bool async)
            {
                (CacheState cacheState, string headerValue, Task<string> pendingTask) = GetHeaderValue();

                switch (cacheState)
                {
                    case CacheState.NoHeaderValueCached:
                        return await GetHeaderValueFromCredentialAsync(message, async).ConfigureAwait(false);

                    case CacheState.UpdatingHeaderValueInProgress:
                        return await WaitForHeaderValueAsync(pendingTask, async, message.CancellationToken);

                    case CacheState.HasHeaderValue:
                        return headerValue;

                    case CacheState.HeaderValueIsAboutToExpire:
                        _ = Task.Run(() => GetHeaderValueFromCredentialAsync(message, async));
                        return headerValue;

                    default:
                        throw new InvalidOperationException("Unexpected value");
                }
            }

            private static async Task<string> WaitForHeaderValueAsync(Task<string> pendingTask, bool async, CancellationToken cancellationToken) {
                if (async) {
                    return await pendingTask.AwaitWithCancellation(cancellationToken);
                }

                try {
                    pendingTask.Wait(cancellationToken);
                } catch (AggregateException) { } // ignore exception here to rethrow it with EnsureCompleted

                return pendingTask.EnsureCompleted();
            }

            private async ValueTask<string> GetHeaderValueFromCredentialAsync(HttpMessage message, bool async)
            {
                try
                {
                    var requestContext = new TokenRequestContext(_scopes, message.Request.ClientRequestId);
                    AccessToken token = async
                        ? await _credential.GetTokenAsync(requestContext, message.CancellationToken).ConfigureAwait(false)
                        : _credential.GetToken(requestContext, message.CancellationToken);
                    return SaveToken(token);
                }
                catch (Exception e)
                {
                    throw ResetTokenIfExpired(e);
                }
            }

            private string SaveToken(AccessToken token)
            {
                if (string.IsNullOrEmpty(token.Token))
                {
                    throw new InvalidOperationException($"{nameof(TokenCredential)}.{nameof(TokenCredential.GetToken)} has failed with unknown error.");
                }

                string headerValue = "Bearer " + token.Token;
                TaskCompletionSource<string>? pendingTcs = UpdateHeaderValue(headerValue, token.ExpiresOn - _tokenRefreshOffset, token.ExpiresOn);
                pendingTcs?.SetResult(headerValue);
                return headerValue;
            }

            private Exception ResetTokenIfExpired(Exception exception)
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
                            exception = new InvalidOperationException($"{nameof(GetHeaderValueAsync)} shouldn't wait in {CacheState.HeaderValueIsAboutToExpire} state.", exception);
                        }
                    }
                }

                pendingTcs?.SetException(exception);
                return exception;
            }

            /// <summary>
            /// Returns stored headerValue (if any), task that can be used to await for headerValue (if GetTokenAsync is in progress),
            /// and if token should be refreshed in background.
            /// </summary>
            private (CacheState cacheState, string headerValue, Task<string> pendingTask) GetHeaderValue()
            {
                lock (_syncObj)
                {
                    CacheState cacheState = GetCacheState(_expiresOn, _refreshOn, _isGettingToken);
                    switch (cacheState)
                    {
                        case CacheState.NoHeaderValueCached:
                            _headerValue = default;
                            _isGettingToken = true;
                            return (cacheState, string.Empty, _emptyTask);

                        case CacheState.UpdatingHeaderValueInProgress:
                            _pendingTcs ??= new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
                            return (cacheState, string.Empty, _pendingTcs.Task);

                        case CacheState.HasHeaderValue:
                            return (cacheState, _headerValue ?? throw new NullReferenceException($"{_headerValue} can't be null"), _emptyTask);

                        case CacheState.HeaderValueIsAboutToExpire:
                            _isGettingToken = true;
                            return (cacheState, _headerValue ?? throw new NullReferenceException($"{_headerValue} can't be null"), _emptyTask);

                        default:
                            throw new InvalidOperationException("Unexpected value");
                    }
                }

                static CacheState GetCacheState(DateTimeOffset expiresOn, DateTimeOffset refreshOn, bool isGettingToken)
                {
                    DateTimeOffset now = DateTimeOffset.UtcNow;
                    if (now >= expiresOn)
                    {
                        return isGettingToken ? CacheState.UpdatingHeaderValueInProgress : CacheState.NoHeaderValueCached;
                    }

                    if (now >= refreshOn)
                    {
                        return isGettingToken ? CacheState.HasHeaderValue : CacheState.HeaderValueIsAboutToExpire;
                    }

                    return CacheState.HasHeaderValue;
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

            private enum CacheState
            {
                NoHeaderValueCached,
                UpdatingHeaderValueInProgress,
                HasHeaderValue,
                HeaderValueIsAboutToExpire,
            }
        }
    }
}
