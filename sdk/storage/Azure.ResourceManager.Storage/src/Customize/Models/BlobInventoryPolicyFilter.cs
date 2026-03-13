// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden IncludePrefix alias for renamed PrefixMatch property.
// Could use @@clientName in spec but would lose the improved name.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class BlobInventoryPolicyFilter
    {
        /// <summary> Backward-compatible alias for PrefixMatch. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("prefixMatch")]
        public IList<string> IncludePrefix => PrefixMatch;
    }
}
