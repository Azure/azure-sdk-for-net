// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// AccessControlChanges contains partial counts of operations that change Access Control Lists recursively.
    /// Additionally it exposes path entries that failed to update while these operations progress.
    /// </summary>
    public class AccessControlChanges : AccessControlChangeCounters
    {
        /// <summary>
        /// An enumerable of path entries that failed to update Access Control List.
        /// </summary>
        public IEnumerable<AccessControlChangeFailure> FailedEntries { get; internal set; }

        internal AccessControlChanges() { }
    }
}
