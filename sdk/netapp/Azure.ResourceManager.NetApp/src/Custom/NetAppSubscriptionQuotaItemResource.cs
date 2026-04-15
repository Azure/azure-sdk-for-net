// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.NetApp
{
    /// <summary>
    /// A backward-compat stub for the removed NetAppSubscriptionQuotaItemResource type.
    /// Use <see cref="NetAppResourceQuotaLimitResource"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class NetAppSubscriptionQuotaItemResource : ArmResource
    {
#pragma warning disable CS0649
        private NetAppSubscriptionQuotaItemData _data;
#pragma warning restore CS0649

        /// <summary> Initializes a new instance for mocking. </summary>
        protected NetAppSubscriptionQuotaItemResource()
        {
        }

        internal NetAppSubscriptionQuotaItemResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.NetApp/locations/quotaLimits";

        /// <summary> Gets whether the current instance has data. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool HasData => _data != null;

        /// <summary> Gets the data representing this resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NetAppSubscriptionQuotaItemData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        /// <summary> Creates a resource identifier. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string quotaLimitName)
        {
            return new ResourceIdentifier($"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/quotaLimits/{quotaLimitName}");
        }

        /// <summary> Gets the quota item. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppSubscriptionQuotaItemResource> Get(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is not supported on the deprecated NetAppSubscriptionQuotaItemResource type. Use NetAppResourceQuotaLimitResource instead.");
        }

        /// <summary> Gets the quota item. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppSubscriptionQuotaItemResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask.ConfigureAwait(false);
            throw new NotSupportedException("This method is not supported on the deprecated NetAppSubscriptionQuotaItemResource type. Use NetAppResourceQuotaLimitResource instead.");
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }
    }
}
