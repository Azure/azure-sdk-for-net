// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for SecurityTypes.
    /// </summary>
    public enum SecurityTypes
    {
        /// <summary>
        /// Trusted launch protects against advanced and persistent attack
        /// techniques.
        /// </summary>
        TrustedLaunch,

        /// <summary>
        /// Azure confidential computing offers confidential VMs are for
        /// tenants with high security and confidentiality requirements. These
        /// VMs provide a strong, hardware-enforced boundary to help meet your
        /// security needs. You can use confidential VMs for migrations without
        /// making changes to your code, with the platform protecting your VM's
        /// state from being read or modified.
        /// </summary>
        ConfidentialVM
    }
}
