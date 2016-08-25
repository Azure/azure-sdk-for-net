using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.V2.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.V2.Compute
{
    public partial class AvailabilitySetImpl : GroupableResource<IAvailabilitySet,
        AvailabilitySetInner,
        Rest.Azure.Resource,
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

        public int? FaultDomainCount
        {
            get
            {
                return Inner.PlatformFaultDomainCount;
            }
        }

        public IList<InstanceViewStatus> Statuses
        {
            get
            {
                return Inner.Statuses;
            }
        }

        public int? UpdateDomainCount
        {
            get
            {
                return Inner.PlatformUpdateDomainCount;
            }
        }

        public IList<string> VirtualMachineIds
        {
            get
            {
                if (idOfVMsInSet == null)
                {
                    idOfVMsInSet = (from subresource in Inner.VirtualMachines
                                    select subresource.Id).ToList();
                }
                return idOfVMsInSet;
            }
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

        public override async Task<IAvailabilitySet> Refresh()
        {
            var availabilitySetInner = await client.GetAsync(ResourceGroupName, Name);
            SetInner(availabilitySetInner);
            idOfVMsInSet = null;
            return this;
        }

        #endregion

        #region Setters

        #region Definition Setters

        public IWithCreate WithFaultDomainCount(int faultDomainCount)
        {
            Inner.PlatformFaultDomainCount = faultDomainCount;
            return this;
        }

        public IWithCreate WithUpdateDomainCount(int updateDomainCount)
        {
            Inner.PlatformUpdateDomainCount = updateDomainCount;
            return this;
        }

        #endregion

        #endregion
    }
}
