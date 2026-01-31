// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Elastic.Models
{
    /// <summary> Properties specific to the monitor resource. </summary>
    public partial class ElasticMonitorProperties
    {
        /// <summary> Provisioning state of the monitor resource. </summary>
        public ElasticProvisioningState? ProvisioningState { get; set; }
    }
}
