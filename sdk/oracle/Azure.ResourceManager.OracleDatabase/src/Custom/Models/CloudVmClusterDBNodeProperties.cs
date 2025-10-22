// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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

            DBNodeOcid = ocid.ToString();
            DBSystemOcid = dbSystemId.ToString();
        }

        /// <summary> The current state of the database node. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DBNodeProvisioningState? LifecycleState { get => DBNodeLifecycleState; }
        /// <summary> The date and time that the database node was created. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? TimeCreated { get => CreatedOn; }
        /// <summary> DbNode OCID. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier Ocid { get => new ResourceIdentifier(DBNodeOcid); }
        /// <summary> The OCID of the backup IP address associated with the database node. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier BackupIPId { get => new ResourceIdentifier(BackupIPOcid); }
        /// <summary> The OCID of the second backup VNIC. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier BackupVnic2Id { get => new ResourceIdentifier(BackupVnic2Ocid); }
        /// <summary> The OCID of the backup VNIC. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier BackupVnicId { get => new ResourceIdentifier(BackupVnicOcid); }
        /// <summary> The OCID of the Exacc Db server associated with the database node. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier DBServerId { get => new ResourceIdentifier(DBServerOcid); }
        /// <summary> The OCID of the DB system. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier DBSystemId { get => new ResourceIdentifier(DBSystemOcid); }
        /// <summary> The OCID of the host IP address associated with the database node. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier HostIPId { get => new ResourceIdentifier(HostIPOcid); }
        /// <summary> The OCID of the second VNIC. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier Vnic2Id { get => new ResourceIdentifier(Vnic2Ocid); }
        /// <summary> The OCID of the VNIC. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier VnicId { get => new ResourceIdentifier(VnicOcid); }
    }
}
