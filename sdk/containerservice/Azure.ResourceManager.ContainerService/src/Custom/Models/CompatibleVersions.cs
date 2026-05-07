// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.ContainerService;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class CompatibleVersions
    {
        /// <summary> Initializes a new instance of <see cref="CompatibleVersions"/>. </summary>
        public CompatibleVersions()
        {
            Versions = new ChangeTrackingList<string>();
        }

        /// <summary> The product/service name. </summary>
        [WirePath("name")]
        public string Name { get; set; }
    }
}
