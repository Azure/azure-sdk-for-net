// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.AppContainers.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppContainers.Models
{
    /// <summary> Workload profile to scope container app execution. </summary>
    public partial class ContainerAppWorkloadProfile
    {
        /// <summary> SkuName for container app. </summary>
        public ContainerAppWorkloadProfile(string workloadProfileType, int minimumCount, int maximumCount)
        {
            Argument.AssertNotNull(workloadProfileType, nameof(workloadProfileType));

            WorkloadProfileType = workloadProfileType;
            MinimumCount = minimumCount;
            MaximumCount = maximumCount;
        }

        /// <summary> SkuName for container app. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int MinimumCount { get => MinCount ?? default; set => MinCount = value; }

        /// <summary> SkuName for container app. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int MaximumCount { get => MaxCount ?? default; set => MaxCount = value; }
    }
}
