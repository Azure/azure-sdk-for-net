// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System.Threading.Tasks;
    using System.Threading;

    /// <summary>
    /// Implementation of PtrRecordSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5QdHJSZWNvcmRTZXRzSW1wbA==
    internal partial class PtrRecordSetsImpl  :
        ReadableWrappers<IPtrRecordSet,PtrRecordSetImpl,RecordSetInner>,
        IPtrRecordSets
    {
        private DnsZoneImpl dnsZone;
        private IRecordSetsOperations client;

        public async Task<IPtrRecordSet> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            RecordSetInner inner = await this.client.GetAsync(this.dnsZone.ResourceGroupName,
                this.dnsZone.Name,
                name,
                RecordType.PTR,
                cancellationToken);
            return new PtrRecordSetImpl(this.dnsZone, inner, this.client);
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:5ED127B8B77B3AAFDDD980010252F039
        public IPtrRecordSet GetByName(string name)
        {
            return this.GetByNameAsync(name, CancellationToken.None).Result;
        }

        ///GENMHASH:604BDFCBD3E17ED8BD832A9DFD7DF085:93DD647D9AB0DB30D017785882D88829
        internal  PtrRecordSetsImpl(DnsZoneImpl dnsZone, IRecordSetsOperations client)
        {
            this.dnsZone = dnsZone;
            this.client = client;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:17F3505BD759D93DD66665661724A896
        public PagedList<IPtrRecordSet> List()
        {
            var pagedList = new PagedList<RecordSetInner>(this.client.ListByType(this.dnsZone.ResourceGroupName,
                this.dnsZone.Name,
                RecordType.PTR), (string nextPageLink) =>
                {
                    return client.ListByTypeNext(nextPageLink);
                });
            return WrapList(pagedList);
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:EF08BDD63ECDB2FDEF9A787AACCE6276
        protected override IPtrRecordSet WrapModel(RecordSetInner inner)
        {
            return new PtrRecordSetImpl(this.dnsZone, inner, this.client);
        }
    }
}