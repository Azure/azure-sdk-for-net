// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics.Tracing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Identity;

namespace Azure.Security.KeyVault
{
    internal sealed class TenantTokenBindingCredential : TokenCredential
    {
        private const string TenantNotAllowedForBoundTokenPattern = @"\bAADSTS3921996\b";
        private readonly TokenCredential _credential;
        private readonly ConcurrentDictionary<string, byte> _bearerOnlyTenants = new(StringComparer.OrdinalIgnoreCase);

        public TenantTokenBindingCredential(TokenCredential credential)
        {
            _credential = credential ?? throw new ArgumentNullException(nameof(credential));
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => GetTokenInternalAsync(requestContext, cancellationToken, false).EnsureCompleted();

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            => GetTokenInternalAsync(requestContext, cancellationToken, true);

        internal TokenRequestContext GetEffectiveRequestContext(TokenRequestContext context) =>
            context.IsProofOfPossessionEnabled && _bearerOnlyTenants.ContainsKey(context.TenantId ?? string.Empty)
                ? CreateBearerContext(context)
                : context;

        private async ValueTask<AccessToken> GetTokenInternalAsync(TokenRequestContext context, CancellationToken cancellationToken, bool async)
        {
            cancellationToken.ThrowIfCancellationRequested();
            context = GetEffectiveRequestContext(context);
            try
            {
                return async
                    ? await _credential.GetTokenAsync(context, cancellationToken).ConfigureAwait(false)
                    : _credential.GetToken(context, cancellationToken);
            }
            catch (Exception exception) when (context.IsProofOfPossessionEnabled &&
                ClassifyFailure(exception) == FailureKind.TenantDenied)
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (_bearerOnlyTenants.TryAdd(context.TenantId ?? string.Empty, 0))
                {
                    AuthenticationEventSource.Singleton.TenantEligibilityFallback();
                }

                // A fresh acquisition with PoP disabled is required; changing the authorization
                // scheme of a bound token would not remove its cryptographic binding.
                TokenRequestContext bearerContext = CreateBearerContext(context);
                return async
                    ? await _credential.GetTokenAsync(bearerContext, cancellationToken).ConfigureAwait(false)
                    : _credential.GetToken(bearerContext, cancellationToken);
            }
        }

        private static TokenRequestContext CreateBearerContext(TokenRequestContext context) =>
            new(context.Scopes,
                parentRequestId: context.ParentRequestId,
                claims: context.Claims,
                tenantId: context.TenantId,
                isCaeEnabled: context.IsCaeEnabled);

        private static FailureKind ClassifyFailure(Exception exception)
        {
            if (exception is not AuthenticationFailedException)
            {
                return FailureKind.Other;
            }

            bool foundDenial = false;
            bool onlyUnavailable = true;
            for (Exception current = exception; current != null; current = current.InnerException)
            {
                if (current is OperationCanceledException or AggregateException)
                {
                    return FailureKind.Other;
                }

                // Aggregate messages combine multiple credentials. A denial in one source must
                // not hide a terminal authentication failure in another.
                if (current is CredentialUnavailableException && current.InnerException is AggregateException aggregate)
                {
                    bool aggregateDenial = false;
                    foreach (Exception inner in aggregate.InnerExceptions)
                    {
                        if (inner is not CredentialUnavailableException)
                        {
                            return FailureKind.Other;
                        }

                        FailureKind kind = ClassifyFailure(inner);
                        if (kind == FailureKind.Other)
                        {
                            return FailureKind.Other;
                        }
                        aggregateDenial |= kind == FailureKind.TenantDenied;
                    }
                    return aggregateDenial ? FailureKind.TenantDenied : onlyUnavailable ? FailureKind.Unavailable : FailureKind.Other;
                }

                // Core can preserve the service error only in an inner exception's message.
                foundDenial |= IsTenantNotAllowedForBoundToken(current.Message);
                onlyUnavailable &= current is not AuthenticationFailedException || current is CredentialUnavailableException;
            }

            return foundDenial ? FailureKind.TenantDenied : onlyUnavailable ? FailureKind.Unavailable : FailureKind.Other;
        }

        internal static bool IsTenantNotAllowedForBoundToken(string message) =>
            message != null && Regex.IsMatch(message, TenantNotAllowedForBoundTokenPattern, RegexOptions.CultureInvariant);

        private enum FailureKind
        {
            Other,
            Unavailable,
            TenantDenied
        }

        private sealed class AuthenticationEventSource : AzureEventSource
        {
            // This shared source is compiled into multiple Key Vault assemblies.
            private AuthenticationEventSource()
                : base(typeof(TenantTokenBindingCredential).Assembly.GetName().Name.Replace('.', '-') + "-Authentication")
            {
            }

            public static AuthenticationEventSource Singleton { get; } = new();

            [Event(1, Level = EventLevel.Warning, Message = "The token service denied attested token issuance for this tenant context. Key Vault is requesting bearer authentication and will remember this decision until the client is recreated.")]
            public void TenantEligibilityFallback() => WriteEvent(1);
        }
    }
}
