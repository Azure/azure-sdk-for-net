// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// Represents an record set collection associated with a Dns zone.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5EbnNSZWNvcmRTZXRzSW1wbA==
    internal partial class DnsRecordSetsImpl  :
        ExternalChildResourcesNonCachedImpl<DnsRecordSetImpl,IDnsRecordSet,RecordSetInner,DnsZoneImpl,IDnsZone>
    {
        private RecordSetsInner client;
        private long defaultTtlInSeconds;
        ///GENMHASH:33CE6A50234E86DD2006E428BDBB63DF:09BF34D10B63453EB734D3C16BE93E66
        internal DnsRecordSetImpl DefinePtrRecordSet(string name)
        {
            //$ return setDefaults(prepareDefine(PtrRecordSetImpl.NewRecordSet(name, this.Parent(), this.client)));
            //$ }

            return null;
        }

        ///GENMHASH:22B43E023856C663DE5242D855A7FD7E:709AC8F2DD250142A76B94E642D35A79
        internal DnsRecordSetImpl UpdateSrvRecordSet(string name)
        {
            //$ return prepareUpdate(SrvRecordSetImpl.NewRecordSet(name, this.Parent(), this.client));
            //$ }

            return null;
        }

        ///GENMHASH:C889FC2248A62D9FE6344CD5D798777B:8BC49BA6AD1446B08692535E25D95BAA
        internal void ClearPendingOperations()
        {
            //$ this.ChildCollection.Clear();
            //$ }

        }

        ///GENMHASH:11F6C7A282BFB4C2631CAE48D9B23761:91DAA152E5541E2ED4906D3FFDE4C24A
        internal DnsRecordSetImpl DefineARecordSet(string name)
        {
            //$ return setDefaults(prepareDefine(ARecordSetImpl.NewRecordSet(name, this.Parent(), this.client)));
            //$ }

            return null;
        }

        ///GENMHASH:59991185F1E4DCE6CD53407115062A4D:722C71889B2C1576A4C5173BBA782847
        internal void WithCnameRecordSet(string name, string alias)
        {
            //$ CnameRecordSetImpl recordSet = CnameRecordSetImpl.NewRecordSet(name, this.Parent(), this.client);
            //$ recordSet.Inner.CnameRecord().WithCname(alias);
            //$ setDefaults(prepareDefine(recordSet.WithTimeToLive(defaultTtlInSeconds)));
            //$ }

        }

        ///GENMHASH:1F53B3ABC8D3DD332F7B6932E224AA8C:95152C98D37950C84476AE785919D52A
        internal void WithoutPtrRecordSet(string name)
        {
            //$ prepareRemove(PtrRecordSetImpl.NewRecordSet(name, this.Parent(), this.client));
            //$ }

        }

        /// <summary>
        /// Creates new DnsRecordSetsImpl.
        /// </summary>
        /// <param name="client">The client to perform REST calls on record sets.</param>
        /// <param name="parent">The parent Dns zone of the record set.</param>
        ///GENMHASH:F9E2D3727D66DFA1253AB4BD2195C4B1:824964281DB07BCB6FFFF714E2A80FA0
        internal  DnsRecordSetsImpl(RecordSetsInner client, DnsZoneImpl parent)
        {
            //$ super(parent, "RecordSet");
            //$ this.client = client;
            //$ }

        }

        ///GENMHASH:19FB56D67F1C3171819C68171374B827:7ACC685EA8F25E6EAF3F794374C9E88E
        internal DnsRecordSetImpl UpdateAaaaRecordSet(string name)
        {
            //$ return prepareUpdate(AaaaRecordSetImpl.NewRecordSet(name, this.Parent(), this.client));
            //$ }

            return null;
        }

        ///GENMHASH:62675C05A328D2B3015CB3D2B125891F:2BB09F59288948492593E33CD613400F
        internal DnsRecordSetImpl UpdateTxtRecordSet(string name)
        {
            //$ return prepareUpdate(TxtRecordSetImpl.NewRecordSet(name, this.Parent(), this.client));
            //$ }

            return null;
        }

        ///GENMHASH:3BE07D98F4ADC1B06829114EA2606ED4:681C93C815E8FF939B5CFDF763BA0BF8
        internal DnsRecordSetImpl DefineNsRecordSet(string name)
        {
            //$ return setDefaults(prepareDefine(NsRecordSetImpl.NewRecordSet(name, this.Parent(), this.client)));
            //$ }

            return null;
        }

        ///GENMHASH:8F3B63282E3A22D23CA9B093FA6A44F8:D5391A93F9C3766E6D0E2B89779EC239
        internal DnsRecordSetImpl UpdateMxRecordSet(string name)
        {
            //$ return prepareUpdate(MxRecordSetImpl.NewRecordSet(name, this.Parent(), this.client));
            //$ }

            return null;
        }

        ///GENMHASH:6A236BC9874C63721A7695A7FE9A4C18:0192D8DCC266E4C9BD1DD2971E321284
        internal void WithoutSrvRecordSet(string name)
        {
            //$ prepareRemove(SrvRecordSetImpl.NewRecordSet(name, this.Parent(), this.client));
            //$ }

        }

        ///GENMHASH:76F011335BBB78AE07E7C19B287C17C2:AEC114564261521EDB0FB780A853D60D
        internal DnsRecordSetImpl DefineAaaaRecordSet(string name)
        {
            //$ return setDefaults(prepareDefine(AaaaRecordSetImpl.NewRecordSet(name, this.Parent(), this.client)));
            //$ }

            return null;
        }

        ///GENMHASH:6CCAD6D4D3A8F0925655956402A80C0F:9DB4A46D41F3A95155FB459800D57EE0
        internal DnsRecordSetImpl DefineTxtRecordSet(string name)
        {
            //$ return setDefaults(prepareDefine(TxtRecordSetImpl.NewRecordSet(name, this.Parent(), this.client)));
            //$ }

            return null;
        }

        ///GENMHASH:5121804C5EF1A7CB4B5C344EFB2BD758:D973B16B89A82B65B4E6CD8E37533244
        internal void WithoutARecordSet(string name)
        {
            //$ prepareRemove(ARecordSetImpl.NewRecordSet(name, this.Parent(), this.client));
            //$ }

        }

        ///GENMHASH:54D2D45FDDD815CD9CB65600866E9EB0:CC31A505901FD47CF2610924AB1E6670
        internal void WithoutMxRecordSet(string name)
        {
            //$ prepareRemove(MxRecordSetImpl.NewRecordSet(name, this.Parent(), this.client));
            //$ }

        }

        ///GENMHASH:DEFDD202FC66399CE6F4DC2385FFBE4E:27B8D0A18BE2BCCE96B837CA9B695464
        internal DnsRecordSetImpl UpdateARecordSet(string name)
        {
            //$ return prepareUpdate(ARecordSetImpl.NewRecordSet(name, this.Parent(), this.client));
            //$ }

            return null;
        }

        ///GENMHASH:52729C9C39AC4D628145F797BF5100E5:1982A79775C12D7B3FC2506568759338
        internal DnsRecordSetImpl UpdatePtrRecordSet(string name)
        {
            //$ return prepareUpdate(PtrRecordSetImpl.NewRecordSet(name, this.Parent(), this.client));
            //$ }

            return null;
        }

        ///GENMHASH:766D91058115C559BE5B14A9C7056073:374F2C4865988ED72AACF9B485DA9454
        internal DnsRecordSetImpl DefineMxRecordSet(string name)
        {
            //$ return setDefaults(prepareDefine(MxRecordSetImpl.NewRecordSet(name, this.Parent(), this.client)));
            //$ }

            return null;
        }

        ///GENMHASH:9AB7664BD0C8EE192BC61FD76EFCAF87:4C0D34487731D9C6F793472DA460A2A0
        internal DnsRecordSetImpl DefineSrvRecordSet(string name)
        {
            //$ return setDefaults(prepareDefine(SrvRecordSetImpl.NewRecordSet(name, this.Parent(), this.client)));
            //$ }

            return null;
        }

        ///GENMHASH:EDB813BC169498B6DE770C4D9858547C:D7878BB646FC3265F12A85E42D5F6FB5
        private DnsRecordSetImpl SetDefaults(DnsRecordSetImpl recordSet)
        {
            //$ return recordSet.WithTimeToLive(defaultTtlInSeconds);
            //$ }

            return null;
        }

        ///GENMHASH:E10C7FF5C36891D769128853352DD627:876C2D07B1DBD4C4068AE2FD33CB00F7
        internal void WithoutAaaaRecordSet(string name)
        {
            //$ prepareRemove(AaaaRecordSetImpl.NewRecordSet(name, this.Parent(), this.client));
            //$ }

        }

        ///GENMHASH:EDF384FBE686F4A04431E3BC18889398:18768AB27F01069942917D1C1419E5B1
        internal void WithoutCnameRecordSet(string name)
        {
            //$ prepareRemove(CnameRecordSetImpl.NewRecordSet(name, this.Parent(), this.client));
            //$ }

        }

        ///GENMHASH:307087E2D68C3C7331CD91AE28C42489:A544C4DB97263ACD321136702E297EB8
        internal DnsRecordSetImpl UpdateSoaRecordSet()
        {
            //$ return prepareUpdate(SoaRecordSetImpl.NewRecordSet(this.Parent(), this.client));
            //$ }

            return null;
        }

        ///GENMHASH:ECF2482EF49EC3D1CB1FA4A823939109:3627164D124D8341C78C833267F1AA85
        internal void WithoutTxtRecordSet(string name)
        {
            //$ prepareRemove(TxtRecordSetImpl.NewRecordSet(name, this.Parent(), this.client));
            //$ }

        }

        ///GENMHASH:329EC651435AC8A74D3A1349985D55EE:203F4CA316E50BB09C1868097CC9C75C
        internal DnsRecordSetImpl UpdateNsRecordSet(string name)
        {
            //$ return prepareUpdate(NsRecordSetImpl.NewRecordSet(name, this.Parent(), this.client));
            //$ }

            return null;
        }

        ///GENMHASH:DBFF1C1D58718301508DC884197E6B5A:AFBA3BF40171221C8B0981419D4FA585
        internal void WithoutNsRecordSet(string name)
        {
            //$ prepareRemove(NsRecordSetImpl.NewRecordSet(name, this.Parent(), this.client));
            //$ }

        }
    }
}