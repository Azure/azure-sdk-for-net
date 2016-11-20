// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    /// <summary>
    /// Implementation of NsRecordSets.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5Oc1JlY29yZFNldHNJbXBs
    internal partial class NsRecordSetsImpl  :
        ReadableWrappersImpl<INsRecordSet,NsRecordSetImpl,RecordSetInner>,
        INsRecordSets
    {
        private DnsZoneImpl dnsZone;
        private RecordSetsInner client;
        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:4A497749B5E023624BDEB285134C423F
        public NsRecordSetImpl GetByName(string name)
        {
            //$ RecordSetInner inner = this.client.Get(this.dnsZone.ResourceGroupName(),
            //$ this.dnsZone.Name(),
            //$ name,
            //$ RecordType.NS);
            //$ return new NsRecordSetImpl(this.dnsZone, inner, this.client);

            return null;
        }

        ///GENMHASH:87CC6AA908BEE0D6E4535EB1332F9164:93DD647D9AB0DB30D017785882D88829
        internal  NsRecordSetsImpl(DnsZoneImpl dnsZone, RecordSetsInner client)
        {
            //$ this.dnsZone = dnsZone;
            //$ this.client = client;
            //$ }

        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:1D093FE5F27526EC91963B97D8C4EFC9
        public PagedList<INsRecordSet> List()
        {
            //$ return super.WrapList(this.client.ListByType(this.dnsZone.ResourceGroupName(), this.dnsZone.Name(), RecordType.NS));

            return null;
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:ADE4AD664D47FA28F09C3CE440BD1806
        protected NsRecordSetImpl WrapModel(RecordSetInner inner)
        {
            //$ return new NsRecordSetImpl(this.dnsZone, inner, this.client);

            return null;
        }
    }
}