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
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpointResource cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            string cdnOriginGroupName = Recording.GenerateAssetName("origingroup-");
            CdnOriginGroupResource cdnOriginGroup = await CreateCdnOriginGroup(cdnEndpoint, cdnOriginGroupName, cdnEndpoint.Data.Origins[0].Name);
            await cdnOriginGroup.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await cdnOriginGroup.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardMicrosoft);
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpointResource cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            string cdnOriginGroupName = Recording.GenerateAssetName("origingroup-");
            CdnOriginGroupResource cdnOriginGroup = await CreateCdnOriginGroup(cdnEndpoint, cdnOriginGroupName, cdnEndpoint.Data.Origins[0].Name);
            CdnOriginGroupPatch updateOptions = new CdnOriginGroupPatch()
            {
                HealthProbeSettings = new HealthProbeSettings
                {
                    ProbePath = "/healthz",
                    ProbeRequestType = HealthProbeRequestType.Head,
                    ProbeProtocol = HealthProbeProtocol.Https,
                    ProbeIntervalInSeconds = 60
                }
            };
            var lro = await cdnOriginGroup.UpdateAsync(WaitUntil.Completed, updateOptions);
            CdnOriginGroupResource updatedCdnOriginGroup = lro.Value;
            ResourceDataHelper.AssertOriginGroupUpdate(updatedCdnOriginGroup, updateOptions);
        }
    }
}
