// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    using TrafficManagerEndpoint.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using TrafficManagerProfile.Update;
    using TrafficManagerEndpoint.UpdateDefinition;
    using TrafficManagerEndpoint.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using System.Threading.Tasks;
    using TrafficManagerEndpoint.UpdateNestedProfileEndpoint;
    using TrafficManagerEndpoint.UpdateExternalEndpoint;
    using System.Threading;
    using TrafficManagerProfile.Definition;
    using TrafficManagerEndpoint.UpdateAzureEndpoint;
    using Resource.Fluent.Core.ChildResourceActions;
    using System;
    using Management.TrafficManager.Fluent.Models;
    using Management.TrafficManager.Fluent;

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
        private IEndpointsOperations client;
        private const string endpointStatusDisabled = "Disabled";
        private const string endpointStatusEnabled = "Enabled";

        ///GENMHASH:974E7FCA59BCBB12A26AB795E4C4A982:8418C83028CC7E2D2717B3EC2E3DBF97
        public TrafficManagerEndpointImpl ToResourceId(string resourceId)
        {
            this.Inner.TargetResourceId = resourceId;
            return this;
        }

        ///GENMHASH:7E4D6CD4225C7C45A2617BA279790518:E401EF0E4FF685DAE73EF65EC2D974A0
        public int RoutingPriority()
        {
            return (int) this.Inner.Priority.Value;
        }

        ///GENMHASH:01C4B6E26D53E1762A443721CECB5D96:43F1F30B8E8EB5054939168766D4F5BE
        public EndpointType EndpointType()
        {
            return new Microsoft.Azure.Management.Trafficmanager.Fluent.EndpointType(this.Inner.Type);
        }

        ///GENMHASH:85BAA8BAAF184D879CCE5080E089F024:D3868AC81F258C85BCA29FE3546FDBB0
        public TrafficManagerEndpointImpl ToProfile(ITrafficManagerProfile nestedProfile)
        {
            this.Inner.TargetResourceId = nestedProfile.Id;
            this.Inner.MinChildEndpoints = 1;
            return this;
        }

        ///GENMHASH:2521373455D66779FDC191E5AF5A324E:A74628459133C1690F2A62C7C482A9A9
        internal  TrafficManagerEndpointImpl(string name, TrafficManagerProfileImpl parent, EndpointInner inner, IEndpointsOperations client) : base(name, parent, inner)
        {
            this.client = client;
        }

        ///GENMHASH:3A31ACD3BD909199AC20F8F3E3739FBC:08D39119EFC0D43565C615E7190EDA65
        public int RoutingWeight()
        {
            return (int) this.Inner.Weight.Value;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:C47C4325FAE65E493A947196909A8664
        public ITrafficManagerEndpoint Refresh()
        {
            EndpointInner inner = this.client.Get(this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.EndpointType().ToString(),
                this.Name());
            this.SetInner(inner);
            return this;
        }

        ///GENMHASH:0FEDA307DAD2022B36843E8905D26EAD:E3744107BCA5CCCE4C7486E0C86460B6
        public async override Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.client.DeleteAsync(this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.EndpointType().LocalName,
                this.Name());
        }

        ///GENMHASH:91BB0A08404D6D37671F71EB696F7DDA:C7EED8E9DF95CD503E77886E10606183
        public TrafficManagerEndpointImpl FromRegion(Region location)
        {
            this.Inner.EndpointLocation = location.Name;
            return this;
        }

        ///GENMHASH:32A8B56FE180FA4429482D706189DEA2:456A0329D077009BC6D9D0C6B91ADA12
        public async override Task<ITrafficManagerEndpoint> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            EndpointInner endpointInner =  await this.client.CreateOrUpdateAsync(this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.EndpointType().LocalName,
                this.Name(),
                this.Inner);
            this.SetInner(endpointInner);
            return this;
        }

        ///GENMHASH:3F2076D33F84FDFAB700A1F0C8C41647:DABEB48E6D840C88546C3B33907CE0B9
        public bool IsEnabled()
        {
            return this.Inner.EndpointStatus.Equals(TrafficManagerEndpointImpl.endpointStatusEnabled, System.StringComparison.OrdinalIgnoreCase);
        }

        ///GENMHASH:E596842042AC44324049E25924338641:279322A898E3742765E012128C6BA094
        public TrafficManagerEndpointImpl WithTrafficDisabled()
        {
            this.Inner.EndpointStatus = TrafficManagerEndpointImpl.endpointStatusDisabled;
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
            this.Inner.Priority = priority;
            return this;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id
        {
            get
            {
                return this.Inner.Id;
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
            this.Inner.EndpointStatus = TrafficManagerEndpointImpl.endpointStatusEnabled;
            return this;
        }

        ///GENMHASH:2BE295DCD7E2E4E353B535754D34B1FF:103A6872B920F82A78D36FE5074C69CB
        public EndpointMonitorStatus MonitorStatus()
        {
            return new EndpointMonitorStatus(this.Inner.EndpointMonitorStatus);
        }

        ///GENMHASH:F1873F4E2C7FA7133A7B71292C66E670:DA5C65C0BDAEE12A7FCA134EE523B9C0
        public TrafficManagerEndpointImpl WithRoutingWeight(int weight)
        {
            this.Inner.Weight = weight;
            return this;
        }

        ///GENMHASH:A4259C4B7C7D66426DF3049BC1F1EA7F:7ED9C9DE573E721F3D9C8B9D654C0F0E
        public TrafficManagerEndpointImpl ToFqdn(string externalFqdn)
        {
            this.Inner.Target = externalFqdn;
            return this;
        }

        ///GENMHASH:E4E05A91613DD6996BA2D79AA74792A7:E7BC928E840DEFB2EF72E4980D9651F7
        public TrafficManagerEndpointImpl WithMinimumEndpointsToEnableTraffic(int count)
        {
            this.Inner.MinChildEndpoints = count;
            return this;
        }

        TrafficManagerProfile.Update.IUpdate ISettable<TrafficManagerProfile.Update.IUpdate>.Parent()
        {
            return this.Parent;
        }
    }
}