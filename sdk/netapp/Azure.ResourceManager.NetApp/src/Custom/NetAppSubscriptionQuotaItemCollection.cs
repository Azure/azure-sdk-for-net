// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
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
    }
}
