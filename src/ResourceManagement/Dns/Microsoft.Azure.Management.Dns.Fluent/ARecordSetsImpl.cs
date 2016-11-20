// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// Implementation of ARecordSets.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5BUmVjb3JkU2V0c0ltcGw=
    internal partial class ARecordSetsImpl  :
        ReadableWrappersImpl<IARecordSet,ARecordSetImpl,RecordSetInner>,
        IARecordSets
    {
        private DnsZoneImpl dnsZone;
        private RecordSetsInner client;
        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:9D63E6488572EF04D783581AA61B0F7E
        public ARecordSetImpl GetByName(string name)
        {
            //$ RecordSetInner inner = this.client.Get(this.dnsZone.ResourceGroupName(),
            //$ this.dnsZone.Name(),
            //$ name,
            //$ RecordType.A);
            //$ return new ARecordSetImpl(this.dnsZone, inner, this.client);

            return null;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:8F2ACE161999F511784115AD341D0CF6
        public PagedList<IARecordSet> List()
        {
            //$ return super.WrapList(this.client.ListByType(this.dnsZone.ResourceGroupName(),
            //$ this.dnsZone.Name(),
            //$ RecordType.A));

            return null;
        }

        ///GENMHASH:A640FDB092C8BFC007EAD13B539088B5:93DD647D9AB0DB30D017785882D88829
        internal  ARecordSetsImpl(DnsZoneImpl dnsZone, RecordSetsInner client)
        {
            //$ this.dnsZone = dnsZone;
            //$ this.client = client;
            //$ }

        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:EACBD36191F2DD9AB334947B7732F4F0
        protected ARecordSetImpl WrapModel(RecordSetInner inner)
        {
            //$ return new ARecordSetImpl(this.dnsZone, inner, this.client);

            return null;
        }
    }
}