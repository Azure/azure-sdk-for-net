// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: Adds constructor overload and property aliases matching prior GA surface.
// Properties were renamed and constructor signature changed.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Properties of the storage task assignment. </summary>
    public partial class StorageTaskAssignmentProperties
    {
        // Prior GA used StorageProvisioningState type; generated code uses
        // StorageTaskAssignmentProvisioningState. Hidden alias for backward compat.
        /// <summary> Represents the provisioning state of the storage task assignment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("provisioningState")]
        public StorageProvisioningState? ProvisioningState { get; internal set; }

        // Backward-compat: prior GA exposed this as StorageTaskAssignmentProvisioningState type with this property name.
        /// <summary> Represents the provisioning state of the storage task assignment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("provisioningState")]
        public StorageTaskAssignmentProvisioningState? StorageTaskAssignmentProvisioningState =>
            ProvisioningState.HasValue ? new StorageTaskAssignmentProvisioningState(ProvisioningState.Value.ToString()) : null;

        // Prior GA property name was "Enabled"; generated code renamed it.
        // Hidden alias preserves the old name for binary compat.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("enabled")]
        public bool IsEnabled { get; set; }

        /// <summary> Initializes a new instance of <see cref="StorageTaskAssignmentProperties"/>. </summary>
        /// <param name="taskId"> Id of the corresponding storage task. </param>
        /// <param name="isEnabled"> Whether the storage task assignment is enabled or not. </param>
        /// <param name="description"> Text that describes the purpose of the storage task assignment. </param>
        /// <param name="executionContext"> The storage task assignment execution context. </param>
        /// <param name="report"> The storage task assignment report. </param>
        // Backward-compatible constructor.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StorageTaskAssignmentProperties(ResourceIdentifier taskId, bool isEnabled, string description, StorageTaskAssignmentExecutionContext executionContext, StorageTaskAssignmentReport report)
            : this(taskId, isEnabled, description, executionContext, report, default, default, null)
        {
        }
    }
}
