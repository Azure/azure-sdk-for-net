// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    ///  Share File Permission.
    /// </summary>
    public class ShareFilePermission
    {
        /// <summary>
        /// Format of File Permission.
        /// </summary>
        public FilePermissionFormat? PermissionFormat { get;  set; }

        /// <summary>
        /// The File Permission itself, in SDDL or base64 encoded binary format.
        /// </summary>
        public string Permission { get;  set; }
    }
}
