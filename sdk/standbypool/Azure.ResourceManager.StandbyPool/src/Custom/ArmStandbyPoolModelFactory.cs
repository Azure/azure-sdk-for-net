// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.StandbyPool.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmStandbyPoolModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.ContainerGroupInstanceCountSummary"/>. </summary>
        /// <param name="instanceCountsByState"> The count of pooled resources in each state. </param>
        /// <returns> A new <see cref="Models.ContainerGroupInstanceCountSummary"/> instance for mocking. </returns>
        public static ContainerGroupInstanceCountSummary ContainerGroupInstanceCountSummary(IEnumerable<PoolResourceStateCount> instanceCountsByState = null)
        {
            instanceCountsByState ??= new List<PoolResourceStateCount>();

            return new ContainerGroupInstanceCountSummary(instanceCountsByState?.ToList(), serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.PoolResourceStateCount"/>. </summary>
        /// <param name="state"> The state that the pooled resources count is for. </param>
        /// <param name="count"> The count of pooled resources in the given state. </param>
        /// <returns> A new <see cref="Models.PoolResourceStateCount"/> instance for mocking. </returns>
        public static PoolResourceStateCount PoolResourceStateCount(string state = null, long count = default)
        {
            return new PoolResourceStateCount(state, count, serializedAdditionalRawData: null);
        }
        /// <summary> Initializes a new instance of <see cref="Models.StandbyVirtualMachineInstanceCountSummary"/>. </summary>
        /// <param name="zone"> The zone that the provided counts are in. This is null if zones are not enabled on the attached VMSS. </param>
        /// <param name="instanceCountsByState"> The count of pooled resources in each state for the given zone. </param>
        /// <returns> A new <see cref="Models.StandbyVirtualMachineInstanceCountSummary"/> instance for mocking. </returns>
        public static StandbyVirtualMachineInstanceCountSummary StandbyVirtualMachineInstanceCountSummary(long? zone = null, IEnumerable<PoolResourceStateCount> instanceCountsByState = null)
        {
            instanceCountsByState ??= new List<PoolResourceStateCount>();
            return new StandbyVirtualMachineInstanceCountSummary(zone, instanceCountsByState?.ToList(), serializedAdditionalRawData: null);
        }
    }
}
