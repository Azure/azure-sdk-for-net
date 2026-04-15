// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.NetApp
{
    /// <summary>
    /// A backward-compat stub for the removed NetAppSubscriptionQuotaItemCollection type.
    /// Use <see cref="NetAppResourceQuotaLimitCollection"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class NetAppSubscriptionQuotaItemCollection : ArmCollection
    {
        /// <summary> Initializes a new instance for mocking. </summary>
        protected NetAppSubscriptionQuotaItemCollection()
        {
        }

        internal NetAppSubscriptionQuotaItemCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Gets a quota item. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppSubscriptionQuotaItemResource> Get(string quotaLimitName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppSubscriptionQuotaItemCollection type. Use NetAppResourceQuotaLimitCollection instead.");
        }

        /// <summary> Gets a quota item. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppSubscriptionQuotaItemResource>> GetAsync(string quotaLimitName, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppSubscriptionQuotaItemCollection type. Use NetAppResourceQuotaLimitCollection instead.");
        }

        /// <summary> Gets all quota items. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppSubscriptionQuotaItemResource> GetAll(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppSubscriptionQuotaItemCollection type. Use NetAppResourceQuotaLimitCollection instead.");
        }

        /// <summary> Gets all quota items. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppSubscriptionQuotaItemResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppSubscriptionQuotaItemCollection type. Use NetAppResourceQuotaLimitCollection instead.");
        }

        /// <summary> Checks if a quota item exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string quotaLimitName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppSubscriptionQuotaItemCollection type. Use NetAppResourceQuotaLimitCollection instead.");
        }

        /// <summary> Checks if a quota item exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string quotaLimitName, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppSubscriptionQuotaItemCollection type. Use NetAppResourceQuotaLimitCollection instead.");
        }

        /// <summary> Gets a quota item if it exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<NetAppSubscriptionQuotaItemResource> GetIfExists(string quotaLimitName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppSubscriptionQuotaItemCollection type. Use NetAppResourceQuotaLimitCollection instead.");
        }

        /// <summary> Gets a quota item if it exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<NetAppSubscriptionQuotaItemResource>> GetIfExistsAsync(string quotaLimitName, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppSubscriptionQuotaItemCollection type. Use NetAppResourceQuotaLimitCollection instead.");
        }
    }
}
