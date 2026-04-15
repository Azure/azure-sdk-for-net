// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager;

namespace Azure.ResourceManager.NetApp
{
    /// <summary>
    /// A backward-compat stub for the removed RegionInfoResourceCollection type.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class RegionInfoResourceCollection : ArmCollection
    {
        /// <summary> Initializes a new instance for mocking. </summary>
        protected RegionInfoResourceCollection()
        {
        }
    }
}
