// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// AccessControlChangeCounters contains counts of operations that change Access Control Lists recursively.
    /// </summary>
    public struct AccessControlChangeCounters
    {
        /// <summary>
        /// Returns number of directories where Access Control List has been updated successfully.
        /// </summary>
        public long ChangedDirectoriesCount { get; internal set; }

        /// <summary>
        /// Returns number of files where Access Control List has been updated successfully.
        /// </summary>
        public long ChangedFilesCount { get; internal set; }

        /// <summary>
        /// Returns number of paths where Access Control List update has failed.
        /// </summary>
        public long FailedChangesCount { get; internal set; }
    }
}
