﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    internal class MsalManagedIdentityClient
    {
        private readonly AsyncLockWithValue<IManagedIdentityApplication> _clientAsyncLock;
        private bool _isForceRefreshEnabled { get; }

        internal bool IsSupportLoggingEnabled { get; }
        internal Microsoft.Identity.Client.AppConfig.ManagedIdentityId ManagedIdentityId { get; }
        internal bool DisableInstanceDiscovery { get; }
        internal CredentialPipeline Pipeline { get; }
        internal Uri AuthorityHost { get; }

        protected MsalManagedIdentityClient()
        { }

        public MsalManagedIdentityClient(ManagedIdentityClientOptions clientOptions)
        {
            // This validation is performed as a backstop. Validation in TokenCredentialOptions.AuthorityHost prevents users from explicitly
            // setting AuthorityHost to a non TLS endpoint. However, the AuthorityHost can also be set by the AZURE_AUTHORITY_HOST environment
            // variable rather than in code. In this case we need to validate the endpoint before we use it. However, we can't validate in
            // CredentialPipeline as this is also used by the ManagedIdentityCredential which allows non TLS endpoints. For this reason
            // we validate here as all other credentials will create an MSAL client.
            Validations.ValidateAuthorityHost(clientOptions?.Options?.AuthorityHost);
            AuthorityHost = clientOptions?.Options?.AuthorityHost ?? AzureAuthorityHosts.GetDefault();
            IsSupportLoggingEnabled = clientOptions?.Options?.IsUnsafeSupportLoggingEnabled ?? false;

            // select the correct managed identity Id.
            ManagedIdentityId = clientOptions.ManagedIdentityId?._idType switch
            {
                ManagedIdentityIdType.SystemAssigned or null => Microsoft.Identity.Client.AppConfig.ManagedIdentityId.SystemAssigned,
                ManagedIdentityIdType.ClientId => Microsoft.Identity.Client.AppConfig.ManagedIdentityId.WithUserAssignedClientId(clientOptions.ManagedIdentityId._userAssignedId),
                ManagedIdentityIdType.ResourceId => Microsoft.Identity.Client.AppConfig.ManagedIdentityId.WithUserAssignedResourceId(clientOptions.ManagedIdentityId._userAssignedId),
                ManagedIdentityIdType.ObjectId => Microsoft.Identity.Client.AppConfig.ManagedIdentityId.WithUserAssignedObjectId(clientOptions.ManagedIdentityId._userAssignedId),
                _ => throw new InvalidOperationException("Invalid ManagedIdentityIdType")
            };

            Pipeline = clientOptions.Pipeline;
            _clientAsyncLock = new AsyncLockWithValue<IManagedIdentityApplication>();
            _isForceRefreshEnabled = clientOptions.IsForceRefreshEnabled;
        }

        protected ValueTask<IManagedIdentityApplication> CreateClientAsync(bool async, CancellationToken cancellationToken)
        {
            return CreateClientCoreAsync(async, cancellationToken);
        }

        protected virtual ValueTask<IManagedIdentityApplication> CreateClientCoreAsync(bool async, CancellationToken cancellationToken)
        {
            ManagedIdentityApplicationBuilder miAppBuilder = ManagedIdentityApplicationBuilder
                .Create(ManagedIdentityId)
                .WithHttpClientFactory(new HttpPipelineClientFactory(Pipeline.HttpPipeline), false)
                .WithLogging(AzureIdentityEventSource.Singleton, enablePiiLogging: IsSupportLoggingEnabled);

            return new ValueTask<IManagedIdentityApplication>(miAppBuilder.Build());
        }

        protected async ValueTask<IManagedIdentityApplication> GetClientAsync(bool async, CancellationToken cancellationToken)
        {
            using var asyncLock = await _clientAsyncLock.GetLockOrValueAsync(async, cancellationToken).ConfigureAwait(false);

            if (asyncLock.HasValue)
            {
                return asyncLock.Value;
            }

            var client = await CreateClientAsync(async, cancellationToken).ConfigureAwait(false);
            asyncLock.SetValue(client);
            return client;
        }

        public virtual async ValueTask<AuthenticationResult> AcquireTokenForManagedIdentityAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
            await AcquireTokenForManagedIdentityAsyncCore(true, requestContext, cancellationToken).ConfigureAwait(false);

        public virtual AuthenticationResult AcquireTokenForManagedIdentity(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
            AcquireTokenForManagedIdentityAsyncCore(false, requestContext, cancellationToken).EnsureCompleted();

        public virtual async ValueTask<AuthenticationResult> AcquireTokenForManagedIdentityAsyncCore(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            IManagedIdentityApplication client = await GetClientAsync(async, cancellationToken).ConfigureAwait(false);

            var builder = client.AcquireTokenForManagedIdentity(requestContext.Scopes.FirstOrDefault());

            if (_isForceRefreshEnabled)
            {
                builder.WithForceRefresh(true);
            }
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
            return async ?
                await builder.ExecuteAsync().ConfigureAwait(false) :
                builder.ExecuteAsync().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
        }
    }
}
