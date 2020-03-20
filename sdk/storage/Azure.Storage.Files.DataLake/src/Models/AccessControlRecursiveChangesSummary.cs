// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// AccessControlRecursiveChangesSummary contains summary counts of operations that change Access Control Lists recursively.
    /// </summary>
    public class AccessControlRecursiveChangesSummary
    {
        /// <summary>
        /// Returns number of directories where Access Control List has been updated successfully.
        /// </summary>
        public long DirectoriesSuccessfulCount { get; internal set; }

        /// <summary>
        /// Returns number of files where Access Control List has been updated successfully.
        /// </summary>
        public long FilesSuccessfulCount { get; internal set; }

        /// <summary>
        /// Returns number of paths where Access Control List update has failed.
        /// </summary>
        public long FailureCount { get; internal set; }

        internal AccessControlRecursiveChangesSummary() { }
    }
}
