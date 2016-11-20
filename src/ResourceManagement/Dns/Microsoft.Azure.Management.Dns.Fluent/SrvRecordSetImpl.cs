// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of SrvRecordSet.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5TcnZSZWNvcmRTZXRJbXBs
    internal partial class SrvRecordSetImpl  :
        DnsRecordSetImpl,
        ISrvRecordSet
    {
        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:53BB67595D71CD0CA502C876E02949C2
        protected RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            //$ if (this.Inner.SrvRecords() != null && this.Inner.SrvRecords().Size() > 0) {
            //$ if (resource.SrvRecords() == null) {
            //$ resource.WithSrvRecords(new ArrayList<SrvRecord>());
            //$ }
            //$ 
            //$ resource.SrvRecords().AddAll(this.Inner.SrvRecords());
            //$ this.Inner.SrvRecords().Clear();
            //$ }
            //$ 
            //$ if (this.RecordSetRemoveInfo.SrvRecords().Size() > 0) {
            //$ if (resource.SrvRecords() != null) {
            //$ foreach(var recordToRemove in this.RecordSetRemoveInfo.SrvRecords())  {
            //$ foreach(var record in resource.SrvRecords())  {
            //$ if (record.Target().EqualsIgnoreCase(recordToRemove.Target())
            //$ && (record.Port().IntValue() == recordToRemove.Port().IntValue())
            //$ && (record.Weight().IntValue() == recordToRemove.Weight().IntValue())
            //$ && (record.Priority().IntValue() == recordToRemove.Priority().IntValue())) {
            //$ resource.SrvRecords().Remove(record);
            //$ break;
            //$ }
            //$ }
            //$ }
            //$ }
            //$ this.RecordSetRemoveInfo.SrvRecords().Clear();
            //$ }
            //$ return resource;

            return null;
        }

        ///GENMHASH:4FC81B687476F8722014B0A4F98E1756:8E7FFCF6FB312ED092A54EB827BE698C
        public IList<SrvRecord> Records()
        {
            //$ if (this.Inner.SrvRecords() != null) {
            //$ return Collections.UnmodifiableList(this.Inner.SrvRecords());
            //$ }
            //$ return Collections.UnmodifiableList(new ArrayList<SrvRecord>());

            return null;
        }

        ///GENMHASH:AEA8C8A92DBF6D46B8137727B5EEFACA:CB203AB264B7FDA759C81987060D51B8
        internal static SrvRecordSetImpl NewRecordSet(string name, DnsZoneImpl parent, RecordSetsInner client)
        {
            //$ return new SrvRecordSetImpl(parent,
            //$ new RecordSetInner()
            //$ .WithName(name)
            //$ .WithType(RecordType.SRV.ToString())
            //$ .WithSrvRecords(new ArrayList<SrvRecord>()),
            //$ client);
            //$ }

            return this;
        }

        ///GENMHASH:F57055097E6BCF7A9A57A97E430EB895:3F5F2CC7F3C4A3B943EC7C1953A9D2E5
        internal  SrvRecordSetImpl(DnsZoneImpl parent, RecordSetInner innerModel, RecordSetsInner client)
        {
            //$ super(parent, innerModel, client);
            //$ }

        }
    }
}