// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.NetApp
{
    // A backward-compat stub for the removed NetAppSubscriptionQuotaItemCollection type.
    // Use NetAppResourceQuotaLimitCollection instead. Cannot be instantiated by callers.
    /// <summary> Legacy collection of <see cref="NetAppSubscriptionQuotaItemResource"/>. </summary>
    [Obsolete("This collection has been replaced by NetAppResourceQuotaLimitCollection. Use NetAppResourceQuotaLimitCollection instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class NetAppSubscriptionQuotaItemCollection : ArmCollection, IEnumerable<NetAppSubscriptionQuotaItemResource>, IAsyncEnumerable<NetAppSubscriptionQuotaItemResource>
    {
        /// <summary> Initializes a new instance for mocking. </summary>
        protected NetAppSubscriptionQuotaItemCollection()
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

        IEnumerator<NetAppSubscriptionQuotaItemResource> IEnumerable<NetAppSubscriptionQuotaItemResource>.GetEnumerator() => throw new NotSupportedException("Deprecated. Use NetAppResourceQuotaLimitCollection.");
        IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException("Deprecated. Use NetAppResourceQuotaLimitCollection.");
        IAsyncEnumerator<NetAppSubscriptionQuotaItemResource> IAsyncEnumerable<NetAppSubscriptionQuotaItemResource>.GetAsyncEnumerator(CancellationToken cancellationToken) => throw new NotSupportedException("Deprecated. Use NetAppResourceQuotaLimitCollection.");
    }
}
