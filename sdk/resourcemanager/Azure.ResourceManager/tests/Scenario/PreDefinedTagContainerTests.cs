// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.s

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class PredefinedTagContainerTests : ResourceManagerTestBase
    {
        public PredefinedTagContainerTests(bool isAsync)
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

        [Test, Order(1)]
        [RecordedTest]
        public async Task Create()
        {
            var tagName = Recording.GenerateAssetName("tagName");
            var container = Client.DefaultSubscription.GetPredefinedTags();
            var result = await container.CreateOrUpdateAsync(tagName);
            Assert.IsTrue(result.Value.Data.TagName.Equals(tagName));
        }

        [Test, Order(1)]
        [RecordedTest]
        public async Task StartCreate()
        {
            var tagName = Recording.GenerateAssetName("tagName");
            var container = Client.DefaultSubscription.GetPredefinedTags();
            var result = await container.StartCreateOrUpdateAsync(tagName);
            Assert.IsTrue(result.Value.Data.TagName.Equals(tagName));
        }

        [Test, Order(2)]
        [RecordedTest]
        public async Task List()
        {
            var container = Client.DefaultSubscription.GetPredefinedTags();
            var result = await container.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(result.Count, 1, "List result less than 1");
            var expectTag = result.Where(x => x.Data.TagName.StartsWith("tagName")).FirstOrDefault();
            Assert.NotNull(expectTag);
        }
    }
}
