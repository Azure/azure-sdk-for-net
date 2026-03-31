// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Why: Baseline had a public parameterless constructor. New generator requires discriminator parameter.
// This adds backward-compatible parameterless ctor.

namespace Azure.ResourceManager.DataBoxEdge
{
    public partial class DataBoxEdgeRoleData
    {
        /// <summary> Initializes a new instance of <see cref="DataBoxEdgeRoleData"/>. </summary>
        public DataBoxEdgeRoleData() : this(default)
        {
        }
    }
}
