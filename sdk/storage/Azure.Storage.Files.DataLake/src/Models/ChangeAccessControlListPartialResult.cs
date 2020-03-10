// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// ChangeAccessControlListPartialResult contains partial counts of operations that change Access Control Lists recursively.
    /// Additionally it exposes path entries that failed to update while these operations progress.
    /// See <see cref="DataLakePathClient.SetAccessControlListRecursive(System.Collections.Generic.IList{PathAccessControlItem}, int?, System.IProgress{ChangeAccessControlListPartialResult}, System.Threading.CancellationToken)"/>
    /// <see cref="DataLakePathClient.SetAccessControlListRecursiveAsync(System.Collections.Generic.IList{PathAccessControlItem}, int?, System.IProgress{ChangeAccessControlListPartialResult}, System.Threading.CancellationToken)"/>
    /// <see cref="DataLakePathClient.ModifyAccessControlListRecursive(System.Collections.Generic.IList{PathAccessControlItem}, int?, System.IProgress{ChangeAccessControlListPartialResult}, System.Threading.CancellationToken)"/>
    /// <see cref="DataLakePathClient.ModifyAccessControlListRecursiveAsync(System.Collections.Generic.IList{PathAccessControlItem}, int?, System.IProgress{ChangeAccessControlListPartialResult}, System.Threading.CancellationToken)"/>
    /// </summary>
    public class ChangeAccessControlListPartialResult : ChangeAccessControlListResult
    {
        /// <summary>
        /// An enumerable of path entries that failed to update Access Control List.
        /// </summary>
        public IEnumerable<ChangeAccessControlListResultFailedEntry> FailedEntries { get; internal set; }

        internal ChangeAccessControlListPartialResult() { }
    }
}
