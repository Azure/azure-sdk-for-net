// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using AvailabilitySet.Definition;
    using AvailabilitySet.Update;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    internal partial class AvailabilitySetImpl 
    {
        /// <summary>
        /// Gets the fault domain count of this availability set.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet.FaultDomainCount
        {
            get
            {
                return this.FaultDomainCount();
            }
        }

        /// <summary>
        /// Gets the statuses of the existing virtual machines in the availability set.
        /// </summary>
        System.Collections.Generic.IList<Models.InstanceViewStatus> Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet.Statuses
        {
            get
            {
                return this.Statuses() as System.Collections.Generic.IList<Models.InstanceViewStatus>;
            }
        }

        /// <summary>
        /// Gets the resource IDs of the virtual machines in the availability set.
        /// </summary>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet.VirtualMachineIds
        {
            get
            {
                return this.VirtualMachineIds() as System.Collections.Generic.IList<string>;
            }
        }

        /// <summary>
        /// Gets the update domain count of this availability set.
        /// </summary>
        int Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet.UpdateDomainCount
        {
            get
            {
                return this.UpdateDomainCount();
            }
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet;
        }

        /// <summary>
        /// Specifies the fault domain count for the availability set.
        /// </summary>
        /// <param name="faultDomainCount">The fault domain count.</param>
        /// <return>The next stage of the definition.</return>
        AvailabilitySet.Definition.IWithCreate AvailabilitySet.Definition.IWithFaultDomainCount.WithFaultDomainCount(int faultDomainCount)
        {
            return this.WithFaultDomainCount(faultDomainCount) as AvailabilitySet.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the update domain count for the availability set.
        /// </summary>
        /// <param name="updateDomainCount">Update domain count.</param>
        /// <return>The next stage of the definition.</return>
        AvailabilitySet.Definition.IWithCreate AvailabilitySet.Definition.IWithUpdateDomainCount.WithUpdateDomainCount(int updateDomainCount)
        {
            return this.WithUpdateDomainCount(updateDomainCount) as AvailabilitySet.Definition.IWithCreate;
        }
    }
}