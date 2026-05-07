// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.RecoveryServicesSiteRecovery.Models;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    public partial class SiteRecoveryVaultSettingCollection : IEnumerable<SiteRecoveryVaultSettingResource>, IAsyncEnumerable<SiteRecoveryVaultSettingResource>
    {
        private readonly string _vaultName;

        internal SiteRecoveryVaultSettingCollection(ArmClient client, ResourceIdentifier id, string vaultName) : this(client, id)
        {
            Argument.AssertNotNullOrEmpty(vaultName, nameof(vaultName));
            _vaultName = vaultName;
        }

        private string GetVaultName()
        {
            if (string.IsNullOrEmpty(_vaultName))
            {
                throw new InvalidOperationException("This collection was constructed without a vault name. Use ResourceGroupResource.GetSiteRecoveryVaultSettings(resourceName) to get a vault-scoped collection.");
            }
            return _vaultName;
        }

        /// <summary> The operation to configure vault setting. </summary>
        public virtual Task<ArmOperation<SiteRecoveryVaultSettingResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string vaultSettingName, SiteRecoveryVaultSettingCreateOrUpdateContent content, CancellationToken cancellationToken = default)
            => CreateOrUpdateAsync(waitUntil, GetVaultName(), vaultSettingName, content, cancellationToken);

        /// <summary> The operation to configure vault setting. </summary>
        public virtual ArmOperation<SiteRecoveryVaultSettingResource> CreateOrUpdate(WaitUntil waitUntil, string vaultSettingName, SiteRecoveryVaultSettingCreateOrUpdateContent content, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, GetVaultName(), vaultSettingName, content, cancellationToken);

        /// <summary> Gets the vault setting. </summary>
        public virtual Task<Response<SiteRecoveryVaultSettingResource>> GetAsync(string vaultSettingName, CancellationToken cancellationToken = default)
            => GetAsync(GetVaultName(), vaultSettingName, cancellationToken);

        /// <summary> Gets the vault setting. </summary>
        public virtual Response<SiteRecoveryVaultSettingResource> Get(string vaultSettingName, CancellationToken cancellationToken = default)
            => Get(GetVaultName(), vaultSettingName, cancellationToken);

        /// <summary> Checks to see if the resource exists in azure. </summary>
        public virtual Task<Response<bool>> ExistsAsync(string vaultSettingName, CancellationToken cancellationToken = default)
            => ExistsAsync(GetVaultName(), vaultSettingName, cancellationToken);

        /// <summary> Checks to see if the resource exists in azure. </summary>
        public virtual Response<bool> Exists(string vaultSettingName, CancellationToken cancellationToken = default)
            => Exists(GetVaultName(), vaultSettingName, cancellationToken);

        /// <summary> Tries to get details for this resource from the service. </summary>
        public virtual Task<NullableResponse<SiteRecoveryVaultSettingResource>> GetIfExistsAsync(string vaultSettingName, CancellationToken cancellationToken = default)
            => GetIfExistsAsync(GetVaultName(), vaultSettingName, cancellationToken);

        /// <summary> Tries to get details for this resource from the service. </summary>
        public virtual NullableResponse<SiteRecoveryVaultSettingResource> GetIfExists(string vaultSettingName, CancellationToken cancellationToken = default)
            => GetIfExists(GetVaultName(), vaultSettingName, cancellationToken);

        /// <summary> Gets the list of vault setting. </summary>
        public virtual AsyncPageable<SiteRecoveryVaultSettingResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new AsyncPageableWrapper<SiteRecoveryVaultSettingData, SiteRecoveryVaultSettingResource>(new ReplicationVaultSettingGetAllAsyncCollectionResultOfT(
                _replicationVaultSettingRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                GetVaultName(),
                context,
                "SiteRecoveryVaultSettingCollection.GetAll"), data => new SiteRecoveryVaultSettingResource(Client, data));
        }

        /// <summary> Gets the list of vault setting. </summary>
        public virtual Pageable<SiteRecoveryVaultSettingResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PageableWrapper<SiteRecoveryVaultSettingData, SiteRecoveryVaultSettingResource>(new ReplicationVaultSettingGetAllCollectionResultOfT(
                _replicationVaultSettingRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                GetVaultName(),
                context,
                "SiteRecoveryVaultSettingCollection.GetAll"), data => new SiteRecoveryVaultSettingResource(Client, data));
        }

        IEnumerator<SiteRecoveryVaultSettingResource> IEnumerable<SiteRecoveryVaultSettingResource>.GetEnumerator() => GetAll().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetAll().GetEnumerator();
        IAsyncEnumerator<SiteRecoveryVaultSettingResource> IAsyncEnumerable<SiteRecoveryVaultSettingResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
    }
}
