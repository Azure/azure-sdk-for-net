// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using Rest.Azure;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for CdnProfiles.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNkbi5pbXBsZW1lbnRhdGlvbi5DZG5Qcm9maWxlc0ltcGw=
    internal partial class CdnProfilesImpl  :
        TopLevelModifiableResources<ICdnProfile,CdnProfileImpl,ProfileInner,IProfilesOperations,ICdnManager>,
        ICdnProfiles
    {
        ///GENMHASH:8B3976582303B73AC81C5220073E2D55:A4104491D327BA3667E857CA7A2EC15D
        public CheckNameAvailabilityResult CheckEndpointNameAvailability(string name)
        {
            return Extensions.Synchronize(() => CheckEndpointNameAvailabilityAsync(name));
        }

        ///GENMHASH:2CEB6E35574F5C7F1D19ADAC97C93D65:1B5FDD33003D9073F97F1C9831CA2660
        public IEnumerable<Operation> ListOperations()
        {
            return Extensions.Synchronize(() => Manager.Inner.ListOperationsAsync())
                                .AsContinuousCollection(link => Extensions.Synchronize(() => Manager.Inner.ListOperationsNextAsync(link)))
                                .Select(inner=> new Operation(inner));
        }

        ///GENMHASH:89CD44AA5060CAB16CB0AF1FB046BC64:416FABEC3862B2A47FF2F9DD56AFEFF6
        public IEnumerable<ResourceUsage> ListResourceUsage()
        {
            return Extensions.Synchronize(() => Manager.Inner.ListResourceUsageAsync())
                                .AsContinuousCollection(link => Extensions.Synchronize(() => Manager.Inner.ListResourceUsageNextAsync(link)))
                                .Select(inner => new ResourceUsage(inner));

        }

        ///GENMHASH:6F0D776A3FBBF84EE0312C9E28F2D855:EC99713AFF94DCD8E902241A49011E4B
        public IEnumerable<EdgeNode> ListEdgeNodes()
        {
            return Extensions.Synchronize(() => Manager.Inner.EdgeNodes.ListAsync())
                                .AsContinuousCollection(link => Extensions.Synchronize(() => Manager.Inner.EdgeNodes.ListNextAsync(link)))
                                .Select(inner => new EdgeNode(inner));
        }

        ///GENMHASH:8C72A32C69D3B2099B1D93E3B9873A71:11F71B6989FF140BBFACEF8AABC579A8
        public async Task LoadEndpointContentAsync(
            string resourceGroupName, 
            string profileName, 
            string endpointName, 
            IList<string> contentPaths,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.Endpoints.LoadContentAsync(resourceGroupName, profileName, endpointName, contentPaths, cancellationToken);
        }

        internal void LoadEndpointContent(
            string resourceGroupName,
            string profileName,
            string endpointName,
            IList<string> contentPaths)
        {
            LoadEndpointContentAsync(resourceGroupName, profileName, endpointName, contentPaths).Wait();
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:6FB4EA69673E1D8A74E1418EB52BB9FE
        protected async override Task<IPage<ProfileInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(cancellationToken);
        }

        protected async override Task<IPage<ProfileInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:B76E119E66FC2C5D09617333DC4FF4E3:50CAB688056CFBD731F264F50EA813EF
        public async Task StartEndpointAsync(
            string resourceGroupName, 
            string profileName, 
            string endpointName,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.Endpoints.StartAsync(resourceGroupName, profileName, endpointName, cancellationToken);
        }

        internal void StartEndpoint(
            string resourceGroupName,
            string profileName,
            string endpointName
            )
        {
            StartEndpointAsync(resourceGroupName, profileName, endpointName).Wait();
        }

        ///GENMHASH:EB7BCC87B72405260E2C64D3F60E7D12:27C4EEED8156C99311E5C3646A2873AB
        public async Task StopEndpointAsync(
            string resourceGroupName, 
            string profileName, 
            string endpointName, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.Endpoints.StopAsync(resourceGroupName, profileName, endpointName, cancellationToken);
        }

        internal void StopEndpoint(
            string resourceGroupName,
            string profileName,
            string endpointName)
        {
            StopEndpointAsync(resourceGroupName, profileName, endpointName).Wait();
        }

        ///GENMHASH:64DEF1711FC41C47500E107416B7F805:506E827968295A02B09C6EA38E8B9C1E
        public async Task<CheckNameAvailabilityResult> CheckEndpointNameAvailabilityAsync(
            string name,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return new CheckNameAvailabilityResult( await Manager.Inner.CheckNameAvailabilityAsync(name, cancellationToken));
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:83F5C51B6E80CB8E2B2AB13088098EAD:7A8055F61731CABECC9333BD0AB0BDA2
        public async Task<string> GenerateSsoUriAsync(
            string resourceGroupName, 
            string profileName, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            SsoUriInner ssoUri = await Manager.Inner.Profiles.GenerateSsoUriAsync(resourceGroupName, profileName, cancellationToken);
            if (ssoUri != null)
            {
                return ssoUri.SsoUriValue;
            }

            return null;
        }

        public string GenerateSsoUri(string resourceGroupName, string profileName)
        {
            return Extensions.Synchronize(() => GenerateSsoUriAsync(resourceGroupName, profileName));
        }

        ///GENMHASH:2404C5CA15B0D5D6226D2C7D01E79303:FA381ABED6F4688FD47A380CF0F41845
        internal  CdnProfilesImpl(CdnManager cdnManager)
            : base(cdnManager.Inner.Profiles, cdnManager)
        {
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public CdnProfileImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        protected async override Task<ProfileInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:BDFF4CB61E8A8D975417EA5FC914921A
        protected async override Task<IPage<ProfileInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupAsync(groupName, cancellationToken);
        }

        protected async override Task<IPage<ProfileInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:BA164FA13589E15D154A149930A7318A
        protected override CdnProfileImpl WrapModel(string name)
        {
            return new CdnProfileImpl(name, new ProfileInner(), Manager);
        }

        ///GENMHASH:96AD55F2D1A183F1EF3F3859FC90630B:E7C740DCEB274D49AE272A1212126D43
        protected override ICdnProfile WrapModel(ProfileInner inner)
        {
            return new CdnProfileImpl(inner.Name, inner, Manager);
        }

        ///GENMHASH:5ABD9E20ED5A3AA9092DC3AC7B3573AC:38A65CDCA635B6616A2B2FC37922C9E1
        public async Task PurgeEndpointContentAsync(
            string resourceGroupName, 
            string profileName, 
            string endpointName, 
            IList<string> contentPaths,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.Endpoints.PurgeContentAsync(resourceGroupName, profileName, endpointName, contentPaths, cancellationToken);
        }

        public void PurgeEndpointContent(
            string resourceGroupName,
            string profileName,
            string endpointName,
            IList<string> contentPaths)
        {
            PurgeEndpointContentAsync(resourceGroupName, profileName, endpointName, contentPaths).Wait();
        }
    }

}
