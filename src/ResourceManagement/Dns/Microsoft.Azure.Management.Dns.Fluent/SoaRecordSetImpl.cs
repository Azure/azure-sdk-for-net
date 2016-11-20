// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
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
        protected RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            //$ if (resource.SoaRecord() == null) {
            //$ resource.WithSoaRecord(new SoaRecord());
            //$ }
            //$ 
            //$ if (this.Inner.SoaRecord().Email() != null) {
            //$ resource.SoaRecord().WithEmail(this.Inner.SoaRecord().Email());
            //$ }
            //$ 
            //$ if (this.Inner.SoaRecord().ExpireTime() != null) {
            //$ resource.SoaRecord().WithExpireTime(this.Inner.SoaRecord().ExpireTime());
            //$ }
            //$ 
            //$ if (this.Inner.SoaRecord().MinimumTtl() != null) {
            //$ resource.SoaRecord().WithMinimumTtl(this.Inner.SoaRecord().MinimumTtl());
            //$ }
            //$ 
            //$ if (this.Inner.SoaRecord().RefreshTime() != null) {
            //$ resource.SoaRecord().WithRefreshTime(this.Inner.SoaRecord().RefreshTime());
            //$ }
            //$ 
            //$ if (this.Inner.SoaRecord().RetryTime() != null) {
            //$ resource.SoaRecord().WithRetryTime(this.Inner.SoaRecord().RetryTime());
            //$ }
            //$ 
            //$ if (this.Inner.SoaRecord().SerialNumber() != null) {
            //$ resource.SoaRecord().WithSerialNumber(this.Inner.SoaRecord().SerialNumber());
            //$ }
            //$ 
            //$ this.Inner.WithSoaRecord(new SoaRecord());
            //$ return resource;

            return null;
        }

        ///GENMHASH:336FEA01421A8435A2D03E2E622EC294:E42DE42A88E9C5F585C74E76DA54EF39
        public SoaRecord Record()
        {
            //$ return this.Inner.SoaRecord();

            return null;
        }

        ///GENMHASH:95E0FEFA5B6425061BFC820775C7828F:CA299EA256F0BDA5FC1EAD032F4E9E7D
        internal static SoaRecordSetImpl NewRecordSet(DnsZoneImpl parent, RecordSetsInner client)
        {
            //$ return new SoaRecordSetImpl(parent,
            //$ new RecordSetInner()
            //$ .WithName("@")
            //$ .WithType(RecordType.SOA.ToString())
            //$ .WithSoaRecord(new SoaRecord()),
            //$ client);
            //$ }

            return this;
        }

        ///GENMHASH:86A2E852C7570A43728795EE557D15C5:3F5F2CC7F3C4A3B943EC7C1953A9D2E5
        internal  SoaRecordSetImpl(DnsZoneImpl parent, RecordSetInner innerModel, RecordSetsInner client)
        {
            //$ super(parent, innerModel, client);
            //$ }

        }
    }
}