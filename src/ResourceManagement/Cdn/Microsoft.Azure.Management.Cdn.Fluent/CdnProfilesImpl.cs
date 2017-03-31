// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ResourceManager.Fluent.Core;
    using System.Threading;
    using Models;

    /// <summary>
    /// Implementation for CdnProfiles.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNkbi5pbXBsZW1lbnRhdGlvbi5DZG5Qcm9maWxlc0ltcGw=
    internal partial class CdnProfilesImpl  :
        GroupableResources<ICdnProfile,CdnProfileImpl,ProfileInner,IProfilesOperations,ICdnManager>,
        ICdnProfiles
    {
        ///GENMHASH:2CEB6E35574F5C7F1D19ADAC97C93D65:4CE4EF96A3377BCB6304539746BB262C
        public IEnumerable<Operation> ListOperations()
        {
            return Manager.Profiles.ListOperations();
        }

        ///GENMHASH:8C72A32C69D3B2099B1D93E3B9873A71:FE90FEDDCD7F5DB55096DEBEBB032C64
        public void LoadEndpointContent(
            string resourceGroupName, 
            string profileName, 
            string endpointName, 
            IList<string> contentPaths)
        {
            Manager.Inner.Endpoints.LoadContent(resourceGroupName, profileName, endpointName, contentPaths);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:6FB4EA69673E1D8A74E1418EB52BB9FE
        public IEnumerable<ICdnProfile> List()
        {
            return WrapList(Inner.List()
                                 .AsContinuousCollection(link => Inner.ListNext(link)));
        }

        ///GENMHASH:B76E119E66FC2C5D09617333DC4FF4E3:5E6BF540BD14D5EE37AC38FE28D3AA9F
        public void StartEndpoint(string resourceGroupName, string profileName, string endpointName)
        {
            Manager.Inner.Endpoints.Start(resourceGroupName, profileName, endpointName);
        }

        ///GENMHASH:EB7BCC87B72405260E2C64D3F60E7D12:0B575D15FFB768C385885373A8223CCA
        public void StopEndpoint(string resourceGroupName, string profileName, string endpointName)
        {
            Manager.Inner.Endpoints.Stop(resourceGroupName, profileName, endpointName);
        }

        ///GENMHASH:8B3976582303B73AC81C5220073E2D55:755994AEE32D03FFE71E80381D36C959
        public CheckNameAvailabilityResult CheckEndpointNameAvailability(string name)
        {
            return new CheckNameAvailabilityResult(Manager.Inner.CheckNameAvailability(name));
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
        public async override Task DeleteByGroupAsync(
            string groupName, 
            string name, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:83F5C51B6E80CB8E2B2AB13088098EAD:B3C4E9597EF812E4EDA1B18AD5F4A05E
        public string GenerateSsoUri(string resourceGroupName, string profileName)
        {
            SsoUriInner ssoUri = Manager.Inner.Profiles.GenerateSsoUri(resourceGroupName, profileName);
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
        public async override Task<ICdnProfile> GetByGroupAsync(
            string groupName, 
            string name, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            ProfileInner profileInner = await Inner.GetAsync(groupName, name, cancellationToken);
            return WrapModel(profileInner);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:BDFF4CB61E8A8D975417EA5FC914921A
        public IEnumerable<ICdnProfile> ListByGroup(string groupName)
        {
            return WrapList(Inner.ListByResourceGroup(groupName)
                                 .AsContinuousCollection(link => Inner.ListByResourceGroupNext(link)));
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
        public void PurgeEndpointContent(
            string resourceGroupName, 
            string profileName, 
            string endpointName, 
            IList<string> contentPaths)
        {
            Manager.Inner.Endpoints.PurgeContent(resourceGroupName, profileName, endpointName, contentPaths);
        }		
    }
}
