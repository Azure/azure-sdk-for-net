// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.s

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class PredefinedTagCollectionTests : ResourceManagerTestBase
    {
        private string _tagName;
        private SubscriptionResource _subscription;

        public PredefinedTagCollectionTests(bool isAsync)
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

        [Test, Order(1)]
        [RecordedTest]
        public async Task Create()
        {
            _tagName = Recording.GenerateAssetName("tagName");
            _subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var result = await _subscription.CreateOrUpdatePredefinedTagAsync(_tagName);
            Assert.IsTrue(result.Value.TagName.Equals(_tagName));
        }

        [Test, Order(1)]
        [RecordedTest]
        public async Task StartCreate()
        {
            _tagName = Recording.GenerateAssetName("tagName");
            _subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var result = await _subscription.CreateOrUpdatePredefinedTagAsync(_tagName);
            Assert.IsTrue(result.Value.TagName.Equals(_tagName));
        }

        [Test, Order(2)]
        [RecordedTest]
        public async Task List()
        {
            _tagName = Recording.GenerateAssetName("tagName");
            _subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var tagLro = await _subscription.CreateOrUpdatePredefinedTagAsync(_tagName);
            var result = await _subscription.GetAllPredefinedTagsAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(result.Count, 1, "List result less than 1");
            var expectTag = result.Where(x => x.TagName.StartsWith("tagName")).FirstOrDefault();
            Assert.NotNull(expectTag);
        }
    }
}
