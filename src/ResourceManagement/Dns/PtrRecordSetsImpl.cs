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
    /// Implementation of PtrRecordSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5QdHJSZWNvcmRTZXRzSW1wbA==
    internal partial class PtrRecordSetsImpl  :
        DnsRecordSetsBaseImpl<IPtrRecordSet,PtrRecordSetImpl>,
        IPtrRecordSets
    {
        ///GENMHASH:698FCAC9EA6BAA4A563CD91E904DAC5A:F8E87D142BE7B967C3D37E08C8777506
        internal PtrRecordSetsImpl(DnsZoneImpl dnsZone) : base(dnsZone, RecordType.PTR)
        {
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:32C3100ECD9DE4B99E3D0DAF02ED4D48
        public async override Task<IPtrRecordSet> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            RecordSetInner inner = await dnsZone.Manager.Inner.RecordSets.GetAsync(
                dnsZone.ResourceGroupName,
                dnsZone.Name,
                name,
                recordType,
                cancellationToken);
            return new PtrRecordSetImpl(dnsZone, inner);
        }

        ///GENMHASH:64B3FB1F01DFC1156B75305640537ED6:B88022863C929300DD0B8354E482F6BC
        protected async override Task<IPagedCollection<IPtrRecordSet>> ListInternAsync(string recordSetNameSuffix, int? pageSize, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IPtrRecordSet, RecordSetInner>.LoadPage(
                async (cancellation) => await dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                                                dnsZone.Name,
                                                                                                recordType,
                                                                                                top: pageSize,
                                                                                                recordsetnamesuffix: recordSetNameSuffix,
                                                                                                cancellationToken: cancellationToken),
                dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }

        ///GENMHASH:B94D04B9D91F75559A6D8E405D4A72FD:469D7E8DEB6CC072406A22D0635C0EC8
        protected override IEnumerable<IPtrRecordSet> ListIntern(string recordSetNameSuffix, int? pageSize)
        {
            return WrapList(Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName,
                                                                dnsZone.Name,
                                                                recordType,
                                                                top: pageSize,
                                                                recordsetnamesuffix: recordSetNameSuffix))
                                                    .AsContinuousCollection(link => Extensions.Synchronize(() => dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync(link))));
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:79EECA7CF25C8E535058201251FF3187
        protected override IPtrRecordSet WrapModel(RecordSetInner inner)
        {
            return new PtrRecordSetImpl(dnsZone, inner);
        }
    }
}
