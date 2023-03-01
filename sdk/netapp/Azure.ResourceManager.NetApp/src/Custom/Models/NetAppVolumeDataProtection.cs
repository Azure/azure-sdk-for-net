// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.ResourceManager.NetApp.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeDataProtection
    {
        internal NetAppVolumeDataProtection(NetAppVolumeBackupConfiguration backup, NetAppReplicationObject replication, VolumeSnapshotProperties snapshot)
        {
            Backup = backup;
            Replication = replication;
            Snapshot = snapshot;
        }
    }
}
