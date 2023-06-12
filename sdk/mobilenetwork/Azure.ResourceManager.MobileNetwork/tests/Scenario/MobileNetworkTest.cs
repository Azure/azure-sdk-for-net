// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.MobileNetwork;
using Azure.ResourceManager.MobileNetwork.Models;
using Azure.ResourceManager.MobileNetwork.Tests.Utilities;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.MobileNetwork.Tests.Scenario
{
    public class MobileNetworkTest : MobileNetworkManagementTestBase
    {
        public MobileNetworkTest(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateCommonClient();
            }
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        [RecordedTest]
        public async Task CanCreateGetMobileNetwork()
        {
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, MobileNetworkManagementUtilities.DefaultResourceGroupName, MobileNetworkManagementUtilities.DefaultResourceLocation);
            string mobileNetworkName = Recording.GenerateAssetName("mobileNetwork");

            // Create Mobile Network
            MobileNetworkResource mobileNetwork = await CreateMobileNetworkResource(rg, mobileNetworkName);

            // Get Mobile Network
            Response<MobileNetworkResource> getMobileNetworkResponse = await mobileNetwork.GetAsync();
            MobileNetworkResource mobileNetworkResourceRetrived = getMobileNetworkResponse.Value;
            Assert.IsNotNull(mobileNetworkResourceRetrived);
            Assert.AreEqual(mobileNetwork.Data.Location, mobileNetworkResourceRetrived.Data.Location);
            Assert.AreEqual("001", mobileNetworkResourceRetrived.Data.PublicLandMobileNetworkIdentifier.Mcc);

            // Delete Mobile Network
            await mobileNetwork.DeleteAsync(WaitUntil.Completed);
        }
    }
}
