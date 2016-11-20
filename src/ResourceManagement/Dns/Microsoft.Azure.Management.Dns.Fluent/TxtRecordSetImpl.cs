// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of TxtRecordSet.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5UeHRSZWNvcmRTZXRJbXBs
    internal partial class TxtRecordSetImpl  :
        DnsRecordSetImpl,
        ITxtRecordSet
    {
        ///GENMHASH:CDD40393B54202CD5F601C8951933BA5:3F5F2CC7F3C4A3B943EC7C1953A9D2E5
        internal  TxtRecordSetImpl(DnsZoneImpl parent, RecordSetInner innerModel, RecordSetsInner client)
        {
            //$ super(parent, innerModel, client);
            //$ }

        }

        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:A6CAFC362ACBF08FA397C2EA60D22E1C
        protected RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            //$ if (this.Inner.TxtRecords() != null && this.Inner.TxtRecords().Size() > 0) {
            //$ if (resource.TxtRecords() == null) {
            //$ resource.WithTxtRecords(new ArrayList<TxtRecord>());
            //$ }
            //$ 
            //$ resource.TxtRecords().AddAll(this.Inner.TxtRecords());
            //$ this.Inner.TxtRecords().Clear();
            //$ }
            //$ 
            //$ if (this.RecordSetRemoveInfo.TxtRecords().Size() > 0) {
            //$ if (resource.TxtRecords() != null) {
            //$ foreach(var recordToRemove in this.RecordSetRemoveInfo.TxtRecords())  {
            //$ foreach(var record in resource.TxtRecords())  {
            //$ if (record.Value().Size() != 0 && record.Value().Get(0).EqualsIgnoreCase(recordToRemove.Value().Get(0))) {
            //$ resource.TxtRecords().Remove(record);
            //$ break;
            //$ }
            //$ }
            //$ }
            //$ }
            //$ this.RecordSetRemoveInfo.TxtRecords().Clear();
            //$ }
            //$ return resource;

            return null;
        }

        ///GENMHASH:4FC81B687476F8722014B0A4F98E1756:271F0595F800257FBA25E945FA53FCF5
        public IList<TxtRecord> Records()
        {
            //$ if (this.Inner.TxtRecords() != null) {
            //$ return Collections.UnmodifiableList(this.Inner.TxtRecords());
            //$ }
            //$ return Collections.UnmodifiableList(new ArrayList<TxtRecord>());

            return null;
        }

        ///GENMHASH:AEA8C8A92DBF6D46B8137727B5EEFACA:39B0573F34E150A79B6172F2B15E69E9
        internal static TxtRecordSetImpl NewRecordSet(string name, DnsZoneImpl parent, RecordSetsInner client)
        {
            //$ return new TxtRecordSetImpl(parent,
            //$ new RecordSetInner()
            //$ .WithName(name)
            //$ .WithType(RecordType.TXT.ToString())
            //$ .WithTxtRecords(new ArrayList<TxtRecord>()),
            //$ client);
            //$ }

            return this;
        }
    }
}