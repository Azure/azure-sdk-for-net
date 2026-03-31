// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Baseline had a public parameterless constructor. New generator requires discriminator parameter.
// This adds backward-compatible parameterless ctor, hidden from IntelliSense since users should use subclass ctors.

using System.ComponentModel;

namespace Azure.ResourceManager.DataBoxEdge
{
    public partial class DataBoxEdgeRoleData
    {
        /// <summary> Initializes a new instance of <see cref="DataBoxEdgeRoleData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataBoxEdgeRoleData() : this(default)
        {
        }
    }
}
