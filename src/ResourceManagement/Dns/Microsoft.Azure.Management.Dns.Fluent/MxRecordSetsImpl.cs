// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// Implementation of MxRecordSets.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5NeFJlY29yZFNldHNJbXBs
    internal partial class MxRecordSetsImpl  :
        ReadableWrappersImpl<IMxRecordSet,MxRecordSetImpl,RecordSetInner>,
        IMxRecordSets
    {
        private DnsZoneImpl dnsZone;
        private RecordSetsInner client;
        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:1AD3FB2435C046F2F71535A24004CDFD
        public MxRecordSetImpl GetByName(string name)
        {
            //$ RecordSetInner inner = this.client.Get(this.dnsZone.ResourceGroupName(),
            //$ this.dnsZone.Name(),
            //$ name,
            //$ RecordType.MX);
            //$ return new MxRecordSetImpl(this.dnsZone, inner, this.client);

            return null;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:35BF201395273B958A9213F1436D5DD1
        public PagedList<IMxRecordSet> List()
        {
            //$ return super.WrapList(this.client.ListByType(this.dnsZone.ResourceGroupName(), this.dnsZone.Name(), RecordType.MX));

            return null;
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:AE9F50303BC13DCE8F677D0C754BDBC0
        protected MxRecordSetImpl WrapModel(RecordSetInner inner)
        {
            //$ return new MxRecordSetImpl(this.dnsZone, inner, this.client);

            return null;
        }

        ///GENMHASH:6F2FBDD481155D6AAAD51709649A57BB:93DD647D9AB0DB30D017785882D88829
        internal  MxRecordSetsImpl(DnsZoneImpl dnsZone, RecordSetsInner client)
        {
            //$ this.dnsZone = dnsZone;
            //$ this.client = client;
            //$ }

        }
    }
}