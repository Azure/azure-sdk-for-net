// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Storage.Files.DataLake.Models
{
    internal partial class SetAccessControlRecursiveResponse
    {
        public int? DirectoriesSuccessful { get; set;  }
        public int? FilesSuccessful { get; set;  }
        public int? FailureCount { get; set; }
        public IReadOnlyList<AclFailedEntry> FailedEntries { get; set; }
    }
}
