// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class ListReplicationsContent
    {
        public ExcludeReplicationsFilter? ExcludeReplicationsFilter
        {
            get => Exclude;
            set => Exclude = value;
        }
    }
}
