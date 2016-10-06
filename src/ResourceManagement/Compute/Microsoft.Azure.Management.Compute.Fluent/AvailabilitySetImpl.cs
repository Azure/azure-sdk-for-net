// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    internal partial class AvailabilitySetImpl : GroupableResource<IAvailabilitySet,
        AvailabilitySetInner,
        Microsoft.Azure.Management.Resource.Fluent.Resource,
        AvailabilitySetImpl,
        IComputeManager, 
        AvailabilitySet.Definition.IWithGroup,
        AvailabilitySet.Definition.IWithCreate,
        AvailabilitySet.Definition.IWithCreate,
        AvailabilitySet.Update.IUpdate>,
        IAvailabilitySet,
        AvailabilitySet.Definition.IDefinition,
        AvailabilitySet.Update.IUpdate
    {
        private IAvailabilitySetsOperations client;
        private List<string> idOfVMsInSet;

        internal AvailabilitySetImpl(string name, AvailabilitySetInner innerModel,
            IAvailabilitySetsOperations client,
            IComputeManager computeManager) : base(name, innerModel, computeManager)
        {
            this.client = client;
        }

        #region Getters

        public int FaultDomainCount()
        {
            return (Inner.PlatformFaultDomainCount.HasValue) ? Inner.PlatformFaultDomainCount.Value : 0;
        }

        public IList<InstanceViewStatus> Statuses()
        {
            return Inner.Statuses;
        }

        public int UpdateDomainCount()
        {
            return (Inner.PlatformUpdateDomainCount.HasValue) ? Inner.PlatformUpdateDomainCount.Value : 0;
        }

        public IList<string> VirtualMachineIds()
        {
            if (idOfVMsInSet == null)
            {
                idOfVMsInSet = (from subresource in Inner.VirtualMachines
                                select subresource.Id).ToList();
            }
            return idOfVMsInSet;
        }

        #endregion

        public override async Task<IAvailabilitySet> CreateResourceAsync(CancellationToken cancellationToken)
        {
            var availabilitySetInner = await client.CreateOrUpdateAsync(ResourceGroupName, Name, Inner);
            SetInner(availabilitySetInner);
            idOfVMsInSet = null;
            return this;
        }

        #region Implementation of IRefreshable

        public override IAvailabilitySet Refresh()
        {
            var availabilitySetInner = client.Get(ResourceGroupName, Name);
            SetInner(availabilitySetInner);
            idOfVMsInSet = null;
            return this;
        }

        #endregion

        #region Setters

        #region Definition Setters

        public AvailabilitySetImpl WithFaultDomainCount(int faultDomainCount)
        {
            Inner.PlatformFaultDomainCount = faultDomainCount;
            return this;
        }

        public AvailabilitySetImpl WithUpdateDomainCount(int updateDomainCount)
        {
            Inner.PlatformUpdateDomainCount = updateDomainCount;
            return this;
        }

        #endregion

        #endregion
    }
}
