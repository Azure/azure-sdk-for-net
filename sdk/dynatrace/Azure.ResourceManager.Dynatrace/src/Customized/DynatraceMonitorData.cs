// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
// using Azure.ResourceManager.Dynatrace.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Dynatrace
{
    public partial class DynatraceMonitorData : TrackedResourceData
    {
        /// <summary> The managed service identities assigned to this resource. Current supported identity types: SystemAssigned, UserAssigned, SystemAndUserAssigned. </summary>
        public ResourceManager.Models.ManagedServiceIdentity Identity { get; set; }
    }
}
