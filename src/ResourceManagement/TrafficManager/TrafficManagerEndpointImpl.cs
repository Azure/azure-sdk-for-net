// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    using ResourceManager.Fluent.Core;
    using TrafficManagerEndpoint.UpdateDefinition;
    using TrafficManagerEndpoint.Definition;
    using System.Threading.Tasks;
    using TrafficManagerEndpoint.UpdateNestedProfileEndpoint;
    using TrafficManagerEndpoint.UpdateExternalEndpoint;
    using System.Threading;
    using TrafficManagerEndpoint.UpdateAzureEndpoint;
    using ResourceManager.Fluent.Core.ChildResourceActions;
    using Models;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    /// <summary>
    /// Implementation for TrafficManagerEndpoint.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnRyYWZmaWNtYW5hZ2VyLmltcGxlbWVudGF0aW9uLlRyYWZmaWNNYW5hZ2VyRW5kcG9pbnRJbXBs
    internal partial class TrafficManagerEndpointImpl  :
        ExternalChildResource<ITrafficManagerEndpoint, EndpointInner, ITrafficManagerProfile, TrafficManagerProfileImpl>,
        ITrafficManagerEndpoint,
        IDefinition<TrafficManagerProfile.Definition.IWithCreate>,
        IUpdateDefinition<TrafficManagerProfile.Update.IUpdate>,
        IUpdateAzureEndpoint,
        IUpdateExternalEndpoint,
        IUpdateNestedProfileEndpoint
    {
        private const string endpointStatusDisabled = "Disabled";
        private const string endpointStatusEnabled = "Enabled";

        ///GENMHASH:2521373455D66779FDC191E5AF5A324E:A74628459133C1690F2A62C7C482A9A9
        internal TrafficManagerEndpointImpl(string name, TrafficManagerProfileImpl parent, EndpointInner inner) : base(name, parent, inner)
        {
        }

        ///GENMHASH:974E7FCA59BCBB12A26AB795E4C4A982:8418C83028CC7E2D2717B3EC2E3DBF97
        public TrafficManagerEndpointImpl ToResourceId(string resourceId)
        {
            Inner.TargetResourceId = resourceId;
            return this;
        }

        ///GENMHASH:7E4D6CD4225C7C45A2617BA279790518:CDE1537547721862503F9A0FA1A322D4
        public int RoutingPriority()
        {
            return (int) Inner.Priority.Value;
        }

        ///GENMHASH:01C4B6E26D53E1762A443721CECB5D96:43F1F30B8E8EB5054939168766D4F5BE
        public EndpointType EndpointType()
        {
            return Fluent.EndpointType.Parse(Inner.Type);
        }

        ///GENMHASH:85BAA8BAAF184D879CCE5080E089F024:D3868AC81F258C85BCA29FE3546FDBB0
        public TrafficManagerEndpointImpl ToProfile(ITrafficManagerProfile nestedProfile)
        {
            Inner.TargetResourceId = nestedProfile.Id;
            Inner.MinChildEndpoints = 1;
            return this;
        }

        ///GENMHASH:3A31ACD3BD909199AC20F8F3E3739FBC:74F3955C06F9B8A4E58621607D351E22
        public int RoutingWeight()
        {
            return (int) Inner.Weight.Value;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:C47C4325FAE65E493A947196909A8664
        protected override async Task<EndpointInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Parent.Manager.Inner.Endpoints.GetAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                EndpointType().ToString(),
                Name(), cancellationToken: cancellationToken);
        }

        ///GENMHASH:0FEDA307DAD2022B36843E8905D26EAD:E3744107BCA5CCCE4C7486E0C86460B6
        public async override Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Parent.Manager.Inner.Endpoints.DeleteAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                EndpointType().LocalName,
                Name(),
                cancellationToken);
        }

        ///GENMHASH:91BB0A08404D6D37671F71EB696F7DDA:C7EED8E9DF95CD503E77886E10606183
        public TrafficManagerEndpointImpl FromRegion(Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region location)
        {
            Inner.EndpointLocation = location.Name;
            return this;
        }

        ///GENMHASH:32A8B56FE180FA4429482D706189DEA2:456A0329D077009BC6D9D0C6B91ADA12
        public async override Task<ITrafficManagerEndpoint> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            EndpointInner endpointInner =  await Parent.Manager.Inner.Endpoints.CreateOrUpdateAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                EndpointType().LocalName,
                Name(),
                Inner,
                cancellationToken);
            SetInner(endpointInner);
            return this;
        }

        ///GENMHASH:3F2076D33F84FDFAB700A1F0C8C41647:DABEB48E6D840C88546C3B33907CE0B9
        public bool IsEnabled()
        {
            return Inner.EndpointStatus.Equals(endpointStatusEnabled, System.StringComparison.OrdinalIgnoreCase);
        }

        ///GENMHASH:E596842042AC44324049E25924338641:279322A898E3742765E012128C6BA094
        public TrafficManagerEndpointImpl WithTrafficDisabled()
        {
            Inner.EndpointStatus = TrafficManagerEndpointImpl.endpointStatusDisabled;
            return this;
        }

        ///GENMHASH:F08598A17ADD014E223DFD77272641FF:B679398E05D03276D85F279699903D19
        public async override Task<ITrafficManagerEndpoint> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await CreateAsync(cancellationToken);
        }

        ///GENMHASH:0F772C1CE5DA7681E1BE68BEBBDC7ED7:4CA1E78BF8CEC54E9503538BE5ED1B9E
        public TrafficManagerEndpointImpl WithRoutingPriority(int priority)
        {
            Inner.Priority = priority;
            return this;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id
        {
            get
            {
                return Inner.Id;
            }
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:34C3D97AC56EA49A0A7DE74A085B41B2
        public TrafficManagerProfileImpl Attach()
        {
            return this.Parent.WithEndpoint(this);
        }

        ///GENMHASH:F3CEF905F52D0898C9748690DA270B37:E6BE9AF60DE7E23E08DA51CD41A40433
        public TrafficManagerEndpointImpl WithTrafficEnabled()
        {
            Inner.EndpointStatus = endpointStatusEnabled;
            return this;
        }

        ///GENMHASH:2BE295DCD7E2E4E353B535754D34B1FF:103A6872B920F82A78D36FE5074C69CB
        public EndpointMonitorStatus MonitorStatus()
        {
            return EndpointMonitorStatus.Parse(Inner.EndpointMonitorStatus);
        }

        ///GENMHASH:F1873F4E2C7FA7133A7B71292C66E670:DA5C65C0BDAEE12A7FCA134EE523B9C0
        public TrafficManagerEndpointImpl WithRoutingWeight(int weight)
        {
            Inner.Weight = weight;
            return this;
        }

        ///GENMHASH:4A45A5907E7D657D8DD40DC76FD41F58:93984FB229DD83A7718C89B007D276C9
        public TrafficManagerEndpointImpl WithGeographicLocation(IGeographicLocation geographicLocation)
        {
            return this.WithGeographicLocation(geographicLocation.Code);
        }

        ///GENMHASH:A547F59734E4765D7E8C66BD9DEABC48:4394EC74F5644573990215653DA5A2D5
        public TrafficManagerEndpointImpl WithGeographicLocations(IList<Microsoft.Azure.Management.TrafficManager.Fluent.IGeographicLocation> geographicLocations)
        {
            foreach(var location in geographicLocations) {
                this.WithGeographicLocation(location);
            }
            return this;
        }

        ///GENMHASH:2B09C0B6E5A6C9EB0FD5F8E5B6F64071:10487097C091DC4BD14341EFE97436FA
        public TrafficManagerEndpointImpl WithGeographicLocations(IList<string> geographicLocationCodes)
        {
            foreach(var locationCode in geographicLocationCodes) {
                this.WithGeographicLocation(locationCode);
            }
            return this;
        }


        ///GENMHASH:D941F2842B927A4DB3CBC5C46BF0FB8C:3758D276108819137AC1BAC3E4F73D66
        public TrafficManagerEndpointImpl WithGeographicLocation(string geographicLocationCode)
        {
            if (this.Inner.GeoMapping == null) {
                this.Inner.GeoMapping = new List<string>();
            }
            if (!this.Inner.GeoMapping.Any(code => code.Equals(geographicLocationCode, System.StringComparison.OrdinalIgnoreCase)))
            {
                this.Inner.GeoMapping.Add(geographicLocationCode);
            }
            return this;
        }

        ///GENMHASH:6B5F84A9B6F2D8700DA3A5F71E5000F8:FB9D4C73535F411169B12EACB830D877
        public TrafficManagerEndpointImpl WithoutGeographicLocation(IGeographicLocation geographicLocation)
        {
            return this.WithoutGeographicLocation(geographicLocation.Code);
        }

        ///GENMHASH:B75C241BF5B6DE548F6D8E4910E12E09:EC93F846A74453DA3A4CBDF41628EF0F
        public TrafficManagerEndpointImpl WithoutGeographicLocation(string geographicLocationCode)
        {
            if (this.Inner.GeoMapping == null) {
                return this;
            }
            this.Inner.GeoMapping = this.Inner.GeoMapping
                .Where(code => !code.Equals(geographicLocationCode, System.StringComparison.OrdinalIgnoreCase))
                .Select(code => code)
                .ToList();
            return this;
        }

        ///GENMHASH:A4259C4B7C7D66426DF3049BC1F1EA7F:7ED9C9DE573E721F3D9C8B9D654C0F0E
        public TrafficManagerEndpointImpl ToFqdn(string externalFqdn)
        {
            Inner.Target = externalFqdn;
            return this;
        }

        ///GENMHASH:E4E05A91613DD6996BA2D79AA74792A7:E7BC928E840DEFB2EF72E4980D9651F7
        public TrafficManagerEndpointImpl WithMinimumEndpointsToEnableTraffic(int count)
        {
            Inner.MinChildEndpoints = count;
            return this;
        }

        ///GENMHASH:F507C7F84BADE3B2935D09B0602D7DE3:645998E0C566D23B620982BEA38A808C
        public IReadOnlyList<string> GeographicLocationCodes()
        {
            if (this.Inner.GeoMapping == null || this.Inner.GeoMapping.Count == 0) {
                return new List<string>();
            }
            return new ReadOnlyCollection<string>(this.Inner.GeoMapping);
        }

        TrafficManagerProfile.Update.IUpdate ISettable<TrafficManagerProfile.Update.IUpdate>.Parent()
        {
            return this.Parent;
        }
    }
}
