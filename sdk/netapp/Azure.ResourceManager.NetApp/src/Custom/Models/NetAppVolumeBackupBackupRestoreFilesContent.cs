// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Restore payload for single file backup restore. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class NetAppVolumeBackupBackupRestoreFilesContent
    {
        /// <summary> Initializes a new instance of <see cref="NetAppVolumeBackupBackupRestoreFilesContent"/>. </summary>
        /// <param name="fileList"> List of files to be restored. </param>
        /// <param name="destinationVolumeId"> Resource Id of the destination volume on which the files need to be restored. </param>
        public NetAppVolumeBackupBackupRestoreFilesContent(IEnumerable<string> fileList, ResourceIdentifier destinationVolumeId)
        {
            FileList = fileList?.ToList();
            DestinationVolumeId = destinationVolumeId;
        }

        /// <summary> List of files to be restored. </summary>
        public IList<string> FileList { get; }

        /// <summary> Resource Id of the destination volume on which the files need to be restored. </summary>
        public ResourceIdentifier DestinationVolumeId { get; }

        /// <summary> Destination folder where the restore files will be placed. </summary>
        public string RestoreFilePath { get; set; }
    }
}
