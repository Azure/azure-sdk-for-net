// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppContainers.Models
{
    /// <summary> A class representing the ContainerAppAvailableWorkloadProfileProperties data model. </summary>
    public partial class ContainerAppAvailableWorkloadProfileProperties
    {
        /// <summary> billing category for container app. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Azure.ResourceManager.AppContainers.Models.ContainerAppBillingMeterCategory? BillingMeterCategory { get; set; }
    }
}
