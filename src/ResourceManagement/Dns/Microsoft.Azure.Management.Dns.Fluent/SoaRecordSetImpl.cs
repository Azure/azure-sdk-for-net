// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.Dns.Fluent.Models;
using System;

namespace Microsoft.Azure.Management.Dns.Fluent
{
    /// <summary>
    /// Implementation of SoaRecordSet.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5Tb2FSZWNvcmRTZXRJbXBs
    internal partial class SoaRecordSetImpl  :
        DnsRecordSetImpl,
        ISoaRecordSet
    {
        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:352DEB81080973F0DD8A640958597C6B
        protected override RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
             if (resource.SoaRecord == null) {
                resource.SoaRecord = new SoaRecord();
             }

             if (this.Inner.SoaRecord.Email != null) {
                resource.SoaRecord.Email = this.Inner.SoaRecord.Email;
             }
            
             if (this.Inner.SoaRecord.ExpireTime != null) {
                resource.SoaRecord.ExpireTime = this.Inner.SoaRecord.ExpireTime;
             }
             
             if (this.Inner.SoaRecord.MinimumTtl != null) {
                resource.SoaRecord.MinimumTtl = this.Inner.SoaRecord.MinimumTtl;
             }
             
             if (this.Inner.SoaRecord.RefreshTime != null) {
                resource.SoaRecord.RefreshTime = this.Inner.SoaRecord.RefreshTime;
             }

             if (this.Inner.SoaRecord.RetryTime != null) {
                resource.SoaRecord.RetryTime = this.Inner.SoaRecord.RetryTime;
             }
             
             if (this.Inner.SoaRecord.SerialNumber != null) {
                resource.SoaRecord.SerialNumber = this.Inner.SoaRecord.SerialNumber;
             }
             
             this.Inner.SoaRecord = new SoaRecord();
             return resource;
        }

        ///GENMHASH:336FEA01421A8435A2D03E2E622EC294:E42DE42A88E9C5F585C74E76DA54EF39
        public SoaRecord Record()
        {
            return this.Inner.SoaRecord;
        }

        ///GENMHASH:95E0FEFA5B6425061BFC820775C7828F:CA299EA256F0BDA5FC1EAD032F4E9E7D
        internal static SoaRecordSetImpl NewRecordSet(DnsZoneImpl parent, IRecordSetsOperations client)
        {
             return new SoaRecordSetImpl(parent,
             new RecordSetInner {
                Name = "@",
                Type = Enum.GetName(typeof(Microsoft.Azure.Management.Dns.Fluent.Models.RecordType), Microsoft.Azure.Management.Dns.Fluent.Models.RecordType.SOA),
                SoaRecord = new SoaRecord()
             },
             client);
        }

        ///GENMHASH:86A2E852C7570A43728795EE557D15C5:3F5F2CC7F3C4A3B943EC7C1953A9D2E5
        internal  SoaRecordSetImpl(DnsZoneImpl parent, RecordSetInner innerModel, IRecordSetsOperations client) : base(parent, innerModel, client)
        {
        }
    }
}