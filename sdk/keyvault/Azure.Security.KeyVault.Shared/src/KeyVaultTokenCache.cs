// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.KeyVault
{
    // Adapted from Azure.Core BearerTokenAuthenticationPolicy.AccessTokenCache (1.63).
    // Keep the single-slot, single-flight and background refresh state machine local until
    // Core can return the SAME token and binding certificate to each request, including hits.
    // Unlike a transport-update callback, this never separates authorization from its key.
    internal sealed class KeyVaultTokenCache
    {
        private readonly object _gate = new();
        private readonly TokenCredential _credential;
        private readonly Func<DateTimeOffset> _clock;
        private readonly TimeSpan _refreshOffset = TimeSpan.FromMinutes(5);
        private readonly TimeSpan _retryDelay = TimeSpan.FromSeconds(30);
        private State _state;

        internal KeyVaultTokenCache(TokenCredential credential, Func<DateTimeOffset> clock = null)
        {
            _credential = credential;
            _clock = clock ?? (() => DateTimeOffset.UtcNow);
        }

        internal async ValueTask<KeyVaultTransport.RequestAuthentication> GetAsync(TokenRequestContext context, bool async, CancellationToken cancellationToken)
        {
            int cancellationRetries = 3;
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                bool refresh = RefreshState(context, out State state);
                if (refresh)
                {
                    if (state.Background != null)
                    {
                        TokenValue current = await GetCurrentAsync(state, async, cancellationToken).ConfigureAwait(false);
                        _ = Task.Run(() => RefreshInBackgroundAsync(state.Background, current, context, async));
                        return current.Authentication;
                    }

                    try
                    {
                        await AcquireAsync(context, state.Current, async, cancellationToken).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException)
                    {
                        state.Current.SetCanceled();
                    }
                    catch (Exception exception)
                    {
                        state.Current.SetException(exception);
                    }
                }
                try
                {
                    return (await GetCurrentAsync(state, async, cancellationToken).ConfigureAwait(false)).Authentication;
                }
                catch (TaskCanceledException) when (!cancellationToken.IsCancellationRequested)
                {
                    if (--cancellationRetries <= 0 && !cancellationToken.CanBeCanceled)
                    {
                        throw;
                    }
                }
            }
        }

        private bool RefreshState(TokenRequestContext context, out State state)
        {
            lock (_gate)
            {
                if (_state == null || !_state.Matches(context))
                {
                    state = _state = new State(context);
                    return true;
                }
                if (!_state.Current.Task.IsCompleted)
                {
                    state = _state;
                    return false;
                }

                DateTimeOffset now = _clock();
                if (_state.Background?.Task.Status == TaskStatus.RanToCompletion &&
                    _state.Background.Task.Result.ExpiresOn > now)
                {
                    _state = new State(context, _state.Background);
                }
                if (_state.Current.Task.Status != TaskStatus.RanToCompletion || now >= _state.Current.Task.Result.ExpiresOn)
                {
                    state = _state = new State(context);
                    return true;
                }
                if (_state.Background == null && now >= _state.Current.Task.Result.RefreshOn)
                {
                    state = _state = new State(context, _state.Current, NewCompletion());
                    return true;
                }
                state = _state;
                return false;
            }
        }

        private async Task RefreshInBackgroundAsync(TaskCompletionSource<TokenValue> completion, TokenValue current, TokenRequestContext context, bool async)
        {
            using var cancellation = new CancellationTokenSource(_retryDelay);
            try
            {
                await AcquireAsync(context, completion, async, cancellation.Token).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                completion.SetResult(new TokenValue(current.Authentication, current.ExpiresOn,
                    _clock() + (cancellation.IsCancellationRequested ? TimeSpan.Zero : _retryDelay)));
                KeyVaultTransport.TransportEventSource.Singleton.RefreshFailed(exception.GetType().FullName);
            }
        }

        private async ValueTask AcquireAsync(TokenRequestContext context, TaskCompletionSource<TokenValue> completion, bool async, CancellationToken cancellationToken)
        {
            AccessToken token = async
                ? await _credential.GetTokenAsync(context, cancellationToken).ConfigureAwait(false)
                : _credential.GetToken(context, cancellationToken);
            DateTimeOffset refreshOn = token.RefreshOn ??
                (_refreshOffset.Ticks > token.ExpiresOn.Ticks ? token.ExpiresOn : token.ExpiresOn - _refreshOffset);
            completion.SetResult(new TokenValue(
                new KeyVaultTransport.RequestAuthentication(token.TokenType + " " + token.Token, token.BindingCertificate),
                token.ExpiresOn, refreshOn));
        }

        private static async ValueTask<TokenValue> GetCurrentAsync(State state, bool async, CancellationToken cancellationToken)
        {
            if (async)
            {
                await state.Current.Task.AwaitWithCancellation(cancellationToken);
                return await state.Current.Task.ConfigureAwait(false);
            }

            else
            {
                if (!state.Current.Task.IsCompleted)
                {
                    try
                    { state.Current.Task.Wait(cancellationToken); }
                    catch (AggregateException) { } // Unwrap below, as in Core's synchronous cache.
                }
#pragma warning disable AZC0104
                return state.Current.Task.EnsureCompleted();
#pragma warning restore AZC0104
            }
        }

        private static TaskCompletionSource<TokenValue> NewCompletion() => new(TaskCreationOptions.RunContinuationsAsynchronously);

        private sealed class State
        {
            private readonly TokenRequestContext _context;
            internal TaskCompletionSource<TokenValue> Current { get; }
            internal TaskCompletionSource<TokenValue> Background { get; }

            internal State(TokenRequestContext context, TaskCompletionSource<TokenValue> current = null, TaskCompletionSource<TokenValue> background = null)
            {
                _context = context;
                Current = current ?? NewCompletion();
                Background = background;
            }

            internal bool Matches(TokenRequestContext context) =>
                (context.Scopes ?? Array.Empty<string>()).SequenceEqual(_context.Scopes ?? Array.Empty<string>()) &&
                string.Equals(context.Claims, _context.Claims, StringComparison.Ordinal) &&
                string.Equals(context.TenantId, _context.TenantId, StringComparison.Ordinal) &&
                context.IsCaeEnabled == _context.IsCaeEnabled &&
                context.IsProofOfPossessionEnabled == _context.IsProofOfPossessionEnabled &&
                (!context.IsProofOfPossessionEnabled ||
                    (context.ResourceRequestUri == _context.ResourceRequestUri &&
                    string.Equals(context.ResourceRequestMethod, _context.ResourceRequestMethod, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(context.ProofOfPossessionNonce, _context.ProofOfPossessionNonce, StringComparison.Ordinal)));
        }

        private readonly struct TokenValue
        {
            internal TokenValue(KeyVaultTransport.RequestAuthentication authentication, DateTimeOffset expiresOn, DateTimeOffset refreshOn)
            {
                Authentication = authentication;
                ExpiresOn = expiresOn;
                RefreshOn = refreshOn;
            }

            internal KeyVaultTransport.RequestAuthentication Authentication { get; }
            internal DateTimeOffset ExpiresOn { get; }
            internal DateTimeOffset RefreshOn { get; }
        }
    }
}
