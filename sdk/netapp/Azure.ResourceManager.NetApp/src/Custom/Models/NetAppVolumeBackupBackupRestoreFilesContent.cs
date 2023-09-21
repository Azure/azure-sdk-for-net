// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
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
        /// <summary> Initializes a new instance of NetAppVolumeBackupBackupRestoreFilesContent. </summary>
        /// <param name="fileList"> List of files to be restored. </param>
        /// <param name="destinationVolumeId"> Resource Id of the destination volume on which the files need to be restored. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileList"/> or <paramref name="destinationVolumeId"/> is null. </exception>
        public NetAppVolumeBackupBackupRestoreFilesContent(IEnumerable<string> fileList, ResourceIdentifier destinationVolumeId)
        {
            Argument.AssertNotNull(fileList, nameof(fileList));
            Argument.AssertNotNull(destinationVolumeId, nameof(destinationVolumeId));

            FileList = fileList.ToList();
            DestinationVolumeId = destinationVolumeId;
        }

        /// <summary> List of files to be restored. </summary>
        public IList<string> FileList { get; }
        /// <summary> Destination folder where the files will be restored. The path name should start with a forward slash. If it is omitted from request then restore is done at the root folder of the destination volume by default. </summary>
        public string RestoreFilePath { get; set; }
        /// <summary> Resource Id of the destination volume on which the files need to be restored. </summary>
        public ResourceIdentifier DestinationVolumeId { get; }
    }
}
