// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Properties of the storage task update assignment. </summary>
    public partial class StorageTaskAssignmentPatchProperties
    {
        /// <summary> Represents the provisioning state of the storage task assignment. </summary>
        [CodeGenMember("ProvisioningState")]
        [WirePath("provisioningState")]
        public StorageProvisioningState? ProvisioningState { get; }

        /// <summary> Represents the provisioning state of the storage task assignment. Backward-compatible alias. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("provisioningState")]
        public StorageTaskAssignmentProvisioningState? StorageTaskAssignmentProvisioningState
        {
            get
            {
                if (ProvisioningState == null) return null;
                return new StorageTaskAssignmentProvisioningState(ProvisioningState.Value.ToString());
            }
        }
    }
}
