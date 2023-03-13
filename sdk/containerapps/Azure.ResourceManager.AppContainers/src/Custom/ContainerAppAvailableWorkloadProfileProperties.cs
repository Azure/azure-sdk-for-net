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

namespace Azure.ResourceManager.AppContainers.Models
{
    /// <summary> A class representing the ContainerAppAvailableWorkloadProfileProperties data model. </summary>
    public partial class ContainerAppAvailableWorkloadProfileProperties
    {
        /// <summary> billing category for container app. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Azure.ResourceManager.AppContainers.Models.ContainerAppBillingMeterCategory? BillingMeterCategory { get; set; }
    }
}
