// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    // Per PR review: `Exclude` and `ExcludeReplicationsFilter` are aliases for the same
    // underlying property, and the alias still works correctly (no behavior loss). Marking
    // it [Obsolete] would emit a warning even though calling it is fine — drop [Obsolete]
    // and keep only [EditorBrowsable(Never)] so existing code compiles cleanly while the
    // alias is hidden from IntelliSense.
    public partial class ListReplicationsContent
    {
        /// <summary> Exclude Replications filter. 'None' returns all replications, 'Deleted' excludes deleted replications. Default is 'None'. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ExcludeReplicationsFilter? Exclude
        {
            get => ExcludeReplicationsFilter;
            set => ExcludeReplicationsFilter = value;
        }
    }
}
