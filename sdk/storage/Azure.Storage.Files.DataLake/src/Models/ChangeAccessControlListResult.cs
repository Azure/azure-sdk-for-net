// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// ChangeAccessControlListResult contains summary counts of operations that change Access Control Lists recursively.
    /// See <see cref="DataLakePathClient.SetAccessControlListRecursive(System.Collections.Generic.IList{PathAccessControlItem}, int?, System.IProgress{ChangeAccessControlListPartialResult}, System.Threading.CancellationToken)"/>
    /// <see cref="DataLakePathClient.SetAccessControlListRecursiveAsync(System.Collections.Generic.IList{PathAccessControlItem}, int?, System.IProgress{ChangeAccessControlListPartialResult}, System.Threading.CancellationToken)"/>
    /// <see cref="DataLakePathClient.ModifyAccessControlListRecursive(System.Collections.Generic.IList{PathAccessControlItem}, int?, System.IProgress{ChangeAccessControlListPartialResult}, System.Threading.CancellationToken)"/>
    /// <see cref="DataLakePathClient.ModifyAccessControlListRecursiveAsync(System.Collections.Generic.IList{PathAccessControlItem}, int?, System.IProgress{ChangeAccessControlListPartialResult}, System.Threading.CancellationToken)"/>
    /// </summary>
    public class ChangeAccessControlListResult
    {
        /// <summary>
        /// Returns number of directories where Access Control List has been updated successfully.
        /// </summary>
        public int DirectoriesSuccessfulCount { get; internal set; }

        /// <summary>
        /// Returns number of files where Access Control List has been updated successfully.
        /// </summary>
        public int FilesSuccessfulCount { get; internal set; }

        /// <summary>
        /// Returns number of paths where Access Control List update has failed.
        /// </summary>
        public int  FailureCount { get; internal set; }

        internal ChangeAccessControlListResult() { }
    }
}
