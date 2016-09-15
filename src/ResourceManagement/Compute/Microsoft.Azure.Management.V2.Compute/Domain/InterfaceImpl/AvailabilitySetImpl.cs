/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition;
    using Microsoft.Rest;
    using System.Threading;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Resource;
    using Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    public partial class AvailabilitySetImpl 
    {
        /// <summary>
        /// Returns the fault domain count of availability set.
        /// <p>
        /// A fault domain represents the group of virtual
        /// machines that shares common power source and network switch.
        /// </summary>
        /// <returns>the fault domain count</returns>
        int? Microsoft.Azure.Management.V2.Compute.IAvailabilitySet.FaultDomainCount
        {
            get
            {
                return this.FaultDomainCount;
            }
        }
        /// <summary>
        /// Lists the statuses of the existing virtual machines in the availability set.
        /// </summary>
        /// <returns>list of virtual machine statuses</returns>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Compute.Models.InstanceViewStatus> Microsoft.Azure.Management.V2.Compute.IAvailabilitySet.Statuses
        {
            get
            {
                return this.Statuses as System.Collections.Generic.IList<Microsoft.Azure.Management.Compute.Models.InstanceViewStatus>;
            }
        }
        /// <summary>
        /// Lists the resource IDs of the virtual machines in the availability set.
        /// </summary>
        /// <returns>list of resource ID strings</returns>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.V2.Compute.IAvailabilitySet.VirtualMachineIds
        {
            get
            {
                return this.VirtualMachineIds as System.Collections.Generic.IList<string>;
            }
        }
        /// <summary>
        /// Returns the update domain count of an availability set.
        /// <p>
        /// An update domain represents the group of virtual
        /// machines and underlying physical hardware that can be rebooted at the same time.
        /// </summary>
        /// <returns>the update domain count</returns>
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
        Microsoft.Azure.Management.V2.Compute.IAvailabilitySet Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.V2.Compute.IAvailabilitySet>.Refresh () {
            return this.Refresh() as Microsoft.Azure.Management.V2.Compute.IAvailabilitySet;
        }

        /// <summary>
        /// Execute the update request asynchronously.
        /// </summary>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        /// <returns>the handle to the REST call</returns>
        async Task<IAvailabilitySet> Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.V2.Compute.IAvailabilitySet>.ApplyAsync (CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true) {
            return await this.ApplyAsync() as IAvailabilitySet;
        }

        /// <summary>
        /// Execute the update request.
        /// </summary>
        /// <returns>the updated resource</returns>
        Microsoft.Azure.Management.V2.Compute.IAvailabilitySet Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.V2.Compute.IAvailabilitySet>.Apply () {
            return this.Apply() as Microsoft.Azure.Management.V2.Compute.IAvailabilitySet;
        }

        /// <summary>
        /// Specifies the fault domain count for the availability set.
        /// </summary>
        /// <param name="faultDomainCount">faultDomainCount fault domain count</param>
        /// <returns>the next stage of the resource definition</returns>
        Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition.IWithFaultDomainCount.WithFaultDomainCount (int faultDomainCount) {
            return this.WithFaultDomainCount( faultDomainCount) as Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the update domain count for the availability set.
        /// </summary>
        /// <param name="updateDomainCount">updateDomainCount update domain count</param>
        /// <returns>the next stage of the resource definition</returns>
        Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition.IWithCreate Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition.IWithUpdateDomainCount.WithUpdateDomainCount (int updateDomainCount) {
            return this.WithUpdateDomainCount( updateDomainCount) as Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition.IWithCreate;
        }

    }
}