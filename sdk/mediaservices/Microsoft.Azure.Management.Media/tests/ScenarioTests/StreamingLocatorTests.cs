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
        private static readonly long HNSTimescale = 10000000;

        [Fact]
        public void StreamingLocatorComboTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType()))
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

                    // Create 2 AssetFilters, to be added to StreamingLocator.
                    // There's no update on StreamingLocators, so no need for update on the Filters.
                    string filterNameA = TestUtilities.GenerateName("assetFilterA");
                    // Create an AssetFilter
                    var ptr = new PresentationTimeRange(0, 600 * HNSTimescale, 120 * HNSTimescale, 0, HNSTimescale, false);
                    AssetFilter assetFilter = new AssetFilter(presentationTimeRange: ptr);
                    AssetFilter createdAssetFilter = MediaClient.AssetFilters.CreateOrUpdate(ResourceGroup, AccountName, assetName, filterNameA, assetFilter);
                    string filterNameB = TestUtilities.GenerateName("assetFilterB");
                    createdAssetFilter = MediaClient.AssetFilters.CreateOrUpdate(ResourceGroup, AccountName, assetName, filterNameB, assetFilter);
                    string[] filters = new string[]
                        {
                           filterNameA,
                           filterNameB
                        };

                    // Create the ContentKeyPolicy for the StreamingLocator
                    string policyName = TestUtilities.GenerateName("contentKeyPolicy");
                    CreateContentKeyPolicy(policyName);

                    // Create a StreamingLocator
                    StreamingLocator input = new StreamingLocator(assetName: assetName, streamingPolicyName: PredefinedStreamingPolicy.ClearKey, defaultContentKeyPolicyName: policyName, filters: filters);
                    StreamingLocator createdLocator = MediaClient.StreamingLocators.Create(ResourceGroup, AccountName, locatorName, input);
                    ValidateLocator(createdLocator, locatorName, assetName, policyName, PredefinedStreamingPolicy.ClearKey, filters);

                    // List the StreamingLocators and validate the newly created one shows up
                    locators = MediaClient.StreamingLocators.List(ResourceGroup, AccountName);
                    Assert.Single(locators);
                    ValidateLocator(locators.First(), locatorName, assetName, policyName, PredefinedStreamingPolicy.ClearKey);

                    // Get the newly created StreamingLocator
                    locator = MediaClient.StreamingLocators.Get(ResourceGroup, AccountName, locatorName);
                    Assert.NotNull(locator);
                    ValidateLocator(locator, locatorName, assetName, policyName, PredefinedStreamingPolicy.ClearKey, filters);

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

        internal static void ValidateLocator(StreamingLocator locator, string expectedName, string expectedAssetName, string expectedDefaultContentKeyPolicyName, string expectedStreamingPolicyName, string[] filters = null)
        {
            Assert.Equal(expectedAssetName, locator.AssetName);
            Assert.Equal(expectedName, locator.Name);
            Assert.Equal(expectedDefaultContentKeyPolicyName, locator.DefaultContentKeyPolicyName);
            Assert.NotEqual(Guid.Empty, locator.StreamingLocatorId);
            Assert.Equal(expectedStreamingPolicyName, locator.StreamingPolicyName);
            Assert.False(string.IsNullOrEmpty(locator.Id));
            if (filters != null)
            {
                foreach (string filter in filters)
                {
                    Assert.True(locator.Filters.Contains(filter));
                }
            }
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


