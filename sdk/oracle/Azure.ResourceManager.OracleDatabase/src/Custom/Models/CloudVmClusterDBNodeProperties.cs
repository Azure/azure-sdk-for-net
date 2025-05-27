// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    public partial class CloudVmClusterDBNodeProperties
    {
        /// <summary> Initializes a new instance of <see cref="CloudVmClusterDBNodeProperties"/>. </summary>
        /// <param name="ocid"> DbNode OCID. </param>
        /// <param name="dbSystemId"> The OCID of the DB system. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CloudVmClusterDBNodeProperties(ResourceIdentifier ocid, ResourceIdentifier dbSystemId)
        {
            Argument.AssertNotNull(ocid, nameof(ocid));
            Argument.AssertNotNull(dbSystemId, nameof(dbSystemId));

            Ocid = ocid.ToString();
            DBSystemId = dbSystemId.ToString();
        }

        /// <summary> The current state of the database node. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DBNodeProvisioningState? LifecycleState { get => DBNodeLifecycleState; }

        /// <summary> The date and time that the database node was created. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? TimeCreated { get => CreatedOn; }
    }
}
