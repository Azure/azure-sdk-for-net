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
        ReadableWrappers<IPtrRecordSet,PtrRecordSetImpl,RecordSetInner>,
        IPtrRecordSets
    {
        private DnsZoneImpl dnsZone;
        private const RecordType PtrRecordType = RecordType.PTR;

        private DnsZoneImpl Parent()
        {
            return dnsZone;
        }

        public async Task<IPtrRecordSet> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            RecordSetInner inner = await dnsZone.Manager.Inner.RecordSets.GetAsync(
                dnsZone.ResourceGroupName,
                dnsZone.Name,
                name,
                PtrRecordType,
                cancellationToken);
            return new PtrRecordSetImpl(dnsZone, inner);
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:5ED127B8B77B3AAFDDD980010252F039
        public IPtrRecordSet GetByName(string name)
        {
            return this.GetByNameAsync(name, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        ///GENMHASH:604BDFCBD3E17ED8BD832A9DFD7DF085:93DD647D9AB0DB30D017785882D88829
        internal  PtrRecordSetsImpl(DnsZoneImpl dnsZone)
        {
            this.dnsZone = dnsZone;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:17F3505BD759D93DD66665661724A896
        public IEnumerable<IPtrRecordSet> List()
        {
            return WrapList(dnsZone.Manager.Inner.RecordSets
                .ListByType(dnsZone.ResourceGroupName,dnsZone.Name, PtrRecordType)
                .AsContinuousCollection(link => dnsZone.Manager.Inner.RecordSets.ListByTypeNext(link)));
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:EF08BDD63ECDB2FDEF9A787AACCE6276
        protected override IPtrRecordSet WrapModel(RecordSetInner inner)
        {
            return new PtrRecordSetImpl(dnsZone, inner);
        }

        public async Task<IPagedCollection<IPtrRecordSet>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IPtrRecordSet, RecordSetInner>.LoadPage(
                async (cancellation) => await dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName, dnsZone.Name, PtrRecordType, cancellationToken: cancellation),
                dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }
    }
}
