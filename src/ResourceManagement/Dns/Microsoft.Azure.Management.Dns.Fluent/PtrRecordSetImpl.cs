// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of PtrRecordSet.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5QdHJSZWNvcmRTZXRJbXBs
    internal partial class PtrRecordSetImpl  :
        DnsRecordSetImpl,
        IPtrRecordSet
    {
        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:8254A32ABF739B147B00EFE318330056
        protected override RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            if (this.Inner.PtrRecords != null && this.Inner.PtrRecords.Count > 0)
            {
                if (resource.PtrRecords == null)
                {
                    resource.PtrRecords = new List<PtrRecord>();
                }

                foreach (var record in this.Inner.PtrRecords)
                {
                    resource.PtrRecords.Add(record);
                }
                this.Inner.PtrRecords.Clear();
            }

            if (this.recordSetRemoveInfo.PtrRecords.Count > 0)
            {
                if (resource.PtrRecords != null)
                {
                    foreach(var recordToRemove in this.recordSetRemoveInfo.PtrRecords)
                    {
                        foreach(var record in resource.PtrRecords)
                        {
                            if (record.Ptrdname.Equals(recordToRemove.Ptrdname, StringComparison.OrdinalIgnoreCase))
                            {
                                resource.PtrRecords.Remove(record);
                                break;
                            }
                        }
                    }
                }
                this.recordSetRemoveInfo.PtrRecords.Clear();
            }
            return resource;
        }

        ///GENMHASH:0E9769D28DB5D19653E121715C77F6C8:87B8885472B9F53C36F3E59296FB7453
        public IList<string> TargetDomainNames()
        {
            List<string> targetDomainNames = new List<string>();
            if (this.Inner.PtrRecords != null) {
                foreach(var ptrRecord in this.Inner.PtrRecords)
                {
                    targetDomainNames.Add(ptrRecord.Ptrdname);
                }
            }
            return targetDomainNames;
        }

        ///GENMHASH:626ADA7635E8C9E10AE63FDF8E70C4FE:3F5F2CC7F3C4A3B943EC7C1953A9D2E5
        internal  PtrRecordSetImpl(DnsZoneImpl parent, RecordSetInner innerModel, IRecordSetsOperations client) : base(parent, innerModel, client)
        {
        }

        ///GENMHASH:AEA8C8A92DBF6D46B8137727B5EEFACA:854410776AE83C4AE59DD946AEEEB94B
        internal static PtrRecordSetImpl NewRecordSet(string name, DnsZoneImpl parent, IRecordSetsOperations client)
        {
            return new PtrRecordSetImpl(parent,
                new RecordSetInner { 
                    Name = name,
                    Type = Enum.GetName(typeof(Microsoft.Azure.Management.Dns.Fluent.Models.RecordType), Microsoft.Azure.Management.Dns.Fluent.Models.RecordType.PTR),
                    PtrRecords = new List<PtrRecord>()
                }, client);
        }
    }
}