// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of MXRecordSet.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5NeFJlY29yZFNldEltcGw=
    internal partial class MXRecordSetImpl :
        DnsRecordSetImpl,
        IMXRecordSet
    {

        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:0D98BE0584279084FC4D20C014B0932B
        protected override RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            if (Inner.MxRecords != null && Inner.MxRecords.Count > 0)
            {
                if (resource.MxRecords == null)
                {
                    resource.MxRecords = new List<MxRecord>();
                }

                foreach (var record in Inner.MxRecords)
                {
                    resource.MxRecords.Add(record);
                }
                Inner.MxRecords.Clear();
            }

            if (this.recordSetRemoveInfo.MxRecords.Count > 0)
            {
                if (resource.MxRecords != null)
                {
                    foreach(var recordToRemove in this.recordSetRemoveInfo.MxRecords)
                    {
                        foreach(var record in resource.MxRecords)
                        {
                            if (record.Exchange.Equals(recordToRemove.Exchange, StringComparison.OrdinalIgnoreCase)
                                && (record.Preference == recordToRemove.Preference))
                            {
                                resource.MxRecords.Remove(record);
                                break;
                            }
                        }
                    }
                }
                this.recordSetRemoveInfo.MxRecords.Clear();
            }
            return resource;
        }

        ///GENMHASH:4FC81B687476F8722014B0A4F98E1756:27B32B5AC9D0BA9549BAC568D5725266
        public IList<MxRecord> Records()
        {
            List<MxRecord> records = new List<MxRecord>();
            if (Inner.MxRecords != null)
            {
                foreach (MxRecord record in Inner.MxRecords)
                {
                    records.Add(new MxRecord
                    {
                        Preference = record.Preference,
                        Exchange = record.Exchange
                    });
                }
            }
            return records;
        }

        ///GENMHASH:274A275E58B0BA3B1ED50C81170E88FC:3F5F2CC7F3C4A3B943EC7C1953A9D2E5
        internal  MXRecordSetImpl(DnsZoneImpl parent, RecordSetInner innerModel) : base(parent, innerModel)
        {
        }

        ///GENMHASH:AEA8C8A92DBF6D46B8137727B5EEFACA:844B1A3C2A17D6AAEE5DCBD858D6A293
        internal static MXRecordSetImpl NewRecordSet(string name, DnsZoneImpl parent)
        {
            return new MXRecordSetImpl(parent,
                new RecordSetInner {
                    Name = name,
                    Type = Enum.GetName(typeof(RecordType), Models.RecordType.MX),
                    MxRecords = new List<MxRecord>()
                });
        }
    }
}
