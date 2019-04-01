// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Media.Tests.ScenarioTests
{
    public class StreamingLocatorTests : MediaScenarioTestBase
    {
        [Fact]
        public void StreamingLocatorComboTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType().FullName))
            {
                try
                {
                    CreateMediaServicesAccount();

                    // List the StreamingLocators, which should be empty
                    var locators = MediaClient.StreamingLocators.List(ResourceGroup, AccountName);
                    Assert.Empty(locators);

                    string locatorName = TestUtilities.GenerateName("StreamingLocator");

                    // Get the StreamingLocator, which should not exist
                    StreamingLocator locator = MediaClient.StreamingLocators.Get(ResourceGroup, AccountName, locatorName);
                    Assert.Null(locator);

                    // Create an Asset for the StreamingLocator to point to
                    string assetName = TestUtilities.GenerateName("assetToPublish");
                    Asset assetToPublish = MediaClient.Assets.CreateOrUpdate(ResourceGroup, AccountName, assetName, new Asset());

                    // Create the ContentKeyPolicy for the StreamingLocator
                    string policyName = TestUtilities.GenerateName("contentKeyPolicy");
                    CreateContentKeyPolicy(policyName);

                    // Create a StreamingLocator
                    StreamingLocator input = new StreamingLocator(assetName: assetName, streamingPolicyName: PredefinedStreamingPolicy.ClearKey, defaultContentKeyPolicyName: policyName);                    
                    StreamingLocator createdLocator = MediaClient.StreamingLocators.Create(ResourceGroup, AccountName, locatorName, input);
                    ValidateLocator(createdLocator, locatorName, assetName, policyName, PredefinedStreamingPolicy.ClearKey);

                    // List the StreamingLocators and validate the newly created one shows up
                    locators = MediaClient.StreamingLocators.List(ResourceGroup, AccountName);
                    Assert.Single(locators);
                    ValidateLocator(locators.First(), locatorName, assetName, policyName, PredefinedStreamingPolicy.ClearKey);

                    // Get the newly created StreamingLocator
                    locator = MediaClient.StreamingLocators.Get(ResourceGroup, AccountName, locatorName);
                    Assert.NotNull(locator);
                    ValidateLocator(locator, locatorName, assetName, policyName, PredefinedStreamingPolicy.ClearKey);

                    // Delete the StreamingLocator
                    MediaClient.StreamingLocators.Delete(ResourceGroup, AccountName, locatorName);

                    // List the StreamingLocators, which should be empty again
                    locators = MediaClient.StreamingLocators.List(ResourceGroup, AccountName);
                    Assert.Empty(locators);

                    // Get the StreamingLocator, which should not exist
                    locator = MediaClient.StreamingLocators.Get(ResourceGroup, AccountName, locatorName);
                    Assert.Null(locator);

                    MediaClient.Assets.Delete(ResourceGroup, AccountName, assetName);
                    MediaClient.ContentKeyPolicies.Delete(ResourceGroup, AccountName, policyName);
                }
                finally
                {
                    DeleteMediaServicesAccount();
                }
            }
        }

        internal static void ValidateLocator(StreamingLocator locator, string expectedName, string expectedAssetName, string expectedDefaultContentKeyPolicyName, string expectedStreamingPolicyName)
        {
            Assert.Equal(expectedAssetName, locator.AssetName);
            Assert.Equal(expectedName, locator.Name);
            Assert.Equal(expectedDefaultContentKeyPolicyName, locator.DefaultContentKeyPolicyName);
            Assert.NotEqual(Guid.Empty, locator.StreamingLocatorId);
            Assert.Equal(expectedStreamingPolicyName, locator.StreamingPolicyName);
            Assert.False(string.IsNullOrEmpty(locator.Id));
        }

        private void CreateContentKeyPolicy(string policyName)
        {
            ContentKeyPolicyOption[] options = new ContentKeyPolicyOption[]
            {
                new ContentKeyPolicyOption(new ContentKeyPolicyClearKeyConfiguration(), new ContentKeyPolicyOpenRestriction())
            };

            ContentKeyPolicy policy = MediaClient.ContentKeyPolicies.CreateOrUpdate(ResourceGroup, AccountName, policyName, options);
        }
    }
}

