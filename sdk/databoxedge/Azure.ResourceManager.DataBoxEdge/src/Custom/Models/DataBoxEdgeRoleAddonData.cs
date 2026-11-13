// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Baseline had a public parameterless constructor. New generator requires discriminator parameter.

using System.ComponentModel;

namespace Azure.ResourceManager.DataBoxEdge
{
    public partial class DataBoxEdgeRoleAddonData
    {
        /// <summary> Initializes a new instance of <see cref="DataBoxEdgeRoleAddonData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataBoxEdgeRoleAddonData() : this(default)
        {
        }
    }
}
