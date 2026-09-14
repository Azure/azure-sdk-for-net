// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    /// <summary>
    /// Attaches the exporter's Entra ID token only to hosts Azure Monitor ingestion answers on.
    /// A single pipeline serves every destination in multi-endpoint mode, and a destination is
    /// named by telemetry, so an unconditional token would be disclosed to whatever host was named.
    /// </summary>
    internal sealed class MultiEndpointBearerTokenAuthenticationPolicy : BearerTokenAuthenticationPolicy
    {
        private readonly EndpointTrustPolicy _trustPolicy;

        public MultiEndpointBearerTokenAuthenticationPolicy(TokenCredential credential, string scope, EndpointTrustPolicy trustPolicy)
            : base(credential, scope)
        {
            _trustPolicy = trustPolicy;
        }

        protected override void AuthorizeRequest(HttpMessage message)
        {
            if (IsTrusted(message))
            {
                base.AuthorizeRequest(message);
            }
        }

        protected override async ValueTask AuthorizeRequestAsync(HttpMessage message)
        {
            if (IsTrusted(message))
            {
                await base.AuthorizeRequestAsync(message).ConfigureAwait(false);
            }
        }

        protected override bool AuthorizeRequestOnChallenge(HttpMessage message)
            => IsTrusted(message) && base.AuthorizeRequestOnChallenge(message);

        protected override async ValueTask<bool> AuthorizeRequestOnChallengeAsync(HttpMessage message)
            => IsTrusted(message) && await base.AuthorizeRequestOnChallengeAsync(message).ConfigureAwait(false);

        private bool IsTrusted(HttpMessage message)
        {
            // Opt-in: a routed destination that did not ask for a token is a component that still
            // accepts instrumentation key auth, and sending one would fail it on a missing role.
            if (!message.TryGetProperty(ApplicationInsightsRestClient.UseAadAuthProperty, out var useAadAuth) || useAadAuth is not true)
            {
                return false;
            }

            var uri = message.Request.Uri.ToUri();

            if (_trustPolicy.IsTrusted(uri))
            {
                return true;
            }

            AzureMonitorExporterEventSource.Log.MultiEndpointTokenWithheld(uri.Host);

            return false;
        }
    }
}
