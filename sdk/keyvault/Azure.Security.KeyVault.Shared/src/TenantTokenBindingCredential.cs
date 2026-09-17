// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics.Tracing;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Identity;
using Microsoft.Identity.Client;

namespace Azure.Security.KeyVault
{
    internal sealed class TenantTokenBindingCredential : TokenCredential
    {
        private const int TenantNotAllowedForBoundTokenErrorCode = 3921996;
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
            if (exception is MsalServiceException serviceException)
            {
                return IsTenantNotAllowedForBoundToken(serviceException) ? FailureKind.TenantDenied : FailureKind.Other;
            }

            if (exception is CredentialUnavailableException unavailable)
            {
                // DefaultAzureCredential aggregates unavailable sources when its initial IMDS
                // probe wraps the MSAL denial. Do not disregard any terminal authentication failure.
                if (unavailable.InnerException is AggregateException aggregate)
                {
                    bool foundDenial = false;
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
                        foundDenial |= kind == FailureKind.TenantDenied;
                    }
                    return foundDenial ? FailureKind.TenantDenied : FailureKind.Unavailable;
                }

                return unavailable.InnerException is AuthenticationFailedException or MsalException
                    ? ClassifyFailure(unavailable.InnerException)
                    : FailureKind.Unavailable;
            }

            return exception is AuthenticationFailedException failure
                ? ClassifyFailure(failure.InnerException)
                : FailureKind.Other;
        }

        internal static bool IsTenantNotAllowedForBoundToken(MsalServiceException exception)
        {
            if (exception.StatusCode is not (400 or 401) || string.IsNullOrEmpty(exception.ResponseBody))
            {
                return false;
            }

            try
            {
                using JsonDocument document = JsonDocument.Parse(exception.ResponseBody);
                if (document.RootElement.ValueKind != JsonValueKind.Object)
                {
                    return false;
                }

                bool found = false;
                foreach (JsonProperty property in document.RootElement.EnumerateObject())
                {
                    if (!property.NameEquals("error_codes"))
                    {
                        continue;
                    }

                    if (found || property.Value.ValueKind != JsonValueKind.Array || property.Value.GetArrayLength() != 1)
                    {
                        return false;
                    }

                    JsonElement code = property.Value[0];
                    if (code.ValueKind != JsonValueKind.Number ||
                        !code.TryGetInt32(out int value) ||
                        value != TenantNotAllowedForBoundTokenErrorCode)
                    {
                        return false;
                    }
                    found = true;
                }
                return found;
            }
            catch (JsonException)
            {
                return false;
            }
        }

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
