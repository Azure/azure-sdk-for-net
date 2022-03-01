// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Identity
{
    internal class ManagedIdentityClient
    {
        internal const string MsiUnavailableError = "ManagedIdentityCredential authentication unavailable. No Managed Identity endpoint found.";

        private Lazy<ManagedIdentitySource> _identitySource;

        protected ManagedIdentityClient()
        { }

        public ManagedIdentityClient(CredentialPipeline pipeline, string clientId = null)
            : this(new ManagedIdentityClientOptions { Pipeline = pipeline, ClientId = clientId })
        { }

        public ManagedIdentityClient(CredentialPipeline pipeline, ResourceIdentifier resourceId)
            : this(new ManagedIdentityClientOptions { Pipeline = pipeline, ResourceIdentifier = resourceId })
        { }

        public ManagedIdentityClient(ManagedIdentityClientOptions options)
        {
            if (options.ClientId != null && options.ResourceIdentifier != null)
            {
                throw new ArgumentException(
                    $"{nameof(ManagedIdentityClientOptions)} cannot specify both {nameof(options.ResourceIdentifier)} and {nameof(options.ClientId)}.");
            }
            ClientId = options.ClientId;
            Pipeline = options.Pipeline;
            _identitySource = new Lazy<ManagedIdentitySource>(() => SelectManagedIdentitySource(options));
        }

        internal CredentialPipeline Pipeline { get; }

        protected string ClientId { get; }

        public virtual async ValueTask<AccessToken> AuthenticateAsync(bool async, TokenRequestContext context, CancellationToken cancellationToken)
        {
            return await _identitySource.Value.AuthenticateAsync(async, context, cancellationToken).ConfigureAwait(false);
        }

        private static ManagedIdentitySource SelectManagedIdentitySource(ManagedIdentityClientOptions options)
        {
            return AppServiceV2017ManagedIdentitySource.TryCreate(options) ??
                   CloudShellManagedIdentitySource.TryCreate(options) ??
                   AzureArcManagedIdentitySource.TryCreate(options) ??
                   ServiceFabricManagedIdentitySource.TryCreate(options) ??
                   TokenExchangeManagedIdentitySource.TryCreate(options) ??
                   new ImdsManagedIdentitySource(options);
        }
    }
}
