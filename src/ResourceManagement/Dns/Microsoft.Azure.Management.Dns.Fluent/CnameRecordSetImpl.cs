// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    /// <summary>
    /// Implementation of CnameRecordSet.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5DbmFtZVJlY29yZFNldEltcGw=
    internal partial class CnameRecordSetImpl  :
        DnsRecordSetImpl,
        ICnameRecordSet
    {
        ///GENMHASH:7D787B3687385E18B312D5F6D6DA9444:AF11C8A7E2B299112E3CED7714F622A7
        protected RecordSetInner PrepareForUpdate(RecordSetInner resource)
        {
            //$ return resource;

            return null;
        }

        ///GENMHASH:E5A5F4A2DE55AF67359951B8714E8E37:3F5F2CC7F3C4A3B943EC7C1953A9D2E5
        internal  CnameRecordSetImpl(DnsZoneImpl parent, RecordSetInner innerModel, RecordSetsInner client)
        {
            //$ super(parent, innerModel, client);
            //$ }

        }

        ///GENMHASH:AEA8C8A92DBF6D46B8137727B5EEFACA:D5B3BC12D1EBABAB93ACF0C43C024873
        internal static CnameRecordSetImpl NewRecordSet(string name, DnsZoneImpl parent, RecordSetsInner client)
        {
            //$ return new CnameRecordSetImpl(parent,
            //$ new RecordSetInner()
            //$ .WithName(name)
            //$ .WithType(RecordType.CNAME.ToString())
            //$ .WithCnameRecord(new CnameRecord()),
            //$ client);
            //$ }

            return this;
        }

        ///GENMHASH:90659807B6B17ED9B2E619F2F74829BA:5F97BB0D1B58FFF4810D8B3F037EC111
        public string CanonicalName()
        {
            //$ if (this.Inner.CnameRecord() != null) {
            //$ return this.Inner.CnameRecord().Cname();
            //$ }
            //$ return null;

            return null;
        }
    }
}