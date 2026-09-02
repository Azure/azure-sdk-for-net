// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // Backward compatibility shim for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // The new API version removed the addressList constructor parameter.
    // This preserves the old constructor signature from v1.1.2.
    public partial class InternetGatewayRules
    {
        /// <summary> Initializes a new instance of <see cref="InternetGatewayRules"/>. </summary>
        /// <param name="action"> The action to take on the traffic. </param>
        /// <param name="addressList"> List of Addresses to be allowed or denied. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This constructor is obsolete and will be removed in a future version.")]
        public InternetGatewayRules(InternetGatewayRuleAction action, IEnumerable<string> addressList) : this(action)
        {
        }
    }
}
