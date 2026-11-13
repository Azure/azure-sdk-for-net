// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ProviderHub.Models
{
    // Backward-compat: 1.2.x exposed the batch provisioning supported operations as a flattened
    // property. The current generator nests it under BatchProvisioningSupport, so this shim restores
    // the flattened accessor and initializes the nested model on demand.
    /// <summary> The ResourceTypeRegistrationResourceManagementOptions. </summary>
    public partial class ResourceTypeRegistrationResourceManagementOptions
    {
        /// <summary> Gets or sets the batch provisioning supported operations. </summary>
        public ResourceManagementSupportedOperation? BatchProvisioningSupportSupportedOperations
        {
            get => BatchProvisioningSupport?.SupportedOperations;
            set
            {
                if (BatchProvisioningSupport is null)
                    BatchProvisioningSupport = new BatchProvisioningSupport();
                BatchProvisioningSupport.SupportedOperations = value;
            }
        }
    }
}
