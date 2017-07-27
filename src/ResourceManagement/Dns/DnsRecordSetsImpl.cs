// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using ResourceManager.Fluent.Core;
    using Models;

    /// <summary>
    /// Represents an record set collection associated with a DNS zone.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5EbnNSZWNvcmRTZXRzSW1wbA==
    internal partial class DnsRecordSetsImpl :
        ExternalChildResourcesNonCached<DnsRecordSetImpl,IDnsRecordSet,RecordSetInner, IDnsZone, DnsZoneImpl>
    {
        private const long defaultTtlInSeconds = 3600;

        ///GENMHASH:33CE6A50234E86DD2006E428BDBB63DF:30201AA27A5A98E1712A29F13778AEE9
        internal DnsRecordSetImpl DefinePtrRecordSet(string name)
        {
            return this.SetDefaults(base.PrepareDefine(PtrRecordSetImpl.NewRecordSet(name, Parent)));
        }

        ///GENMHASH:22B43E023856C663DE5242D855A7FD7E:2034830894BF8B9F5B1349D42E84B6F9
        internal DnsRecordSetImpl UpdateSrvRecordSet(string name)
        {
            return base.PrepareUpdate(SrvRecordSetImpl.NewRecordSet(name, Parent));
        }

        ///GENMHASH:C889FC2248A62D9FE6344CD5D798777B:8BC49BA6AD1446B08692535E25D95BAA
        internal void ClearPendingOperations()
        {
            this.collection.Clear();
        }

        ///GENMHASH:11F6C7A282BFB4C2631CAE48D9B23761:97124592B616D3F5FD334710FD6A460A
        internal DnsRecordSetImpl DefineARecordSet(string name)
        {
            return this.SetDefaults(base.PrepareDefine(ARecordSetImpl.NewRecordSet(name, Parent)));
        }

        ///GENMHASH:1F806E4CBC9AF647A64C1631E4524D83:15CC59C3355994491CE8B7C76344C34D
        internal void WithCNameRecordSet(string name, string alias)
        {
            CNameRecordSetImpl recordSet = CNameRecordSetImpl.NewRecordSet(name, Parent);
            recordSet.Inner.CnameRecord.Cname = alias;
            this.SetDefaults(base.PrepareDefine(recordSet.WithTimeToLive(defaultTtlInSeconds)));
        }

        ///GENMHASH:C9A7146C9B1311BD2295FF461FD54E80:661C2511C19BA0F92D83F060EC17686F
        internal void WithoutPtrRecordSet(string name, string eTagValue)
        {
            base.PrepareRemove(PtrRecordSetImpl.NewRecordSet(name, Parent).WithETagOnDelete(eTagValue));
        }

        /// <summary>
        /// Creates new DnsRecordSetsImpl.
        /// </summary>
        /// <param name="parent">The parent DNS zone of the record set.</param>
        ///GENMHASH:679769A0C3AB0DC0D68CC67BCE854713:3408A9E4E134A47B47F8849E354922EB
        internal DnsRecordSetsImpl(DnsZoneImpl parent) : base(parent, "RecordSet")
        {
        }

        ///GENMHASH:19FB56D67F1C3171819C68171374B827:9120AD659996B031DCB7C692C41F8828
        internal DnsRecordSetImpl UpdateAaaaRecordSet(string name)
        {
            return base.PrepareUpdate(AaaaRecordSetImpl.NewRecordSet(name, Parent));
        }

        ///GENMHASH:62675C05A328D2B3015CB3D2B125891F:21202F5AA1FBBD1F9E5DB7B71022F1CB
        internal DnsRecordSetImpl UpdateTxtRecordSet(string name)
        {
            return base.PrepareUpdate(TxtRecordSetImpl.NewRecordSet(name, Parent));
        }

        ///GENMHASH:46C9C87DA2C900034A20B7DB46BD77F5:4CD2654453EBD92C92BC47075793C28F
        internal DnsRecordSetImpl DefineNSRecordSet(string name)
        {
            return this.SetDefaults(base.PrepareDefine(NSRecordSetImpl.NewRecordSet(name, Parent)));
        }

        ///GENMHASH:5CC95DD8B9468242DBEEF10F96E9EECF:65D7F2059CC1C64C3DD92597A04E6BA4
        internal DnsRecordSetImpl UpdateMXRecordSet(string name)
        {
            return base.PrepareUpdate(MXRecordSetImpl.NewRecordSet(name, Parent));
        }

        ///GENMHASH:EC620CE3EF72DD020734D0F57C7057F2:1B291A760BFBA465B86B473C301C6278
        internal void WithoutSrvRecordSet(string name, string eTagValue)
        {
            base.PrepareRemove(SrvRecordSetImpl.NewRecordSet(name, Parent).WithETagOnDelete(eTagValue));
        }

        ///GENMHASH:76F011335BBB78AE07E7C19B287C17C2:28BE6F1DD0B79FD244BAFB93257566AC
        internal DnsRecordSetImpl DefineAaaaRecordSet(string name)
        {
            return this.SetDefaults(base.PrepareDefine(AaaaRecordSetImpl.NewRecordSet(name, Parent)));
        }

        ///GENMHASH:6CCAD6D4D3A8F0925655956402A80C0F:C9CEFA6CBE51DAD3746646E5D5A29363
        internal DnsRecordSetImpl DefineTxtRecordSet(string name)
        {
            return this.SetDefaults(base.PrepareDefine(TxtRecordSetImpl.NewRecordSet(name, Parent)));
        }

        ///GENMHASH:B52E7C54A2094CF7BC537D1CC67AD933:96A6C5A1D364B5BF691E2D2C3CE73911
        internal void WithoutARecordSet(string name, string eTagValue)
        {
            base.PrepareRemove(ARecordSetImpl.NewRecordSet(name, Parent).WithETagOnDelete(eTagValue));
        }

        ///GENMHASH:4F52CFFC8EB4D698DB3A4C3B1E187BD0:3FBE768F6D1CB0F7CD6734B2CAF6EAA4
        internal DnsRecordSetImpl UpdateCNameRecordSet(string name)
        {
            return this.PrepareUpdate(CNameRecordSetImpl.NewRecordSet(name, this.Parent));
        }

        ///GENMHASH:CAE11DD729AC8148C1BB19AC98C19A66:E45581AE5C46A0FE18E2A1DD0A2CCCFD
        internal void WithoutMXRecordSet(string name, string eTagValue)
        {
            base.PrepareRemove(MXRecordSetImpl.NewRecordSet(name, Parent).WithETagOnDelete(eTagValue));
        }

        ///GENMHASH:DEFDD202FC66399CE6F4DC2385FFBE4E:14A42864F2BD8170C54648B80D594EAE
        internal DnsRecordSetImpl UpdateARecordSet(string name)
        {
            return base.PrepareUpdate(ARecordSetImpl.NewRecordSet(name, Parent));
        }

        ///GENMHASH:52729C9C39AC4D628145F797BF5100E5:E879FCC900581FF0F2E1A6390496B6B5
        internal DnsRecordSetImpl UpdatePtrRecordSet(string name)
        {
            return base.PrepareUpdate(PtrRecordSetImpl.NewRecordSet(name, Parent));
        }

        ///GENMHASH:7FD0DE0CD548F2703A15E4BAA97D6873:E0DD5160A509D33589ABF4C98C436DD9
        internal DnsRecordSetImpl DefineMXRecordSet(string name)
        {
            return this.SetDefaults(base.PrepareDefine(MXRecordSetImpl.NewRecordSet(name, Parent)));
        }

        ///GENMHASH:9AB7664BD0C8EE192BC61FD76EFCAF87:FCDEEB64BF192A5C748A33711BAFB5CB
        internal DnsRecordSetImpl DefineSrvRecordSet(string name)
        {
            return this.SetDefaults(base.PrepareDefine(SrvRecordSetImpl.NewRecordSet(name, Parent)));
        }

        ///GENMHASH:EDB813BC169498B6DE770C4D9858547C:D7878BB646FC3265F12A85E42D5F6FB5
        private DnsRecordSetImpl SetDefaults(DnsRecordSetImpl recordSet)
        {
            return recordSet.WithTimeToLive(defaultTtlInSeconds);
        }

        ///GENMHASH:762F03CE80F4A9BF3ADBEEC0D41DB5AF:EF8391D0A55BD3AE0A43B8DF9F219881
        internal void WithoutAaaaRecordSet(string name, string eTagValue)
        {
            base.PrepareRemove(AaaaRecordSetImpl.NewRecordSet(name, Parent).WithETagOnDelete(eTagValue));
        }

        ///GENMHASH:69DD1218436902CDC3B7BC8695982064:C475FC32598A569356704FFFEB377798
        internal void WithoutCNameRecordSet(string name, string eTagValue)
        {
            this.PrepareRemove(CNameRecordSetImpl.NewRecordSet(name, Parent).WithETagOnDelete(eTagValue));
        }

        ///GENMHASH:D5078976D64C68B60845416B4A519771:C6D9FE23F88DD0A91B8AFADCF6747DA3
        internal DnsRecordSetImpl DefineCNameRecordSet(string name)
        {
            return this.SetDefaults(base.PrepareDefine(CNameRecordSetImpl.NewRecordSet(name, this.Parent)));
        }

        ///GENMHASH:307087E2D68C3C7331CD91AE28C42489:B22C11E1F7EF21FF71D46CA02658B558
        internal DnsRecordSetImpl UpdateSoaRecordSet()
        {
            return base.PrepareUpdate(SoaRecordSetImpl.NewRecordSet(Parent));
        }

        ///GENMHASH:2AAD8D85A395EE1384B1E0A6010A750B:27BB73B236A4A4AEB05FD1E551F32CA1
        internal void WithoutTxtRecordSet(string name, string eTagValue)
        {
            base.PrepareRemove(TxtRecordSetImpl.NewRecordSet(name, this.Parent).WithETagOnDelete(eTagValue));
        }

        ///GENMHASH:CC4422F1AB1A272DA6DBEBD9DD8767DF:7A219FC32D8DF9309477349CADDC6FAC
        internal DnsRecordSetImpl UpdateNSRecordSet(string name)
        {
            return base.PrepareUpdate(NSRecordSetImpl.NewRecordSet(name, Parent));
        }

        ///GENMHASH:0A638BEAEF3AE7294B3373C1072B1E0A:FB6B9486A3534F4BD163041C4A2F7188
        internal void WithoutNSRecordSet(string name, string eTagValue)
        {
            this.PrepareRemove(NSRecordSetImpl.NewRecordSet(name, Parent).WithETagOnDelete(eTagValue));
        }
    }
}
