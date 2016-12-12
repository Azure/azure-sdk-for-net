// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Threading;

    /// <summary>
    /// The implementation for AvailabilitySet and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uQXZhaWxhYmlsaXR5U2V0SW1wbA==
    internal partial class AvailabilitySetImpl : GroupableResource<IAvailabilitySet,
        AvailabilitySetInner,
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

        ///GENMHASH:8C96B0BDC54BDF41F3FC5BCCAA028C8D:113A819FAF18DEACEC4BCC60120F8166
        internal AvailabilitySetImpl(string name, AvailabilitySetInner innerModel,
            IAvailabilitySetsOperations client,
            IComputeManager computeManager) : base(name, innerModel, computeManager)
        {
            this.client = client;
        }

        ///GENMHASH:C260E0C5666F525F67582200AB726081:4B1DAA6C409946EBB2C2321E793006F2
        public int FaultDomainCount()
        {
            return (Inner.PlatformFaultDomainCount.HasValue) ? Inner.PlatformFaultDomainCount.Value : 0;
        }

        ///GENMHASH:2BD1C2DEE2E7FBB6D90AB920FAD6E9EE:EA53AD3391D9207B84DE8253439698A9
        public IList<InstanceViewStatus> Statuses()
        {
            return Inner.Statuses;
        }

        ///GENMHASH:1FF50300531E284E780AF0F5120C9D38:152A2C0AC0AC1EEDAAC511B9B9F3A223
        public int UpdateDomainCount()
        {
            return (Inner.PlatformUpdateDomainCount.HasValue) ? Inner.PlatformUpdateDomainCount.Value : 0;
        }

        ///GENMHASH:7CF67BED6AE72D13DE2B93CB9ABDBE99:D5A13B2EFFE12E36E1A8B800CA03B181
        public IList<string> VirtualMachineIds()
        {
            if (idOfVMsInSet == null)
            {
                idOfVMsInSet = (from subresource in Inner.VirtualMachines
                                select subresource.Id).ToList();
            }
            return idOfVMsInSet;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:BFC85CD3DA2E7E01EDB277A99CA8A8DE
        public async override Task<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var availabilitySetInner = await client.CreateOrUpdateAsync(ResourceGroupName, Name, Inner);
            SetInner(availabilitySetInner);
            idOfVMsInSet = null;
            return this;
        }
        
        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:031612B4E8FDCD8F07810CE8D68580BA
        public override IAvailabilitySet Refresh()
        {
            var availabilitySetInner = client.Get(ResourceGroupName, Name);
            SetInner(availabilitySetInner);
            idOfVMsInSet = null;
            return this;
        }

        ///GENMHASH:CA43B507757943D4A56F8423528A061B:D4173FCB09ADA658582853B4D80CC7E9
        public AvailabilitySetImpl WithFaultDomainCount(int faultDomainCount)
        {
            Inner.PlatformFaultDomainCount = faultDomainCount;
            return this;
        }

        ///GENMHASH:7D519B50E1C9EA7DC342C547AD8C1270:B0B7246867BBF129E53124A4716F0ADC
        public AvailabilitySetImpl WithUpdateDomainCount(int updateDomainCount)
        {
            Inner.PlatformUpdateDomainCount = updateDomainCount;
            return this;
        }
    }
}
