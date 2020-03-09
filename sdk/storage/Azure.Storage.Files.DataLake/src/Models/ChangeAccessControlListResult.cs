// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// ChangeAccessControlListResult.
    /// </summary>
    public class ChangeAccessControlListResult
    {
        /// <summary>
        /// DirectoriesSuccessful.
        /// </summary>
        public int DirectoriesSuccessfulCount { get; internal set; }

        /// <summary>
        /// FilesSuccessfulCount.
        /// </summary>
        public int FilesSuccessfulCount { get; internal set; }

        /// <summary>
        /// FailureCount.
        /// </summary>
        public int  FailureCount { get; internal set; }

        internal ChangeAccessControlListResult() { }
    }
}
