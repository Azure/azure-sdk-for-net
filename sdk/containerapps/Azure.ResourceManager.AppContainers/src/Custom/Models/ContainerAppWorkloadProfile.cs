// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.AppContainers.Models
{
    public partial class ContainerAppWorkloadProfile
    {
        // The generated names must remain MaximumNodeCount/MinimumNodeCount for GA compatibility.
        // Preserve the newer MaximumCount/MinimumCount aliases and the shipped three-parameter constructor.
        /// <summary> Initializes a new instance of <see cref="ContainerAppWorkloadProfile"/>. </summary>
        /// <param name="workloadProfileType"> Workload profile type for the workloads to run on. </param>
        /// <param name="minimumCount"> The minimum capacity. </param>
        /// <param name="maximumCount"> The maximum capacity. </param>
        // TODO: Remove this compatibility constructor after https://github.com/microsoft/typespec/issues/11588 is fixed.
        public ContainerAppWorkloadProfile(string workloadProfileType, int minimumCount, int maximumCount)
            : this(workloadProfileType, workloadProfileType)
        {
            MinimumCount = minimumCount;
            MaximumCount = maximumCount;
        }

        /// <summary> The maximum capacity. </summary>
        public int MaximumCount
        {
            get => MaximumNodeCount.GetValueOrDefault();
            set => MaximumNodeCount = value;
        }

        /// <summary> The minimum capacity. </summary>
        public int MinimumCount
        {
            get => MinimumNodeCount.GetValueOrDefault();
            set => MinimumNodeCount = value;
        }
    }
}
