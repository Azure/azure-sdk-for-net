// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of ARecordSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5BUmVjb3JkU2V0c0ltcGw=
    internal partial class ARecordSetsImpl  :
        DnsRecordSetsBaseImpl<Microsoft.Azure.Management.Dns.Fluent.IARecordSet, Microsoft.Azure.Management.Dns.Fluent.ARecordSetImpl>,
        IARecordSets
    {
        ///GENMHASH:E10F3F1B0497821B014BAFEF65431F45:F8E87D142BE7B967C3D37E08C8777506
        internal ARecordSetsImpl(DnsZoneImpl dnsZone) : base(dnsZone, RecordType.A)
        {
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:2CAFCB69FA35BE2592639975C84B12D6
        public async override Task<IARecordSet> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            RecordSetInner inner = await dnsZone.Manager.Inner.RecordSets.GetAsync(
                dnsZone.ResourceGroupName,
                dnsZone.Name,
                name,
                recordType,
                cancellationToken);
            return new ARecordSetImpl(dnsZone, inner);
        }

        ///GENMHASH:64B3FB1F01DFC1156B75305640537ED6:07ABC4D78867EC3255A945D0F05D4882
        protected async override Task<IPagedCollection<IARecordSet>> ListInternAsync(string recordSetNameSuffix, int? pageSize, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IARecordSet, RecordSetInner>.LoadPage(
                async (cancellation) => await dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                                                dnsZone.Name,
                                                                                                recordType,
                                                                                                top: pageSize,
                                                                                                recordsetnamesuffix: recordSetNameSuffix,
                                                                                                cancellationToken: cancellationToken),
                dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        ///GENMHASH:B94D04B9D91F75559A6D8E405D4A72FD:14206AD3A35D0E04558660C133F8DA1D
        protected override IEnumerable<IARecordSet> ListIntern(string recordSetNameSuffix, int? pageSize)
        {
            return WrapList(Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                dnsZone.Name,
                                                                recordType,
                                                                top: pageSize,
                                                                recordsetnamesuffix: recordSetNameSuffix))
                                                    .AsContinuousCollection(link => Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync(link))));
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:29F76B986FA21FD2583D531C098AD879
        protected override IARecordSet WrapModel(RecordSetInner inner)
        {
            return new ARecordSetImpl(dnsZone, inner);
        }
    }
}
