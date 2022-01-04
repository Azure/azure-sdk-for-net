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
        private PredefinedTag _predefinedTag;

        public PredefinedTagOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TearDown]
        protected async Task TagCleanupAsync()
        {
            if(_predefinedTag != null)
                _ = await _predefinedTag.DeleteAsync(_predefinedTag.Data.TagName);
        }

        [RecordedTest]
        [SyncOnly]
        public void NoDataValidation()
        {
            _predefinedTag = null;
            ///subscriptions/0accec26-d6de-4757-8e74-d080f38eaaab/tagNames/platformsettings.host_environment.service.platform_optedin_for_rootcerts
            var resource = Client.GetPreDefinedTag(new ResourceIdentifier($"/subscriptions/{Guid.NewGuid()}/tagNames/fakeTagName"));
            Assert.Throws<InvalidOperationException>(() => { var data = resource.Data; });
        }

        [TestCase]
        [RecordedTest]
        public async Task GetTagsOperation()
        {
            _predefinedTag = null;
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false); 
            var operation = Client.GetPreDefinedTag(new ResourceIdentifier($"/subscriptions/{subscription.Id.SubscriptionId}/tagNames/fakeTagName"));
            Assert.NotNull(operation.Id.SubscriptionId);
            Assert.AreEqual(operation.Id.SubscriptionId, TestEnvironment.SubscriptionId);
        }

        [TestCase]
        [RecordedTest]
        public async Task ValueTest()
        {
            var tagName = Recording.GenerateAssetName("tagName");
            var collection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetPredefinedTags();
            var preDefinedTagOp = await collection.CreateOrUpdateAsync(tagName).ConfigureAwait(false);
            _predefinedTag = preDefinedTagOp.Value;
            // Assert create tag value
            var createValue = await _predefinedTag.CreateOrUpdateValueAsync(tagName, "testValue").ConfigureAwait(false);
            Assert.IsTrue(createValue.Value.TagValueValue.Equals("testValue"));
            // Assert delete tag value
            await _predefinedTag.DeleteValueAsync(tagName, "testValue").ConfigureAwait(false);
            var listResult = await collection.GetAllAsync().ToEnumerableAsync();
            var expectTag = listResult.Where(x => x.Data.TagName == tagName).FirstOrDefault();
            var expectValue = expectTag.Data.Values.Where(x => x.TagValueValue == "testValue").FirstOrDefault();
            Assert.IsNull(expectValue);
        }

        [TestCase]
        [RecordedTest]
        public async Task DeleteTag()
        {
            var tagName = Recording.GenerateAssetName("tagName");
            var collection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetPredefinedTags();
            var preDefinedTagOp = await collection.CreateOrUpdateAsync(tagName).ConfigureAwait(false);
            _predefinedTag = preDefinedTagOp.Value;
            await _predefinedTag.DeleteAsync(tagName).ConfigureAwait(false);
            var listResult = await collection.GetAllAsync().ToEnumerableAsync();
            var expectTag = listResult.Where(x => x.Data.TagName.Equals(tagName)).FirstOrDefault();
            Assert.IsNull(expectTag);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartDelete()
        {
            var tagName = Recording.GenerateAssetName("tagName");
            var collection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetPredefinedTags();
            var preDefinedTagOp = InstrumentOperation(await collection.CreateOrUpdateAsync(tagName).ConfigureAwait(false));
            _predefinedTag = preDefinedTagOp.Value;
            await _predefinedTag.DeleteAsync(tagName, false).ConfigureAwait(false);
            var listResult = await collection.GetAllAsync().ToEnumerableAsync();
            var expectTag = listResult.Where(x => x.Data.TagName.Equals(tagName)).FirstOrDefault();
            Assert.IsNull(expectTag);
        }
    }
}
