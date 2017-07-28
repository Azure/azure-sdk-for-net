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
    /// Implementation of NSRecordSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5OU1JlY29yZFNldHNJbXBs
    internal partial class NSRecordSetsImpl  :
        DnsRecordSetsBaseImpl<INSRecordSet, NSRecordSetImpl>,
        INSRecordSets
    {
        ///GENMHASH:C5867A000D4912C160F6F94159505827:F8E87D142BE7B967C3D37E08C8777506
        internal NSRecordSetsImpl(DnsZoneImpl dnsZone) : base(dnsZone, RecordType.NS)
        {
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:0A49A0336CCC3F7A7573EA68B07F0500
        public async override Task<INSRecordSet> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            RecordSetInner inner = await dnsZone.Manager.Inner.RecordSets.GetAsync(
                dnsZone.ResourceGroupName,
                dnsZone.Name,
                name,
                recordType,
                cancellationToken);
            return new NSRecordSetImpl(dnsZone, inner);
        }

        ///GENMHASH:64B3FB1F01DFC1156B75305640537ED6:6ABA6F3C2D4325C9176D80BB4E70E2B8
        protected async override Task<IPagedCollection<INSRecordSet>> ListInternAsync(string recordSetNameSuffix, int? pageSize, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<INSRecordSet, RecordSetInner>.LoadPage(
                async (cancellation) => await dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                                                dnsZone.Name,
                                                                                                recordType,
                                                                                                top: pageSize,
                                                                                                recordsetnamesuffix: recordSetNameSuffix,
                                                                                                cancellationToken: cancellationToken),
                dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        ///GENMHASH:B94D04B9D91F75559A6D8E405D4A72FD:89AFD60B8A5875A2B8CC4B9A343A49AE
        protected override IEnumerable<INSRecordSet> ListIntern(string recordSetNameSuffix, int? pageSize)
        {
            return WrapList(Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                dnsZone.Name,
                                                                recordType,
                                                                top: pageSize,
                                                                recordsetnamesuffix: recordSetNameSuffix))
                                                                .AsContinuousCollection(link => Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync(link))));
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:5F707291D14DA5598B0C79A53C240FCC
        protected override INSRecordSet WrapModel(RecordSetInner inner)
        {
            return new NSRecordSetImpl(dnsZone, inner);
        }
    }
}
