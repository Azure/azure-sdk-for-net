// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class CdnManagementTestBase : ManagementRecordedTestBase<CdnManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected CdnManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected CdnManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroup> CreateResourceGroup(string rgNamePrefix)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS);
            var lro = await Client.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            return lro.Value;
        }

        protected async Task<Profile> CreateProfile(ResourceGroup rg, string profileName, SkuName skuName)
        {
            ProfileData profileData = ResourceDataHelper.CreateProfileData(skuName);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(profileName, profileData);
            return lro.Value;
        }

        protected async Task<Profile> CreateAFDProfile(ResourceGroup rg, string profileName, SkuName skuName)
        {
            ProfileData profileData = ResourceDataHelper.CreateAFDProfileData(skuName);
            var lro = await rg.GetProfiles().CreateOrUpdateAsync(profileName, profileData);
            return lro.Value;
        }

        protected async Task<Endpoint> CreateEndpoint(Profile profile, string endpointName)
        {
            EndpointData endpointData = ResourceDataHelper.CreateEndpointData();
            DeepCreatedOrigin deepCreatedOrigin = ResourceDataHelper.CreateDeepCreatedOrigin();
            endpointData.Origins.Add(deepCreatedOrigin);
            var lro = await profile.GetEndpoints().CreateOrUpdateAsync(endpointName, endpointData);
            return lro.Value;
        }

        protected async Task<Endpoint> CreateEndpointWithOriginGroup(Profile profile, string endpointName)
        {
            EndpointData endpointData = ResourceDataHelper.CreateEndpointData();
            DeepCreatedOrigin deepCreatedOrigin = ResourceDataHelper.CreateDeepCreatedOrigin();
            DeepCreatedOriginGroup deepCreatedOriginGroup = ResourceDataHelper.CreateDeepCreatedOriginGroup();
            deepCreatedOriginGroup.Origins.Add(new ResourceReference
            {
                Id = $"{profile.Id}/endpoints/{endpointName}/origins/{deepCreatedOrigin.Name}"
            });
            endpointData.Origins.Add(deepCreatedOrigin);
            endpointData.OriginGroups.Add(deepCreatedOriginGroup);
            endpointData.DefaultOriginGroup = new ResourceReference
            {
                Id = $"{profile.Id}/endpoints/{endpointName}/originGroups/{deepCreatedOriginGroup.Name}"
            };
            var lro = await profile.GetEndpoints().CreateOrUpdateAsync(endpointName, endpointData);
            return lro.Value;
        }

        protected async Task<Origin> CreateOrigin(Endpoint endpoint, string originName)
        {
            OriginData originData = ResourceDataHelper.CreateOriginData();
            var lro = await endpoint.GetOrigins().CreateOrUpdateAsync(originName, originData);
            return lro.Value;
        }

        protected async Task<OriginGroup> CreateOriginGroup(Endpoint endpoint, string originGroupName, string originName)
        {
            OriginGroupData originGroupData = new OriginGroupData();
            originGroupData.Origins.Add(new ResourceReference
            {
                Id = $"{endpoint.Id}/origins/{originName}"
            });
            var lro = await endpoint.GetOriginGroups().CreateOrUpdateAsync(originGroupName, originGroupData);
            return lro.Value;
        }

        protected async Task<CustomDomain> CreateCustomDomain(Endpoint endpoint, string customDomainName, string hostName)
        {
            CustomDomainParameters customDomainParameters = ResourceDataHelper.CreateCustomDomainParameters(hostName);
            var lro = await endpoint.GetCustomDomains().CreateOrUpdateAsync(customDomainName, customDomainParameters);
            return lro.Value;
        }
    }
}
