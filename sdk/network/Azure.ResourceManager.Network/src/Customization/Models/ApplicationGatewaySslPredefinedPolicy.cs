// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ApplicationGatewaySslPredefinedPolicy
    {
        // Absent in 1.15.0, but shipped in 1.17.0. Preserve the released subclass constructor signature.
        /// <summary> Initializes a new instance of the ApplicationGatewaySslPredefinedPolicy class. </summary>
        protected ApplicationGatewaySslPredefinedPolicy(bool _) { }

        // ApiCompat CP0002: 1.17.0 requires the non-nullable ResourceType.get, not the inherited nullable getter.
        // Read native wire metadata rather than inferring a potentially different type from Id.
        /// <summary> Gets the resource type. </summary>
        public new ResourceType ResourceType => base.ResourceType ?? default;
    }
}
