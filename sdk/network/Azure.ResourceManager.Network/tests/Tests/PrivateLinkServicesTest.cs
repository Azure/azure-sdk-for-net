// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class PrivateLinkServicesTest : NetworkTestsManagementClientBase
    {
        public PrivateLinkServicesTest(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task CheckPrivateLinkServiceVisibilityTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("cplsrg");
            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/connections");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
            var param = new CheckPrivateLinkServiceVisibilityRequest("mypls.00000000-0000-0000-0000-000000000000.azure.privatelinkservice");
            var checkRawResponse = await PrivateLinkServicesOperations.StartCheckPrivateLinkServiceVisibilityByResourceGroupAsync(location, resourceGroupName, param);
            PrivateLinkServiceVisibility response = await WaitForCompletionAsync(checkRawResponse);
            Assert.False(response.Visible);
        }
    }
}
