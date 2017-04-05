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
        ReadableWrappers<ITxtRecordSet,TxtRecordSetImpl,RecordSetInner>,
        ITxtRecordSets
    {
        private DnsZoneImpl dnsZone;
        private const RecordType TxtRecordType = RecordType.TXT;

        private DnsZoneImpl Parent()
        {
            return dnsZone;
        }

        ///GENMHASH:70F336C47374A14980F4F5D3557E78E9:93DD647D9AB0DB30D017785882D88829
        internal  TxtRecordSetsImpl(DnsZoneImpl dnsZone)
        {
            this.dnsZone = dnsZone;
        }

        public async Task<ITxtRecordSet> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            RecordSetInner inner = await dnsZone.Manager.Inner.RecordSets.GetAsync(
                dnsZone.ResourceGroupName,
                dnsZone.Name,
                name,
                TxtRecordType,
                cancellationToken);
            return new TxtRecordSetImpl(dnsZone, inner);
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:AAC0A7813BAD48114C2EF153D9E157A1
        public ITxtRecordSet GetByName(string name)
        {
            return this.GetByNameAsync(name, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:0A5A4DAF4EB520E3FAB8309AF1336143
        public IEnumerable<ITxtRecordSet> List()
        {
            return WrapList(dnsZone.Manager.Inner.RecordSets
                .ListByType(dnsZone.ResourceGroupName,dnsZone.Name, TxtRecordType)
                .AsContinuousCollection(link => dnsZone.Manager.Inner.RecordSets.ListByTypeNext(link)));
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:C6F06A2EC17D0A1052A28CE3A09D4D83
        protected override ITxtRecordSet WrapModel(RecordSetInner inner)
        {
            return new TxtRecordSetImpl(dnsZone, inner);
        }

        public async Task<IPagedCollection<ITxtRecordSet>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<ITxtRecordSet, RecordSetInner>.LoadPage(
                async (cancellation) => await dnsZone.Manager.Inner.RecordSets.ListByTypeAsync(dnsZone.ResourceGroupName, dnsZone.Name, TxtRecordType, cancellationToken: cancellation),
                dnsZone.Manager.Inner.RecordSets.ListByTypeNextAsync,
                WrapModel, loadAllPages, cancellationToken);
        }
    }
}
