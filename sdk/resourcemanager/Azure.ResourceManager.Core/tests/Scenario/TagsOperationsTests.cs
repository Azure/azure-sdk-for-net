// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        public async Task CRUDTest()
        {
            var tagName = Recording.GenerateAssetName("tagName");
            var operation = GetTagsOperations();
            var createTag = await operation.CreateOrUpdateAsync(tagName);
            Assert.IsTrue(createTag.Value.TagName.Equals(tagName));
            var createValue = await operation.CreateOrUpdateValueAsync(tagName, "testValue");
            Assert.IsTrue(createValue.Value.TagValueValue.Equals("testValue"));
            var listResult = await operation.ListAsync().ToEnumerableAsync();
            var expectTag = listResult.Where(x => x.TagName == tagName).FirstOrDefault();
            Assert.NotNull(expectTag);
            await operation.DeleteValueAsync(tagName, "testValue").ConfigureAwait(false);
            await operation.DeleteAsync(tagName).ConfigureAwait(false);
            listResult = await operation.ListAsync().ToEnumerableAsync();
            expectTag = listResult.Where(x => x.TagName.Equals(tagName)).FirstOrDefault();
            Assert.IsNull(expectTag);
            // In progress
        }

        protected TagsOperations GetTagsOperations()
        {
            return new TagsOperations(new ClientContext(Client.DefaultSubscription.ClientOptions, Client.DefaultSubscription.Credential, Client.DefaultSubscription.BaseUri, Client.DefaultSubscription.Pipeline), Client.DefaultSubscription.Id);
        }

    }
}
