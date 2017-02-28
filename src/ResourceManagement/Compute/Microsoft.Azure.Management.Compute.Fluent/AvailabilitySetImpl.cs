// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Resource.Fluent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

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
        private List<string> idOfVMsInSet;

        ///GENMHASH:8C96B0BDC54BDF41F3FC5BCCAA028C8D:113A819FAF18DEACEC4BCC60120F8166
        internal AvailabilitySetImpl(string name, AvailabilitySetInner innerModel, IComputeManager computeManager) :
            base(name, innerModel, computeManager)
        {
        }

        ///GENMHASH:C260E0C5666F525F67582200AB726081:7DE3282328DE495135BCEDAABABE05D1
        public int FaultDomainCount()
        {
            return (Inner.PlatformFaultDomainCount.HasValue) ? Inner.PlatformFaultDomainCount.Value : 0;
        }

        ///GENMHASH:2BD1C2DEE2E7FBB6D90AB920FAD6E9EE:EA53AD3391D9207B84DE8253439698A9
        public IList<InstanceViewStatus> Statuses()
        {
            return Inner.Statuses;
        }

        ///GENMHASH:1FF50300531E284E780AF0F5120C9D38:294D69029925C7F021009A4279127F9F
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
            if (Inner.PlatformFaultDomainCount == null)
            {
                Inner.PlatformFaultDomainCount = 2;
            }
            if (Inner.PlatformUpdateDomainCount == null)
            {
                Inner.PlatformUpdateDomainCount = 5;
            }
            var availabilitySetInner = await Manager.Inner.AvailabilitySets.CreateOrUpdateAsync(ResourceGroupName, Name, Inner);
            SetInner(availabilitySetInner);
            idOfVMsInSet = null;
            return this;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:031612B4E8FDCD8F07810CE8D68580BA
        public override IAvailabilitySet Refresh()
        {
            var availabilitySetInner = Manager.Inner.AvailabilitySets.Get(ResourceGroupName, Name);
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

        ///GENMHASH:F792F6C8C594AA68FA7A0FCA92F55B55:76F4D314E5BB1E6DEE9BFF0081B150DC
        public AvailabilitySetSkuTypes Sku()
        {
            if (Inner.Sku != null && Inner.Sku.Name != null)
            {
                return AvailabilitySetSkuTypes.Parse(Inner.Sku.Name);
            }
            return null;
        }

        ///GENMHASH:53AB73C440C52ADA0E332540DA0BEEB4:F6990CB6AF41DB826958D5810A250621
        public AvailabilitySetImpl WithSku(AvailabilitySetSkuTypes skuType)
        {
            if (Inner.Sku == null)
            {
                Inner.Sku = new Sku();
            }
            Inner.Sku.Name = skuType.ToString();
            return this;
        }
    }
}