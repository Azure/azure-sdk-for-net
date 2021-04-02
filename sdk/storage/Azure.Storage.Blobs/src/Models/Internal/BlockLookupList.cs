// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Storage.Blobs.Models
{
    internal partial class BlockLookupList
    {
        public IList<string> Committed { get; set; }
        public IList<string> Uncommitted { get; set; }
        public IList<string> Latest { get; set; }
    }
}
