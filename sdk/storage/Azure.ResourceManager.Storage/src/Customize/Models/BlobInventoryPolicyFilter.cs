// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class BlobInventoryPolicyFilter
    {
        /// <summary> Backward-compatible alias for PrefixMatch. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> IncludePrefix => PrefixMatch;
    }
}
