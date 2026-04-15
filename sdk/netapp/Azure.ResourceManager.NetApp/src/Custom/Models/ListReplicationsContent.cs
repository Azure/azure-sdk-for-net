// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class ListReplicationsContent
    {
        /// <summary> Exclude replications filter. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ExcludeReplicationsFilter? ExcludeReplicationsFilter
        {
            get => Exclude;
            set => Exclude = value;
        }
    }
}
