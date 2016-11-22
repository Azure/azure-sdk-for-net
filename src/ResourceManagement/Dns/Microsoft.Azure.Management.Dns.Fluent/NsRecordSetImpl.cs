// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of NsRecordSet.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5Oc1JlY29yZFNldEltcGw=
    internal partial class NsRecordSetImpl  :
        DnsRecordSetImpl,
        INsRecordSet
    {
        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:E6E1BF61694F9FB722424D294C6DFFA4
        protected override RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
             if (this.Inner.NsRecords != null && this.Inner.NsRecords.Count > 0) {
                if (resource.NsRecords == null) {
                    resource.NsRecords = new List<NsRecord>();
                }

                foreach(var record in this.Inner.NsRecords)  {
                    resource.NsRecords.Add(record);
                }
                this.Inner.NsRecords.Clear();
             }
             
             if (this.recordSetRemoveInfo.NsRecords.Count > 0) {
                if (resource.NsRecords != null) {
                    foreach(var recordToRemove in this.recordSetRemoveInfo.NsRecords)  {
                        foreach(var record in resource.NsRecords)  {
                            if (record.Nsdname.Equals(recordToRemove.Nsdname, StringComparison.OrdinalIgnoreCase)) {
                                resource.NsRecords.Remove(record);
                                break;
                            }
                        }
                    }
                }
                this.recordSetRemoveInfo.NsRecords.Clear();
             }
            return resource;
        }

        ///GENMHASH:901E189AE86408AC3D4B4FC4B66B4701:3F5F2CC7F3C4A3B943EC7C1953A9D2E5
        internal  NsRecordSetImpl(DnsZoneImpl parent, RecordSetInner innerModel, IRecordSetsOperations client) : base(parent, innerModel, client)
        {
        }

        ///GENMHASH:2EBE0E253F1D6DB178F3433FF5310EA8:90C2D44162C23B74515368207322B17F
        public IList<string> NameServers()
        {
            List<string> nameServers = new List<string>();
            if (this.Inner.NsRecords != null) {
                foreach(var nsRecord in this.Inner.NsRecords)  {
                    nameServers.Add(nsRecord.Nsdname);
                }
            }
            return nameServers;
        }

        ///GENMHASH:AEA8C8A92DBF6D46B8137727B5EEFACA:0D19D078966BFE8A7D5832F78E2CDA2D
        internal static NsRecordSetImpl NewRecordSet(string name, DnsZoneImpl parent, IRecordSetsOperations client)
        {
            return new NsRecordSetImpl(parent,
            new RecordSetInner {
                Name = name,
                Type = Enum.GetName(typeof(Microsoft.Azure.Management.Dns.Fluent.Models.RecordType), Microsoft.Azure.Management.Dns.Fluent.Models.RecordType.NS),
                NsRecords = new List<NsRecord>()
            },
            client);
        }
    }
}