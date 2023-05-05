// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary> Security profile for the container service cluster. </summary>
    [CodeGenSuppress("WorkloadIdentityEnabled")]
    [CodeGenSuppress("NodeRestrictionEnabled")]
    public partial class ManagedClusterSecurityProfile
    {
        /// <summary> Whether to enable Workload Identity. </summary>
        public bool? IsWorkloadIdentityEnabled
        {
            get => WorkloadIdentity is null ? default : WorkloadIdentity.Enabled;
            set
            {
                if (WorkloadIdentity is null)
                    WorkloadIdentity = new ManagedClusterSecurityProfileWorkloadIdentity();
                WorkloadIdentity.Enabled = value;
            }
        }

        /// <summary> Whether to enable Node Restriction. </summary>
        public bool? IsNodeRestrictionEnabled
        {
            get => NodeRestriction is null ? default : NodeRestriction.Enabled;
            set
            {
                if (NodeRestriction is null)
                    NodeRestriction = new ManagedClusterSecurityProfileNodeRestriction();
                NodeRestriction.Enabled = value;
            }
        }
    }
}
