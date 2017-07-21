// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using ResourceManager.Fluent.Core;
    using Models;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of CNameRecordSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5DTmFtZVJlY29yZFNldHNJbXBs
    internal partial class CNameRecordSetsImpl  :
        DnsRecordSetsBaseImpl<ICNameRecordSet,CNameRecordSetImpl>,
        ICNameRecordSets
    {
        ///GENMHASH:7FD3C6284190B406493F8F2FF172B5CE:F8E87D142BE7B967C3D37E08C8777506
        internal CNameRecordSetsImpl(DnsZoneImpl dnsZone) : base(dnsZone, RecordType.CNAME)
        {
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:834B985CB612474BBF3D57983D242F20
        public async override Task<ICNameRecordSet> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            RecordSetInner inner = await dnsZone.Manager.Inner.RecordSets.GetAsync(
                dnsZone.ResourceGroupName,
                dnsZone.Name,
                name,
                recordType,
                cancellationToken);
            return new CNameRecordSetImpl(dnsZone, inner);
        }

        ///GENMHASH:64B3FB1F01DFC1156B75305640537ED6:3D0D7890A72816D6D70C56930E93BFEF
        protected async override Task<IPagedCollection<ICNameRecordSet>> ListInternAsync(string recordSetNameSuffix, int? pageSize, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<ICNameRecordSet, RecordSetInner>.LoadPage(
                async (cancellation) => await dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                                                dnsZone.Name,
                                                                                                recordType,
                                                                                                top: pageSize,
                                                                                                recordsetnamesuffix: recordSetNameSuffix,
                                                                                                cancellationToken: cancellationToken),
                dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        ///GENMHASH:B94D04B9D91F75559A6D8E405D4A72FD:D009704C171C4D453FCEC632203851C7
        protected override IEnumerable<ICNameRecordSet> ListIntern(string recordSetNameSuffix, int? pageSize)
        {
            return WrapList(Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                dnsZone.Name,
                                                                recordType,
                                                                top: pageSize,
                                                                recordsetnamesuffix: recordSetNameSuffix))
                                                    .AsContinuousCollection(link => Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync(link))));
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:DF02675D7363FC8D2194BA7296AC08B3
        protected override ICNameRecordSet WrapModel(RecordSetInner inner)
        {
            return new CNameRecordSetImpl(dnsZone, inner);
        }
    }
}
