// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class PredefinedTagOperationsTests : ResourceManagerTestBase
    {
        private string _tagName;
        private SubscriptionResource _subscription;

        public PredefinedTagOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TearDown]
        protected async Task TagCleanupAsync()
        {
            var tags = await _subscription.GetAllPredefinedTagsAsync().ToEnumerableAsync();
            if (tags.Any(tag => tag.TagName.Equals(_tagName)))
            {
                _ = await _subscription.DeletePredefinedTagAsync(_tagName);
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task ValueTest()
        {
            _tagName = Recording.GenerateAssetName("tagName");
            _subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var preDefinedTagOp = await _subscription.CreateOrUpdatePredefinedTagAsync(_tagName).ConfigureAwait(false);
            // Assert create tag value
            var createValue = await _subscription.CreateOrUpdatePredefinedTagValueAsync(_tagName, "testValue").ConfigureAwait(false);
            Assert.IsTrue(createValue.Value.TagValue.Equals("testValue"));
            // Assert delete tag value
            await _subscription.DeletePredefinedTagValueAsync(_tagName, "testValue").ConfigureAwait(false);
            var listResult = await _subscription.GetAllPredefinedTagsAsync().ToEnumerableAsync();
            var expectTag = listResult.Where(x => x.TagName == _tagName).FirstOrDefault();
            var expectValue = expectTag.Values.Where(x => x.TagValue == "testValue").FirstOrDefault();
            Assert.IsNull(expectValue);
        }

        [TestCase]
        [RecordedTest]
        public async Task DeleteTag()
        {
            _tagName = Recording.GenerateAssetName("tagName");
            _subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var preDefinedTagOp = await _subscription.CreateOrUpdatePredefinedTagAsync(_tagName).ConfigureAwait(false);
            await _subscription.DeletePredefinedTagAsync(_tagName).ConfigureAwait(false);
            var listResult = await _subscription.GetAllPredefinedTagsAsync().ToEnumerableAsync();
            var expectTag = listResult.Where(x => x.TagName.Equals(_tagName)).FirstOrDefault();
            Assert.IsNull(expectTag);
        }
    }
}
