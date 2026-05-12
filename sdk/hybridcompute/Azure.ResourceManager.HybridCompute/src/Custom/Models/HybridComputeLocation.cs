// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.HybridCompute.Models
{
    /// <summary>
    /// Backward-compatible alias for <see cref="LocationData"/>.
    /// This type was renamed to <see cref="LocationData"/> during the migration from AutoRest to TypeSpec.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class HybridComputeLocation : LocationData
    {
        /// <summary> Initializes a new instance of <see cref="HybridComputeLocation"/>. </summary>
        /// <param name="name"> A canonical name for the geographic or physical location. </param>
        public HybridComputeLocation(string name) : base(name) { }
    }
}
