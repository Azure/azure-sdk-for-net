// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;
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
        /// <summary> Initializes a new instance for mocking. </summary>
        protected NetAppSubscriptionQuotaItemResource()
        {
        }

        internal NetAppSubscriptionQuotaItemResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.NetApp/locations/quotaLimits";

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }
    }
}
