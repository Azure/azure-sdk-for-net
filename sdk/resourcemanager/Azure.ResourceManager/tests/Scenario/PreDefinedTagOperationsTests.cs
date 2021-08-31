// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class PredefinedTagOperationsTests : ResourceManagerTestBase
    {
        public PredefinedTagOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeTearDown]
        protected async Task GlobalTagCleanupAsync()
        {
            var container = Client.DefaultSubscription.GetPredefinedTags();
            var listResult = (await container.GetAllAsync().ToEnumerableAsync()).Where(x => x.Data.TagName.StartsWith("tagName"));
            foreach (var item in listResult)
            {
                await item.DeleteAsync(item.Data.TagName).ConfigureAwait(false);
            };
        }

        [RecordedTest]
        [SyncOnly]
        public void NoDataValidation()
        {
            ///subscriptions/0accec26-d6de-4757-8e74-d080f38eaaab/tagNames/platformsettings.host_environment.service.platform_optedin_for_rootcerts
            var resource = Client.GetPreDefinedTag($"/subscriptions/{Guid.NewGuid()}/tagNames/fakeTagName");
            Assert.Throws<InvalidOperationException>(() => { var data = resource.Data; });
        }

        [TestCase]
        [RecordedTest]
        public void GetTagsOperation()
        {
            var operation = Client.GetPreDefinedTag($"/subscriptions/{Client.DefaultSubscription.Id.SubscriptionId}/tagNames/fakeTagName");
            string subscriptionId;
            Assert.IsTrue(operation.Id.TryGetSubscriptionId(out subscriptionId));
            Assert.AreEqual(subscriptionId, TestEnvironment.SubscriptionId);
        }

        [TestCase]
        [RecordedTest]
        public async Task ValueTest()
        {
            var tagName = Recording.GenerateAssetName("tagName");
            var container = Client.DefaultSubscription.GetPredefinedTags();
            PredefinedTag preDefinedTag = await container.CreateOrUpdateAsync(tagName).ConfigureAwait(false);
            // Assert create tag value
            var createValue = await preDefinedTag.CreateOrUpdateValueAsync(tagName, "testValue").ConfigureAwait(false);
            Assert.IsTrue(createValue.Value.TagValueValue.Equals("testValue"));
            // Assert delete tag value
            await preDefinedTag.DeleteValueAsync(tagName, "testValue").ConfigureAwait(false);
            var listResult = await container.GetAllAsync().ToEnumerableAsync();
            var expectTag = listResult.Where(x => x.Data.TagName == tagName).FirstOrDefault();
            var expectValue = expectTag.Data.Values.Where(x => x.TagValueValue == "testValue").FirstOrDefault();
            Assert.IsNull(expectValue);
        }

        [TestCase]
        [RecordedTest]
        public async Task DeleteTag()
        {
            var tagName = Recording.GenerateAssetName("tagName");
            var container = Client.DefaultSubscription.GetPredefinedTags();
            PredefinedTag preDefinedTag = await container.CreateOrUpdateAsync(tagName).ConfigureAwait(false);
            await preDefinedTag.DeleteAsync(tagName).ConfigureAwait(false);
            var listResult = await container.GetAllAsync().ToEnumerableAsync();
            var expectTag = listResult.Where(x => x.Data.TagName.Equals(tagName)).FirstOrDefault();
            Assert.IsNull(expectTag);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartDelete()
        {
            var tagName = Recording.GenerateAssetName("tagName");
            var container = Client.DefaultSubscription.GetPredefinedTags();
            PredefinedTag preDefinedTag = await container.CreateOrUpdateAsync(tagName).ConfigureAwait(false);
            await preDefinedTag.StartDeleteAsync(tagName).ConfigureAwait(false);
            var listResult = await container.GetAllAsync().ToEnumerableAsync();
            var expectTag = listResult.Where(x => x.Data.TagName.Equals(tagName)).FirstOrDefault();
            Assert.IsNull(expectTag);
        }
    }
}
