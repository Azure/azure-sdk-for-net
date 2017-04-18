// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implementation of TxtRecordSet.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5UeHRSZWNvcmRTZXRJbXBs
    internal partial class TxtRecordSetImpl :
        DnsRecordSetImpl,
        ITxtRecordSet
    {
        ///GENMHASH:CDD40393B54202CD5F601C8951933BA5:3F5F2CC7F3C4A3B943EC7C1953A9D2E5
        internal  TxtRecordSetImpl(DnsZoneImpl parent, RecordSetInner innerModel) : base(parent, innerModel)
        {
        }

        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:A6CAFC362ACBF08FA397C2EA60D22E1C
        protected override RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            if (Inner.TxtRecords != null && Inner.TxtRecords.Count > 0)
            {
                if (resource.TxtRecords == null)
                {
                    resource.TxtRecords = new List<TxtRecord>();
                }
             
                foreach (var record in Inner.TxtRecords)
                {
                    resource.TxtRecords.Add(record);
                }
             
                Inner.TxtRecords.Clear();
             }
             
            if (this.recordSetRemoveInfo.TxtRecords.Count > 0)
            {
                if (resource.TxtRecords != null)
                {
                    foreach(var recordToRemove in this.recordSetRemoveInfo.TxtRecords)
                    {
                        foreach(var record in resource.TxtRecords)
                        {
                            if (record.Value.Count != 0 && record.Value[0].Equals(recordToRemove.Value[0], StringComparison.OrdinalIgnoreCase))
                            {
                                resource.TxtRecords.Remove(record);
                                break;
                            }
                        }
                    }
                }
                this.recordSetRemoveInfo.TxtRecords.Clear();
             }
            return resource;
        }

        ///GENMHASH:4FC81B687476F8722014B0A4F98E1756:271F0595F800257FBA25E945FA53FCF5
        public IReadOnlyList<TxtRecord> Records()
        {
            if (Inner.TxtRecords != null) {
                return Inner.TxtRecords?.ToList();
            }
            return new List<TxtRecord>();
        }

        ///GENMHASH:AEA8C8A92DBF6D46B8137727B5EEFACA:39B0573F34E150A79B6172F2B15E69E9
        internal static TxtRecordSetImpl NewRecordSet(string name, DnsZoneImpl parent)
        {
            return new TxtRecordSetImpl(parent,
            new RecordSetInner {
                Name = name,
                Type = Enum.GetName(typeof(RecordType), Models.RecordType.TXT),
                TxtRecords = new List<TxtRecord>()
            });
        }
    }
}
