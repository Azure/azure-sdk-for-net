// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    /// <summary> DbServer resource properties. </summary>
    public partial class OracleDBServerProperties
    {
        /// <summary> Initializes a new instance of <see cref="OracleDBServerProperties"/>. </summary>
        public OracleDBServerProperties()
        {
            VmClusterOcids = new ChangeTrackingList<string>();
            DBNodeOcids = new ChangeTrackingList<string>();
            AutonomousVmClusterOcids = new ChangeTrackingList<string>();
            AutonomousVirtualMachineOcids = new ChangeTrackingList<string>();
        }

        /// <summary> Db server name. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier Ocid { get => new ResourceIdentifier(DBServerOcid); }
        /// <summary> The OCID of the compartment. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier CompartmentId { get => new ResourceIdentifier(CompartmentOcid); }
        /// <summary> The OCID of the Exadata infrastructure. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier ExadataInfrastructureId { get => new ResourceIdentifier(ExadataInfrastructureOcid); }
        /// <summary> The OCID of the VM Clusters associated with the Db server. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<ResourceIdentifier> VmClusterIds { get => VmClusterOcids?.Select(id => new ResourceIdentifier(id)).ToList(); }
        /// <summary> The OCID of the Db nodes associated with the Db server. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<ResourceIdentifier> DBNodeIds { get => DBNodeOcids?.Select(id => new ResourceIdentifier(id)).ToList(); }
        /// <summary> The list of OCIDs of the Autonomous VM Clusters associated with the Db server. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<ResourceIdentifier> AutonomousVmClusterIds { get => AutonomousVmClusterOcids?.Select(id => new ResourceIdentifier(id)).ToList(); }
        /// <summary> The list of OCIDs of the Autonomous Virtual Machines associated with the Db server. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<ResourceIdentifier> AutonomousVirtualMachineIds { get => AutonomousVirtualMachineOcids?.Select(id => new ResourceIdentifier(id)).ToList(); }
    }
}
