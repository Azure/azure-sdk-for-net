// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using System.Net;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Test;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Management.ResourceManager.Models;
using System.Collections.Generic;
using FluentAssertions;
using System.Threading;

namespace ResourceGroups.Tests
{
    public class LiveTagsTests : TestBase
    {
        const string DefaultLocation = "South Central US";

        public ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = this.GetResourceManagementClientWithHandler(context, handler);
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationRetryTimeout = 0;
            }

            return client;
        }

        [Fact]
        public void CreateListAndDeleteSubscriptionTag()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string tagName = TestUtilities.GenerateName("csmtg");

                var client = GetResourceManagementClient(context, handler);
                var createResult = client.Tags.CreateOrUpdate(tagName);

                Assert.Equal(tagName, createResult.TagName);
                
                var listResult = client.Tags.List();
                Assert.True(listResult.Count() > 0);

                client.Tags.Delete(tagName);
            }
        }

        [Fact]
        public void CreateListAndDeleteSubscriptionTagValue()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string tagName = TestUtilities.GenerateName("csmtg");
                string tagValue = TestUtilities.GenerateName("csmtgv");

                var client = GetResourceManagementClient(context, handler);
                var createNameResult = client.Tags.CreateOrUpdate(tagName);
                var createValueResult = client.Tags.CreateOrUpdateValue(tagName, tagValue);

                Assert.Equal(tagName, createNameResult.TagName);
                Assert.Equal(tagValue, createValueResult.TagValueProperty);

                var listResult = client.Tags.List();
                Assert.True(listResult.Count() > 0);

                client.Tags.DeleteValue(tagName, tagValue);
                client.Tags.Delete(tagName);
            }
        }

        [Fact]
        public void CreateTagValueWithoutCreatingTag()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string tagName = TestUtilities.GenerateName("csmtg");
                string tagValue = TestUtilities.GenerateName("csmtgv");

                var client = GetResourceManagementClient(context, handler);
                Assert.Throws<CloudException>(() => client.Tags.CreateOrUpdateValue(tagName, tagValue));
            }
        }


        /// <summary>
        /// Utility method to test Put request for Tags Operation within tracked resources and proxy resources
        /// </summary>
        private void CreateOrUpdateTagsTest(MockContext context, string resourceScope = "")
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            var tagsResource = new TagsResource(new Tags(
                new Dictionary<string, string> {
                    { "tagKey1", "tagValue1" },
                    { "tagKey2", "tagValue2" }
                }
            ));
            var client = GetResourceManagementClient(context, handler);
            var subscriptionScope = "/subscriptions/" + client.SubscriptionId;
            resourceScope = subscriptionScope + resourceScope;

            // test creating tags for resources
            var putResponse = client.Tags.CreateOrUpdateAtScope(resourceScope, tagsResource);
            putResponse.Properties.TagsProperty.Should().HaveCount(tagsResource.Properties.TagsProperty.Count);
            this.CompareTagsResource(tagsResource, putResponse).Should().BeTrue();
        }

        /// <summary>
        /// Put request for Tags Operation within tracked resources
        /// </summary>
        [Fact]    
        public void CreateTagsWithTrackedResourcesTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // test tags for tracked resources
                string resourceScope = "/resourcegroups/TagsApiSDK/providers/Microsoft.Compute/virtualMachines/TagTestVM";
                this.CreateOrUpdateTagsTest(context:context, resourceScope:resourceScope);
            }
        }

        /// <summary>
        /// Put request for Tags Operation within subscription test
        /// </summary>
        [Fact]
        public void CreateTagsWithSubscriptionTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // test tags for subscription
                this.CreateOrUpdateTagsTest(context: context);
            }
        }

        /// <summary>
        /// Utility method to test Patch request for Tags Operation within tracked resources and proxy resources, including Replace|Merge|Delete operations
        /// </summary>
        private void UpdateTagsTest(MockContext context, string resourceScope = "")
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetResourceManagementClient(context, handler);
            var subscriptionScope = "/subscriptions/" + client.SubscriptionId;
            resourceScope = subscriptionScope + resourceScope;

            // using Tags.CreateOrUpdateAtScope to create two tags initially
            var tagsResource = new TagsResource(new Tags(
                new Dictionary<string, string> {
                    { "tagKey1", "tagValue1" },
                    { "tagKey2", "tagValue2" }
                }
            ));
            client.Tags.CreateOrUpdateAtScope(resourceScope, tagsResource);
            Thread.Sleep(3000);

            var putTags = new Tags(
                new Dictionary<string, string> {
                    { "tagKey1", "tagValue3" },
                    { "tagKey3", "tagValue3" }
                });

            { // test for Merge operation
                var tagPatchRequest = new TagsPatchResource("Merge", putTags);
                var patchResponse = client.Tags.UpdateAtScope(resourceScope, tagPatchRequest);

                var expectedResponse = new TagsResource(new Tags(
                    new Dictionary<string, string> {
                    { "tagKey1", "tagValue3" },
                    { "tagKey2", "tagValue2" },
                    { "tagKey3", "tagValue3" }
                    }
                ));
                patchResponse.Properties.TagsProperty.Should().HaveCount(expectedResponse.Properties.TagsProperty.Count);
                this.CompareTagsResource(expectedResponse, patchResponse).Should().BeTrue();
            }

            { // test for Replace operation                  
                var tagPatchRequest = new TagsPatchResource("Replace", putTags);
                var patchResponse = client.Tags.UpdateAtScope(resourceScope, tagPatchRequest);

                var expectedResponse = new TagsResource(putTags);
                patchResponse.Properties.TagsProperty.Should().HaveCount(expectedResponse.Properties.TagsProperty.Count);
                this.CompareTagsResource(expectedResponse, patchResponse).Should().BeTrue();
            }

            { // test for Delete operation                  
                var tagPatchRequest = new TagsPatchResource("Delete", putTags);
                var patchResponse = client.Tags.UpdateAtScope(resourceScope, tagPatchRequest);
                patchResponse.Properties.TagsProperty.Should().BeEmpty();
            }
        }

        /// <summary>
        /// Patch request for Tags Operation within tracked resources test, including Replace|Merge|Delete operations
        /// </summary>
        [Fact]
        public void UpdateTagsWithTrackedResourcesTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // test tags for tracked resources
                string resourceScope = "/resourcegroups/TagsApiSDK/providers/Microsoft.Compute/virtualMachines/TagTestVM";
                this.UpdateTagsTest(context:context, resourceScope: resourceScope);
            }
        }

        /// <summary>
        /// Patch request for Tags Operation within subscription test, including Replace|Merge|Delete operations
        /// </summary>
        [Fact]
        public void UpdateTagsWithSubscriptionTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // test tags for subscription
                this.UpdateTagsTest(context: context);
            }
        }

        /// <summary>
        /// Utility method to test Get request for Tags Operation within tracked resources and proxy resources
        /// </summary>
        private void GetTagsTest(MockContext context, string resourceScope = "")
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            
            var client = GetResourceManagementClient(context, handler);
            var subscriptionScope = "/subscriptions/" + client.SubscriptionId;
            resourceScope = subscriptionScope + resourceScope;

            // using Tags.CreateOrUpdateAtScope to create two tags initially
            var tagsResource = new TagsResource(new Tags(
                new Dictionary<string, string> {
                    { "tagKey1", "tagValue1" },
                    { "tagKey2", "tagValue2" }
                }
            ));
            client.Tags.CreateOrUpdateAtScope(resourceScope, tagsResource);
            Thread.Sleep(3000);

            // get request should return created TagsResource
            var getResponse = client.Tags.GetAtScope(resourceScope);
            getResponse.Properties.TagsProperty.Should().HaveCount(tagsResource.Properties.TagsProperty.Count);
            this.CompareTagsResource(tagsResource, getResponse).Should().BeTrue();
        }

        /// <summary>
        /// Get request for Tags Operation within tracked resources test
        /// </summary>
        [Fact]
        public void GetTagsWithTrackedResourcesTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // test tags for tracked resources
                string resourceScope = "/resourcegroups/TagsApiSDK/providers/Microsoft.Compute/virtualMachines/TagTestVM";
                this.GetTagsTest(context: context, resourceScope: resourceScope);
            }
        }

        /// <summary>
        /// Get request for Tags Operation within subscription test
        /// </summary>
        [Fact]
        public void GetTagsWithSubscriptionTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // test tags for subscription
                this.GetTagsTest(context: context);
            }
        }

        /// <summary>
        /// Utility method to test Delete request for Tags Operation within tracked resources and proxy resources
        /// </summary>
        private TagsResource DeleteTagsTest(MockContext context, string resourceScope = "")
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(context, handler);
            var subscriptionScope = "/subscriptions/" + client.SubscriptionId;
            resourceScope = subscriptionScope + resourceScope;

            // using Tags.CreateOrUpdateAtScope to create two tags initially
            var tagsResource = new TagsResource(new Tags(
                new Dictionary<string, string> {
                    { "tagKey1", "tagValue1" },
                    { "tagKey2", "tagValue2" }
                }
            ));
            client.Tags.CreateOrUpdateAtScope(resourceScope, tagsResource);
            Thread.Sleep(3000);

            // try to delete existing tags
            client.Tags.DeleteAtScope(resourceScope);
            Thread.Sleep(3000);

            // after deletion, Get request should get 0 tags back
            return client.Tags.GetAtScope(resourceScope);        
        }

        /// <summary>
        /// Get request for Tags Operation within tracked resources test
        /// </summary>
        [Fact]
        public void DeleteTagsWithTrackedResourcesTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // test tags for tracked resources
                string resourceScope = "/resourcegroups/TagsApiSDK/providers/Microsoft.Compute/virtualMachines/TagTestVM";
                this.DeleteTagsTest(context: context, resourceScope: resourceScope).Properties.TagsProperty.Should().BeEmpty();
            }
        }

        /// <summary>
        /// Get request for Tags Operation within subscription test
        /// </summary>
        [Fact]
        public void DeleteTagsWithSubscriptionTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // test tags for subscription
                this.DeleteTagsTest(context: context).Properties.TagsProperty.Should().BeEmpty();
            }            
        }

        /// <summary>
        /// utility method to compare two TagsResource object to see if they are the same
        /// </summary>
        /// <param name="tag1">first TagsResource object</param>
        /// <param name="tag2">second TagsResource object</param>
        /// <returns> boolean to show whether two objects are the same</returns>
        private bool CompareTagsResource(TagsResource tag1, TagsResource tag2)
        {
            if ((tag1 == null && tag2 == null) || (tag1.Properties.TagsProperty.Count == 0 && tag2.Properties.TagsProperty.Count == 0))
            {
                return true;
            }
            if ((tag1 == null || tag2 == null) || (tag1.Properties.TagsProperty.Count == 0 || tag2.Properties.TagsProperty.Count == 0))
            {
                return false;
            }
            foreach (var pair in tag1.Properties.TagsProperty)
            {
                if (!tag2.Properties.TagsProperty.ContainsKey(pair.Key) || tag2.Properties.TagsProperty[pair.Key] != pair.Value)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

