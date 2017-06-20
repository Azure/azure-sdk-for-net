// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implementation of SrvRecordSet.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5TcnZSZWNvcmRTZXRJbXBs
    internal partial class SrvRecordSetImpl :
        DnsRecordSetImpl,
        ISrvRecordSet
    {

        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:53BB67595D71CD0CA502C876E02949C2
        protected override RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            if (Inner.SrvRecords != null && Inner.SrvRecords.Count > 0)
            {
                if (resource.SrvRecords == null)
                {
                    resource.SrvRecords = new List<SrvRecord>();
                }
                foreach (var record in Inner.SrvRecords)
                {
                    resource.SrvRecords.Add(record);
                }
                Inner.SrvRecords.Clear();
            }
            if (this.recordSetRemoveInfo.SrvRecords.Count > 0)
            {
                if (resource.SrvRecords != null)
                {
                   foreach(var recordToRemove in this.recordSetRemoveInfo.SrvRecords)
                    {
                       foreach(var record in resource.SrvRecords)
                        {
                           if (record.Target.Equals(recordToRemove.Target, StringComparison.OrdinalIgnoreCase)
                               && (record.Port == recordToRemove.Port)
                               && (record.Weight == recordToRemove.Weight)
                               && (record.Priority == recordToRemove.Priority))
                           {
                                   resource.SrvRecords.Remove(record);
                                   break;
                           }
                       }
                   }
               }
               this.recordSetRemoveInfo.SrvRecords.Clear();
            }
            return resource;
        }

        ///GENMHASH:4FC81B687476F8722014B0A4F98E1756:8E7FFCF6FB312ED092A54EB827BE698C
        public IReadOnlyList<SrvRecord> Records()
        {
            if (Inner.SrvRecords != null)
            {
                return Inner.SrvRecords?.ToList();
            }
            return new List<SrvRecord>();
        }

        ///GENMHASH:AEA8C8A92DBF6D46B8137727B5EEFACA:CB203AB264B7FDA759C81987060D51B8
        internal static SrvRecordSetImpl NewRecordSet(string name, DnsZoneImpl parent)
        {
             return new SrvRecordSetImpl(parent,
             new RecordSetInner {
                Name = name,
                Type = Enum.GetName(typeof(RecordType), Models.RecordType.SRV),
                 SrvRecords = new List<SrvRecord>()
             });
        }

        internal  SrvRecordSetImpl(DnsZoneImpl parent, RecordSetInner innerModel) : base(parent, innerModel)
        {
        }
    }
}
