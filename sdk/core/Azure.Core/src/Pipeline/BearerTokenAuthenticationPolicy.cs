// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// A policy that sends an <see cref="AccessToken"/> provided by a <see cref="TokenCredential"/> as an <see cref="HttpHeader.Names.Authorization"/> header.
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
            _accessTokenCache = new AccessTokenCache(credential, tokenRefreshOffset, tokenRefreshRetryDelay);
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
            var context = new TokenRequestContext(_scopes, message.Request.ClientRequestId, isCaeEnabled: true);
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
            var context = new TokenRequestContext(_scopes, message.Request.ClientRequestId, isCaeEnabled: true);
            AuthenticateAndAuthorizeRequest(message, context);
        }

        /// <summary>
        /// Executed in the event a 401 response with a WWW-Authenticate authentication challenge header is received after the initial request.
        /// The default implementation will attempt to handle Continuous Access Evaluation (CAE) claims challenges.
        /// </summary>
        /// <remarks>Service client libraries may override this to handle service specific authentication challenges.</remarks>
        /// <param name="message">The <see cref="HttpMessage"/> to be authenticated.</param>
        /// <returns>A boolean indicating whether the request was successfully authenticated and should be sent to the transport.</returns>
        protected virtual async ValueTask<bool> AuthorizeRequestOnChallengeAsync(HttpMessage message)
        {
            if (AuthorizationChallengeParser.IsCaeClaimsChallenge(message.Response) &&
                TryGetTokenRequestContextForCaeChallenge(message, out var tokenRequestContext))
            {
                await AuthenticateAndAuthorizeRequestAsync(message, tokenRequestContext).ConfigureAwait(false);
                return true;
            }

            return default;
        }

        /// <summary>
        /// Executed in the event a 401 response with a WWW-Authenticate authentication challenge header is received after the initial request.
        /// The default implementation will attempt to handle Continuous Access Evaluation (CAE) claims challenges.
        /// </summary>
        /// <remarks>Service client libraries may override this to handle service specific authentication challenges.</remarks>
        /// <param name="message">The <see cref="HttpMessage"/> to be authenticated.</param>
        /// <returns>A boolean indicating whether the request was successfully authenticated and should be sent to the transport.</returns>
        protected virtual bool AuthorizeRequestOnChallenge(HttpMessage message)
        {
            if (AuthorizationChallengeParser.IsCaeClaimsChallenge(message.Response) &&
                TryGetTokenRequestContextForCaeChallenge(message, out var tokenRequestContext))
            {
                AuthenticateAndAuthorizeRequest(message, tokenRequestContext);
                return true;
            }
            return false;
        }

        internal bool TryGetTokenRequestContextForCaeChallenge(HttpMessage message, out TokenRequestContext tokenRequestContext)
        {
            string? decodedClaims = null;
            string? encodedClaims = AuthorizationChallengeParser.GetChallengeParameterFromResponse(message.Response, "Bearer", "claims");
            try
            {
                decodedClaims = encodedClaims switch
                {
                    null => null,
                    { Length: 0 } => null,
                    string enc => Encoding.UTF8.GetString(Convert.FromBase64String(enc))
                };
            }
            catch (FormatException ex)
            {
                AzureCoreEventSource.Singleton.FailedToDecodeCaeChallengeClaims(encodedClaims, ex.ToString());
            }
            if (decodedClaims == null)
            {
                tokenRequestContext = default;
                return false;
            }

            tokenRequestContext = new TokenRequestContext(_scopes, message.Request.ClientRequestId, decodedClaims, isCaeEnabled: true);
            return true;
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
            string headerValue = await _accessTokenCache.GetAuthHeaderValueAsync(message, context, true).ConfigureAwait(false);
            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, headerValue);
        }

        /// <summary>
        /// Sets the Authorization header on the <see cref="Request"/> by calling GetToken, or from cache, if possible.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> with the <see cref="Request"/> to be authorized.</param>
        /// <param name="context">The <see cref="TokenRequestContext"/> used to authorize the <see cref="Request"/>.</param>
        protected void AuthenticateAndAuthorizeRequest(HttpMessage message, TokenRequestContext context)
        {
            string headerValue = _accessTokenCache.GetAuthHeaderValueAsync(message, context, false).EnsureCompleted();
            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, headerValue);
        }

        internal class AccessTokenCache
        {
            private readonly object _syncObj = new object();
            private readonly TokenCredential _credential;
            private readonly TimeSpan _tokenRefreshOffset;
            private readonly TimeSpan _tokenRefreshRetryDelay;

            // must be updated under lock (_syncObj)
            internal TokenRequestState? _state;

            public AccessTokenCache(TokenCredential credential, TimeSpan tokenRefreshOffset, TimeSpan tokenRefreshRetryDelay)
            {
                _credential = credential;
                _tokenRefreshOffset = tokenRefreshOffset;
                _tokenRefreshRetryDelay = tokenRefreshRetryDelay;
            }

            public async ValueTask<string> GetAuthHeaderValueAsync(HttpMessage message, TokenRequestContext context, bool async)
            {
                bool shouldRefreshFromCredential;
                int maxCancellationRetries = 3;

                while (true)
                {
                    shouldRefreshFromCredential = RefreshTokenRequestState(context, out TokenRequestState localState);
                    AuthHeaderValueInfo headerValueInfo;

                    if (shouldRefreshFromCredential)
                    {
                        if (localState.BackgroundTokenUpdateTcs != null)
                        {
                            headerValueInfo = await localState.GetCurrentHeaderValue(async, false, message.CancellationToken).ConfigureAwait(false);
                            _ = Task.Run(() => GetHeaderValueFromCredentialInBackgroundAsync(localState.BackgroundTokenUpdateTcs, headerValueInfo, context, async));
                            return headerValueInfo.HeaderValue;
                        }

                        try
                        {
                            await SetResultOnTcsFromCredentialAsync(context, localState.CurrentTokenTcs, async, message.CancellationToken).ConfigureAwait(false);
                        }
                        catch (OperationCanceledException)
                        {
                            localState.CurrentTokenTcs.SetCanceled();
                        }
                        catch (Exception exception)
                        {
                            localState.CurrentTokenTcs.SetException(exception);
                            // The exception will be thrown on the next lines when we touch the result of
                            // headerValueTcs.Task, this approach will prevent later runtime UnobservedTaskException
                        }
                    }

                    try
                    {
                        headerValueInfo = await localState.GetCurrentHeaderValue(async, true, message.CancellationToken).ConfigureAwait(false);
                        return headerValueInfo.HeaderValue;
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
                        //Retry the call to RefreshTokenRequestState.
                        continue;
                    }
                }
            }

            /// <summary>
            /// Refresh the <see cref="TokenRequestState"/> for the current request context.
            /// </summary>
            /// <param name="context">The <see cref="TokenRequestContext"/> for the current request.</param>
            /// <param name="updatedState"></param>
            /// <returns>true if the token should be refreshed from the credential, else false.</returns>
            private bool RefreshTokenRequestState(TokenRequestContext context, out TokenRequestState updatedState)
            {
                // Check if the current state requires no updates to _state under lock and is valid.
                // All checks must be done on the local prefixed variables as _state can be modified by other threads.
                var localState = _state;
                if (localState != null && localState.CurrentTokenTcs.Task.IsCompleted && !localState.IsCurrentContextMismatched(context))
                {
                    DateTimeOffset now = DateTimeOffset.UtcNow;
                    if (!localState.IsBackgroundTokenAvailable(now) && !localState.IsCurrentTokenTcsFailedOrExpired(now) && !localState.TokenNeedsBackgroundRefresh(now))
                    {
                        // localState entity has a valid token, no need to enter lock.
                        updatedState = localState;
                        return false;
                    }
                }
                lock (_syncObj)
                {
                    // Initial state. RefreshTokenRequestState has been called for the first time
                    if (_state == null || _state.IsCurrentContextMismatched(context))
                    {
                        _state = TokenRequestState.FromNewContext(context);
                        updatedState = _state;
                        return true;
                    }

                    // Getting new access token is in progress, wait for it
                    if (!_state.CurrentTokenTcs.Task.IsCompleted)
                    {
                        // Only create new TokenRequestState if necessary.
                        if (_state.BackgroundTokenUpdateTcs != null)
                        {
                            _state = _state.WithDefaultBackgroundUpdateTcs();
                        }
                        updatedState = _state;
                        return false;
                    }

                    DateTimeOffset now = DateTimeOffset.UtcNow;
                    // Access token has been successfully acquired in background and it is not expired yet, use it instead of current one
                    if (_state.IsBackgroundTokenAvailable(now))
                    {
                        _state = _state.WithBackgroundUpdateTcsAsCurrent();
                    }

                    // Attempt to get access token has failed or it has already expired. Need to get a new one
                    if (_state.IsCurrentTokenTcsFailedOrExpired(now))
                    {
                        _state = _state.WithNewCurrentTokenTcs();
                        updatedState = _state;
                        return true;
                    }

                    // Access token is still valid but is about to expire, try to get it in background
                    if (_state.TokenNeedsBackgroundRefresh(now))
                    {
                        _state = _state.WithNewBackroundUpdateTokenTcs();
                        updatedState = _state;
                        return true;
                    }

                    // Access token is valid, use it
                    updatedState = _state;
                    return false;
                }
            }

            private async ValueTask GetHeaderValueFromCredentialInBackgroundAsync(
                TaskCompletionSource<AuthHeaderValueInfo> backgroundUpdateTcs,
                AuthHeaderValueInfo currentAuthHeaderInfo,
                TokenRequestContext context,
                bool async)
            {
                var cts = new CancellationTokenSource(_tokenRefreshRetryDelay);
                try
                {
                    await SetResultOnTcsFromCredentialAsync(context, backgroundUpdateTcs, async, cts.Token).ConfigureAwait(false);
                }
                catch (OperationCanceledException oce) when (cts.IsCancellationRequested)
                {
                    backgroundUpdateTcs.SetResult(new AuthHeaderValueInfo(currentAuthHeaderInfo.HeaderValue, currentAuthHeaderInfo.ExpiresOn, DateTimeOffset.UtcNow));
                    AzureCoreEventSource.Singleton.BackgroundRefreshFailed(context.ParentRequestId ?? string.Empty, oce.ToString());
                }
                catch (Exception e)
                {
                    backgroundUpdateTcs.SetResult(new AuthHeaderValueInfo(currentAuthHeaderInfo.HeaderValue, currentAuthHeaderInfo.ExpiresOn, DateTimeOffset.UtcNow + _tokenRefreshRetryDelay));
                    AzureCoreEventSource.Singleton.BackgroundRefreshFailed(context.ParentRequestId ?? string.Empty, e.ToString());
                }
                finally
                {
                    cts.Dispose();
                }
            }

            private async ValueTask SetResultOnTcsFromCredentialAsync(TokenRequestContext context, TaskCompletionSource<AuthHeaderValueInfo> targetTcs, bool async, CancellationToken cancellationToken)
            {
                AccessToken token = async
                    ? await _credential.GetTokenAsync(context, cancellationToken).ConfigureAwait(false)
                    : _credential.GetToken(context, cancellationToken);

                DateTimeOffset refreshOn = token.RefreshOn.HasValue switch
                {
                    true => token.RefreshOn.Value,
                    false when _tokenRefreshOffset.Ticks > token.ExpiresOn.Ticks => token.ExpiresOn,
                    _ => token.ExpiresOn - _tokenRefreshOffset
                };

                targetTcs.SetResult(new AuthHeaderValueInfo("Bearer " + token.Token, token.ExpiresOn, refreshOn));
            }

            internal readonly struct AuthHeaderValueInfo
            {
                public string HeaderValue { get; }
                public DateTimeOffset ExpiresOn { get; }
                public DateTimeOffset RefreshOn { get; }

                public AuthHeaderValueInfo(string headerValue, DateTimeOffset expiresOn, DateTimeOffset refreshOn)
                {
                    HeaderValue = headerValue;
                    ExpiresOn = expiresOn;
                    RefreshOn = refreshOn;
                }
            }

            internal class TokenRequestState
            {
                public TokenRequestContext CurrentContext { get; }
                public TaskCompletionSource<AuthHeaderValueInfo> CurrentTokenTcs { get; }
                public TaskCompletionSource<AuthHeaderValueInfo>? BackgroundTokenUpdateTcs { get; }

                public TokenRequestState(TokenRequestContext currentContext, TaskCompletionSource<AuthHeaderValueInfo> currentTokenTcs,
                    TaskCompletionSource<AuthHeaderValueInfo>? backgroundTokenUpdateTcs)
                {
                    CurrentContext = currentContext;
                    CurrentTokenTcs = currentTokenTcs;
                    BackgroundTokenUpdateTcs = backgroundTokenUpdateTcs;
                }

                public bool IsCurrentContextMismatched(TokenRequestContext context) =>
                    (context.Scopes != null && !context.Scopes.AsSpan().SequenceEqual(CurrentContext.Scopes.AsSpan())) ||
                    !string.Equals(context.Claims, CurrentContext.Claims) ||
                    (context.TenantId != null && !string.Equals(context.TenantId, CurrentContext.TenantId));

                public bool IsBackgroundTokenAvailable(DateTimeOffset now) =>
                    BackgroundTokenUpdateTcs != null &&
                        BackgroundTokenUpdateTcs.Task.Status == TaskStatus.RanToCompletion &&
                        BackgroundTokenUpdateTcs.Task.Result.ExpiresOn > now;

                public bool IsCurrentTokenTcsFailedOrExpired(DateTimeOffset now) =>
                    CurrentTokenTcs.Task.Status != TaskStatus.RanToCompletion || now >= CurrentTokenTcs.Task.Result.ExpiresOn;

                public bool TokenNeedsBackgroundRefresh(DateTimeOffset now) =>
                    now >= CurrentTokenTcs.Task.Result.RefreshOn && BackgroundTokenUpdateTcs == null;

                public static TokenRequestState FromNewContext(TokenRequestContext newContext) =>
                    new TokenRequestState(newContext, new TaskCompletionSource<AuthHeaderValueInfo>(TaskCreationOptions.RunContinuationsAsynchronously), default);

                public TokenRequestState WithDefaultBackgroundUpdateTcs() =>
                    new TokenRequestState(CurrentContext, CurrentTokenTcs, default);

                public TokenRequestState WithBackgroundUpdateTcsAsCurrent() =>
                    new TokenRequestState(CurrentContext, BackgroundTokenUpdateTcs!, default);

                public TokenRequestState WithNewCurrentTokenTcs() =>
                    new TokenRequestState(CurrentContext, new TaskCompletionSource<AuthHeaderValueInfo>(TaskCreationOptions.RunContinuationsAsynchronously), default);

                public TokenRequestState WithNewBackroundUpdateTokenTcs() =>
                    new TokenRequestState(CurrentContext, CurrentTokenTcs, new TaskCompletionSource<AuthHeaderValueInfo>(TaskCreationOptions.RunContinuationsAsynchronously));

                public async ValueTask<AuthHeaderValueInfo> GetCurrentHeaderValue(bool async, bool checkForCompletion = false, CancellationToken cancellationToken = default)
                {
                    if (async)
                    {
                        if (checkForCompletion & !CurrentTokenTcs.Task.IsCompleted)
                        {
                            await CurrentTokenTcs.Task.AwaitWithCancellation(cancellationToken);
                        }
                        return await CurrentTokenTcs.Task.ConfigureAwait(false);
                    }
                    else
                    {
                        if (checkForCompletion & !CurrentTokenTcs.Task.IsCompleted)
                        {
                            try
                            {
                                CurrentTokenTcs.Task.Wait(cancellationToken);
                            }
                            catch (AggregateException) { } // ignore exception here to rethrow it with EnsureCompleted
                        }
#pragma warning disable AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
                        return CurrentTokenTcs.Task.EnsureCompleted();
#pragma warning restore AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
                    }
                }
            }
        }
    }
}
