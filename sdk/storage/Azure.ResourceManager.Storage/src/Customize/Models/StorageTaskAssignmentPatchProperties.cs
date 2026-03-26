// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Preserves older property names and exposes ProvisioningState as
// StorageProvisioningState (prior GA type) instead of generated type.

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Properties of the storage task update assignment. </summary>
    public partial class StorageTaskAssignmentPatchProperties
    {
        // CodeGenMember renames generated "ProvisioningState" to use StorageProvisioningState
        // type (prior GA type) instead of generated StorageTaskAssignmentProvisioningState.
        /// <summary> Represents the provisioning state of the storage task assignment. </summary>
        [CodeGenMember("ProvisioningState")]
        [WirePath("provisioningState")]
        public StorageProvisioningState? ProvisioningState { get; }

        // Backward-compatible alias: exposes the generated type alongside the prior GA type.
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

        // Prior GA property name was "Enabled"; generated code renamed it.
        // Hidden alias preserves the old name for binary compat.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("enabled")]
        public bool? IsEnabled { get; set; }

        /// <summary> Id of the corresponding storage task. </summary>
        [WirePath("taskId")]
        public string TaskId { get; set; }
    }
}
