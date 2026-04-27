// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat stub: the GA SDK exposed a NetAppSubscriptionQuotaItemData type that has been
// replaced by NetAppResourceQuotaLimitData in the new TypeSpec spec. We keep an empty data type
// here so the deprecated NetAppSubscriptionQuotaItemResource (which carries this data type
// generically) still has a target to compile against. Public API consumers should migrate to
// NetAppResourceQuotaLimitData / NetAppResourceQuotaLimitResource.
namespace Azure.ResourceManager.NetApp
{
    /// <summary> SubscriptionQuotaItem data. </summary>
    public partial class NetAppSubscriptionQuotaItemData
    {
        /// <summary> Initializes a new instance of <see cref="NetAppSubscriptionQuotaItemData"/> for deserialization. </summary>
        public NetAppSubscriptionQuotaItemData()
        {
        }
    }
}
