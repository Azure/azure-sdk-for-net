// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.Sphere.Models;

namespace Azure.ResourceManager.Sphere
{
    public partial class SphereCatalogData
    {
        /// <summary> The status of the last operation. </summary>
        public SphereProvisioningState? ProvisioningState => Properties?.ProvisioningState;

        /// <summary> The Azure Sphere tenant ID associated with the catalog. </summary>
        public Guid? TenantId
        {
            get
            {
                string tenantId = Properties?.TenantId;
                return Guid.TryParse(tenantId, out Guid value) ? value : (Guid?)null;
            }
        }
    }
}
