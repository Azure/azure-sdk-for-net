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
    public class CdnOriginGroupOperationsTests : CdnManagementTestBase
    {
        public CdnOriginGroupOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            Profile cdnProfile = await CreateCdnProfile(rg, cdnProfileName, SkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpoint cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            string cdnOriginGroupName = Recording.GenerateAssetName("origingroup-");
            CdnOriginGroup cdnOriginGroup = await CreateCdnOriginGroup(cdnEndpoint, cdnOriginGroupName, cdnEndpoint.Data.Origins[0].Name);
            await cdnOriginGroup.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await cdnOriginGroup.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            Profile cdnProfile = await CreateCdnProfile(rg, cdnProfileName, SkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpoint cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            string cdnOriginGroupName = Recording.GenerateAssetName("origingroup-");
            CdnOriginGroup cdnOriginGroup = await CreateCdnOriginGroup(cdnEndpoint, cdnOriginGroupName, cdnEndpoint.Data.Origins[0].Name);
            OriginGroupUpdateOptions updateOptions = new OriginGroupUpdateOptions()
            {
                HealthProbeSettings = new HealthProbeParameters
                {
                    ProbePath = "/healthz",
                    ProbeRequestType = HealthProbeRequestType.Head,
                    ProbeProtocol = ProbeProtocol.Https,
                    ProbeIntervalInSeconds = 60
                }
            };
            var lro = await cdnOriginGroup.UpdateAsync(updateOptions);
            CdnOriginGroup updatedCdnOriginGroup = lro.Value;
            ResourceDataHelper.AssertOriginGroupUpdate(updatedCdnOriginGroup, updateOptions);
        }
    }
}
