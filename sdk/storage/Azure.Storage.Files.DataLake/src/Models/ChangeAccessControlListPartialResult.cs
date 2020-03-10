// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// ChangeAccessControlListPartialResult.
    /// </summary>
    public class ChangeAccessControlListPartialResult : ChangeAccessControlListResult
    {
        /// <summary>
        /// Failed Entries.
        /// </summary>
        public IEnumerable<ChangeAccessControlListResultFailedEntry> FailedEntries { get; internal set; }

        internal ChangeAccessControlListPartialResult() { }
    }
}
