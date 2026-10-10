// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the EffectiveBaseSecurityAdminRule type. </summary>
    public abstract partial class EffectiveBaseSecurityAdminRule
    {
        /// <summary> Resource ID. </summary>
        [WirePath("id")]
        public ResourceIdentifier ResourceId => Id;
    }
}
