// Copyright (c) Microsoft Corporation. All rights reserved.
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
                    if (await AuthorizeRequestOnChallengeAsync(message).ConfigureAwait(false))
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

            // must be updated under lock (_syncObj)
            private TokenRequestState _state;

            public AccessTokenCache(TokenCredential credential, TimeSpan tokenRefreshOffset, TimeSpan tokenRefreshRetryDelay, string[] initialScopes)
            {
                _credential = credential;
                _tokenRefreshOffset = tokenRefreshOffset;
                _tokenRefreshRetryDelay = tokenRefreshRetryDelay;
                _state = new TokenRequestState(new TokenRequestContext(initialScopes), default, default);
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
                // Check if the current state requires no updates to _state under lock and is valid.
                // All checks must be done on the local prefixed variables as _state can be modified by other threads.
                var (localCurrentContext, localInfoTcs, localBackgroundUpdateTcs) = _state;
                if (localInfoTcs != null && localInfoTcs.Task.IsCompleted && localBackgroundUpdateTcs == null && !RequestRequiresNewToken(context, localCurrentContext))
                {
                    DateTimeOffset now = DateTimeOffset.UtcNow;
                    if (localInfoTcs.Task.Status == TaskStatus.RanToCompletion && now < localInfoTcs.Task.Result.ExpiresOn && now < localInfoTcs.Task.Result.RefreshOn)
                    {
                        // localState entity has a valid token, no need to enter lock.
                        return (localInfoTcs, default, false);
                    }
                }
                lock (_syncObj)
                {
                    var (currentContext, infoTcs, backgroundUpdateTcs) = _state;
                    // Initial state. GetTaskCompletionSources has been called for the first time
                    if (infoTcs == null || RequestRequiresNewToken(context, currentContext))
                    {
                        currentContext = context;
                        infoTcs = new TaskCompletionSource<HeaderValueInfo>(TaskCreationOptions.RunContinuationsAsynchronously);
                        backgroundUpdateTcs = default;
                        _state = new TokenRequestState(currentContext, infoTcs, backgroundUpdateTcs);
                        return (infoTcs, backgroundUpdateTcs, true);
                    }

                    // Getting new access token is in progress, wait for it
                    if (!infoTcs.Task.IsCompleted)
                    {
                        // Only create new TokenRequestState if necessary.
                        if (backgroundUpdateTcs != null)
                        {
                            backgroundUpdateTcs = default;
                            _state = new TokenRequestState(currentContext, infoTcs, backgroundUpdateTcs);
                        }
                        return (infoTcs, backgroundUpdateTcs, false);
                    }

                    DateTimeOffset now = DateTimeOffset.UtcNow;
                    // Access token has been successfully acquired in background and it is not expired yet, use it instead of current one
                    if (backgroundUpdateTcs != null &&
                        backgroundUpdateTcs.Task.Status == TaskStatus.RanToCompletion &&
                        backgroundUpdateTcs.Task.Result.ExpiresOn > now)
                    {
                        infoTcs = backgroundUpdateTcs;
                        backgroundUpdateTcs = default;
                        _state = new TokenRequestState(currentContext, infoTcs, backgroundUpdateTcs);
                    }

                    // Attempt to get access token has failed or it has already expired. Need to get a new one
                    if (infoTcs.Task.Status != TaskStatus.RanToCompletion || now >= infoTcs.Task.Result.ExpiresOn)
                    {
                        infoTcs = new TaskCompletionSource<HeaderValueInfo>(TaskCreationOptions.RunContinuationsAsynchronously);
                        _state = new TokenRequestState(currentContext, infoTcs, backgroundUpdateTcs);
                        return (infoTcs, default, true);
                    }

                    // Access token is still valid but is about to expire, try to get it in background
                    if (now >= infoTcs.Task.Result.RefreshOn && backgroundUpdateTcs == null)
                    {
                        backgroundUpdateTcs = new TaskCompletionSource<HeaderValueInfo>(TaskCreationOptions.RunContinuationsAsynchronously);
                        _state = new TokenRequestState(currentContext, infoTcs, backgroundUpdateTcs);
                        return (infoTcs, backgroundUpdateTcs, true);
                    }

                    // Access token is valid, use it
                    return (infoTcs, default, false);
                }
            }

            private static bool RequestRequiresNewToken(TokenRequestContext context, TokenRequestContext currentContext) =>
                (context.Scopes != null && !context.Scopes.AsSpan().SequenceEqual(currentContext.Scopes.AsSpan())) ||
                (context.Claims != null && !string.Equals(context.Claims, currentContext.Claims));

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

            private class TokenRequestState
            {
                public TokenRequestContext CurrentContext { get; }
                public TaskCompletionSource<HeaderValueInfo>? InfoTcs { get; }
                public TaskCompletionSource<HeaderValueInfo>? BackgroundUpdateTcs { get; }

                public TokenRequestState(TokenRequestContext currentContext, TaskCompletionSource<HeaderValueInfo>? infoTcs,
                    TaskCompletionSource<HeaderValueInfo>? backgroundUpdateTcs)
                {
                    CurrentContext = currentContext;
                    InfoTcs = infoTcs;
                    BackgroundUpdateTcs = backgroundUpdateTcs;
                }

                public void Deconstruct(out TokenRequestContext currentContext, out TaskCompletionSource<HeaderValueInfo>? infoTcs,
                    out TaskCompletionSource<HeaderValueInfo>? backgroundUpdateTcs)
                {
                    currentContext = CurrentContext;
                    infoTcs = InfoTcs;
                    backgroundUpdateTcs = BackgroundUpdateTcs;
                }
            }
        }
    }
}
