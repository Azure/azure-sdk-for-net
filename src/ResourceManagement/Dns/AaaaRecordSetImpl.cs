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
    internal partial class AaaaRecordSetImpl :
        DnsRecordSetImpl,
        IAaaaRecordSet
    {

        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:09F5D9EDC414E52781BD92550F31253C
        protected override RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
             if (Inner.AaaaRecords != null && Inner.AaaaRecords.Count > 0) {
                if (resource.AaaaRecords == null) {
                    resource.AaaaRecords = new List<AaaaRecord>();
                }

                foreach (var record in Inner.AaaaRecords)
                {
                    resource.AaaaRecords.Add(record);
                }
                Inner.AaaaRecords.Clear();
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
        internal IReadOnlyList<string> IPv6Addresses()
        {
            List<string> ipv6Addresses = new List<string>();
            if (Inner.AaaaRecords != null) {
                foreach(var aaaaRecord in Inner.AaaaRecords)  {
                    ipv6Addresses.Add(aaaaRecord.Ipv6Address);
                }
            }
            return ipv6Addresses;
        }

        ///GENMHASH:0DB1EF710EE5C9DF4D735B90F801CE51:F56FF3A2E46C4061C08F5FA6A4C334F3
        internal AaaaRecordSetImpl(DnsZoneImpl parent, RecordSetInner innerModel) : base(parent, innerModel)
        {
        }

        ///GENMHASH:8ABF9B557B42803047EF280885243BA8:78C836DC83E601CABF099843CB28CA6A
        internal static AaaaRecordSetImpl NewRecordSet(string name, DnsZoneImpl parent)
        {
            return new AaaaRecordSetImpl(
                parent,
                new RecordSetInner() {
                    Name = name,
                    Type = Enum.GetName(typeof(RecordType), Models.RecordType.AAAA),
                    AaaaRecords = new List<AaaaRecord>()
                });
        }
    }
}
