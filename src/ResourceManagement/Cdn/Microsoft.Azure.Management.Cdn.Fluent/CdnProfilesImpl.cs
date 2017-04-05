// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ResourceManager.Fluent.Core;
    using System.Threading;
    using System.Linq;
    using Models;
    using Management.Fluent.Resource.Core;
    using Rest.Azure;

    /// <summary>
    /// Implementation for CdnProfiles.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNkbi5pbXBsZW1lbnRhdGlvbi5DZG5Qcm9maWxlc0ltcGw=
    internal partial class CdnProfilesImpl  :
        TopLevelModifiableResources<ICdnProfile,CdnProfileImpl,ProfileInner,IProfilesOperations,ICdnManager>,
        ICdnProfiles
    {
        ///GENMHASH:2CEB6E35574F5C7F1D19ADAC97C93D65:4CE4EF96A3377BCB6304539746BB262C
        public IEnumerable<Operation> ListOperations()
        {
            return Manager.Inner.ListOperations()
                                .AsContinuousCollection(link => Manager.Inner.ListOperationsNext(link))
                                .Select(inner=> new Operation(inner));
        }

        ///GENMHASH:8C72A32C69D3B2099B1D93E3B9873A71:FE90FEDDCD7F5DB55096DEBEBB032C64
        public async Task LoadEndpointContentAsync(
            string resourceGroupName, 
            string profileName, 
            string endpointName, 
            IList<string> contentPaths,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.Endpoints.LoadContentAsync(resourceGroupName, profileName, endpointName, contentPaths, cancellationToken);
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

        ///GENMHASH:B76E119E66FC2C5D09617333DC4FF4E3:5E6BF540BD14D5EE37AC38FE28D3AA9F
        public async Task StartEndpointAsync(
            string resourceGroupName, 
            string profileName, 
            string endpointName,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.Endpoints.StartAsync(resourceGroupName, profileName, endpointName, cancellationToken);
        }

        ///GENMHASH:EB7BCC87B72405260E2C64D3F60E7D12:0B575D15FFB768C385885373A8223CCA
        public async Task StopEndpointAsync(
            string resourceGroupName, 
            string profileName, 
            string endpointName, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.Endpoints.StopAsync(resourceGroupName, profileName, endpointName, cancellationToken);
        }

        ///GENMHASH:8B3976582303B73AC81C5220073E2D55:755994AEE32D03FFE71E80381D36C959
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

        ///GENMHASH:83F5C51B6E80CB8E2B2AB13088098EAD:B3C4E9597EF812E4EDA1B18AD5F4A05E
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

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:80BCE26D6F015BF71C5D9844E17987C3
        protected override CdnProfileImpl WrapModel(string name)
        {
            return new CdnProfileImpl(name, new ProfileInner(), Manager);
        }

        ///GENMHASH:96AD55F2D1A183F1EF3F3859FC90630B:5C433EEBC4BF45CC1E0EFAB86E0F40A0
        protected override ICdnProfile WrapModel(ProfileInner inner)
        {
            return new CdnProfileImpl(inner.Name, inner, Manager);
        }

        ///GENMHASH:5ABD9E20ED5A3AA9092DC3AC7B3573AC:B20E4E386B5A7F961CDF4176B3046556
        public async Task PurgeEndpointContentAsync(
            string resourceGroupName, 
            string profileName, 
            string endpointName, 
            IList<string> contentPaths,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.Endpoints.PurgeContentAsync(resourceGroupName, profileName, endpointName, contentPaths, cancellationToken);
        }		
    }
}
