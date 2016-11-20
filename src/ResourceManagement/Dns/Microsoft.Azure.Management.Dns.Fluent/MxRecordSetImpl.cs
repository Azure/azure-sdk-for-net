// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of MxRecordSet.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5NeFJlY29yZFNldEltcGw=
    internal partial class MxRecordSetImpl  :
        DnsRecordSetImpl,
        IMxRecordSet
    {
        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:0D98BE0584279084FC4D20C014B0932B
        protected RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            //$ if (this.Inner.MxRecords() != null && this.Inner.MxRecords().Size() > 0) {
            //$ if (resource.MxRecords() == null) {
            //$ resource.WithMxRecords(new ArrayList<MxRecord>());
            //$ }
            //$ 
            //$ resource.MxRecords().AddAll(this.Inner.MxRecords());
            //$ this.Inner.MxRecords().Clear();
            //$ }
            //$ 
            //$ if (this.RecordSetRemoveInfo.MxRecords().Size() > 0) {
            //$ if (resource.MxRecords() != null) {
            //$ foreach(var recordToRemove in this.RecordSetRemoveInfo.MxRecords())  {
            //$ foreach(var record in resource.MxRecords())  {
            //$ if (record.Exchange().EqualsIgnoreCase(recordToRemove.Exchange())
            //$ && (record.Preference() == recordToRemove.Preference())) {
            //$ resource.MxRecords().Remove(record);
            //$ break;
            //$ }
            //$ }
            //$ }
            //$ }
            //$ this.RecordSetRemoveInfo.MxRecords().Clear();
            //$ }
            //$ return resource;

            return null;
        }

        ///GENMHASH:4FC81B687476F8722014B0A4F98E1756:27B32B5AC9D0BA9549BAC568D5725266
        public IList<MxRecord> Records()
        {
            //$ if (this.Inner.MxRecords() != null) {
            //$ return Collections.UnmodifiableList(this.Inner.MxRecords());
            //$ }
            //$ return Collections.UnmodifiableList(new ArrayList<MxRecord>());

            return null;
        }

        ///GENMHASH:274A275E58B0BA3B1ED50C81170E88FC:3F5F2CC7F3C4A3B943EC7C1953A9D2E5
        internal  MxRecordSetImpl(DnsZoneImpl parent, RecordSetInner innerModel, RecordSetsInner client)
        {
            //$ super(parent, innerModel, client);
            //$ }

        }

        ///GENMHASH:AEA8C8A92DBF6D46B8137727B5EEFACA:844B1A3C2A17D6AAEE5DCBD858D6A293
        internal static MxRecordSetImpl NewRecordSet(string name, DnsZoneImpl parent, RecordSetsInner client)
        {
            //$ return new MxRecordSetImpl(parent,
            //$ new RecordSetInner()
            //$ .WithName(name)
            //$ .WithType(RecordType.MX.ToString())
            //$ .WithMxRecords(new ArrayList<MxRecord>()),
            //$ client);
            //$ }

            return this;
        }
    }
}