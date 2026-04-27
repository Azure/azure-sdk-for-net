// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    // The GA SDK exposed both `Exclude` (Obsolete alias) and `ExcludeReplicationsFilter` (primary).
    // The new spec emits only `ExcludeReplicationsFilter`, so we re-add the deprecated `Exclude`
    // alias here for source-compat. @@clientName cannot help because spec-side renames produce a
    // single name — we need both surfaces.
    public partial class ListReplicationsContent
    {
        /// <summary> Exclude Replications filter. 'None' returns all replications, 'Deleted' excludes deleted replications. Default is 'None'. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Please use 'ExcludeReplicationsFilter' instead.", false)]
        public ExcludeReplicationsFilter? Exclude
        {
            get => ExcludeReplicationsFilter;
            set => ExcludeReplicationsFilter = value;
        }
    }
}
