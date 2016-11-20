// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Threading;
    using Microsoft.Azure.Management.Resource.Fluent;
    using DnsZone.Update;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using DnsZone.Definition;

    /// <summary>
    /// Implementation for DnsZone.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5EbnNab25lSW1wbA==
    internal partial class DnsZoneImpl  :
        GroupableResource<IDnsZone,ZoneInner,DnsZoneImpl,DnsZoneManager>,
        IDnsZone,
        IDefinition,
        IUpdate
    {
        private ZonesInner innerCollection;
        private RecordSetsInner recordSetsClient;
        private IARecordSets aRecordSets;
        private IAaaaRecordSets aaaaRecordSets;
        private ICnameRecordSets cnameRecordSets;
        private IMxRecordSets mxRecordSets;
        private INsRecordSets nsRecordSets;
        private IPtrRecordSets ptrRecordSets;
        private ISrvRecordSets srvRecordSets;
        private ITxtRecordSets txtRecordSets;
        private DnsRecordSetsImpl recordSetsImpl;
        ///GENMHASH:33CE6A50234E86DD2006E428BDBB63DF:FFB0399D38F75C513DB4745F5D8C0E9F
        public DnsRecordSetImpl DefinePtrRecordSet(string name)
        {
            //$ return recordSetsImpl.DefinePtrRecordSet(name);

            return null;
        }

        ///GENMHASH:22B43E023856C663DE5242D855A7FD7E:E663F7DE074998860C4B12E1FE35B49A
        public DnsRecordSetImpl UpdateSrvRecordSet(string name)
        {
            //$ return recordSetsImpl.UpdateSrvRecordSet(name);

            return null;
        }

        ///GENMHASH:0EEABE3EECC944A59D1B1E0293BB0E07:27DC8959BB73F2F73F3A3012FEF5E5E3
        public IARecordSets ARecordSets()
        {
            //$ return this.aRecordSets;

            return null;
        }

        ///GENMHASH:2EBE0E253F1D6DB178F3433FF5310EA8:676B110D94D76F014EEEE150AEE3144F
        public IList<string> NameServers()
        {
            //$ return this.Inner.NameServers();

            return null;
        }

        ///GENMHASH:11F6C7A282BFB4C2631CAE48D9B23761:266B9231EBE6B8B39DE5D64A23C759BF
        public DnsRecordSetImpl DefineARecordSet(string name)
        {
            //$ return recordSetsImpl.DefineARecordSet(name);

            return null;
        }

        ///GENMHASH:59991185F1E4DCE6CD53407115062A4D:E56D214B54EED0F5CA056506698B3A2B
        public DnsZoneImpl WithCnameRecordSet(string name, string alias)
        {
            //$ recordSetsImpl.WithCnameRecordSet(name, alias);
            //$ return this;

            return this;
        }

        ///GENMHASH:1F53B3ABC8D3DD332F7B6932E224AA8C:8D7D9D9E77BFB11F3297690E49391493
        public DnsZoneImpl WithoutPtrRecordSet(string name)
        {
            //$ recordSetsImpl.WithoutPtrRecordSet(name);
            //$ return this;

            return this;
        }

        ///GENMHASH:92C4BF577DB6715BC383624BAE7694E5:F61135431BDB8F0F20AAC7E8F1DAA179
        public long MaxNumberOfRecordSets()
        {
            //$ return this.Inner.MaxNumberOfRecordSets();

            return 0;
        }

        ///GENMHASH:4412D5DEE797756911CD87C84F382A35:8933C3344596C85C396329822B55F61D
        public DnsRecordSetImpl UpdateSoaRecord()
        {
            //$ return recordSetsImpl.UpdateSoaRecordSet();

            return null;
        }

        ///GENMHASH:19FB56D67F1C3171819C68171374B827:0FA2DC825F16546F36E9485E5B1BF167
        public DnsRecordSetImpl UpdateAaaaRecordSet(string name)
        {
            //$ return recordSetsImpl.UpdateAaaaRecordSet(name);

            return null;
        }

        ///GENMHASH:62675C05A328D2B3015CB3D2B125891F:E29D3C8FA71CEC5271170990C3A2CB1B
        public DnsRecordSetImpl UpdateTxtRecordSet(string name)
        {
            //$ return recordSetsImpl.UpdateTxtRecordSet(name);

            return null;
        }

        ///GENMHASH:EE1082F2F97076B859060B336D52A16B:73E10727349F87730D611072370EFB6E
        private void InitRecordSets()
        {
            //$ this.aRecordSets = new ARecordSetsImpl(this, this.recordSetsClient);
            //$ this.aaaaRecordSets = new AaaaRecordSetsImpl(this, this.recordSetsClient);
            //$ this.cnameRecordSets = new CnameRecordSetsImpl(this, this.recordSetsClient);
            //$ this.mxRecordSets = new MxRecordSetsImpl(this, this.recordSetsClient);
            //$ this.nsRecordSets = new NsRecordSetsImpl(this, this.recordSetsClient);
            //$ this.ptrRecordSets = new PtrRecordSetsImpl(this, this.recordSetsClient);
            //$ this.srvRecordSets = new SrvRecordSetsImpl(this, this.recordSetsClient);
            //$ this.txtRecordSets = new TxtRecordSetsImpl(this, this.recordSetsClient);
            //$ this.recordSetsImpl.ClearPendingOperations();
            //$ }

        }

        ///GENMHASH:3BE07D98F4ADC1B06829114EA2606ED4:3C28045E01B03B7494D3302D6A7D064D
        public DnsRecordSetImpl DefineNsRecordSet(string name)
        {
            //$ return recordSetsImpl.DefineNsRecordSet(name);

            return null;
        }

        ///GENMHASH:8F3B63282E3A22D23CA9B093FA6A44F8:20E3842CCAFDF776C20B1023B1BA21C4
        public DnsRecordSetImpl UpdateMxRecordSet(string name)
        {
            //$ return recordSetsImpl.UpdateMxRecordSet(name);

            return null;
        }

        ///GENMHASH:6A236BC9874C63721A7695A7FE9A4C18:8E60906622FD55B055D5983DD550D216
        public DnsZoneImpl WithoutSrvRecordSet(string name)
        {
            //$ recordSetsImpl.WithoutSrvRecordSet(name);
            //$ return this;

            return this;
        }

        ///GENMHASH:87C6576F7C5A41E12DA61251590634AA:6B2F5F529555C811DA244F0261C7F42C
        public INsRecordSets NsRecordSets()
        {
            //$ return this.nsRecordSets;

            return null;
        }

        ///GENMHASH:76F011335BBB78AE07E7C19B287C17C2:24F9401B87CAEAFB4C0B9D7C009DE5FA
        public DnsRecordSetImpl DefineAaaaRecordSet(string name)
        {
            //$ return recordSetsImpl.DefineAaaaRecordSet(name);

            return null;
        }

        ///GENMHASH:6CCAD6D4D3A8F0925655956402A80C0F:BFD703DC159A6C7C5690B49646355CCD
        public DnsRecordSetImpl DefineTxtRecordSet(string name)
        {
            //$ return recordSetsImpl.DefineTxtRecordSet(name);

            return null;
        }

        ///GENMHASH:82DDFD7EF42553D6690E5976569BC3A5:6F7BEBF118C7CAC28AEBD6B33F9EE35C
        public IPtrRecordSets PtrRecordSets()
        {
            //$ return this.ptrRecordSets;

            return null;
        }

        ///GENMHASH:3EECA7B78CDBF9708E3E2E13E2122004:31CB15D3EB20E8486D2995C3637E584B
        public ICnameRecordSets CnameRecordSets()
        {
            //$ return this.cnameRecordSets;

            return null;
        }

        ///GENMHASH:F5E15CDECC035B82BF39162780BA9198:A252C32524D1D7E7B960E559973C4ED1
        public ISrvRecordSets SrvRecordSets()
        {
            //$ return this.srvRecordSets;

            return null;
        }

        ///GENMHASH:5121804C5EF1A7CB4B5C344EFB2BD758:60833011EC968E62025764949BC25A79
        public DnsZoneImpl WithoutARecordSet(string name)
        {
            //$ recordSetsImpl.WithoutARecordSet(name);
            //$ return this;

            return this;
        }

        ///GENMHASH:54D2D45FDDD815CD9CB65600866E9EB0:6462A500BE7F66FC6CFF8010C7DFB6C1
        public DnsZoneImpl WithoutMxRecordSet(string name)
        {
            //$ recordSetsImpl.WithoutMxRecordSet(name);
            //$ return this;

            return this;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:EF3CE1F98A96F8DA517AE632974073AA
        public async Task<IDnsZone> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ DnsZoneImpl self = this;
            //$ return this.innerCollection.CreateOrUpdateAsync(this.ResourceGroupName(), this.Name(), this.Inner)
            //$ .Map(innerToFluentMap(this))
            //$ .FlatMap(new Func1<DnsZone, Observable<? extends DnsZone>>() {
            //$ @Override
            //$ public Observable<? extends DnsZone> call(DnsZone dnsZone) {
            //$ return self.RecordSetsImpl.CommitAndGetAllAsync()
            //$ .Map(new Func1<List<DnsRecordSetImpl>, DnsZone>() {
            //$ @Override
            //$ public DnsZone call(List<DnsRecordSetImpl> recordSets) {
            //$ return self;
            //$ }
            //$ });
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:DEFDD202FC66399CE6F4DC2385FFBE4E:E09C978D163DA3D891F10EDEA4E7EAE2
        public DnsRecordSetImpl UpdateARecordSet(string name)
        {
            //$ return recordSetsImpl.UpdateARecordSet(name);

            return null;
        }

        ///GENMHASH:52729C9C39AC4D628145F797BF5100E5:36E2465D33C18BB23AEA110DC31293E4
        public DnsRecordSetImpl UpdatePtrRecordSet(string name)
        {
            //$ return recordSetsImpl.UpdatePtrRecordSet(name);

            return null;
        }

        ///GENMHASH:766D91058115C559BE5B14A9C7056073:45786BE7DC1F8A260526EC385F813C1B
        public DnsRecordSetImpl DefineMxRecordSet(string name)
        {
            //$ return recordSetsImpl.DefineMxRecordSet(name);

            return null;
        }

        ///GENMHASH:132875C15861A92E60F93E154E091602:F70AB38B6FDE85737888182B48E6B611
        internal  DnsZoneImpl(string name, ZoneInner innerModel, ZonesInner innerCollection, RecordSetsInner recordSetsClient, DnsZoneManager trafficManager)
        {
            //$ {
            //$ super(name, innerModel, trafficManager);
            //$ this.innerCollection = innerCollection;
            //$ this.recordSetsClient = recordSetsClient;
            //$ this.recordSetsImpl = new DnsRecordSetsImpl(recordSetsClient, this);
            //$ initRecordSets();
            //$ }

        }

        ///GENMHASH:3F0A6CC3DBBB3330F47E8737215D7ECE:08F4FF93F43929543646D0EBF2903504
        public ISoaRecordSet GetSoaRecordSet()
        {
            //$ RecordSetInner inner = this.recordSetsClient.Get(this.ResourceGroupName(), this.Name(), "@", RecordType.SOA);
            //$ return new SoaRecordSetImpl(this, inner, this.recordSetsClient);

            return null;
        }

        ///GENMHASH:9AB7664BD0C8EE192BC61FD76EFCAF87:F3CAC648F4ECD829852ED6ADB4E1A338
        public DnsRecordSetImpl DefineSrvRecordSet(string name)
        {
            //$ return recordSetsImpl.DefineSrvRecordSet(name);

            return null;
        }

        ///GENMHASH:5954219C81F347FC86D24BBD07355380:8CFD324CF132033F543444B0B1ED6EC5
        public IAaaaRecordSets AaaaRecordSets()
        {
            //$ return this.aaaaRecordSets;

            return null;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:6E114CA661817C270373E8F5D86D84F5
        public IDnsZone Refresh()
        {
            //$ ZoneInner inner = this.innerCollection.Get(this.ResourceGroupName(), this.Name());
            //$ this.SetInner(inner);
            //$ this.InitRecordSets();
            //$ return this;

            return null;
        }

        ///GENMHASH:E10C7FF5C36891D769128853352DD627:C2BD0B555A21A8D13988A3FB8138875D
        public DnsZoneImpl WithoutAaaaRecordSet(string name)
        {
            //$ recordSetsImpl.WithoutAaaaRecordSet(name);
            //$ return this;

            return this;
        }

        ///GENMHASH:94C8130FABA73F5B8D40A0A1D4A5487B:B6F715104E7D3FFD403D53AB2D808CEA
        public ITxtRecordSets TxtRecordSets()
        {
            //$ return this.txtRecordSets;

            return null;
        }

        ///GENMHASH:EDF384FBE686F4A04431E3BC18889398:B6C34FCD3D80CE6399DBF488AC70440F
        public DnsZoneImpl WithoutCnameRecordSet(string name)
        {
            //$ recordSetsImpl.WithoutCnameRecordSet(name);
            //$ return this;

            return this;
        }

        ///GENMHASH:6367F8A407349BBB833D3790CE7781BE:E5617108F877DD24CA72463B3D7BBB6D
        public long NumberOfRecordSets()
        {
            //$ return this.Inner.NumberOfRecordSets();

            return 0;
        }

        ///GENMHASH:9346CB4D0F5C719EB9C7E3A3AE77D732:CF958FACD1F19347590706D6D905C707
        public IMxRecordSets MxRecordSets()
        {
            //$ return this.mxRecordSets;

            return null;
        }

        ///GENMHASH:ECF2482EF49EC3D1CB1FA4A823939109:CFA02769236E87811E8DDA4F0363D6EC
        public DnsZoneImpl WithoutTxtRecordSet(string name)
        {
            //$ recordSetsImpl.WithoutTxtRecordSet(name);
            //$ return this;

            return this;
        }

        ///GENMHASH:329EC651435AC8A74D3A1349985D55EE:F2A93F30A698AE9ED05A108FF9F65CFB
        public DnsRecordSetImpl UpdateNsRecordSet(string name)
        {
            //$ return recordSetsImpl.UpdateNsRecordSet(name);

            return null;
        }

        ///GENMHASH:DBFF1C1D58718301508DC884197E6B5A:0944E077B82EF0CBECB458CFBCC47DDA
        public DnsZoneImpl WithoutNsRecordSet(string name)
        {
            //$ recordSetsImpl.WithoutNsRecordSet(name);
            //$ return this;

            return this;
        }
    }
}