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
        private PredefinedTag _predefinedTag;

        public PredefinedTagCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TearDown]
        protected async Task TagCleanupAsync()
        {
            if (_predefinedTag != null)
                _ = await _predefinedTag.DeleteAsync(_predefinedTag.Data.TagName);
        }

        [Test, Order(1)]
        [RecordedTest]
        public async Task Create()
        {
            var tagName = Recording.GenerateAssetName("tagName");
            var collection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetPredefinedTags();
            var result = await collection.CreateOrUpdateAsync(tagName);
            _predefinedTag = result.Value;
            Assert.IsTrue(result.Value.Data.TagName.Equals(tagName));
        }

        [Test, Order(1)]
        [RecordedTest]
        public async Task StartCreate()
        {
            var tagName = Recording.GenerateAssetName("tagName");
            var collection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetPredefinedTags();
            var result = await collection.CreateOrUpdateAsync(tagName);
            _predefinedTag = result.Value;
            Assert.IsTrue(result.Value.Data.TagName.Equals(tagName));
        }

        [Test, Order(2)]
        [RecordedTest]
        public async Task List()
        {
            var tagName = Recording.GenerateAssetName("tagName");
            var collection = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetPredefinedTags();
            var tagLro = await collection.CreateOrUpdateAsync(tagName);
            _predefinedTag = tagLro.Value;
            var result = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(result.Count, 1, "List result less than 1");
            var expectTag = result.Where(x => x.Data.TagName.StartsWith("tagName")).FirstOrDefault();
            Assert.NotNull(expectTag);
        }
    }
}
