// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.OracleDatabase;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    /// <summary>
    /// DbSystem resource base model.
    /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="OracleDBSystemProperties"/>.
    /// </summary>
    public abstract partial class OracleDBSystemBaseProperties
    {
        /// <summary> Initializes a new instance of <see cref="OracleDBSystemBaseProperties"/>. </summary>
        /// <param name="resourceAnchorId"> Azure Resource Anchor ID. </param>
        /// <param name="networkAnchorId"> Azure Network Anchor ID. </param>
        /// <param name="hostname"> The hostname for the DB system. </param>
        /// <param name="shape"> The shape of the DB system. The shape determines resources to allocate to the DB system. For virtual machine shapes, the number of CPU cores and memory. For bare metal and Exadata shapes, the number of CPU cores, storage, and memory. </param>
        /// <param name="sshPublicKeys"> The public key portion of one or more key pairs used for SSH access to the DB system. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceAnchorId"/>, <paramref name="networkAnchorId"/>, <paramref name="hostname"/>, <paramref name="shape"/> or <paramref name="sshPublicKeys"/> is null. </exception>
        protected OracleDBSystemBaseProperties(ResourceIdentifier resourceAnchorId, ResourceIdentifier networkAnchorId, string hostname, string shape, IEnumerable<string> sshPublicKeys)
        {
            Argument.AssertNotNull(resourceAnchorId, nameof(resourceAnchorId));
            Argument.AssertNotNull(networkAnchorId, nameof(networkAnchorId));
            Argument.AssertNotNull(hostname, nameof(hostname));
            Argument.AssertNotNull(shape, nameof(shape));
            Argument.AssertNotNull(sshPublicKeys, nameof(sshPublicKeys));

            ResourceAnchorId = resourceAnchorId;
            NetworkAnchorId = networkAnchorId;
            Hostname = hostname;
            ScanIPs = new ChangeTrackingList<string>();
            Shape = shape;
            SshPublicKeys = sshPublicKeys.ToList();
        }
    }
}
