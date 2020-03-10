// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// ChangeAccessControlListResult.
    /// </summary>
    public class ChangeAccessControlListResultFailedEntry
    {
        /// <summary>
        /// DirectoriesSuccessful.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// FilesSuccessfulCount.
        /// </summary>
        public string Type { get; internal set; }

        /// <summary>
        /// FailureCount.
        /// </summary>
        public string  ErrorMessage { get; internal set; }

        internal ChangeAccessControlListResultFailedEntry() { }
    }
}
