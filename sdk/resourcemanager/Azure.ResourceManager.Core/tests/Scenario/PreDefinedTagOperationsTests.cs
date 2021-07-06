// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    public class PreDefinedTagOperationsTests : ResourceManagerTestBase
    {
        public PreDefinedTagOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeTearDown]
        protected async Task GlobalTagCleanupAsync()
        {
            var container = Client.DefaultSubscription.GetPredefinedTags();
            var operation = Client.DefaultSubscription.GetPreDefinedTagOperations();
            var listResult = (await container.ListAsync().ToEnumerableAsync()).Where(x => x.Data.TagName.StartsWith("tagName"));
            foreach (var item in listResult)
            {
                await item.DeleteAsync(item.Data.TagName).ConfigureAwait(false);
            };
        }

        [TestCase]
        [RecordedTest]
        public void GetTagsOperation()
        {
            var operation = Client.DefaultSubscription.GetPreDefinedTagOperations();
            string subscriptionId;
            Assert.IsTrue(operation.Id.TryGetSubscriptionId(out subscriptionId));
            Assert.AreEqual(subscriptionId, TestEnvironment.SubscriptionId);
        }

        [TestCase]
        [RecordedTest]
        public async Task ValueTest()
        {
            var tagName = Recording.GenerateAssetName("tagName");
            var operation = Client.DefaultSubscription.GetPreDefinedTagOperations();
            var container = Client.DefaultSubscription.GetPredefinedTags();
            await container.CreateOrUpdateAsync(tagName).ConfigureAwait(false);
            // Assert create tag value
            var createValue = await operation.CreateOrUpdateValueAsync(tagName, "testValue").ConfigureAwait(false);
            Assert.IsTrue(createValue.Value.TagValueValue.Equals("testValue"));
            // Assert delete tag value
            await operation.DeleteValueAsync(tagName, "testValue").ConfigureAwait(false);
            var listResult = await container.ListAsync().ToEnumerableAsync();
            var expectTag = listResult.Where(x => x.Data.TagName == tagName).FirstOrDefault();
            var expectValue = expectTag.Data.Values.Where(x => x.TagValueValue == "testValue").FirstOrDefault();
            Assert.IsNull(expectValue);
        }

        [TestCase]
        [RecordedTest]
        public async Task DeleteTag()
        {
            var tagName = Recording.GenerateAssetName("tagName");
            var operation = Client.DefaultSubscription.GetPreDefinedTagOperations();
            var container = Client.DefaultSubscription.GetPredefinedTags();
            await container.CreateOrUpdateAsync(tagName).ConfigureAwait(false);
            await operation.DeleteAsync(tagName).ConfigureAwait(false);
            var listResult = await container.ListAsync().ToEnumerableAsync();
            var expectTag = listResult.Where(x => x.Data.TagName.Equals(tagName)).FirstOrDefault();
            Assert.IsNull(expectTag);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartDelete()
        {
            var tagName = Recording.GenerateAssetName("tagName");
            var operation = Client.DefaultSubscription.GetPreDefinedTagOperations();
            var container = Client.DefaultSubscription.GetPredefinedTags();
            await container.CreateOrUpdateAsync(tagName).ConfigureAwait(false);
            await operation.StartDeleteAsync(tagName).ConfigureAwait(false);
            var listResult = await container.ListAsync().ToEnumerableAsync();
            var expectTag = listResult.Where(x => x.Data.TagName.Equals(tagName)).FirstOrDefault();
            Assert.IsNull(expectTag);
        }
    }
}
