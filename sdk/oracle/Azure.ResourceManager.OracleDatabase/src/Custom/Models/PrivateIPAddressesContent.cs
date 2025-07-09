// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    /// <summary> Private Ip Addresses filter. </summary>
    public partial class PrivateIPAddressesContent
    {
        /// <summary> Initializes a new instance of <see cref="PrivateIPAddressesContent"/>. </summary>
        /// <param name="subnetId"> Subnet OCID. </param>
        /// <param name="vnicId"> VCN OCID. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subnetId"/> or <paramref name="vnicId"/> is null. </exception>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PrivateIPAddressesContent(ResourceIdentifier subnetId, ResourceIdentifier vnicId)
        {
            Argument.AssertNotNull(subnetId, nameof(subnetId));
            Argument.AssertNotNull(vnicId, nameof(vnicId));
        }

        /// <summary> Subnet OCID. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier SubnetId { get => new ResourceIdentifier(SubnetOcid); }
        /// <summary> VCN OCID. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier VnicId { get => new ResourceIdentifier(VnicOcid); }
    }
}
