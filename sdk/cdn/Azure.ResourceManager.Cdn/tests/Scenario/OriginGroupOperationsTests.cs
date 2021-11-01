// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class OriginGroupOperationsTests : CdnManagementTestBase
    {
        public OriginGroupOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            Profile profile = await CreateProfile(rg, profileName, SkuName.StandardMicrosoft);
            string endpointName = Recording.GenerateAssetName("endpoint-");
            Endpoint endpoint = await CreateEndpoint(profile, endpointName);
            string originGroupName = Recording.GenerateAssetName("origingroup-");
            OriginGroup originGroup = await CreateOriginGroup(endpoint, originGroupName, endpoint.Data.Origins[0].Name);
            await originGroup.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await originGroup.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            Profile profile = await CreateProfile(rg, profileName, SkuName.StandardMicrosoft);
            string endpointName = Recording.GenerateAssetName("endpoint-");
            Endpoint endpoint = await CreateEndpoint(profile, endpointName);
            string originGroupName = Recording.GenerateAssetName("origingroup-");
            OriginGroup originGroup = await CreateOriginGroup(endpoint, originGroupName, endpoint.Data.Origins[0].Name);
            OriginGroupUpdateParameters originGroupUpdateParameters = new OriginGroupUpdateParameters()
            {
                HealthProbeSettings = new HealthProbeParameters
                {
                    ProbePath = "/healthz",
                    ProbeRequestType = HealthProbeRequestType.Head,
                    ProbeProtocol = ProbeProtocol.Https,
                    ProbeIntervalInSeconds = 60
                }
            };
            var lro = await originGroup.UpdateAsync(originGroupUpdateParameters);
            OriginGroup updatedOriginGroup = lro.Value;
            ResourceDataHelper.AssertOriginGroupUpdate(updatedOriginGroup, originGroupUpdateParameters);
        }
    }
}
