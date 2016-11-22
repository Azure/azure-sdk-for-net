// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using System.Threading.Tasks;
    using System.Threading;
    using Microsoft.Azure.Management.Resource.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;

    /// <summary>
    /// Implementation of DnsZones.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5EbnNab25lc0ltcGw=
    internal partial class DnsZonesImpl  :
        GroupableResources<IDnsZone, DnsZoneImpl, ZoneInner, IZonesOperations, IDnsZoneManager>,
        IDnsZones
    {
        private IRecordSetsOperations recordSetsClient;

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:4C6EFF21E5E730775AFD95DC77DDD7F4
        public override async Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.InnerCollection.DeleteAsync(groupName, name, null, cancellationToken);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:6A5AFD43FB6D60947DE42BF4153B3E35
        public DnsZoneImpl Define(string name)
        {
            return this.SetDefaults(WrapModel(name));
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        public override async Task<IDnsZone> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await this.InnerCollection.GetAsync(groupName, name));
        }

        ///GENMHASH:6FA0B6DE5CB193A4650CC6B5966DBC04:345CFB0A0B8A514DED6957391B1D99E5
        internal  DnsZonesImpl(DnsManagementClient dnsManagementClient, DnsZoneManager dnsZoneManager) : base(dnsManagementClient.Zones, dnsZoneManager)
        {
            this.recordSetsClient = dnsManagementClient.RecordSets;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:E29BEEAB8CFC79BEFB042BF8EE0AED00
        public PagedList<IDnsZone> List()
        {
            var pagedList = new PagedList<ZoneInner>(this.InnerCollection.List(), (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
            });
            return WrapList(pagedList);
        }

        ///GENMHASH:D57C6EF7B32D03E7098E2D735EEF70BD:4E951CDE0BF14119F1DB863BEC8121A9
        private DnsZoneImpl SetDefaults(DnsZoneImpl dnsZone)
        {
            // Zone location must be 'global' irrespective of region of the resource group it resides.
            dnsZone.Inner.Location = "global";
            return dnsZone;
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:B533AA6052ED2EA7F8D7C96A5C95034C
        public PagedList<IDnsZone> ListByGroup(string groupName)
        {
            var pagedList = new PagedList<ZoneInner>(this.InnerCollection.ListByResourceGroup(groupName), (string nextPageLink) =>
            {
                return InnerCollection.ListByResourceGroupNext(nextPageLink);
            });
            return WrapList(pagedList);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:F388A69B4ED70BD6EEC04A90B7F6BC69
        protected override DnsZoneImpl WrapModel(string name)
        {
            return new DnsZoneImpl(name,
            new ZoneInner(),
            this.InnerCollection,
            this.recordSetsClient,
            this.Manager);
        }

        ///GENMHASH:50B7BBEB7CFE01590A174CABC4281F74:FFEBBA1AA8764B359821A3189D400AA9
        protected override IDnsZone WrapModel(ZoneInner inner)
        {
            return new DnsZoneImpl(inner.Name,
                inner,
                this.InnerCollection,
                this.recordSetsClient,
                this.Manager);
        }
    }
}