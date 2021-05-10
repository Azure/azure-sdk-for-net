﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// A policy that sends an <see cref="AccessToken"/> provided by a <see cref="TokenCredential"/> as an Authentication header.
    /// </summary>
    public class BearerTokenAuthenticationPolicy : HttpPipelinePolicy
    {
        private string[] _scopes;
        private readonly AccessTokenCache _accessTokenCache;

        /// <summary>
        /// Creates a new instance of <see cref="BearerTokenAuthenticationPolicy"/> using provided token credential and scope to authenticate for.
        /// </summary>
        /// <param name="credential">The token credential to use for authentication.</param>
        /// <param name="scope">The scope to be included in acquired tokens.</param>
        public BearerTokenAuthenticationPolicy(TokenCredential credential, string scope) : this(credential, new[] { scope }) { }

        /// <summary>
        /// Creates a new instance of <see cref="BearerTokenAuthenticationPolicy"/> using provided token credential and scopes to authenticate for.
        /// </summary>
        /// <param name="credential">The token credential to use for authentication.</param>
        /// <param name="scopes">Scopes to be included in acquired tokens.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="credential"/> or <paramref name="scopes"/> is null.</exception>
        public BearerTokenAuthenticationPolicy(TokenCredential credential, IEnumerable<string> scopes)
            : this(credential, scopes, TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(30))
        { }

        internal BearerTokenAuthenticationPolicy(
            TokenCredential credential,
            IEnumerable<string> scopes,
            TimeSpan tokenRefreshOffset,
            TimeSpan tokenRefreshRetryDelay)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(scopes, nameof(scopes));

            _scopes = scopes.ToArray();
            _accessTokenCache = new AccessTokenCache(credential, tokenRefreshOffset, tokenRefreshRetryDelay, scopes.ToArray());
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

        /// <summary>
        /// Executes before <see cref="ProcessAsync(HttpMessage, ReadOnlyMemory{HttpPipelinePolicy})"/> or
        /// <see cref="Process(HttpMessage, ReadOnlyMemory{HttpPipelinePolicy})"/> is called.
        /// Implementers of this method are expected to call <see cref="AuthenticateAndAuthorizeRequest"/> or <see cref="AuthenticateAndAuthorizeRequestAsync"/>
        /// if authorization is required for requests not related to handling a challenge response.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> this policy would be applied to.</param>
        /// <returns>The <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        protected virtual ValueTask AuthorizeRequestAsync(HttpMessage message)
        {
            var context = new TokenRequestContext(_scopes, message.Request.ClientRequestId);
            return AuthenticateAndAuthorizeRequestAsync(message, context);
        }

        /// <summary>
        /// Executes before <see cref="ProcessAsync(HttpMessage, ReadOnlyMemory{HttpPipelinePolicy})"/> or
        /// <see cref="Process(HttpMessage, ReadOnlyMemory{HttpPipelinePolicy})"/> is called.
        /// Implementers of this method are expected to call <see cref="AuthenticateAndAuthorizeRequest"/> or <see cref="AuthenticateAndAuthorizeRequestAsync"/>
        /// if authorization is required for requests not related to handling a challenge response.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> this policy would be applied to.</param>
        protected virtual void AuthorizeRequest(HttpMessage message)
        {
            var context = new TokenRequestContext(_scopes, message.Request.ClientRequestId);
            AuthenticateAndAuthorizeRequest(message, context);
        }

        /// <summary>
        /// Executed in the event a 401 response with a WWW-Authenticate authentication challenge header is received after the initial request.
        /// </summary>
        /// <remarks>Service client libraries may override this to handle service specific authentication challenges.</remarks>
        /// <param name="message">The <see cref="HttpMessage"/> to be authenticated.</param>
        /// <returns>A boolean indicating whether the request was successfully authenticated and should be sent to the transport.</returns>
        protected virtual ValueTask<bool> AuthorizeRequestOnChallengeAsync(HttpMessage message)
        {
            return default;
        }

        /// <summary>
        /// Executed in the event a 401 response with a WWW-Authenticate authentication challenge header is received after the initial request.
        /// </summary>
        /// <remarks>Service client libraries may override this to handle service specific authentication challenges.</remarks>
        /// <param name="message">The <see cref="HttpMessage"/> to be authenticated.</param>
        /// <returns>A boolean indicating whether the request was successfully authenticated and should be sent to the transport.</returns>
        protected virtual bool AuthorizeRequestOnChallenge(HttpMessage message)
        {
            return false;
        }

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            if (message.Request.Uri.Scheme != Uri.UriSchemeHttps)
            {
                throw new InvalidOperationException("Bearer token authentication is not permitted for non TLS protected (https) endpoints.");
            }

            if (async)
            {
                await AuthorizeRequestAsync(message).ConfigureAwait(false);
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                AuthorizeRequest(message);
                ProcessNext(message, pipeline);
            }

            // Check if we have received a challenge or we have not yet issued the first request.
            if (message.Response.Status == (int)HttpStatusCode.Unauthorized && message.Response.Headers.Contains(HttpHeader.Names.WwwAuthenticate))
            {
                // Attempt to get the TokenRequestContext based on the challenge.
                // If we fail to get the context, the challenge was not present or invalid.
                // If we succeed in getting the context, authenticate the request and pass it up the policy chain.
                if (async)
                {
                    if (await AuthorizeRequestOnChallengeAsync((message)).ConfigureAwait(false))
                    {
                        await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                    }
                }
                else
                {
                    if (AuthorizeRequestOnChallenge(message))
                    {
                        ProcessNext(message, pipeline);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the Authorization header on the <see cref="Request"/> by calling GetToken, or from cache, if possible.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> with the <see cref="Request"/> to be authorized.</param>
        /// <param name="context">The <see cref="TokenRequestContext"/> used to authorize the <see cref="Request"/>.</param>
        protected async ValueTask AuthenticateAndAuthorizeRequestAsync(HttpMessage message, TokenRequestContext context)
        {
            string headerValue = await _accessTokenCache.GetHeaderValueAsync(message, context, true).ConfigureAwait(false);
            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, headerValue);
        }

        /// <summary>
        /// Sets the Authorization header on the <see cref="Request"/> by calling GetToken, or from cache, if possible.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> with the <see cref="Request"/> to be authorized.</param>
        /// <param name="context">The <see cref="TokenRequestContext"/> used to authorize the <see cref="Request"/>.</param>
        protected void AuthenticateAndAuthorizeRequest(HttpMessage message, TokenRequestContext context)
        {
            string headerValue = _accessTokenCache.GetHeaderValueAsync(message, context, false).EnsureCompleted();
            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, headerValue);
        }

        private class AccessTokenCache
        {
            private readonly object _syncObj = new object();
            private readonly TokenCredential _credential;
            private readonly TimeSpan _tokenRefreshOffset;
            private readonly TimeSpan _tokenRefreshRetryDelay;

            private TokenRequestContext? _currentContext;
            private TaskCompletionSource<HeaderValueInfo>? _infoTcs;
            private TaskCompletionSource<HeaderValueInfo>? _backgroundUpdateTcs;

            public AccessTokenCache(TokenCredential credential, TimeSpan tokenRefreshOffset, TimeSpan tokenRefreshRetryDelay, string[] initialScopes)
            {
                _credential = credential;
                _tokenRefreshOffset = tokenRefreshOffset;
                _tokenRefreshRetryDelay = tokenRefreshRetryDelay;
                _currentContext = new TokenRequestContext(initialScopes);
            }

            public async ValueTask<string> GetHeaderValueAsync(HttpMessage message, TokenRequestContext context, bool async)
            {
                bool getTokenFromCredential;
                TaskCompletionSource<HeaderValueInfo> headerValueTcs;
                TaskCompletionSource<HeaderValueInfo>? backgroundUpdateTcs;
                int maxCancellationRetries = 3;

                while (true)
                {
                    (headerValueTcs, backgroundUpdateTcs, getTokenFromCredential) = GetTaskCompletionSources(context);
                    HeaderValueInfo info;
                    if (getTokenFromCredential)
                    {
                        if (backgroundUpdateTcs != null)
                        {
                            if (async)
                            {
                                info = await headerValueTcs.Task.ConfigureAwait(false);
                            }
                            else
                            {
#pragma warning disable AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
                                info = headerValueTcs.Task.EnsureCompleted();
#pragma warning restore AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
                            }
                            _ = Task.Run(() => GetHeaderValueFromCredentialInBackgroundAsync(backgroundUpdateTcs, info, context, async));
                            return info.HeaderValue;
                        }

                        try
                        {
                            info = await GetHeaderValueFromCredentialAsync(context, async, message.CancellationToken).ConfigureAwait(false);
                            headerValueTcs.SetResult(info);
                        }
                        catch (OperationCanceledException)
                        {
                            headerValueTcs.SetCanceled();
                        }
                        catch (Exception exception)
                        {
                            headerValueTcs.SetException(exception);
                            // The exception will be thrown on the next lines when we touch the result of
                            // headerValueTcs.Task, this approach will prevent later runtime UnobservedTaskException
                        }
                    }

                    var headerValueTask = headerValueTcs.Task;
                    try
                    {
                        if (!headerValueTask.IsCompleted)
                        {
                            if (async)
                            {
                                await headerValueTask.AwaitWithCancellation(message.CancellationToken);
                            }
                            else
                            {
                                try
                                {
                                    headerValueTask.Wait(message.CancellationToken);
                                }
                                catch (AggregateException) { } // ignore exception here to rethrow it with EnsureCompleted
                            }
                        }
                        if (async)
                        {
                            info = await headerValueTcs.Task.ConfigureAwait(false);
                        }
                        else
                        {
#pragma warning disable AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
                            info = headerValueTcs.Task.EnsureCompleted();
#pragma warning restore AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
                        }

                        return info.HeaderValue;
                    }
                    catch (TaskCanceledException) when (!message.CancellationToken.IsCancellationRequested)
                    {
                        maxCancellationRetries--;

                        // If the current message has no CancellationToken and we have tried this 3 times, throw.
                        if (!message.CancellationToken.CanBeCanceled && maxCancellationRetries <= 0)
                        {
                            throw;
                        }

                        // We were waiting on a previous headerValueTcs operation which was canceled.
                        //Retry the call to GetTaskCompletionSources.
                        continue;
                    }
                }
            }

            private (TaskCompletionSource<HeaderValueInfo> InfoTcs, TaskCompletionSource<HeaderValueInfo>? BackgroundUpdateTcs, bool GetTokenFromCredential)
                GetTaskCompletionSources(TokenRequestContext context)
            {
                lock (_syncObj)
                {
                    // Initial state. GetTaskCompletionSources has been called for the first time
                    if (_infoTcs == null || RequestRequiresNewToken(context))
                    {
                        _currentContext = context;
                        _infoTcs = new TaskCompletionSource<HeaderValueInfo>(TaskCreationOptions.RunContinuationsAsynchronously);
                        _backgroundUpdateTcs = default;
                        return (_infoTcs, _backgroundUpdateTcs, true);
                    }

                    // Getting new access token is in progress, wait for it
                    if (!_infoTcs.Task.IsCompleted)
                    {
                        _backgroundUpdateTcs = default;
                        return (_infoTcs, _backgroundUpdateTcs, false);
                    }

                    DateTimeOffset now = DateTimeOffset.UtcNow;
                    // Access token has been successfully acquired in background and it is not expired yet, use it instead of current one
                    if (_backgroundUpdateTcs != null &&
                        _backgroundUpdateTcs.Task.Status == TaskStatus.RanToCompletion &&
                        _backgroundUpdateTcs.Task.Result.ExpiresOn > now)
                    {
                        _infoTcs = _backgroundUpdateTcs;
                        _backgroundUpdateTcs = default;
                    }

                    // Attempt to get access token has failed or it has already expired. Need to get a new one
                    if (_infoTcs.Task.Status != TaskStatus.RanToCompletion || now >= _infoTcs.Task.Result.ExpiresOn)
                    {
                        _infoTcs = new TaskCompletionSource<HeaderValueInfo>(TaskCreationOptions.RunContinuationsAsynchronously);
                        return (_infoTcs, default, true);
                    }

                    // Access token is still valid but is about to expire, try to get it in background
                    if (now >= _infoTcs.Task.Result.RefreshOn && _backgroundUpdateTcs == null)
                    {
                        _backgroundUpdateTcs = new TaskCompletionSource<HeaderValueInfo>(TaskCreationOptions.RunContinuationsAsynchronously);
                        return (_infoTcs, _backgroundUpdateTcs, true);
                    }

                    // Access token is valid, use it
                    return (_infoTcs, default, false);
                }
            }

            // must be called under lock (_syncObj)
            private bool RequestRequiresNewToken(TokenRequestContext context) =>
                _currentContext == null ||
                (context.Scopes != null && !context.Scopes.AsSpan().SequenceEqual(_currentContext.Value.Scopes.AsSpan())) ||
                (context.Claims != null && !string.Equals(context.Claims, _currentContext.Value.Claims));

            private async ValueTask GetHeaderValueFromCredentialInBackgroundAsync(
                TaskCompletionSource<HeaderValueInfo> backgroundUpdateTcs,
                HeaderValueInfo info,
                TokenRequestContext context,
                bool async)
            {
                var cts = new CancellationTokenSource(_tokenRefreshRetryDelay);
                try
                {
                    HeaderValueInfo newInfo = await GetHeaderValueFromCredentialAsync(context, async, cts.Token).ConfigureAwait(false);
                    backgroundUpdateTcs.SetResult(newInfo);
                }
                catch (OperationCanceledException oce) when (cts.IsCancellationRequested)
                {
                    backgroundUpdateTcs.SetResult(new HeaderValueInfo(info.HeaderValue, info.ExpiresOn, DateTimeOffset.UtcNow));
                    AzureCoreEventSource.Singleton.BackgroundRefreshFailed(context.ParentRequestId ?? string.Empty, oce.ToString());
                }
                catch (Exception e)
                {
                    backgroundUpdateTcs.SetResult(new HeaderValueInfo(info.HeaderValue, info.ExpiresOn, DateTimeOffset.UtcNow + _tokenRefreshRetryDelay));
                    AzureCoreEventSource.Singleton.BackgroundRefreshFailed(context.ParentRequestId ?? string.Empty, e.ToString());
                }
                finally
                {
                    cts.Dispose();
                }
            }

            private async ValueTask<HeaderValueInfo> GetHeaderValueFromCredentialAsync(TokenRequestContext context, bool async, CancellationToken cancellationToken)
            {
                AccessToken token = async
                    ? await _credential.GetTokenAsync(context, cancellationToken).ConfigureAwait(false)
                    : _credential.GetToken(context, cancellationToken);

                return new HeaderValueInfo("Bearer " + token.Token, token.ExpiresOn, token.ExpiresOn - _tokenRefreshOffset);
            }

            private readonly struct HeaderValueInfo
            {
                public string HeaderValue { get; }
                public DateTimeOffset ExpiresOn { get; }
                public DateTimeOffset RefreshOn { get; }

                public HeaderValueInfo(string headerValue, DateTimeOffset expiresOn, DateTimeOffset refreshOn)
                {
                    HeaderValue = headerValue;
                    ExpiresOn = expiresOn;
                    RefreshOn = refreshOn;
                }
            }
        }
    }
}
