// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

#nullable enable

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// This is a direct copy of BearerTokenChallengeAuthenticationPolicy.AccessTokenCache, with only the token lookup and force refresh logic replaced.
    /// </summary>
    internal class ContainerRegistryRefreshTokenCache
    {
        private readonly TimeSpan DefaultTokenRefreshOffset = TimeSpan.FromMinutes(5);
        private readonly TimeSpan DefaultTokenRefreshRetryDelay = TimeSpan.FromSeconds(30);

        private readonly object _syncObj = new object();
        private readonly TokenCredential _aadTokenCredential;
        private readonly TimeSpan _tokenRefreshOffset;
        private readonly TimeSpan _tokenRefreshRetryDelay;
        private readonly IContainerRegistryAuthenticationClient _authenticationRestClient;

        private string? _currentTokenService;
        private TaskCompletionSource<RefreshTokenInfo>? _infoTcs;
        private TaskCompletionSource<RefreshTokenInfo>? _backgroundUpdateTcs;

        public ContainerRegistryRefreshTokenCache(TokenCredential aadTokenCredential, IContainerRegistryAuthenticationClient authClient, TimeSpan? tokenRefreshOffset = null, TimeSpan? tokenRefreshRetryDelay = null)
        {
            _aadTokenCredential = aadTokenCredential;
            _authenticationRestClient = authClient;

            _tokenRefreshOffset = tokenRefreshOffset ?? DefaultTokenRefreshOffset;
            _tokenRefreshRetryDelay = tokenRefreshRetryDelay ?? DefaultTokenRefreshRetryDelay;
        }

        public async ValueTask<string> GetAcrRefreshTokenAsync(HttpMessage message, TokenRequestContext context, string service, bool async)
        {
            bool getTokenFromCredential;
            TaskCompletionSource<RefreshTokenInfo> refreshTokenTcs;
            TaskCompletionSource<RefreshTokenInfo>? backgroundUpdateTcs;
            int maxCancellationRetries = 3;

            while (true)
            {
                (refreshTokenTcs, backgroundUpdateTcs, getTokenFromCredential) = GetTaskCompletionSources(service);
                RefreshTokenInfo info;
                if (getTokenFromCredential)
                {
                    if (backgroundUpdateTcs != null)
                    {
                        if (async)
                        {
                            info = await refreshTokenTcs.Task.ConfigureAwait(false);
                        }
                        else
                        {
#pragma warning disable AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
                            info = refreshTokenTcs.Task.EnsureCompleted();
#pragma warning restore AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
                        }

                        _ = Task.Run(() => GetRefreshTokenFromCredentialInBackgroundAsync(backgroundUpdateTcs, info, context, service, async));
                        return info.RefreshToken;
                    }

                    try
                    {
                        info = await GetRefreshTokenFromCredentialAsync(context, service, async, message.CancellationToken).ConfigureAwait(false);
                        refreshTokenTcs.SetResult(info);
                    }
                    catch (OperationCanceledException)
                    {
                        refreshTokenTcs.SetCanceled();
                    }
                    catch (Exception exception)
                    {
                        refreshTokenTcs.SetException(exception);
                        // The exception will be thrown on the next lines when we touch the result of
                        // refreshTokenTcs.Task, this approach will prevent later runtime UnobservedTaskException
                    }
                }

                var refreshTokenTask = refreshTokenTcs.Task;
                try
                {
                    if (!refreshTokenTask.IsCompleted)
                    {
                        if (async)
                        {
                            await refreshTokenTask.AwaitWithCancellation(message.CancellationToken);
                        }
                        else
                        {
                            try
                            {
                                refreshTokenTask.Wait(message.CancellationToken);
                            }
                            catch (AggregateException) { } // ignore exception here to rethrow it with EnsureCompleted
                        }
                    }
                    if (async)
                    {
                        info = await refreshTokenTcs.Task.ConfigureAwait(false);
                    }
                    else
                    {
#pragma warning disable AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
                        info = refreshTokenTcs.Task.EnsureCompleted();
#pragma warning restore AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
                    }

                    return info.RefreshToken;
                }
                catch (TaskCanceledException) when (!message.CancellationToken.IsCancellationRequested)
                {
                    maxCancellationRetries--;

                    // If the current message has no CancellationToken and we have tried this 3 times, throw.
                    if (!message.CancellationToken.CanBeCanceled && maxCancellationRetries <= 0)
                    {
                        throw;
                    }

                    // We were waiting on a previous refreshTokenTcs operation which was canceled.
                    //Retry the call to GetTaskCompletionSources.
                    continue;
                }
            }
        }

        private (TaskCompletionSource<RefreshTokenInfo> InfoTcs, TaskCompletionSource<RefreshTokenInfo>? BackgroundUpdateTcs, bool GetTokenFromCredential) GetTaskCompletionSources(string service)
        {
            lock (_syncObj)
            {
                // Initial state. GetTaskCompletionSources has been called for the first time
                if (_infoTcs == null || RequestRequiresNewToken(service))
                {
                    _currentTokenService = service;
                    _infoTcs = new TaskCompletionSource<RefreshTokenInfo>(TaskCreationOptions.RunContinuationsAsynchronously);
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

                    // return nothing here so we can enter the 5th case and start bg thread if needed.
                }

                // Attempt to get access token has failed or it has already expired. Need to get a new one
                if (_infoTcs.Task.Status != TaskStatus.RanToCompletion || now >= _infoTcs.Task.Result.ExpiresOn)
                {
                    _infoTcs = new TaskCompletionSource<RefreshTokenInfo>(TaskCreationOptions.RunContinuationsAsynchronously);
                    return (_infoTcs, default, true);
                }

                // Access token is still valid but is about to expire, try to get it in background
                if (now >= _infoTcs.Task.Result.RefreshOn && _backgroundUpdateTcs == null)
                {
                    _backgroundUpdateTcs = new TaskCompletionSource<RefreshTokenInfo>(TaskCreationOptions.RunContinuationsAsynchronously);
                    return (_infoTcs, _backgroundUpdateTcs, true);
                }

                // Access token is valid, use it
                return (_infoTcs, default, false);
            }
        }

        // must be called under lock (_syncObj)
        private bool RequestRequiresNewToken(string service) =>
            _currentTokenService == null ||
            (service != null && !string.Equals(service, _currentTokenService));

        private async ValueTask GetRefreshTokenFromCredentialInBackgroundAsync(TaskCompletionSource<RefreshTokenInfo> backgroundUpdateTcs, RefreshTokenInfo info, TokenRequestContext context, string service, bool async)
        {
            var cts = new CancellationTokenSource(_tokenRefreshRetryDelay);
            try
            {
                RefreshTokenInfo newInfo = await GetRefreshTokenFromCredentialAsync(context, service, async, cts.Token).ConfigureAwait(false);
                backgroundUpdateTcs.SetResult(newInfo);
            }
            catch (OperationCanceledException) when (cts.IsCancellationRequested)
            {
                backgroundUpdateTcs.SetResult(new RefreshTokenInfo(info.RefreshToken, info.ExpiresOn, DateTimeOffset.UtcNow));

                // https://github.com/Azure/azure-sdk-for-net/issues/18539
                //AzureCoreEventSource.Singleton.BackgroundRefreshFailed(context.ParentRequestId ?? string.Empty, oce.ToString());
            }
            catch (Exception)
            {
                backgroundUpdateTcs.SetResult(new RefreshTokenInfo(info.RefreshToken, info.ExpiresOn, DateTimeOffset.UtcNow + _tokenRefreshRetryDelay));

                // https://github.com/Azure/azure-sdk-for-net/issues/18539
                //AzureCoreEventSource.Singleton.BackgroundRefreshFailed(context.ParentRequestId ?? string.Empty, e.ToString());
            }
            finally
            {
                cts.Dispose();
            }
        }

        private async ValueTask<RefreshTokenInfo> GetRefreshTokenFromCredentialAsync(TokenRequestContext context, string service, bool async, CancellationToken cancellationToken)
        {
            AccessToken aadAccessToken = async ?
                await _aadTokenCredential.GetTokenAsync(context, cancellationToken).ConfigureAwait(false) :
                _aadTokenCredential.GetToken(context, cancellationToken);

            AcrRefreshToken acrRefreshToken = async ?
                await _authenticationRestClient.ExchangeAadAccessTokenForAcrRefreshTokenAsync(PostContentSchemaGrantType.AccessToken, service, null, null, aadAccessToken.Token, cancellationToken).ConfigureAwait(false) :
                _authenticationRestClient.ExchangeAadAccessTokenForAcrRefreshToken(PostContentSchemaGrantType.AccessToken, service, null, null, aadAccessToken.Token, cancellationToken);

            DateTimeOffset expiresOn = GetTokenExpiryTime(acrRefreshToken);

            return new RefreshTokenInfo(acrRefreshToken.RefreshToken, expiresOn, expiresOn - _tokenRefreshOffset);
        }

        internal static DateTimeOffset GetTokenExpiryTime(AcrRefreshToken acrRefreshToken)
        {
            // If we can't parse the expiration from the JWT, indicate that it's expired now.
            return GetTokenExpiryFromJwt(acrRefreshToken.RefreshToken) ?? DateTimeOffset.UtcNow;
        }

        private static DateTimeOffset? GetTokenExpiryFromJwt(string jwtValue)
        {
            // The JWT is in the format <Base64Url encoded header>.<Base64Url encoded body>.<Base64Url encoded signature>
            // Here, we Base64Url decode the body and treat it as a JSON object in order to get the "exp" value

            if (string.IsNullOrEmpty(jwtValue))
            {
                return null;
            }

            string[] jwtSegments = jwtValue.Split('.');
            if (jwtSegments.Length < 2)
            {
                return null;
            }

            string jwtBodyEncoded = jwtSegments[1];

            if (string.IsNullOrEmpty(jwtBodyEncoded))
            {
                return null;
            }

            byte[] jwtBodyDecoded = Base64Url.Decode(jwtBodyEncoded);
            JsonDocument jsonBody = JsonDocument.Parse(jwtBodyDecoded);

            if (!jsonBody.RootElement.TryGetProperty("exp", out JsonElement value))
            {
                return null;
            }

            if (!value.TryGetInt64(out long expValue))
            {
                return null;
            }

            return DateTimeOffset.FromUnixTimeSeconds(expValue);
        }

        private readonly struct RefreshTokenInfo
        {
            public string RefreshToken { get; }
            public DateTimeOffset ExpiresOn { get; }
            public DateTimeOffset RefreshOn { get; }

            public RefreshTokenInfo(string refreshToken, DateTimeOffset expiresOn, DateTimeOffset refreshOn)
            {
                RefreshToken = refreshToken;
                ExpiresOn = expiresOn;
                RefreshOn = refreshOn;
            }
        }
    }
}
