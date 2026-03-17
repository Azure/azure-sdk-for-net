// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetworkCloud
{
    // CodeGenSuppress for parameterless ctor: the generated serialization file has an internal one.
    // After regeneration, only the custom public ctor will remain.
    [CodeGenSuppress("NetworkCloudRackSkuData")]
    public partial class NetworkCloudRackSkuData
    {
        // Backward compat: old API had a public parameterless constructor; new generated code has only internal.
        /// <summary> Initializes a new instance of <see cref="NetworkCloudRackSkuData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudRackSkuData()
        {
        }
    }
}
