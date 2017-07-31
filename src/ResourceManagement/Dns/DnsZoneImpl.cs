// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Threading;
    using ResourceManager.Fluent;
    using DnsZone.Update;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using DnsZone.Definition;
    using Models;
    using System.Linq;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for DnsZone.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5EbnNab25lSW1wbA==
    internal partial class DnsZoneImpl  :
        GroupableResource<IDnsZone,
            ZoneInner, 
            DnsZoneImpl, 
            IDnsZoneManager,
            DnsZone.Definition.IWithCreate,
            DnsZone.Definition.IWithCreate,
            DnsZone.Definition.IWithCreate,
            DnsZone.Update.IUpdate>,
        IDnsZone,
        IDefinition,
        IUpdate
    {
        private IARecordSets aRecordSets;
        private IAaaaRecordSets aaaaRecordSets;
        private ICNameRecordSets cnameRecordSets;
        private IMXRecordSets mxRecordSets;
        private INSRecordSets nsRecordSets;
        private IPtrRecordSets ptrRecordSets;
        private ISrvRecordSets srvRecordSets;
        private ITxtRecordSets txtRecordSets;
        private DnsRecordSetsImpl recordSetsImpl;
        private string dnsZoneETag;

        ///GENMHASH:33CE6A50234E86DD2006E428BDBB63DF:FFB0399D38F75C513DB4745F5D8C0E9F
        public DnsRecordSetImpl DefinePtrRecordSet(string name)
        {
            return recordSetsImpl.DefinePtrRecordSet(name);
        }

        ///GENMHASH:22B43E023856C663DE5242D855A7FD7E:E663F7DE074998860C4B12E1FE35B49A
        public DnsRecordSetImpl UpdateSrvRecordSet(string name)
        {
            return recordSetsImpl.UpdateSrvRecordSet(name);
        }

        ///GENMHASH:0EEABE3EECC944A59D1B1E0293BB0E07:27DC8959BB73F2F73F3A3012FEF5E5E3
        public IARecordSets ARecordSets()
        {
            return this.aRecordSets;
        }
        
        ///GENMHASH:1F806E4CBC9AF647A64C1631E4524D83:F08C99E11B7048517EE726026B9D7B91
        public DnsZoneImpl WithCNameRecordSet(string name, string alias)
        {
            recordSetsImpl.WithCNameRecordSet(name, alias);
            return this;
        }
        
        ///GENMHASH:2EBE0E253F1D6DB178F3433FF5310EA8:676B110D94D76F014EEEE150AEE3144F
        public IReadOnlyList<string> NameServers()
        {
            if (Inner.NameServers == null)
            {
                return new List<string>();
            }
            return Inner.NameServers?.ToList();
        }

        ///GENMHASH:11F6C7A282BFB4C2631CAE48D9B23761:266B9231EBE6B8B39DE5D64A23C759BF
        public DnsRecordSetImpl DefineARecordSet(string name)
        {
            return recordSetsImpl.DefineARecordSet(name);
        }

        ///GENMHASH:1F53B3ABC8D3DD332F7B6932E224AA8C:5DE8F63E4D78168B2EC742B4E14FF460
        public DnsZoneImpl WithoutPtrRecordSet(string name)
        {
            return this.WithoutPtrRecordSet(name, null);
        }

        ///GENMHASH:C9A7146C9B1311BD2295FF461FD54E80:6FBFF1647C0BF93094CA21512F31CDB0
        public DnsZoneImpl WithoutPtrRecordSet(string name, string eTag)
        {
            recordSetsImpl.WithoutPtrRecordSet(name, eTag);
            return this;
        }

        ///GENMHASH:92C4BF577DB6715BC383624BAE7694E5:F61135431BDB8F0F20AAC7E8F1DAA179
        public long MaxNumberOfRecordSets()
        {
            return Inner.MaxNumberOfRecordSets.HasValue ? Inner.MaxNumberOfRecordSets.Value : 0;
        }

        ///GENMHASH:4412D5DEE797756911CD87C84F382A35:8933C3344596C85C396329822B55F61D
        public DnsRecordSetImpl UpdateSoaRecord()
        {
            return recordSetsImpl.UpdateSoaRecordSet();
        }

        ///GENMHASH:19FB56D67F1C3171819C68171374B827:0FA2DC825F16546F36E9485E5B1BF167
        public DnsRecordSetImpl UpdateAaaaRecordSet(string name)
        {
            return recordSetsImpl.UpdateAaaaRecordSet(name);
        }

        ///GENMHASH:62675C05A328D2B3015CB3D2B125891F:E29D3C8FA71CEC5271170990C3A2CB1B
        public DnsRecordSetImpl UpdateTxtRecordSet(string name)
        {
            return recordSetsImpl.UpdateTxtRecordSet(name);
        }

        ///GENMHASH:EE1082F2F97076B859060B336D52A16B:D92A2603A69DACAF219D702920E38B76
        private void InitRecordSets()
        {
            this.aRecordSets = new ARecordSetsImpl(this);
            this.aaaaRecordSets = new AaaaRecordSetsImpl(this);
            this.cnameRecordSets = new CNameRecordSetsImpl(this);
            this.mxRecordSets = new MXRecordSetsImpl(this);
            this.nsRecordSets = new NSRecordSetsImpl(this);
            this.ptrRecordSets = new PtrRecordSetsImpl(this);
            this.srvRecordSets = new SrvRecordSetsImpl(this);
            this.txtRecordSets = new TxtRecordSetsImpl(this);
            this.recordSetsImpl.ClearPendingOperations();
        }

        ///GENMHASH:46C9C87DA2C900034A20B7DB46BD77F5:1DA0B75A59F0F7EA35F5896C50FF1674
        public DnsRecordSetImpl DefineNSRecordSet(string name)
        {
            return recordSetsImpl.DefineNSRecordSet(name);
        }

        ///GENMHASH:5CC95DD8B9468242DBEEF10F96E9EECF:38DD916F9A94FC35BD4A0989BACBA7C2
        public DnsRecordSetImpl UpdateMXRecordSet(string name)
        {
            return recordSetsImpl.UpdateMXRecordSet(name);
        }

        ///GENMHASH:6A236BC9874C63721A7695A7FE9A4C18:62D250C4665A5EB885FF4EB68C6CDECE
        public DnsZoneImpl WithoutSrvRecordSet(string name)
        {
            recordSetsImpl.WithoutSrvRecordSet(name, null);
            return this;
        }

        ///GENMHASH:EC620CE3EF72DD020734D0F57C7057F2:50499B3F2D7F7D7AD2BE5E0349AD9C6B
        public DnsZoneImpl WithoutSrvRecordSet(string name, string eTag)
        {
            recordSetsImpl.WithoutSrvRecordSet(name, eTag);
            return this;
        }

        ///GENMHASH:87C6576F7C5A41E12DA61251590634AA:6B2F5F529555C811DA244F0261C7F42C
        public INSRecordSets NSRecordSets()
        {
            return this.nsRecordSets;
        }

        ///GENMHASH:76F011335BBB78AE07E7C19B287C17C2:24F9401B87CAEAFB4C0B9D7C009DE5FA
        public DnsRecordSetImpl DefineAaaaRecordSet(string name)
        {
            return recordSetsImpl.DefineAaaaRecordSet(name);
        }

        ///GENMHASH:6CCAD6D4D3A8F0925655956402A80C0F:BFD703DC159A6C7C5690B49646355CCD
        public DnsRecordSetImpl DefineTxtRecordSet(string name)
        {
            return recordSetsImpl.DefineTxtRecordSet(name);
        }

        ///GENMHASH:82DDFD7EF42553D6690E5976569BC3A5:6F7BEBF118C7CAC28AEBD6B33F9EE35C
        public IPtrRecordSets PtrRecordSets()
        {
            return this.ptrRecordSets;
        }

        ///GENMHASH:3EECA7B78CDBF9708E3E2E13E2122004:31CB15D3EB20E8486D2995C3637E584B
        public ICNameRecordSets CNameRecordSets()
        {
            return this.cnameRecordSets;
        }

        ///GENMHASH:F5E15CDECC035B82BF39162780BA9198:A252C32524D1D7E7B960E559973C4ED1
        public ISrvRecordSets SrvRecordSets()
        {
            return this.srvRecordSets;
        }

        ///GENMHASH:5121804C5EF1A7CB4B5C344EFB2BD758:D541888961AD74A86A658F00E4B05473
        public DnsZoneImpl WithoutARecordSet(string name)
        {
            return this.WithoutARecordSet(name, null);
        }

        ///GENMHASH:B52E7C54A2094CF7BC537D1CC67AD933:B8A798352224F54D9E1D30018F30BB68
        public DnsZoneImpl WithoutARecordSet(string name, string eTag)
        {
            recordSetsImpl.WithoutARecordSet(name, eTag);
            return this;
        }

        ///GENMHASH:4913BE5E272184975DDDF5335B476BBD:88ACBC17B6D51A9C055E4CC9834ED144
        public string ETag()
        {
            return this.Inner.Etag;
        }

        ///GENMHASH:AD6BE020D87A1FB1A7984887D3A945F6:9BB7605D73C9042DD071BBDE7C3B1BA3
        public IEnumerable<Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet> ListRecordSets()
        {
            return this.ListRecordSetsIntern(null, null);
        }

        ///GENMHASH:C7F16AA02D02CBF87CCC8862D08C1466:B09101AB23BBB35855F7C2A6A1D83C2A
        public IEnumerable<Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet> ListRecordSets(string recordSetNameSuffix)
        {
            return this.ListRecordSetsIntern(recordSetNameSuffix, null);
        }

        ///GENMHASH:3CBC468A730B7550412EEA9CB7234833:62AA8C34C5A8D473B0E450D3BDBA0F1E
        public IEnumerable<Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet> ListRecordSets(int pageSize)
        {
            return this.ListRecordSetsIntern(null, pageSize);
        }

        ///GENMHASH:D8DD6F1A4E44E62105E4B9AA26CD9AD3:9D05C7F6EF3046ACCC3A3FC33174E0F9
        public IEnumerable<Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet> ListRecordSets(string recordSetNameSuffix, int pageSize)
        {
            return this.ListRecordSetsIntern(recordSetNameSuffix, pageSize);
        }

        ///GENMHASH:4F52CFFC8EB4D698DB3A4C3B1E187BD0:066E16471A496BBA90633388ACB75206
        public DnsRecordSetImpl UpdateCNameRecordSet(string name)
        {
            return recordSetsImpl.UpdateCNameRecordSet(name);
        }

        ///GENMHASH:791593DE94E8D431FBB634CF0578A424:B9A84F7258ADA4688FCB65555E502356
        public DnsZoneImpl WithETagCheck()
        {
            if (IsInCreateMode) {
                this.dnsZoneETag = "*";
                return this;
            }
            return this.WithETagCheck(this.Inner.Etag);
        }

        ///GENMHASH:CAE9667D3C5220302471B1AF817CBA6A:4215D16B5B94BA109439FA15BFA72800
        public DnsZoneImpl WithETagCheck(string eTagValue)
        {
            this.dnsZoneETag = eTagValue;
            return this;
        }

        ///GENMHASH:9AE527899D61D17A703966B76C70745E:2504EABC711E0C4024D6109846A65F7C
        public DnsZoneImpl WithoutMXRecordSet(string name)
        {
            return this.WithoutMXRecordSet(name, null);
        }

        ///GENMHASH:CAE11DD729AC8148C1BB19AC98C19A66:6D14E692FE907A7C399F73CC723B491C
        public DnsZoneImpl WithoutMXRecordSet(string name, string eTag)
        {
            recordSetsImpl.WithoutMXRecordSet(name, eTag);
            return this;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:EF3CE1F98A96F8DA517AE632974073AA
        public async override Task<IDnsZone> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ZoneInner innerResource;
            if (IsInCreateMode)
            {
                innerResource = await Manager.Inner.Zones.CreateOrUpdateAsync(ResourceGroupName, 
                    Name, 
                    Inner,
                    ifMatch: null,
                    ifNoneMatch: this.dnsZoneETag,
                    cancellationToken: cancellationToken);
            }
            else
            {
                innerResource = await Manager.Inner.Zones.CreateOrUpdateAsync(ResourceGroupName,
                    Name,
                    Inner,
                    ifMatch: this.dnsZoneETag,
                    ifNoneMatch: null,
                    cancellationToken: cancellationToken);
            }
            SetInner(innerResource);
            this.dnsZoneETag = null;
            await recordSetsImpl.CommitAndGetAllAsync(cancellationToken);
            return this;
        }

        ///GENMHASH:DEFDD202FC66399CE6F4DC2385FFBE4E:E09C978D163DA3D891F10EDEA4E7EAE2
        public DnsRecordSetImpl UpdateARecordSet(string name)
        {
            return recordSetsImpl.UpdateARecordSet(name);
        }

        ///GENMHASH:52729C9C39AC4D628145F797BF5100E5:36E2465D33C18BB23AEA110DC31293E4
        public DnsRecordSetImpl UpdatePtrRecordSet(string name)
        {
            return recordSetsImpl.UpdatePtrRecordSet(name);
        }

        ///GENMHASH:7FD0DE0CD548F2703A15E4BAA97D6873:3D5969EEF23E4C353B1011DB95AC7B15
        public DnsRecordSetImpl DefineMXRecordSet(string name)
        {
            return recordSetsImpl.DefineMXRecordSet(name);
        }

        ///GENMHASH:132875C15861A92E60F93E154E091602:F70AB38B6FDE85737888182B48E6B611
        internal  DnsZoneImpl(string name, ZoneInner innerModel, IDnsZoneManager dnsZoneManager) : base(name, innerModel, dnsZoneManager)
        {
            recordSetsImpl = new DnsRecordSetsImpl(this);
            InitRecordSets();
        }

        ///GENMHASH:3F0A6CC3DBBB3330F47E8737215D7ECE:89EB3CA649B988C6CE1268D1D2437E71
        public ISoaRecordSet GetSoaRecordSet()
        {
            RecordSetInner inner = Extensions.Synchronize(() => Manager.Inner.RecordSets.GetAsync(ResourceGroupName, Name, "@", RecordType.SOA));
            return new SoaRecordSetImpl(this, inner);
        }

        ///GENMHASH:DAB4AD5D3ECB1C104BA24998D652F125:360292BEDD7386B9C66109E12C8F07EB
        private IEnumerable<Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet> ListRecordSetsIntern(string recordSetSuffix, int? pageSize)
        {
            return Extensions.Synchronize(() => Manager.Inner.RecordSets.ListByDnsZoneAsync(
                    ResourceGroupName,
                    Name,
                    top: pageSize,
                    recordsetnamesuffix: recordSetSuffix))
                .Select(inner =>
                {
                    var recordSet = new DnsRecordSetImpl(this, inner);
                    switch(recordSet.RecordType())
                    {
                        case RecordType.A:
                            return new ARecordSetImpl(this, inner);
                        case RecordType.AAAA:
                            return new AaaaRecordSetImpl(this, inner);
                        case RecordType.CNAME:
                            return new CNameRecordSetImpl(this, inner);
                        case RecordType.MX:
                            return new MXRecordSetImpl(this, inner);
                        case RecordType.NS:
                            return new NSRecordSetImpl(this, inner);
                        case RecordType.PTR:
                            return new PtrRecordSetImpl(this, inner);
                        case RecordType.SOA:
                            return new SoaRecordSetImpl(this, inner);
                        case RecordType.SRV:
                            return new SrvRecordSetImpl(this, inner);
                        case RecordType.TXT:
                            return new TxtRecordSetImpl(this, inner);
                        default:
                            return recordSet;
                    }
                });
        }

        ///GENMHASH:9AB7664BD0C8EE192BC61FD76EFCAF87:F3CAC648F4ECD829852ED6ADB4E1A338
        public DnsRecordSetImpl DefineSrvRecordSet(string name)
        {
            return recordSetsImpl.DefineSrvRecordSet(name);
        }

        ///GENMHASH:5954219C81F347FC86D24BBD07355380:8CFD324CF132033F543444B0B1ED6EC5
        public IAaaaRecordSets AaaaRecordSets()
        {
            return aaaaRecordSets;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:6E114CA661817C270373E8F5D86D84F5
        public override async Task<IDnsZone> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ZoneInner inner = await GetInnerAsync(cancellationToken);
            SetInner(inner);
            InitRecordSets();
            return this;
        }

        protected override async Task<ZoneInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.Zones.GetAsync(
                ResourceGroupName, Name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:E10C7FF5C36891D769128853352DD627:C2BD0B555A21A8D13988A3FB8138875D
        public DnsZoneImpl WithoutAaaaRecordSet(string name)
        {
            return this.WithoutAaaaRecordSet(name, null);
        }

        ///GENMHASH:762F03CE80F4A9BF3ADBEEC0D41DB5AF:0C4D21F444FFB1EF936C1B1D1AE3A942
        public DnsZoneImpl WithoutAaaaRecordSet(string name, string eTag)
        {
            recordSetsImpl.WithoutAaaaRecordSet(name, eTag);
            return this;
        }

        ///GENMHASH:94C8130FABA73F5B8D40A0A1D4A5487B:B6F715104E7D3FFD403D53AB2D808CEA
        public ITxtRecordSets TxtRecordSets()
        {
            return this.txtRecordSets;
        }

        ///GENMHASH:3CAFB4506578B44622E2A442A3CD8788:BAB752D3A1C75B0A4AACB01ABC60D250
        public DnsZoneImpl WithoutCNameRecordSet(string name)
        {
            return this.WithoutCNameRecordSet(name, null);
        }

        ///GENMHASH:69DD1218436902CDC3B7BC8695982064:96CEC3DC66305E02C742E45C265DC665
        public DnsZoneImpl WithoutCNameRecordSet(string name, string eTag)
        {
            recordSetsImpl.WithoutCNameRecordSet(name, eTag);
            return this;
        }

        ///GENMHASH:D5078976D64C68B60845416B4A519771:01D3AFD955DB0833B9A627FE561F323F
        public DnsRecordSetImpl DefineCNameRecordSet(string name)
        {
            return recordSetsImpl.DefineCNameRecordSet(name);
        }

        ///GENMHASH:6367F8A407349BBB833D3790CE7781BE:E5617108F877DD24CA72463B3D7BBB6D
        public long NumberOfRecordSets()
        {
            return Inner.NumberOfRecordSets.HasValue ? Inner.NumberOfRecordSets.Value : 0;
        }

        ///GENMHASH:9346CB4D0F5C719EB9C7E3A3AE77D732:CF958FACD1F19347590706D6D905C707
        public IMXRecordSets MXRecordSets()
        {
            return this.mxRecordSets;
        }

        ///GENMHASH:ECF2482EF49EC3D1CB1FA4A823939109:7E0994466D2DD0EFB8D1887B0196BE7A
        public DnsZoneImpl WithoutTxtRecordSet(string name)
        {
            return this.WithoutTxtRecordSet(name, null);
        }

        ///GENMHASH:2AAD8D85A395EE1384B1E0A6010A750B:1C3A4C0AE733A58BBF09EC9FCB441723
        public DnsZoneImpl WithoutTxtRecordSet(string name, string eTag)
        {
            recordSetsImpl.WithoutTxtRecordSet(name, eTag);
            return this;
        }

        ///GENMHASH:CC4422F1AB1A272DA6DBEBD9DD8767DF:070360140FDAF9C6E1A75749391C90AC
        public DnsRecordSetImpl UpdateNSRecordSet(string name)
        {
            return recordSetsImpl.UpdateNSRecordSet(name);
        }

        ///GENMHASH:A84F222A2C667953801DCF98F7DE030D:923487771CD86EE9B0CD6AB037014FE9
        public DnsZoneImpl WithoutNSRecordSet(string name)
        {
            return this.WithoutNSRecordSet(name, null);
        }

        ///GENMHASH:0A638BEAEF3AE7294B3373C1072B1E0A:2B26177638239DD0FDCDF40F74E0B5E8
        public DnsZoneImpl WithoutNSRecordSet(string name, string eTag)
        {
            recordSetsImpl.WithoutNSRecordSet(name, eTag);
            return this;
        }
    }
}
