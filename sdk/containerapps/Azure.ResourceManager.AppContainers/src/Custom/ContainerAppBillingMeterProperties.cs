// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppContainers.Models
{
    /// <summary> Revision resource specific properties. </summary>
    public partial class ContainerAppBillingMeterProperties
    {
        /// <summary> billing category for container app. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Azure.ResourceManager.AppContainers.Models.ContainerAppBillingMeterCategory? Category { get => WorkloadProfileCategory; }
    }
}
