// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.AppContainers.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppContainers
{
    /// <summary> A class representing the ContainerAppManagedEnvironmentData data model. </summary>
    public partial class ContainerAppManagedEnvironmentData : TrackedResourceData
    {
        /// <summary> SkuName for container app. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Azure.ResourceManager.AppContainers.Models.AppContainersSkuName? SkuName { get; set; }
    }
}
