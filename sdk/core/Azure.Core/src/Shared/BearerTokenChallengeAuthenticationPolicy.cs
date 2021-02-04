// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;

#nullable enable

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// A policy that sends an <see cref="AccessToken"/> provided by a <see cref="TokenCredential"/> as an Authentication header.
    /// Note: This class is currently in preview and is therefore subject to possible future breaking changes.
    /// </summary>
    internal class BearerTokenChallengeAuthenticationPolicy : HttpPipelinePolicy
    {
        private const string ChallengeHeader = "WWW-Authenticate";
        private readonly AccessTokenCache _accessTokenCache;
        private string[] _scopes;

        /// <summary>
        /// Creates a new instance of <see cref="BearerTokenChallengeAuthenticationPolicy"/> using provided token credential and scope to authenticate for.
        /// </summary>
        /// <param name="credential">The token credential to use for authentication.</param>
        /// <param name="scope">The scope to authenticate for.</param>
        public BearerTokenChallengeAuthenticationPolicy(TokenCredential credential, string scope) : this(credential, new[] { scope }) { }

        /// <summary>
        /// Creates a new instance of <see cref="BearerTokenChallengeAuthenticationPolicy"/> using provided token credential and scopes to authenticate for.
        /// </summary>
        /// <param name="credential">The token credential to use for authentication.</param>
        /// <param name="scopes">Scopes to authenticate for.</param>
        public BearerTokenChallengeAuthenticationPolicy(TokenCredential credential, IEnumerable<string> scopes)
            : this(credential, scopes, TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(30)) { }

        internal BearerTokenChallengeAuthenticationPolicy(TokenCredential credential, IEnumerable<string> scopes, TimeSpan tokenRefreshOffset, TimeSpan tokenRefreshRetryDelay)
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
        /// Executed in the event a 401 response with a WWW-Authenticate authentication challenge header is received after the initial request.
        /// </summary>
        /// <remarks>This implementation handles common authentication challenges such as claims challenges. Service client libraries may derive from this and extend to handle service specific authentication challenges.</remarks>
        /// <param name="message">The <see cref="HttpMessage"/> to be authenticated.</param>
        /// <param name="context">If the return value is <c>true</c>, a <see cref="TokenRequestContext"/>.</param>
        /// <returns>A boolean indicated whether the request contained a valid challenge and a <see cref="TokenRequestContext"/> was successfully initialized with it.</returns>
        protected virtual bool TryGetTokenRequestContextFromChallenge(HttpMessage message, out TokenRequestContext context)
        {
            context = default;

            var claimsChallenge = GetClaimsChallenge(message.Response);

            if (claimsChallenge != null)
            {
                context = new TokenRequestContext(_scopes, message.Request.ClientRequestId, claimsChallenge);
                return true;
            }

            return false;
        }

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            if (message.Request.Uri.Scheme != Uri.UriSchemeHttps)
            {
                throw new InvalidOperationException("Bearer token authentication is not permitted for non TLS protected (https) endpoints.");
            }

            TokenRequestContext context;

            // If the message already has a challenge response due to a sub-class pre-processing the request, get the context from the challenge.
            if (message.HasResponse && message.Response.Status == (int)HttpStatusCode.Unauthorized && message.Response.Headers.Contains(ChallengeHeader))
            {
                if (!TryGetTokenRequestContextFromChallenge(message, out context))
                {
                    // We were unsuccessful in handling the challenge, so bail out now.
                    return;
                }
                _scopes = context.Scopes;
            }
            else
            {
                context = new TokenRequestContext(_scopes, message.Request.ClientRequestId);
            }

            await AuthenticateRequestAsync(message, context, async).ConfigureAwait(false);

            if (async)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
            }

            // Check if we have received a challenge or we have not yet issued the first request.
            if (message.Response.Status == (int)HttpStatusCode.Unauthorized && message.Response.Headers.Contains(ChallengeHeader))
            {
                // Attempt to get the TokenRequestContext based on the challenge.
                // If we fail to get the context, the challenge was not present or invalid.
                // If we succeed in getting the context, authenticate the request and pass it up the policy chain.
                if (TryGetTokenRequestContextFromChallenge(message, out context))
                {
                    // Ensure the scopes are consistent with what was set by <see cref="TryGetTokenRequestContextFromChallenge" />.
                    _scopes = context.Scopes;

                    await AuthenticateRequestAsync(message, context, async).ConfigureAwait(false);

                    if (async)
                    {
                        await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                    }
                    else
                    {
                        ProcessNext(message, pipeline);
                    }
                }
            }
        }

        private async Task AuthenticateRequestAsync(HttpMessage message, TokenRequestContext context, bool async)
        {
            string headerValue;
            if (async)
            {
                headerValue = await _accessTokenCache.GetHeaderValueAsync(message, context, async).ConfigureAwait(false);
            }
            else
            {
                headerValue = _accessTokenCache.GetHeaderValueAsync(message, context, async).EnsureCompleted();
            }

            message.Request.SetHeader(HttpHeader.Names.Authorization, headerValue);
        }

        private static string? GetClaimsChallenge(Response response)
        {
            if (response.Status != (int)HttpStatusCode.Unauthorized || !response.Headers.TryGetValue(ChallengeHeader, out string? headerValue))
            {
                return null;
            }

            ReadOnlySpan<char> bearer = "Bearer".AsSpan();
            ReadOnlySpan<char> claims = "claims".AsSpan();
            ReadOnlySpan<char> headerSpan = headerValue.AsSpan();

            // Iterate through each challenge value.
            while (TryGetNextChallenge(ref headerSpan, out var challengeKey))
            {
                // Enumerate each key=value parameter until we find the 'claims' key on the 'Bearer' challenge.
                while (TryGetNextParameter(ref headerSpan, out var key, out var value))
                {
                    if (challengeKey.Equals(bearer, StringComparison.OrdinalIgnoreCase) && key.Equals(claims, StringComparison.OrdinalIgnoreCase))
                    {
                        return Base64Url.DecodeString(value.ToString());
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Iterates through the challenge schemes present in a challenge header.
        /// </summary>
        /// <param name="headerValue">
        /// The header value which will be sliced to remove the first parsed <paramref name="challengeKey"/>.
        /// </param>
        /// <param name="challengeKey">The parsed challenge scheme.</param>
        /// <returns>
        /// <c>true</c> if a challenge scheme was successfully parsed.
        /// The value of <paramref name="headerValue"/> should be passed to <see cref="TryGetNextParameter"/> to parse the challenge parameters if <c>true</c>.
        /// </returns>
        internal static bool TryGetNextChallenge(ref ReadOnlySpan<char> headerValue, out ReadOnlySpan<char> challengeKey)
        {
            challengeKey = default;

            headerValue = headerValue.TrimStart(' ');
            int endOfChallengeKey = headerValue.IndexOf(' ');

            if (endOfChallengeKey < 0)
            {
                return false;
            }

            challengeKey = headerValue.Slice(0, endOfChallengeKey);

            // Slice the challenge key from the headerValue
            headerValue = headerValue.Slice(endOfChallengeKey + 1);

            return true;
        }

        /// <summary>
        /// Iterates through a challenge header value after being parsed by <see cref="TryGetNextChallenge"/>.
        /// </summary>
        /// <param name="headerValue">The header value after being parsed by <see cref="TryGetNextChallenge"/>.</param>
        /// <param name="paramKey">The parsed challenge parameter key.</param>
        /// <param name="paramValue">The parsed challenge parameter value.</param>
        /// <param name="separator">The challenge parameter key / value pair separator. The default is '='.</param>
        /// <returns>
        /// <c>true</c> if the next available challenge parameter was successfully parsed.
        /// <c>false</c> if there are no more parameters for the current challenge scheme or an additional challenge scheme was encountered in the <paramref name="headerValue"/>.
        /// The value of <paramref name="headerValue"/> should be passed again to <see cref="TryGetNextChallenge"/> to attempt to parse any additional challenge schemes if <c>false</c>.
        /// </returns>
        internal static bool TryGetNextParameter(ref ReadOnlySpan<char> headerValue, out ReadOnlySpan<char> paramKey, out ReadOnlySpan<char> paramValue, char separator = '=')
        {
            paramKey = default;
            paramValue = default;
            var spaceOrComma = " ,".AsSpan();

            // Trim any separater prefixes.
            headerValue = headerValue.TrimStart(spaceOrComma);

            int nextSpace = headerValue.IndexOf(' ');
            int nextSeparator = headerValue.IndexOf(separator);

            if (nextSpace < nextSeparator && nextSpace != -1)
            {
                // we encountered another challenge value.
                return false;
            }

            if (nextSeparator < 0)
                return false;

            // Get the paramKey.
            paramKey = headerValue.Slice(0, nextSeparator).Trim();

            // Slice to remove the 'paramKey=' from the parameters.
            headerValue = headerValue.Slice(nextSeparator + 1);

            // The start of paramValue will usually be a quoted string. Find the first quote.
            int quoteIndex = headerValue.IndexOf('\"');

            // Get the paramValue, which is delimited by the trailing quote.
            headerValue = headerValue.Slice(quoteIndex + 1);
            if (quoteIndex >= 0)
            {
                // The values are quote wrapped
                paramValue = headerValue.Slice(0, headerValue.IndexOf('\"'));
            }
            else
            {
                //the values are not quote wrapped (storage is one example of this)
                // either find the next space indicating the delimiter to the next value, or go to the end since this is the last value.
                int trailingDelimiterIndex = headerValue.IndexOfAny(spaceOrComma);
                if (trailingDelimiterIndex >= 0)
                {
                    paramValue = headerValue.Slice(0, trailingDelimiterIndex);
                }
                else
                {
                    paramValue = headerValue;
                }
            }

            // Slice to remove the '"paramValue"' from the parameters.
            if (headerValue != paramValue)
                headerValue = headerValue.Slice(paramValue.Length + 1);

            return true;
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
                        throw;
                    }
                    catch (Exception exception)
                    {
                        headerValueTcs.SetException(exception);
                        throw;
                    }
                }

                var headerValueTask = headerValueTcs.Task;
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

            private (TaskCompletionSource<HeaderValueInfo>, TaskCompletionSource<HeaderValueInfo>?, bool) GetTaskCompletionSources(TokenRequestContext context)
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
                    if (_backgroundUpdateTcs != null && _backgroundUpdateTcs.Task.Status == TaskStatus.RanToCompletion && _backgroundUpdateTcs.Task.Result.ExpiresOn > now)
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
                (context.Scopes != null && !context.Scopes.SequenceEqual(_currentContext.Value.Scopes)) ||
                (context.Claims != null && !string.Equals(context.Claims, _currentContext.Value.Claims));

            private async ValueTask GetHeaderValueFromCredentialInBackgroundAsync(TaskCompletionSource<HeaderValueInfo> backgroundUpdateTcs, HeaderValueInfo info, TokenRequestContext context, bool async)
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
