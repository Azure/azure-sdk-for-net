// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Resources.Tests;
using NUnit.Framework;

namespace ResourceGroups.Tests
{
    public class LiveTagsTests : ResourceOperationsTestsBase
    {
        public LiveTagsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
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
        public async Task CreateListAndDeleteSubscriptionTag()
        {
            string tagName = Recording.GenerateAssetName("csmtg");
            var createResult = (await TagsOperations.CreateOrUpdateAsync(tagName)).Value;
            Assert.AreEqual(tagName, createResult.TagName);

            var listResult =await TagsOperations.ListAsync().ToEnumerableAsync();
            Assert.True(listResult.Count() > 0);

            await TagsOperations.DeleteAsync(tagName);
        }

        [Test]
        public async Task CreateListAndDeleteSubscriptionTagValue()
        {
            string tagName = Recording.GenerateAssetName("csmtg");
            string tagValue = Recording.GenerateAssetName("csmtgv");

            var createNameResult = await TagsOperations.CreateOrUpdateAsync(tagName);
            var createValueResult = await TagsOperations.CreateOrUpdateValueAsync(tagName, tagValue);
            Assert.AreEqual(tagName, createNameResult.Value.TagName);
            Assert.AreEqual(tagValue, createValueResult.Value.TagValueValue);

            var listResult =await TagsOperations.ListAsync().ToEnumerableAsync();
            Assert.True(listResult.Count() > 0);

            await TagsOperations.DeleteValueAsync(tagName, tagValue);
            await TagsOperations.DeleteAsync(tagName);
        }

        [Test]
        public async Task CreateTagValueWithoutCreatingTag()
        {
            string tagName = Recording.GenerateAssetName("csmtg");
            string tagValue = Recording.GenerateAssetName("csmtgv");
            try
            {
                await TagsOperations.CreateOrUpdateValueAsync(tagName, tagValue);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
        }

        /// <summary>
        /// Utility method to test Put request for Tags Operation within tracked resources and proxy resources
        /// </summary>
        private async void CreateOrUpdateTagsTest(string resourceScope = "")
        {
            var tagsResource = new TagsResource(new Tags()
            {
                TagsValue = {
                    { "tagKey1", "tagValue1" },
                    { "tagKey2", "tagValue2" }
                }
            }
            );
            string subscriptionScope = "/subscriptions/" + TestEnvironment.SubscriptionId;
            resourceScope = subscriptionScope + resourceScope;

            // test creating tags for resources
            var putResponse =(await TagsOperations.CreateOrUpdateAtScopeAsync(resourceScope, tagsResource)).Value;
            Assert.AreEqual(putResponse.Properties.TagsValue.Count(), tagsResource.Properties.TagsValue.Count());
            Assert.IsTrue(CompareTagsResource(tagsResource, putResponse));
        }

        /// <summary>
        /// Put request for Tags Operation within tracked resources
        /// </summary>
        [Test]
        public void  CreateTagsWithTrackedResourcesTest()
        {
            // test tags for tracked resources
            string resourceScope = "/resourcegroups/TagsApiSDK/providers/Microsoft.Compute/virtualMachines/TagTestVM";
            CreateOrUpdateTagsTest(resourceScope: resourceScope);
        }

        /// <summary>
        /// Put request for Tags Operation within subscription test
        /// </summary>
        [Test]
        public void CreateTagsWithSubscriptionTest()
        {
            // test tags for subscription
            CreateOrUpdateTagsTest();
        }

        /// <summary>
        /// Utility method to test Patch request for Tags Operation within tracked resources and proxy resources, including Replace|Merge|Delete operations
        /// </summary>
        private async void UpdateTagsTest(string resourceScope = "")
        {
            var subscriptionScope = "/subscriptions/" + TestEnvironment.SubscriptionId;
            resourceScope = subscriptionScope + resourceScope;

            // using Tags.CreateOrUpdateAtScope to create two tags initially
            var tagsResource = new TagsResource(new Tags()
            {
                TagsValue = {
                    { "tagKey1", "tagValue1" },
                    { "tagKey2", "tagValue2" }
                }
            }
            );
            await TagsOperations.CreateOrUpdateAtScopeAsync(resourceScope, tagsResource);

            SleepInTest(3*1000);

            var putTags = new Tags()
            {
                TagsValue = {
                    { "tagKey1", "tagValue3" },
                    { "tagKey3", "tagValue3" }
                }
            };
            // test for Merge operation
            {
                var tagPatchRequest = new TagsPatchResource() { Operation = TagsPatchResourceOperation.Merge, Properties = putTags };
                var patchResponse =(await TagsOperations.UpdateAtScopeAsync(resourceScope, tagPatchRequest)).Value;

                var expectedResponse = new TagsResource(new Tags()
                {
                    TagsValue = {
                    { "tagKey1", "tagValue3" },
                    { "tagKey2", "tagValue2" },
                    { "tagKey3", "tagValue3" }
                    }
                }
                );
                Assert.AreEqual(patchResponse.Properties.TagsValue.Count(), expectedResponse.Properties.TagsValue.Count());
                Assert.IsTrue(this.CompareTagsResource(expectedResponse, patchResponse));
            }
            // test for Replace operation
            {
                var tagPatchRequest = new TagsPatchResource() { Operation = TagsPatchResourceOperation.Replace, Properties = putTags };
                var patchResponse = (await TagsOperations.UpdateAtScopeAsync(resourceScope, tagPatchRequest)).Value;

                var expectedResponse = new TagsResource(putTags);
                Assert.AreEqual(patchResponse.Properties.TagsValue.Count(), expectedResponse.Properties.TagsValue.Count());
                Assert.IsTrue(this.CompareTagsResource(expectedResponse, patchResponse));
            }
            // test for Delete operation
            {
                var tagPatchRequest = new TagsPatchResource() { Operation = TagsPatchResourceOperation.Delete, Properties = putTags };
                var patchResponse = (await TagsOperations.UpdateAtScopeAsync(resourceScope, tagPatchRequest)).Value;
                Assert.IsEmpty(patchResponse.Properties.TagsValue);
            }
        }

        /// <summary>
        /// Patch request for Tags Operation within tracked resources test, including Replace|Merge|Delete operations
        /// </summary>
        [Test]
        public void UpdateTagsWithTrackedResourcesTest()
        {
            // test tags for tracked resources
            string resourceScope = "/resourcegroups/TagsApiSDK/providers/Microsoft.Compute/virtualMachines/TagTestVM";
            UpdateTagsTest(resourceScope: resourceScope);
        }

        /// <summary>
        /// Patch request for Tags Operation within subscription test, including Replace|Merge|Delete operations
        /// </summary>
        [Test]
        public void UpdateTagsWithSubscriptionTest()
        {
            // test tags for subscription
            UpdateTagsTest();
        }

        /// <summary>
        /// Utility method to test Get request for Tags Operation within tracked resources and proxy resources
        /// </summary>
        private async void GetTagsTest(string resourceScope = "")
        {
            var subscriptionScope = "/subscriptions/" + TestEnvironment.SubscriptionId;
            resourceScope = subscriptionScope + resourceScope;

            // using Tags.CreateOrUpdateAtScope to create two tags initially
            var tagsResource = new TagsResource(new Tags()
            {
                TagsValue = {
                    { "tagKey1", "tagValue1" },
                    { "tagKey2", "tagValue2" }
                }
            });
            await TagsOperations.CreateOrUpdateAtScopeAsync(resourceScope, tagsResource);
            if (Mode == RecordedTestMode.Record)
                Thread.Sleep(3*1000);

            // get request should return created TagsResource
            var getResponse = (await TagsOperations.GetAtScopeAsync(resourceScope)).Value;
            Assert.AreEqual(getResponse.Properties.TagsValue.Count(), tagsResource.Properties.TagsValue.Count());
            Assert.IsTrue(this.CompareTagsResource(tagsResource, getResponse));
        }

        /// <summary>
        /// Get request for Tags Operation within tracked resources test
        /// </summary>
        [Test]
        public void GetTagsWithTrackedResourcesTest()
        {
             // test tags for tracked resources
             string resourceScope = "/resourcegroups/TagsApiSDK/providers/Microsoft.Compute/virtualMachines/TagTestVM";
             GetTagsTest(resourceScope: resourceScope);
        }

        /// <summary>
        /// Get request for Tags Operation within subscription test
        /// </summary>
        [Test]
        public void GetTagsWithSubscriptionTest()
        {
            // test tags for subscription
            GetTagsTest();
        }

        /// <summary>
        /// Utility method to test Delete request for Tags Operation within tracked resources and proxy resources
        /// </summary>
        private async Task<TagsResource> DeleteTagsTest(string resourceScope = "")
        {
            var subscriptionScope = "//subscriptions/" + TestEnvironment.SubscriptionId;
            resourceScope = subscriptionScope + resourceScope;

            // using Tags.CreateOrUpdateAtScope to create two tags initially
            var tagsResource = new TagsResource(new Tags()
            {
                TagsValue = {
                    { "tagKey1", "tagValue1" },
                    { "tagKey2", "tagValue2" }
                }
            });
            await TagsOperations.CreateOrUpdateAtScopeAsync(resourceScope, tagsResource);
            if (Mode == RecordedTestMode.Record)
                Thread.Sleep(3*1000);

            // try to delete existing tags
            await TagsOperations.DeleteAtScopeAsync(resourceScope);
            if (Mode == RecordedTestMode.Record)
                Thread.Sleep(15*1000);

            // after deletion, Get request should get 0 tags back
            var result = (await TagsOperations.GetAtScopeAsync(resourceScope)).Value; ;
            return result;
        }

        /// <summary>
        /// Get request for Tags Operation within tracked resources test
        /// </summary>
        [Test]
        public void DeleteTagsWithTrackedResourcesTest()
        {
            // test tags for tracked resources
            string resourceScope = "/resourcegroups/TagsApiSDK/providers/Microsoft.Compute/virtualMachines/TagTestVM";
            Assert.AreEqual(0, DeleteTagsTest(resourceScope: resourceScope).Result.Properties.TagsValue.Count);
        }

        /// <summary>
        /// Get request for Tags Operation within subscription test
        /// </summary>
        [Test]
        public void DeleteTagsWithSubscriptionTest()
        {
            // test tags for subscription
            Assert.IsEmpty(DeleteTagsTest().Result.Properties.TagsValue);
        }

        /// <summary>
        /// utility method to compare two TagsResource object to see if they are the same
        /// </summary>
        /// <param name="tag1">first TagsResource object</param>
        /// <param name="tag2">second TagsResource object</param>
        /// <returns> boolean to show whether two objects are the same</returns>
        private bool CompareTagsResource(TagsResource tag1, TagsResource tag2)
        {
            if ((tag1 == null && tag2 == null) || (tag1.Properties.TagsValue.Count == 0 && tag2.Properties.TagsValue.Count == 0))
            {
                return true;
            }
            if ((tag1 == null || tag2 == null) || (tag1.Properties.TagsValue.Count == 0 || tag2.Properties.TagsValue.Count == 0))
            {
                return false;
            }
            foreach (var pair in tag1.Properties.TagsValue)
            {
                if (!tag2.Properties.TagsValue.ContainsKey(pair.Key) || tag2.Properties.TagsValue[pair.Key] != pair.Value)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
