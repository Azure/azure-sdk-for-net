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
        /// <param name="name"> Workload profile type for the workloads to run on. </param>
        /// <param name="maximumCount"> The maximum capacity. </param>
        /// <param name="minimumCount"> The minimum capacity. </param>
        public ContainerAppWorkloadProfile(string name, int maximumCount, int minimumCount)
            : this(name, name)
        {
            MaximumCount = maximumCount;
            MinimumCount = minimumCount;
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
