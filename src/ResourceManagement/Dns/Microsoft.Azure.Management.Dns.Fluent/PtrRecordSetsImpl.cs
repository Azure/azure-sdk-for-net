// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// Implementation of PtrRecordSets.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5QdHJSZWNvcmRTZXRzSW1wbA==
    internal partial class PtrRecordSetsImpl  :
        ReadableWrappersImpl<IPtrRecordSet,PtrRecordSetImpl,RecordSetInner>,
        IPtrRecordSets
    {
        private DnsZoneImpl dnsZone;
        private RecordSetsInner client;
        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:5ED127B8B77B3AAFDDD980010252F039
        public PtrRecordSetImpl GetByName(string name)
        {
            //$ RecordSetInner inner = this.client.Get(this.dnsZone.ResourceGroupName(),
            //$ this.dnsZone.Name(),
            //$ name,
            //$ RecordType.PTR);
            //$ return new PtrRecordSetImpl(this.dnsZone, inner, this.client);

            return null;
        }

        ///GENMHASH:604BDFCBD3E17ED8BD832A9DFD7DF085:93DD647D9AB0DB30D017785882D88829
        internal  PtrRecordSetsImpl(DnsZoneImpl dnsZone, RecordSetsInner client)
        {
            //$ this.dnsZone = dnsZone;
            //$ this.client = client;
            //$ }

        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:17F3505BD759D93DD66665661724A896
        public PagedList<IPtrRecordSet> List()
        {
            //$ return super.WrapList(this.client.ListByType(this.dnsZone.ResourceGroupName(), this.dnsZone.Name(), RecordType.PTR));

            return null;
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:EF08BDD63ECDB2FDEF9A787AACCE6276
        protected PtrRecordSetImpl WrapModel(RecordSetInner inner)
        {
            //$ return new PtrRecordSetImpl(this.dnsZone, inner, this.client);

            return null;
        }
    }
}