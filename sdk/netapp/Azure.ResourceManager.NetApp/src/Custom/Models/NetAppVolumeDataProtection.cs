// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Text;
//using Azure.ResourceManager.NetApp.Models;
//using static System.Net.Mime.MediaTypeNames;

//namespace Azure.ResourceManager.NetApp.Models
//{
//    /// <summary> DataProtection type volumes include an object containing details of the replication. </summary>
//    public partial class NetAppVolumeDataProtection
//    {
//        /// <summary> Backup Properties. </summary>
//        [EditorBrowsable(EditorBrowsableState.Never)]
//        public NetAppVolumeBackupConfiguration Backup { get; set; }

//        /// <summary> Initializes a new instance of NetAppVolumeDataProtection. </summary>
//        /// <param name="backup"> Backup Properties. </param>
//        /// <param name="replication"> Replication properties. </param>
//        /// <param name="snapshot"> Snapshot properties. </param>
//        /// <param name="volumeRelocation"> VolumeRelocation properties. </param>
//        internal NetAppVolumeDataProtection(NetAppVolumeBackupConfiguration backup, NetAppReplicationObject replication, VolumeSnapshotProperties snapshot, NetAppVolumeRelocationProperties volumeRelocation)
//        {
//            Backup = backup;
//            Replication = replication;
//            Snapshot = snapshot;
//            VolumeRelocation = volumeRelocation;
//        }
//    }
//}
