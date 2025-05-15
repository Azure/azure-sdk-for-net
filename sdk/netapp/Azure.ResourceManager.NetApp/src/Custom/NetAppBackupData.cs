// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    /// <summary>
    /// A class representing the NetAppBackup data model.
    /// Backup of a Volume
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class NetAppBackupData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="NetAppBackupData"/>. </summary>
        /// <param name="location"> Resource location. </param>
        public NetAppBackupData(AzureLocation location)
        {
            Location = location;
        }

        /// <summary> Resource location. </summary>
        public AzureLocation Location { get; set; }

        /// <summary> Volume name. </summary>
        public string VolumeName { get; }

        /// <summary> ResourceId used to identify the backup policy. </summary>
        public string BackupPolicyResourceId
        {
            get { return BackupPolicyArmResourceId?.ToString();}
        }
    }
}
