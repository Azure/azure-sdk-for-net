// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional parameters for deleteing a Share.
    /// </summary>
    public class ShareDeleteOptions
    {
        /// <summary>
        /// A value indicating whether to delete a share's snapshots or leased snapshots in addition
        /// to the share itself.
        /// </summary>
        public ShareSnapshotsDeleteOption? ShareSnapshotsDeleteOption { get; set; }

        /// <summary>
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on deleting the share. Refer sample code <see href="https://github.com/Azure-Samples/Azure-CXP-Developer-Support/blob/main/Storage/File/dotnet/ShareDelete/Readme.md">here</see>.
        /// </summary>
        public ShareFileRequestConditions Conditions { get; set; }
    }
}
