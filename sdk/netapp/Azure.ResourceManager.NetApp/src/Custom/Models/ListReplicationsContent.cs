// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.NetApp.Models
{
    // `Exclude` and `ExcludeReplicationsFilter` are aliases for the same underlying property.
    public partial class ListReplicationsContent
    {
        /// <summary> Exclude Replications filter. 'None' returns all replications, 'Deleted' excludes deleted replications. Default is 'None'. </summary>
        public ExcludeReplicationsFilter? Exclude
        {
            get => ExcludeReplicationsFilter;
            set => ExcludeReplicationsFilter = value;
        }
    }
}
