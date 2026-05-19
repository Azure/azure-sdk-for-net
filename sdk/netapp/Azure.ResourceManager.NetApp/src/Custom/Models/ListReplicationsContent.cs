// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class ListReplicationsContent
    {
        // Backward-compat: Exclude shipped in GA as an alias for the generated
        // ExcludeReplicationsFilter property. Keep it hidden from IntelliSense.
        /// <summary> Exclude Replications filter. 'None' returns all replications, 'Deleted' excludes deleted replications. Default is 'None'. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ExcludeReplicationsFilter? Exclude
        {
            get => ExcludeReplicationsFilter;
            set => ExcludeReplicationsFilter = value;
        }
    }
}
