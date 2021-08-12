﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class PrivateLinkServicesTest : NetworkServiceClientTestBase
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

        //[TearDown]
        //public async Task CleanupResourceGroup()
        //{
        //    await CleanupResourceGroupsAsync();
        //}

        [Test]
        public async Task CheckPrivateLinkServiceVisibilityTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("cplsrg");
            string location = await NetworkManagementTestUtilities.GetResourceLocation(ArmClient, "Microsoft.Network/connections");
            ResourceGroup rg = await ArmClient.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(resourceGroupName, new ResourceGroupData(location));
            var param = new CheckPrivateLinkServiceVisibilityRequest()
            {
                PrivateLinkServiceAlias = "mypls.00000000-0000-0000-0000-000000000000.azure.privatelinkservice"
            };
            // TODO: What's the correct test sceanrio?
            //var checkRawResponse = await GetResourceGroup(resourceGroupName).GetPrivateLinkServices().Get("mypls").Value.StartCheckPrivateLinkServiceVisibilityByResourceGroupAsync("mypls.00000000-0000-0000-0000-000000000000.azure.privatelinkservice");
            //PrivateLinkServicesOperations.StartCheckPrivateLinkServiceVisibilityByResourceGroupAsync(location, resourceGroupName, param);
            //PrivateLinkServiceVisibility response = await checkRawResponse.WaitForCompletionAsync();;
            //Assert.False(response.Visible);
        }
    }
}
