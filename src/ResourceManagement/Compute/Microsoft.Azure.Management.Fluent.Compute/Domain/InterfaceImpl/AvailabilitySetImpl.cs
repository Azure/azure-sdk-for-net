// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Compute
{

    using Microsoft.Azure.Management.Compute.Models;
    using System.Threading;
    using Microsoft.Azure.Management.Fluent.Compute.AvailabilitySet.Definition;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Fluent.Compute.AvailabilitySet.Update;
    using Microsoft.Azure.Management.Fluent.Resource;
    using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
    internal partial class AvailabilitySetImpl 
    {
        /// <returns>the fault domain count of this availability set</returns>
        int Microsoft.Azure.Management.Fluent.Compute.IAvailabilitySet.FaultDomainCount
        {
            get
            { 
            return this.FaultDomainCount();
            }
        }
        /// <returns>the statuses of the existing virtual machines in the availability set</returns>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Compute.Models.InstanceViewStatus> Microsoft.Azure.Management.Fluent.Compute.IAvailabilitySet.Statuses
        {
            get
            { 
            return this.Statuses() as System.Collections.Generic.IList<Microsoft.Azure.Management.Compute.Models.InstanceViewStatus>;
            }
        }
        /// <returns>the resource IDs of the virtual machines in the availability set</returns>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Fluent.Compute.IAvailabilitySet.VirtualMachineIds
        {
            get
            { 
            return this.VirtualMachineIds() as System.Collections.Generic.IList<string>;
            }
        }
        /// <returns>the update domain count of this availability set</returns>
        int Microsoft.Azure.Management.Fluent.Compute.IAvailabilitySet.UpdateDomainCount
        {
            get
            { 
            return this.UpdateDomainCount();
            }
        }
        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <returns>the refreshed resource</returns>
        Microsoft.Azure.Management.Fluent.Compute.IAvailabilitySet Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Fluent.Compute.IAvailabilitySet>.Refresh() { 
            return this.Refresh() as Microsoft.Azure.Management.Fluent.Compute.IAvailabilitySet;
        }

        /// <summary>
        /// Specifies the fault domain count for the availability set.
        /// </summary>
        /// <param name="faultDomainCount">faultDomainCount the fault domain count</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.AvailabilitySet.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Compute.AvailabilitySet.Definition.IWithFaultDomainCount.WithFaultDomainCount(int faultDomainCount) { 
            return this.WithFaultDomainCount( faultDomainCount) as Microsoft.Azure.Management.Fluent.Compute.AvailabilitySet.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the update domain count for the availability set.
        /// </summary>
        /// <param name="updateDomainCount">updateDomainCount update domain count</param>
        /// <returns>the next stage of the definition</returns>
        Microsoft.Azure.Management.Fluent.Compute.AvailabilitySet.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Compute.AvailabilitySet.Definition.IWithUpdateDomainCount.WithUpdateDomainCount(int updateDomainCount) { 
            return this.WithUpdateDomainCount( updateDomainCount) as Microsoft.Azure.Management.Fluent.Compute.AvailabilitySet.Definition.IWithCreate;
        }

    }
}