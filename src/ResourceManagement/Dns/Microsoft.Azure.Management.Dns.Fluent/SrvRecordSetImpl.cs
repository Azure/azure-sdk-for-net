// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Models;
    using System;
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
        protected override RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            if (this.Inner.SrvRecords != null && this.Inner.SrvRecords.Count > 0)
            {
                if (resource.SrvRecords == null)
                {
                    resource.SrvRecords = new List<SrvRecord>();
                }
                foreach (var record in this.Inner.SrvRecords)
                {
                    resource.SrvRecords.Add(record);
                }
                this.Inner.SrvRecords.Clear();
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
        public IList<SrvRecord> Records()
        {
            if (this.Inner.SrvRecords != null)
            {
                return this.Inner.SrvRecords;
            }
            return new List<SrvRecord>();
        }

        ///GENMHASH:AEA8C8A92DBF6D46B8137727B5EEFACA:CB203AB264B7FDA759C81987060D51B8
        internal static SrvRecordSetImpl NewRecordSet(string name, DnsZoneImpl parent, IRecordSetsOperations client)
        {
             return new SrvRecordSetImpl(parent,
             new RecordSetInner {
                Name = name,
                Type = Enum.GetName(typeof(Microsoft.Azure.Management.Dns.Fluent.Models.RecordType), Microsoft.Azure.Management.Dns.Fluent.Models.RecordType.SRV),
                 SrvRecords = new List<SrvRecord>()
             },
             client);
        }

        ///GENMHASH:F57055097E6BCF7A9A57A97E430EB895:3F5F2CC7F3C4A3B943EC7C1953A9D2E5
        internal  SrvRecordSetImpl(DnsZoneImpl parent, RecordSetInner innerModel, IRecordSetsOperations client) : base(parent, innerModel, client)
        {
        }
    }
}