// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Threading.Tasks;
    using System.Threading;
    using ResourceManager.Fluent.Core;
    using Models;
    using Rest.Azure;

    /// <summary>
    /// Implementation of DnsZones.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5EbnNab25lc0ltcGw=
    internal partial class DnsZonesImpl  :
        TopLevelModifiableResources<IDnsZone, DnsZoneImpl, ZoneInner, IZonesOperations, IDnsZoneManager>,
        IDnsZones
    {
        ///GENMHASH:661990698C9F921298FFAE9CEA236CB5:2EB3BA42E4C5B714FF72B5FE32A54A03
        public async Task DeleteByResourceGroupNameAsync(string resourceGroupName, string zoneName, string eTagValue, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Manager.Inner.Zones.DeleteAsync(resourceGroupName, zoneName, eTagValue);
        }

        ///GENMHASH:39C3F7BAA4073DBF7D9C81AC4336F2D1:32FF50F6C08B8687F5130EDE8E5BA465
        public void DeleteByResourceGroupName(string resourceGroupName, string zoneName, string eTagValue)
        {
            Extensions.Synchronize(() => DeleteByResourceGroupNameAsync(resourceGroupName, zoneName, eTagValue));
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:6A5AFD43FB6D60947DE42BF4153B3E35
        public DnsZoneImpl Define(string name)
        {
            return this.SetDefaults(WrapModel(name));
        }

        ///GENMHASH:A17E5445D2F99DCCB7C75768B0291EED:46771EA9A18C8A10AFFAEA5F5B47057F
        public void DeleteById(string id, string eTagValue)
        {
            Extensions.Synchronize(() => DeleteByIdAsync(id, eTagValue));
        }

        ///GENMHASH:888AD5B0E0B6C157410F28C8D7AB0DD6:65F3733A4D17B7CA277164946BAE2A98
        public Task DeleteByIdAsync(string id, string eTagValue, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteByResourceGroupNameAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id), eTagValue);
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:4C6EFF21E5E730775AFD95DC77DDD7F4
        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        protected async override Task<ZoneInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:F6A0AFFF7CA56B78765E68E54D0DBD52:BF1A0B6AF7B2DE0C94B618D0F4D5E98C
        internal DnsZonesImpl(DnsZoneManager dnsZoneManager) : base(dnsZoneManager.Inner.Zones, dnsZoneManager)
        {
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:E29BEEAB8CFC79BEFB042BF8EE0AED00
        protected async override Task<IPage<ZoneInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(cancellationToken: cancellationToken);
        }

        protected async override Task<IPage<ZoneInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:D57C6EF7B32D03E7098E2D735EEF70BD:4E951CDE0BF14119F1DB863BEC8121A9
        private DnsZoneImpl SetDefaults(DnsZoneImpl dnsZone)
        {
            // Zone location must be 'global' irrespective of region of the resource group it resides.
            dnsZone.Inner.Location = "global";
            return dnsZone;
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:B533AA6052ED2EA7F8D7C96A5C95034C
        protected async override Task<IPage<ZoneInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupAsync(groupName, cancellationToken: cancellationToken);
        }

        protected async override Task<IPage<ZoneInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:7A00028F7FB028D8A9AE061B1ECACF4E
        protected override DnsZoneImpl WrapModel(string name)
        {
            return new DnsZoneImpl(name, new ZoneInner(), Manager);
        }

        ///GENMHASH:50B7BBEB7CFE01590A174CABC4281F74:156330360C3F1E79BC8D5461CF0AE1C2
        protected override IDnsZone WrapModel(ZoneInner inner)
        {
            return new DnsZoneImpl(inner.Name, inner, Manager);
        }
    }
}
