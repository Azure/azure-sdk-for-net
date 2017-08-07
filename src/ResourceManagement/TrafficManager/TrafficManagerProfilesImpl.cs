// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    using ResourceManager.Fluent.Core;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Collections.Generic;
    using Models;
    using Rest.Azure;

    /// <summary>
    /// Implementation for TrafficManagerProfiles.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnRyYWZmaWNtYW5hZ2VyLmltcGxlbWVudGF0aW9uLlRyYWZmaWNNYW5hZ2VyUHJvZmlsZXNJbXBs
    internal partial class TrafficManagerProfilesImpl  :
        TopLevelModifiableResources<ITrafficManagerProfile, TrafficManagerProfileImpl, ProfileInner, IProfilesOperations, ITrafficManager>,
        ITrafficManagerProfiles
    {
        private IGeographicHierarchiesBeta geographicHierarchies;

        ///GENMHASH:84B6E84F790DD3CF43388254CEEE3609:519A2844AD55FAC6990427C640AC9D4B
        internal TrafficManagerProfilesImpl(TrafficManager trafficManager) : base(trafficManager.Inner.Profiles, trafficManager)
        {
            this.geographicHierarchies = new GeographicHierarchiesImpl(trafficManager, trafficManager.Inner.GeographicHierarchies);
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:EA7883DCA673C6F67CCCF6E8828D7D51:4DBFF5109C555E749B7E1943ECE31E34
        public CheckProfileDnsNameAvailabilityResult CheckDnsNameAvailability(string dnsNameLabel)
        {
            return Extensions.Synchronize(() => CheckDnsNameAvailabilityAsync(dnsNameLabel));
        }

        public async Task<CheckProfileDnsNameAvailabilityResult> CheckDnsNameAvailabilityAsync(
            string dnsNameLabel, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return new CheckProfileDnsNameAvailabilityResult(
                await Inner.CheckTrafficManagerRelativeDnsNameAvailabilityAsync(
                    dnsNameLabel, 
                    "Microsoft.Network/trafficManagerProfiles"));
        }

        ///GENMHASH:875C07AF573FB7A6B4C57642740BC90A:B51EF456AE67D2EF8EF100C6611084A4
        public IGeographicLocation GetGeographicHierarchyRoot()
        {
            return this.geographicHierarchies.GetRoot();
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:6A5AFD43FB6D60947DE42BF4153B3E35
        public TrafficManagerProfileImpl Define(string name)
        {
            return SetDefaults(WrapModel(name));
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        protected async override Task<ProfileInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:36E25639805611CF89054C004B22BB15
        protected async override Task<IPage<ProfileInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return ConvertToPage(await Inner.ListBySubscriptionAsync(cancellationToken));
        }

        protected async override Task<IPage<ProfileInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Task.FromResult<IPage<ProfileInner>>(null);
        }

        ///GENMHASH:ADB150394F552772047E309EF2616501:6EFED76EB6275BD09D4B902BEDDF03D4
        private TrafficManagerProfileImpl SetDefaults(TrafficManagerProfileImpl profile)
        {
            // MonitorConfig is required
            profile.Inner.MonitorConfig = new MonitorConfig();
            profile.WithHttpMonitoring(); // Default to Http monitoring
            //$ // DnsConfig is required
            profile.Inner.DnsConfig = new DnsConfig();
            profile.WithTimeToLive(300);
            // TM location must be 'global' irrespective of region of the resource group it resides.
            profile.Inner.Location = "global";
            // Endpoints are external child resource still initializing it avoid null checks in the model impl.
            profile.Inner.Endpoints = new List<EndpointInner>();
            return profile;
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:2A90E64B785A8609460D87572CE513A1
        protected async override Task<IPage<ProfileInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return ConvertToPage(await Inner.ListByResourceGroupAsync(groupName, cancellationToken));
        }

        protected async override Task<IPage<ProfileInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Task.FromResult<IPage<ProfileInner>>(null);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:12B839BC780AC48D63D16C362B5E2FF5
        protected override TrafficManagerProfileImpl WrapModel(string name)
        {
             return new TrafficManagerProfileImpl(name, new ProfileInner(), Manager);
        }

        ///GENMHASH:96AD55F2D1A183F1EF3F3859FC90630B:3C2F1C0167F4F4C255F6C1FD907E64F4
        protected override ITrafficManagerProfile WrapModel(ProfileInner inner)
        {
            return new TrafficManagerProfileImpl(inner.Name, inner, Manager);
        }
    }
}
