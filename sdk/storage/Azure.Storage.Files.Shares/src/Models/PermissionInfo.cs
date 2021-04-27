// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// PermissionInfo
    /// </summary>
    public class PermissionInfo
    {
        /// <summary>
        /// Key of the permission set for the directory/file.
        /// </summary>
        public string FilePermissionKey { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of PermissionInfo instances.
        /// You can use ShareModelFactory.PermissionInfo instead.
        /// </summary>
        internal PermissionInfo() { }
    }
}
