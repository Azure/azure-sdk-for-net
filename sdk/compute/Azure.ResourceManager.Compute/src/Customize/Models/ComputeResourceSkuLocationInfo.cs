// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    // TEMPORARY: this piece of customized code replaces the ExtendedLocationType with the one in resourcemanager
    public partial class ComputeResourceSkuLocationInfo
    {
        /// <summary> The type of the extended location. </summary>
        [CodeGenMember("ExtendedLocationType")]
        public Azure.ResourceManager.Resources.Models.ExtendedLocationType? ExtendedLocationType { get; }
    }
}
