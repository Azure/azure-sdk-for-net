// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Management.Fluent.Resource.Core;
    using System;

    /// <summary>
    /// Implementation of ARecordSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5BUmVjb3JkU2V0c0ltcGw=
    internal partial class ARecordSetsImpl  :
        ReadableWrappers<IARecordSet,ARecordSetImpl,RecordSetInner>,
        IARecordSets
    {
        private DnsZoneImpl dnsZone;
        private const RecordType ARecordType = RecordType.A;

        public async Task<IARecordSet> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            RecordSetInner inner = await dnsZone.Manager.Inner.RecordSets.GetAsync(
                dnsZone.ResourceGroupName,
                dnsZone.Name,
                name,
                ARecordType,
                cancellationToken);
            return new ARecordSetImpl(dnsZone, inner);
        }

        private DnsZoneImpl Parent()
        {
            return this.dnsZone;
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:9D63E6488572EF04D783581AA61B0F7E
        public IARecordSet GetByName(string name)
        {
            return GetByNameAsync(name, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:8F2ACE161999F511784115AD341D0CF6
        public IEnumerable<IARecordSet> List()
        {
            return WrapList(dnsZone.Manager.Inner.RecordSets
                .ListByType(dnsZone.ResourceGroupName,dnsZone.Name, ARecordType)
                .AsContinuousCollection(link => dnsZone.Manager.Inner.RecordSets.ListByTypeNext(link)));
        }

        ///GENMHASH:A640FDB092C8BFC007EAD13B539088B5:93DD647D9AB0DB30D017785882D88829
        internal  ARecordSetsImpl(DnsZoneImpl dnsZone)
        {
            this.dnsZone = dnsZone;
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:EACBD36191F2DD9AB334947B7732F4F0
        protected override IARecordSet WrapModel(RecordSetInner inner)
        {
            return new ARecordSetImpl(dnsZone, inner);
        }

        public async Task<IPagedCollection<IARecordSet>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IARecordSet, RecordSetInner>.LoadPage(
                async (cancellation) => await dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName, dnsZone.Name, ARecordType, cancellationToken: cancellation),
                dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }
    }
}
