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
            var container = GetTagsContainer();
            var operation = GetTagsOperations();
            var listResult = container.List().Where(x => x.TagName.StartsWith("tagName"));
            foreach (var item in listResult)
            {
                operation.Delete(item.TagName);
            };
        }

        [TestCase]
        [RecordedTest]
        public void GetTagsOperation()
        {
            var operation = GetTagsOperations();
            string subscriptionId;
            Assert.IsTrue(operation.Id.TryGetSubscriptionId(out subscriptionId));
            Assert.AreEqual(subscriptionId, TestEnvironment.SubscriptionId);
        }

        [TestCase]
        [RecordedTest]
        public async Task ValueTest()
        {
            var tagName = Recording.GenerateAssetName("tagName");
            var operation = GetTagsOperations();
            var container = GetTagsContainer();
            await container.CreateOrUpdateAsync(tagName).ConfigureAwait(false);
            // Assert create tag value
            var createValue = await operation.CreateOrUpdateValueAsync(tagName, "testValue").ConfigureAwait(false);
            Assert.IsTrue(createValue.Value.TagValueValue.Equals("testValue"));
            // Assert delete tag value
            await operation.DeleteValueAsync(tagName, "testValue").ConfigureAwait(false);
            var listResult = await container.ListAsync().ToEnumerableAsync();
            var expectTag = listResult.Where(x => x.TagName == tagName).FirstOrDefault();
            var expectValue = expectTag.Values.Where(x => x.TagValueValue == "testValue").FirstOrDefault();
            Assert.IsNull(expectValue);
        }

        [TestCase]
        [RecordedTest]
        public async Task DeleteTag()
        {
            var tagName = Recording.GenerateAssetName("tagName");
            var operation = GetTagsOperations();
            var container = GetTagsContainer();
            await container.CreateOrUpdateAsync(tagName).ConfigureAwait(false);
            await operation.DeleteAsync(tagName).ConfigureAwait(false);
            var listResult = await container.ListAsync().ToEnumerableAsync();
            var expectTag = listResult.Where(x => x.TagName.Equals(tagName)).FirstOrDefault();
            Assert.IsNull(expectTag);
        }

        protected TagsContainer GetTagsContainer()
        {
            return new TagsContainer(new ClientContext(Client.DefaultSubscription.ClientOptions, Client.DefaultSubscription.Credential, Client.DefaultSubscription.BaseUri, Client.DefaultSubscription.Pipeline), Client.DefaultSubscription.Id.SubscriptionId);
        }

        protected TagsOperations GetTagsOperations()
        {
            return new TagsOperations(new ClientContext(Client.DefaultSubscription.ClientOptions, Client.DefaultSubscription.Credential, Client.DefaultSubscription.BaseUri, Client.DefaultSubscription.Pipeline), Client.DefaultSubscription.Id.SubscriptionId);
        }
    }
}
