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
    /// Implementation of TxtRecordSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5UeHRSZWNvcmRTZXRzSW1wbA==
    internal partial class TxtRecordSetsImpl  :
        DnsRecordSetsBaseImpl<ITxtRecordSet, TxtRecordSetImpl>,
        ITxtRecordSets
    {
        ///GENMHASH:DE142040F109CD3B229E5070C0CA4D4F:F8E87D142BE7B967C3D37E08C8777506
        internal TxtRecordSetsImpl(DnsZoneImpl dnsZone) : base(dnsZone, RecordType.TXT)
        {
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:891E91CBEE046376B0D9377B27399767
        public async override Task<ITxtRecordSet> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            RecordSetInner inner = await dnsZone.Manager.Inner.RecordSets.GetAsync(
                dnsZone.ResourceGroupName,
                dnsZone.Name,
                name,
                recordType,
                cancellationToken);
            return new TxtRecordSetImpl(dnsZone, inner);
        }

        ///GENMHASH:64B3FB1F01DFC1156B75305640537ED6:0A2E4C960F052949FDFA8DC6753F4860
        protected async override Task<IPagedCollection<ITxtRecordSet>> ListInternAsync(string recordSetNameSuffix, int? pageSize, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<ITxtRecordSet, RecordSetInner>.LoadPage(
                async (cancellation) => await dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                                                dnsZone.Name,
                                                                                                recordType,
                                                                                                top: pageSize,
                                                                                                recordsetnamesuffix: recordSetNameSuffix,
                                                                                                cancellationToken: cancellationToken),
                dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        ///GENMHASH:B94D04B9D91F75559A6D8E405D4A72FD:75EE3247B7E5B19C0139A9BD8ACE8C80
        protected override IEnumerable<ITxtRecordSet> ListIntern(string recordSetNameSuffix, int? pageSize)
        {
            return WrapList(Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                dnsZone.Name,
                                                                recordType,
                                                                top: pageSize,
                                                                recordsetnamesuffix: recordSetNameSuffix))
                                                    .AsContinuousCollection(link => Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync(link))));
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:F34D4050AF5DEA0333DEAB400CDEE5CB
        protected override ITxtRecordSet WrapModel(RecordSetInner inner)
        {
            return new TxtRecordSetImpl(dnsZone, inner);
        }
    }
}
