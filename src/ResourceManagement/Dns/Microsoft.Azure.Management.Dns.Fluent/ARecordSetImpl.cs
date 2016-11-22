// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of ARecordSet.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5BUmVjb3JkU2V0SW1wbA==
    internal partial class ARecordSetImpl  :
        DnsRecordSetImpl,
        IARecordSet
    {
        ///GENMHASH:04586DB2C8D9E7DB2F3AB47785D5A15A:F328364702E41F21DD4388BDA9FC5770
        public IList<string> Ipv4Addresses()
        {
            List<string> ipv4Addresses = new List<string>();
            if (this.Inner.ARecords != null) {
                foreach(var aRecord in this.Inner.ARecords)  {
                    ipv4Addresses.Add(aRecord.Ipv4Address);
                }
            }
            return ipv4Addresses;
        }

        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:BFFE923AC1A74C33749D31F3CABB1EA2
        protected override RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            if (this.Inner.ARecords != null && this.Inner.ARecords.Count > 0) {
                if (resource.ARecords == null) {
                    resource.ARecords = new List<ARecord>();
                }
                foreach (var record in this.Inner.ARecords) {
                    resource.ARecords.Add(record);
                }
                this.Inner.ARecords.Clear();
            }

            if (this.recordSetRemoveInfo.ARecords.Count > 0) {
                if (resource.ARecords != null) {
                    foreach(var recordToRemove in this.recordSetRemoveInfo.ARecords)  {
                        foreach(var record in resource.ARecords)  {
                            if (record.Ipv4Address.Equals(recordToRemove.Ipv4Address, System.StringComparison.OrdinalIgnoreCase)) {
                                resource.ARecords.Remove(record);
                                break;
                            }
                        }
                    }
                }
                this.recordSetRemoveInfo.ARecords.Clear();
             }
             return resource;
        }

        ///GENMHASH:E1426F341AA03829F8336FF9716A3A8D:3F5F2CC7F3C4A3B943EC7C1953A9D2E5
        internal  ARecordSetImpl(DnsZoneImpl parent, RecordSetInner innerModel, IRecordSetsOperations client) : base(parent, innerModel, client)
        {
        }

        ///GENMHASH:AEA8C8A92DBF6D46B8137727B5EEFACA:7BDEC259FD27CB56EA82014D5B2F1271
        internal static ARecordSetImpl NewRecordSet(string name, DnsZoneImpl parent, IRecordSetsOperations client)
        {
            return new ARecordSetImpl(parent,
                new RecordSetInner {
                    Name = name,
                    Type = Enum.GetName(typeof(Microsoft.Azure.Management.Dns.Fluent.Models.RecordType), Microsoft.Azure.Management.Dns.Fluent.Models.RecordType.A),
                    ARecords = new List<ARecord>()
                }, client);
        }
    }
}
