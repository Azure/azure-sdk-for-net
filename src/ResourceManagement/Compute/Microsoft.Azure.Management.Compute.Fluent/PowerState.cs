// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System.Linq;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    /// <summary>
    /// Define values for PowerState
    /// </summary>
    public class PowerState : ExpandableStringEnum<PowerState>
    {
        /// <summary>
        /// Static value PowerState/running for PowerState.
        /// </summary>
        public static readonly PowerState Running = Parse("PowerState/running");

        /// <summary>
        /// Static value PowerState/deallocating for PowerState.
        /// </summary>
        public static readonly PowerState Deallocating = Parse("PowerState/deallocating");

        /// <summary>
        /// Static value PowerState/deallocated for PowerState.
        /// </summary>
        public static readonly PowerState Deallocated = Parse("PowerState/deallocated");

        /// <summary>
        /// Static value PowerState/starting for PowerState.
        /// </summary>
        public static readonly PowerState Starting = Parse("PowerState/starting");

        /// <summary>
        /// Static value PowerState/stopped for PowerState.
        /// </summary>
        public static readonly PowerState Stopped = Parse("PowerState/stopped");

        /// <summary>
        /// Static value PowerState/unknown for PowerState.
        /// </summary>
        public static readonly PowerState Unknown = Parse("PowerState/unknown");

        /// <summary>
        /// Creates an instance of PowerState from the virtual machine instance view status entry corresponding
        /// to the power state.
        /// </summary>
        /// <param name="virtualMachineInstanceView">the virtual machine instance view</param>
        /// <returns>the PowerState</returns>
        public static PowerState FromInstanceView(VirtualMachineInstanceView virtualMachineInstanceView)
        {
            if (virtualMachineInstanceView != null && virtualMachineInstanceView.Statuses != null)
            {
                return (from status in virtualMachineInstanceView.Statuses
                                        where status.Code != null && status.Code.StartsWith("PowerState")
                                        select Parse(status.Code)).FirstOrDefault();
            }
            return null;
        }
    }
}
