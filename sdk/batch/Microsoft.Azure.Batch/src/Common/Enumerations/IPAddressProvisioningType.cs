// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Linq;

    /// <summary>
    /// The provisioning type for Public IP Addresses for the Pool.
    /// </summary>
    public enum IPAddressProvisioningType
    {
        /// <summary>
        /// A public IP will be created and managed by Batch. There may be multiple public IPs depending on the size of the Pool.
        /// </summary>
        BatchManaged,

        /// <summary>
        /// Public IPs are provided by the user and will be used to provision the Compute Nodes.
        /// </summary>
        UserManaged,

        /// <summary>
        /// No public IP Address will be created.
        /// </summary>
        NoPublicIPAddresses
    }
}
