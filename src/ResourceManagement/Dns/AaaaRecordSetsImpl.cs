// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using ResourceManager.Fluent.Core;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of AaaaRecordSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5BYWFhUmVjb3JkU2V0c0ltcGw=
    internal partial class AaaaRecordSetsImpl  :
        DnsRecordSetsBaseImpl<Microsoft.Azure.Management.Dns.Fluent.IAaaaRecordSet, Microsoft.Azure.Management.Dns.Fluent.AaaaRecordSetImpl>,
        IAaaaRecordSets
    {
        ///GENMHASH:4DBB29DC0AB074A2ADEBE0995A37B2FD:F8E87D142BE7B967C3D37E08C8777506
        internal AaaaRecordSetsImpl(DnsZoneImpl dnsZone) : base(dnsZone, RecordType.AAAA)
        {
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:65AB75EBD71F75518D48103C45889A8D
        public async override Task<IAaaaRecordSet> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            RecordSetInner inner = await dnsZone.Manager.Inner.RecordSets.GetAsync(
                dnsZone.ResourceGroupName,
                dnsZone.Name,
                name,
                recordType,
                cancellationToken);
            return new AaaaRecordSetImpl(dnsZone, inner);
        }

        ///GENMHASH:64B3FB1F01DFC1156B75305640537ED6:EF16F127367E57700C33A2174D62009D
        protected async override Task<IPagedCollection<IAaaaRecordSet>> ListInternAsync(string recordSetNameSuffix, int? pageSize, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IAaaaRecordSet, RecordSetInner>.LoadPage(
                async (cancellation) => await dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                                                dnsZone.Name,
                                                                                                recordType,
                                                                                                top: pageSize,
                                                                                                recordsetnamesuffix: recordSetNameSuffix,
                                                                                                cancellationToken: cancellationToken),
                dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        ///GENMHASH:B94D04B9D91F75559A6D8E405D4A72FD:2D7A98BB2BCAD1ACBF5B8624AD621EE4
        protected override IEnumerable<IAaaaRecordSet> ListIntern(string recordSetNameSuffix, int? pageSize)
        {
            return WrapList(Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName, 
                                                                    dnsZone.Name,
                                                                    recordType, 
                                                                    top: pageSize,
                                                                    recordsetnamesuffix: recordSetNameSuffix))
                                                                .AsContinuousCollection(link => Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync(link))));
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:583D2C6D497AA58FD8B23595EF66DCF0
        protected override IAaaaRecordSet WrapModel(RecordSetInner inner)
        {
            return new AaaaRecordSetImpl(dnsZone, inner);
        }
    }
}
