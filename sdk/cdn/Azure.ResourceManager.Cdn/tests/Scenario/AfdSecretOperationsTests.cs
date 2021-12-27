// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class AfdSecretOperationsTests : CdnManagementTestBase
    {
        public AfdSecretOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdSecretName = Recording.GenerateAssetName("AFDSecret-");
            AfdSecret afdSecret = await CreateAfdSecret(afdProfile, afdSecretName);
            await afdSecret.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await afdSecret.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }
    }
}
