// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    public class TagsOperationsTests : ResourceManagerTestBase
    {
        public TagsOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeTearDown]
        protected void GlobalTagCleanup()
        {
            var operation = GetTagsOperations();
            var listResult = operation.List().Where(x => x.TagName.StartsWith("tagName"));
            foreach (var item in listResult)
            {
                operation.Delete(item.TagName);
            };
            operation.DeleteAtScope("subscriptions/" + operation.Id.SubscriptionId);
        }

        [TestCase]
        [RecordedTest]
        public void GetTagsOperation()
        {
            var operation = GetTagsOperations();
            Assert.AreEqual(operation.Id.SubscriptionId, TestEnvironment.SubscriptionId);
        }

        [TestCase]
        [RecordedTest]
        public async Task CRUDTests()
        {
            var tagName = Recording.GenerateAssetName("tagName");
            var operation = GetTagsOperations();
            // Assert create tag
            var createTag = await operation.CreateOrUpdateAsync(tagName);
            Assert.IsTrue(createTag.Value.TagName.Equals(tagName));
            // Assert create tag value
            var createValue = await operation.CreateOrUpdateValueAsync(tagName, "testValue");
            Assert.IsTrue(createValue.Value.TagValueValue.Equals("testValue"));
            // Assert tag list, created tag exists
            var listResult = await operation.ListAsync().ToEnumerableAsync();
            var expectTag = listResult.Where(x => x.TagName == tagName).FirstOrDefault();
            Assert.IsTrue(expectTag.TagName.Equals(tagName));
            // Assert delete tag value
            await operation.DeleteValueAsync(tagName, "testValue").ConfigureAwait(false);
            expectTag = listResult.Where(x => x.TagName == tagName).FirstOrDefault();
            var expectValue = expectTag.Values.Where(x => x.TagValueValue == "testValue").FirstOrDefault();
            Assert.IsTrue(expectValue.TagValueValue.Equals("testValue"));
            // Assert delete tag
            await operation.DeleteAsync(tagName).ConfigureAwait(false);
            listResult = await operation.ListAsync().ToEnumerableAsync();
            expectTag = listResult.Where(x => x.TagName.Equals(tagName)).FirstOrDefault();
            Assert.IsNull(expectTag);
        }

        [TestCase]
        [RecordedTest]
        public async Task ScopeTests()
        {
            // Assert create at subscription scope
            var tagData = new Dictionary<string, string>();
            tagData.Add("tag1", "value1");
            tagData.Add("tag2", "value2");
            var operation = GetTagsOperations();
            var tagsResource = new TagsResource(new TagsData(tagData));
            var createResponse = await operation.CreateOrUpdateAtScopeAsync("subscriptions/" + operation.Id.SubscriptionId, tagsResource).ConfigureAwait(false);
            Assert.IsTrue(createResponse.Value.Properties.TagsValue.Count == 2);
            // Assert get at subscription scope
            var getResponse = await operation.GetAtScopeAsync("subscriptions/" + operation.Id.SubscriptionId).ConfigureAwait(false);
            Assert.IsTrue(getResponse.Value.Properties.TagsValue.ContainsKey("tag2"));
            // Assert update at subscription scope
            var tagPatch = new TagsPatchResource() { Operation = TagsPatchResourceOperation.Replace };
            tagPatch.Properties = new TagsData();
            tagPatch.Properties.TagsValue.Add("tag1", "newValue");
            tagPatch.Properties.TagsValue.Add("newTag2", "value2");
            var updateResponse = await operation.UpdateAtScopeAsync("subscriptions/" + operation.Id.SubscriptionId, tagPatch).ConfigureAwait(false);
            var updateResult = updateResponse.Value;
            Assert.IsTrue(updateResult.Properties.TagsValue.Contains(new KeyValuePair<string, string>("tag1", "newValue")));
            Assert.IsTrue(updateResult.Properties.TagsValue.Contains(new KeyValuePair<string, string>("newTag2", "value2")));
            Assert.IsTrue(!updateResult.Properties.TagsValue.Contains(new KeyValuePair<string, string>("tag1", "value1")));
            Assert.IsTrue(!updateResult.Properties.TagsValue.Contains(new KeyValuePair<string, string>("tag2", "value2")));
            // Assert delete at subscription scope
            await operation.DeleteAtScopeAsync("subscriptions/" + operation.Id.SubscriptionId).ConfigureAwait(false);
            getResponse = await operation.GetAtScopeAsync("subscriptions/" + operation.Id.SubscriptionId).ConfigureAwait(false);
            Assert.IsTrue(getResponse.Value.Properties.TagsValue.Count == 0);
        }

        protected TagsOperations GetTagsOperations()
        {
            return new TagsOperations(new ClientContext(Client.DefaultSubscription.ClientOptions, Client.DefaultSubscription.Credential, Client.DefaultSubscription.BaseUri, Client.DefaultSubscription.Pipeline), Client.DefaultSubscription.Id);
        }

    }
}
