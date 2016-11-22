// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of AaaaRecordSet.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5BYWFhUmVjb3JkU2V0SW1wbA==
    internal partial class AaaaRecordSetImpl  :
        DnsRecordSetImpl,
        IAaaaRecordSet
    {
        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:09F5D9EDC414E52781BD92550F31253C
        protected override RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
             if (this.Inner.AaaaRecords != null && this.Inner.AaaaRecords.Count > 0) {
                if (resource.AaaaRecords == null) {
                    resource.AaaaRecords = new List<AaaaRecord>();
                }

                foreach (var record in this.Inner.AaaaRecords)
                {
                    resource.AaaaRecords.Add(record);
                }
                this.Inner.AaaaRecords.Clear();
             }
             
             if (this.recordSetRemoveInfo.AaaaRecords.Count > 0) {
                if (resource.AaaaRecords != null) {
                    foreach(var recordToRemove in this.recordSetRemoveInfo.AaaaRecords)  {
                        foreach(var record in resource.AaaaRecords)  {
                            if (record.Ipv6Address.Equals(recordToRemove.Ipv6Address, StringComparison.OrdinalIgnoreCase)) {
                                resource.AaaaRecords.Remove(record);
                                break;
                            }
                        }
                    }
                }
                this.recordSetRemoveInfo.AaaaRecords.Clear();
             }
            return resource;
        }

        ///GENMHASH:4E53164CA4B37A1BF907696B7858DE65:0789FFFE5FE21310241EC5F7738AE5A4
        public IList<string> Ipv6Addresses()
        {
            List<string> ipv6Addresses = new List<string>();
            if (this.Inner.AaaaRecords != null) {
                foreach(var aaaaRecord in this.Inner.AaaaRecords)  {
                    ipv6Addresses.Add(aaaaRecord.Ipv6Address);
                }
            }
            return ipv6Addresses;
        }

        ///GENMHASH:6CC2CE509AA8735DD6507ACE8F3C9688:3F5F2CC7F3C4A3B943EC7C1953A9D2E5
        internal  AaaaRecordSetImpl(DnsZoneImpl parent, RecordSetInner innerModel, IRecordSetsOperations client) : base(parent, innerModel, client)
        {
        }

        ///GENMHASH:AEA8C8A92DBF6D46B8137727B5EEFACA:A6C5980717429E458E9F5A7FCB8885B4
        internal static AaaaRecordSetImpl NewRecordSet(string name, DnsZoneImpl parent, IRecordSetsOperations client)
        {
            return new AaaaRecordSetImpl(parent,
                new RecordSetInner() {
                    Name = name,
                    Type = Enum.GetName(typeof(Microsoft.Azure.Management.Dns.Fluent.Models.RecordType), Microsoft.Azure.Management.Dns.Fluent.Models.RecordType.AAAA),
                    AaaaRecords = new List<AaaaRecord>()
                },
                client);
        }
    }
}