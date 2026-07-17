// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: keep the renamed discriminator base mockable/subclassable.
    public abstract partial class GcpOrganizationalInfo
    {
        /// <summary> Initializes a new instance of <see cref="GcpOrganizationalInfo"/>. </summary>
        protected GcpOrganizationalInfo()
        {
        }
    }
}
