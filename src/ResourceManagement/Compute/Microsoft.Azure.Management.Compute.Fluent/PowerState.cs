// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent.Models;
using System.Linq;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    /// <summary>
    /// Define values for PowerState
    /// </summary>
    public class PowerState
    {
        /// <summary>
        /// Static value PowerState/running for PowerState.
        /// </summary>
        public static readonly PowerState RUNNING = new PowerState("PowerState/running");

        /// <summary>
        /// Static value PowerState/deallocating for PowerState.
        /// </summary>
        public static readonly PowerState DEALLOCATING = new PowerState("PowerState/deallocating");

        /// <summary>
        /// Static value PowerState/deallocated for PowerState.
        /// </summary>
        public static readonly PowerState DEALLOCATED = new PowerState("PowerState/deallocated");

        /// <summary>
        /// Static value PowerState/starting for PowerState.
        /// </summary>
        public static readonly PowerState STARTING = new PowerState("PowerState/starting");

        /// <summary>
        /// Static value PowerState/stopped for PowerState.
        /// </summary>
        public static readonly PowerState STOPPED = new PowerState("PowerState/stopped");

        /// <summary>
        /// Static value PowerState/unknown for PowerState.
        /// </summary>
        public static readonly PowerState UNKNOWN = new PowerState("PowerState/unknown");

        private string value;

        public PowerState(string sizeName)
        {
            this.value = sizeName;
        }

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
                                        select new PowerState(status.Code)).FirstOrDefault();
            }
            return null;
        }

        public override string ToString()
        {
            return this.value;
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public static bool operator ==(PowerState lhs, PowerState rhs)
        {
            if (object.ReferenceEquals(lhs, null))
            {
                return object.ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(PowerState lhs, PowerState rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {

            string value = this.ToString();
            if (!(obj is PowerState))
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            PowerState rhs = (PowerState)obj;
            if (value == null)
            {
                return rhs.value == null;
            }
            return value.Equals(rhs.value);
        }
    }
}
