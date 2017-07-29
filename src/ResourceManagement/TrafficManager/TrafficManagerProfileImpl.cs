// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    using TrafficManagerProfile.Update;
    using TrafficManagerProfile.Definition;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using ResourceManager.Fluent;
    using Models;

    /// <summary>
    /// Implementation for TrafficManagerProfile.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnRyYWZmaWNtYW5hZ2VyLmltcGxlbWVudGF0aW9uLlRyYWZmaWNNYW5hZ2VyUHJvZmlsZUltcGw=
    internal partial class TrafficManagerProfileImpl  :
        GroupableResource<ITrafficManagerProfile,
            ProfileInner,
            TrafficManagerProfileImpl,
            ITrafficManager,
            TrafficManagerProfile.Definition.IWithLeafDomainLabel,
            TrafficManagerProfile.Definition.IWithLeafDomainLabel,
            TrafficManagerProfile.Definition.IWithCreate,
            TrafficManagerProfile.Update.IUpdate>,
        ITrafficManagerProfile,
        IDefinition,
        IUpdate
    {
        private const string profileStatusDisabled = "Disabled";
        private const string profileStatusEnabled = "Enabled";
        private TrafficManagerEndpointsImpl endpoints;

        ///GENMHASH:C5CC2EE74F2176AA6473857322F7C248:4D37314EF7F75B745F5D65EF257C1402
        internal TrafficManagerProfileImpl(string name, ProfileInner innerModel, ITrafficManager trafficManager)
            : base(name, innerModel, trafficManager)
        {
            endpoints = new TrafficManagerEndpointsImpl(this);
        }

        ///GENMHASH:C7D63CAAB4D5C78DCBABA455FA741326:50737CF16CD493FD8BB7A09EF461690C
        public string MonitoringPath()
        {
            return Inner.MonitorConfig.Path;
        }

        ///GENMHASH:6C28BB464B795DC8681442F876749A3D:57455B1D83CC1849A88FF401A87B3652
        public IReadOnlyDictionary<string,ITrafficManagerExternalEndpoint> ExternalEndpoints()
        {
            return this.endpoints.ExternalEndpointsAsMap();
        }

        ///GENMHASH:0C153B8A8223F6B3602B8C639E43B1A2:4B04E200B529E471D39F93CEBC5617FA
        public IReadOnlyDictionary<string,ITrafficManagerNestedProfileEndpoint> NestedProfileEndpoints()
        {
            return this.endpoints.NestedProfileEndpointsAsMap();
        }

        ///GENMHASH:C6A6B547BAC20098D634B85B4700816E:68BB0F621666DC65A06B08FC37AF8535
        public TrafficManagerProfileImpl WithWeightBasedRouting()
        {
            this.WithTrafficRoutingMethod(Microsoft.Azure.Management.TrafficManager.Fluent.TrafficRoutingMethod.Weighted);
            return this;
        }

        ///GENMHASH:BA29DA1F2009E6120D5974787A4DCC48:A743B4E1DEB81D6E9C28A26880134BF6
        public TrafficManagerProfileImpl WithGeographicBasedRouting()
        {
            return this.WithTrafficRoutingMethod((Microsoft.Azure.Management.TrafficManager.Fluent.TrafficRoutingMethod.Geographic));
        }

        ///GENMHASH:B4A36FDF16CFB0AB15EF06C3C41DEAE6:3907B35E8FE4F9DF1790E670E5612AA5
        public TrafficManagerEndpointImpl DefineExternalTargetEndpoint(string name)
        {
            return this.endpoints.DefineExteralTargetEndpoint(name);
        }

        ///GENMHASH:4FD71958F542A872CEE597B1CEA332F8:CD2E0F8F28E49A3BD6482AFD85AFF2C1
        public TrafficManagerProfileImpl WithLeafDomainLabel(string dnsLabel)
        {
            Inner.DnsConfig.RelativeName = dnsLabel;
            return this;
        }

        ///GENMHASH:2C0DB6B1F104247169DC6BCC9246747C:D88E948223FB86124BBB6F6774621201
        public int TimeToLive()
        {
            return (int) Inner.DnsConfig.Ttl.Value;
        }

        ///GENMHASH:5E218AF13EC4B07DD7170E0991E64373:B45FF059EA30EB01427BCCB27086FEBF
        public TrafficManagerEndpointImpl DefineNestedTargetEndpoint(string name)
        {
            return this.endpoints.DefineNestedProfileTargetEndpoint(name);
        }

        ///GENMHASH:9AEC42BC2F36531F5A364F6C9BC7299B:06AEBFC10FD1E07B85CFFC68257D1C3A
        public TrafficManagerProfileImpl WithProfileStatusEnabled()
        {
            Inner.ProfileStatus = TrafficManagerProfileImpl.profileStatusEnabled;
            return this;
        }

        ///GENMHASH:507A92D4DCD93CE9595A78198DEBDFCF:322DFB55FFECEA782B6CC4759AD25BD4
        private async Task<ITrafficManagerProfile> UpdateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // In update we first commit the endpoints then update profile, the reason is through portal and direct API
            // call one can create endpoints without properties those are not applicable for the profile's current routing
            // method. We cannot update the routing method of the profile until existing endpoints contains the properties
            // required for the new routing method.
            await endpoints.CommitAndGetAllAsync(cancellationToken);
            ProfileInner profileInner = await Manager.Inner.Profiles.CreateOrUpdateAsync(ResourceGroupName, Name, Inner, cancellationToken);
            SetInner(profileInner);
            return this;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:44175AF0C87DAFA56DB9009ABE7645E4
        public async override Task<ITrafficManagerProfile> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (IsInCreateMode)
            {
                ProfileInner profileInner = await Manager.Inner.Profiles.CreateOrUpdateAsync(ResourceGroupName, Name, Inner, cancellationToken);
                SetInner(profileInner);
                await endpoints.CommitAndGetAllAsync(cancellationToken);
                return this;
            }
            else
            {
                return await UpdateResourceAsync(cancellationToken);
            }
        }

        ///GENMHASH:655A859AB9D888489CDFDD334146F9D1:176F10BD0111531F78393D5651ABF7C5
        public TrafficManagerProfileImpl WithProfileStatusDisabled()
        {
            Inner.ProfileStatus = profileStatusDisabled;
            return this;
        }

        ///GENMHASH:655A58D21C12B40631EB483D86D298A3:D63D64FAE4C0512A29775948289CD9AF
        public TrafficManagerEndpointImpl UpdateAzureTargetEndpoint(string name)
        {
            return this.endpoints.UpdateAzureEndpoint(name);
        }

        ///GENMHASH:46B51A2A6E317FB877781A1B0B0CE163:1999508BD6CE91CA6BAF0C5AEC85B294
        public TrafficManagerProfileImpl WithoutEndpoint(string name)
        {
            this.endpoints.Remove(name);
            return this;
        }

        ///GENMHASH:3E133DCD07354DCF10F28C2FA07E1C8C:59E6C148DC851CD612F81A3DF8325AAF
        public IReadOnlyDictionary<string,ITrafficManagerAzureEndpoint> AzureEndpoints()
        {
            return this.endpoints.AzureEndpointsAsMap();
        }

        ///GENMHASH:577F8437932AEC6E08E1A137969BDB4A:93FB31E2F199B29EB12AF1D037A21B91
        public string Fqdn()
        {
            return Inner.DnsConfig.Fqdn;
        }

        ///GENMHASH:CBED4DBEF4FE611072BC440D90324271:80930CC778C5ED77B07A0B587D7C5950
        public int MonitoringPort()
        {
            return (int) Inner.MonitorConfig.Port.Value;
        }

        ///GENMHASH:C69FFBA25D969C2C45775433EBFD49EA:01BC02A541C8C945111AEC0AF9DB6FF1
        public TrafficManagerProfileImpl WithPriorityBasedRouting()
        {
            this.WithTrafficRoutingMethod(Fluent.TrafficRoutingMethod.Priority);
            return this;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:280DEDDFDA82FD8E8EA83F4139D8C99A
        public override async Task<ITrafficManagerProfile> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ProfileInner inner = await GetInnerAsync(cancellationToken);
            SetInner(inner);
            endpoints.Refresh();
            return this;
        }

        protected override async Task<ProfileInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.Profiles.GetAsync(
                ResourceGroupName, Name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:4AF52DA6D7309E03BCF9F21C532F19E0:DEF2407DA0E866749EF9CC5952427470
        public TrafficManagerProfileImpl WithPerformanceBasedRouting()
        {
            WithTrafficRoutingMethod(Fluent.TrafficRoutingMethod.Performance);
            return this;
        }

        ///GENMHASH:1306B0380955C0A661257F568E407491:91614D0A65D7DE56C3E04201D6614324
        public TrafficManagerEndpointImpl UpdateExternalTargetEndpoint(string name)
        {
            return this.endpoints.UpdateExternalEndpoint(name);
        }

        ///GENMHASH:CF5737257DFBF1F0FB9DD7771AF4A4DD:6522777576C2DD8F098342824404B3E5
        internal TrafficManagerProfileImpl WithEndpoint(TrafficManagerEndpointImpl endpoint)
        {
            this.endpoints.AddEndpoint(endpoint);
            return this;
        }

        ///GENMHASH:AA50DC9DCA33186877C0E55612409D74:DB63F33DBE42C3412FD84412DA6DF98C
        public TrafficManagerProfileImpl WithHttpMonitoring()
        {
            return this.WithHttpMonitoring(80, "/");
        }

        ///GENMHASH:088F115956764D909356F941714DD214:72C3991B01AC2306292D697D6CB9A5EE
        public TrafficManagerProfileImpl WithHttpMonitoring(int port, string path)
        {
            Inner.MonitorConfig.Port = port;
            Inner.MonitorConfig.Path = path;
            Inner.MonitorConfig.Protocol = "http";
            return this;
        }

        ///GENMHASH:C7D52FF3F5A2A28882BA7713BB288475:193FB4C1B236385E2ED537BCBD77E6D0
        public TrafficManagerProfileImpl WithHttpsMonitoring()
        {
            return this.WithHttpsMonitoring(443, "/");
        }

        ///GENMHASH:339D7124F9EE53875E3B1321B2E2D9FD:A28860E9058E7040BCE32AA17CDB136B
        public TrafficManagerProfileImpl WithHttpsMonitoring(int port, string path)
        {
            Inner.MonitorConfig.Port = port;
            Inner.MonitorConfig.Path = path;
            Inner.MonitorConfig.Protocol = "https";
            return this;
        }

        ///GENMHASH:E75269B73212138A7E1E8F94A2FD913C:AD931D14F514F37D5342A16ACD3342B3
        public TrafficManagerProfileImpl WithTimeToLive(int ttlInSeconds)
        {
            Inner.DnsConfig.Ttl = ttlInSeconds;
            return this;
        }

        ///GENMHASH:4E79F831CA615F31A3B9091C9216E524:1135A0CCE498B0EFFC0343DDE3CEB9BF
        public string DnsLabel()
        {
            return Inner.DnsConfig.RelativeName;
        }

        ///GENMHASH:3F2076D33F84FDFAB700A1F0C8C41647:8E2768B25039756DEB5365F724C21484
        public bool IsEnabled()
        {
            return Inner.ProfileStatus.Equals(TrafficManagerProfileImpl.profileStatusEnabled, System.StringComparison.OrdinalIgnoreCase);
        }

        ///GENMHASH:BB0D1050B0185C55C13B3722F9DC8EFD:954997B5F0A4C3371FBFA90DB6C24AC3
        public TrafficManagerProfileImpl WithTrafficRoutingMethod(TrafficRoutingMethod routingMethod)
        {
            Inner.TrafficRoutingMethod = routingMethod.ToString();
            return this;
        }

        ///GENMHASH:C4319084EC81C9B9397CE86527D1A3CE:17F4836836395BFB8393F702736B5F31
        public TrafficRoutingMethod TrafficRoutingMethod()
        {
            return Fluent.TrafficRoutingMethod.Parse(Inner.TrafficRoutingMethod);
        }

        ///GENMHASH:2BE295DCD7E2E4E353B535754D34B1FF:0B13B9735DB0972678CCB2C7544FA3F9
        public ProfileMonitorStatus MonitorStatus()
        {
            if (Inner.MonitorConfig != null)
            {
                return ProfileMonitorStatus.Parse(Inner.MonitorConfig.ProfileMonitorStatus);
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:A912B64DAA5D27988A4E605BC2374EEA:EDA05BB34633EA106E7F50083F9059DD
        public TrafficManagerEndpointImpl DefineAzureTargetEndpoint(string name)
        {
            return this.endpoints.DefineAzureTargetEndpoint(name);
        }

        ///GENMHASH:3D482C7836B7C641301B728A17656970:426E2267E364721B07885A7317332651
        public TrafficManagerEndpointImpl UpdateNestedProfileTargetEndpoint(string name)
        {
            return this.endpoints.UpdateNestedProfileEndpoint(name);
        }
    }
}
