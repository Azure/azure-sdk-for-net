// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.Compute.Models;
    using System.Threading.Tasks;
    using System.Threading;
    using Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition;
    using Microsoft.Azure.Management.V2.Resource;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    internal partial class AvailabilitySetImpl
    {
        /// <returns>the fault domain count of this availability set</returns>
        int? Microsoft.Azure.Management.V2.Compute.IAvailabilitySet.FaultDomainCount
        {
            get
            {
                return this.FaultDomainCount;
            }
        }
        /// <returns>the statuses of the existing virtual machines in the availability set</returns>
        System.Collections.Generic.List<Microsoft.Azure.Management.Compute.Models.InstanceViewStatus> Microsoft.Azure.Management.V2.Compute.IAvailabilitySet.Statuses
        {
            get
            {
                return this.Statuses as System.Collections.Generic.List<Microsoft.Azure.Management.Compute.Models.InstanceViewStatus>;
            }
        }
        /// <returns>the resource IDs of the virtual machines in the availability set</returns>
        System.Collections.Generic.List<string> Microsoft.Azure.Management.V2.Compute.IAvailabilitySet.VirtualMachineIds
        {
            get
            {
                return this.VirtualMachineIds as System.Collections.Generic.List<string>;
            }
        }
        /// <returns>the update domain count of this availability set</returns>
        int? Microsoft.Azure.Management.V2.Compute.IAvailabilitySet.UpdateDomainCount
        {
            get
            {
                return this.UpdateDomainCount;
            }
        }
        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <returns>the refreshed resource</returns>
        Microsoft.Azure.Management.V2.Compute.IAvailabilitySet Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.V2.Compute.IAvailabilitySet>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.V2.Compute.IAvailabilitySet;
        }

        /// <summary>
        /// Specifies the fault domain count for the availability set.
        /// </summary>
        /// <param name="faultDomainCount">faultDomainCount the fault domain count</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition.IWithFaultDomainCount.WithFaultDomainCount(int faultDomainCount)
        {
            return this.WithFaultDomainCount(faultDomainCount) as Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the update domain count for the availability set.
        /// </summary>
        /// <param name="updateDomainCount">updateDomainCount update domain count</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition.IWithUpdateDomainCount.WithUpdateDomainCount(int updateDomainCount)
        {
            return this.WithUpdateDomainCount(updateDomainCount) as Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition.IWithCreate;
        }

    }
}