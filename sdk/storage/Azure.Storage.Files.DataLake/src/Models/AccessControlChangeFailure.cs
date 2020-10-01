// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Represents an entry that failed to update Access Control List.
    /// </summary>
    public struct AccessControlChangeFailure
    {
        /// <summary>
        /// Returns name of an entry.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Returns whether entry is a directory.
        /// </summary>
        public bool IsDirectory { get; internal set; }

        /// <summary>
        /// Returns error message that is the reason why entry failed to update.
        /// </summary>
        public string ErrorMessage { get; internal set; }
    }
}
