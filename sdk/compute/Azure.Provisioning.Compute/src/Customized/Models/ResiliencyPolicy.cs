// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

#nullable disable

namespace Azure.Provisioning.Compute
{
    public partial class ResiliencyPolicy
    {
        // TODO: Remove these custom member renames once https://github.com/Azure/azure-sdk-for-net/issues/60921 is fixed.
        /// <summary> Gets or sets the Enabled. </summary>
        [CodeGenMember("ResilientVmCreationEnabled")]
        public BicepValue<bool> ResilientVmCreationPolicyEnabled
        {
            get
            {
                return ResilientVmCreationPolicy is null ? default : ResilientVmCreationPolicy.Enabled;
            }
            set
            {
                if (ResilientVmCreationPolicy is null)
                {
                    ResilientVmCreationPolicy = new ResilientVMCreationPolicy();
                }
                ResilientVmCreationPolicy.Enabled = value;
            }
        }

        /// <summary> Gets or sets the Enabled. </summary>
        [CodeGenMember("ResilientVmDeletionEnabled")]
        public BicepValue<bool> ResilientVmDeletionPolicyEnabled
        {
            get
            {
                return ResilientVmDeletionPolicy is null ? default : ResilientVmDeletionPolicy.Enabled;
            }
            set
            {
                if (ResilientVmDeletionPolicy is null)
                {
                    ResilientVmDeletionPolicy = new ResilientVMDeletionPolicy();
                }
                ResilientVmDeletionPolicy.Enabled = value;
            }
        }
    }
}
