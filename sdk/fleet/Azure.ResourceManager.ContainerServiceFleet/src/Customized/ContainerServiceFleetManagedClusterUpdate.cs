// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ContainerServiceFleet.Models
{
    public partial class ContainerServiceFleetManagedClusterUpdate
    {
        /// <summary> The node image upgrade type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NodeImageSelectionType? SelectionType
        {
            get => NodeImageSelection is null ? default(NodeImageSelectionType?) : NodeImageSelection.SelectionType;
            set
            {
                NodeImageSelection = value.HasValue ? new NodeImageSelection(value.Value) : null;
            }
        }
    }
}