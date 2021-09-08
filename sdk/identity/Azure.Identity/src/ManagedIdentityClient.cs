// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity
{
    internal class ManagedIdentityClient
    {
        internal const string MsiUnavailableError = "ManagedIdentityCredential authentication unavailable. No Managed Identity endpoint found.";

        private readonly ManagedIdentitySource _identitySource;

        protected ManagedIdentityClient()
        {
        }

        public ManagedIdentityClient(CredentialPipeline pipeline, string clientId = null)
            : this(new ManagedIdentityClientOptions { Pipeline = pipeline, ClientId = clientId})
        {
        }

        public ManagedIdentityClient(ManagedIdentityClientOptions options)
        {
            ClientId = options.ClientId;
            Pipeline = options.Pipeline;

            _identitySource = AppServiceV2017ManagedIdentitySource.TryCreate(options) ??
                                                    CloudShellManagedIdentitySource.TryCreate(options) ??
                                                    AzureArcManagedIdentitySource.TryCreate(options) ??
                                                    ServiceFabricManagedIdentitySource.TryCreate(options) ??
                                                    TokenExchangeManagedIdentitySource.TryCreate(options) ??
                                                    new ImdsManagedIdentitySource(Pipeline, ClientId);
        }

        internal CredentialPipeline Pipeline { get; }

        protected string ClientId { get; }

        public virtual async ValueTask<AccessToken> AuthenticateAsync(bool async, TokenRequestContext context, CancellationToken cancellationToken)
        {
            return await _identitySource.AuthenticateAsync(async, context, cancellationToken).ConfigureAwait(false);
        }
    }
}
