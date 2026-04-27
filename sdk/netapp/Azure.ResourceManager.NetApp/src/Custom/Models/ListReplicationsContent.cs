// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
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
