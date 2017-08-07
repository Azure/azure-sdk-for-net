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
    /// Implementation of MXRecordSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5NWFJlY29yZFNldHNJbXBs
    internal partial class MXRecordSetsImpl  :
        DnsRecordSetsBaseImpl<IMXRecordSet, MXRecordSetImpl>,
        IMXRecordSets
    {
        ///GENMHASH:14AE18696E6F84E16A1DFEA287A79275:F8E87D142BE7B967C3D37E08C8777506
        internal MXRecordSetsImpl(DnsZoneImpl dnsZone) : base(dnsZone, RecordType.MX)
        {
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:4220E0447E3353F85EF257662DFA7835
        public async override Task<IMXRecordSet> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            RecordSetInner inner = await dnsZone.Manager.Inner.RecordSets.GetAsync(
                dnsZone.ResourceGroupName,
                dnsZone.Name,
                name,
                recordType,
                cancellationToken);
            return new MXRecordSetImpl(dnsZone, inner);
        }

        ///GENMHASH:64B3FB1F01DFC1156B75305640537ED6:88D68360ACE410D62161C03A03BF1C94
        protected async override Task<IPagedCollection<IMXRecordSet>> ListInternAsync(string recordSetNameSuffix, int? pageSize, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IMXRecordSet, RecordSetInner>.LoadPage(
                async (cancellation) => await dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                                                dnsZone.Name,
                                                                                                recordType,
                                                                                                top: pageSize,
                                                                                                recordsetnamesuffix: recordSetNameSuffix,
                                                                                                cancellationToken: cancellationToken),
                dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:726C64E2292CCBC7CE184E032B06D829
        protected override IEnumerable<IMXRecordSet> ListIntern(string recordSetNameSuffix, int? pageSize)
        {
            return WrapList(Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                dnsZone.Name,
                                                                recordType,
                                                                top: pageSize,
                                                                recordsetnamesuffix: recordSetNameSuffix))
                                                        .AsContinuousCollection(link => Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync(link))));
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:DC4FF2A84773DB187EB6D9E5EEE7D21A
        protected override IMXRecordSet WrapModel(RecordSetInner inner)
        {
            return new MXRecordSetImpl(dnsZone, inner);
        }
    }
}
