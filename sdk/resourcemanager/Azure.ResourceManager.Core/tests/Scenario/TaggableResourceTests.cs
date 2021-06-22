// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    public class TaggableResourceTests : ResourceManagerTestBase
    {
        private static readonly IDictionary<string, string> UpdateTags = new Dictionary<string, string> { { "UpdateKey1", "UpdateValue1" }, { "UpdateKey2", "UpdateValue2" } };
        private static readonly IDictionary<string, string> ExpectedAddTags = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" }, { "UpdateKey3", "UpdateValue3" } };
        private static readonly IDictionary<string, string> OriTags = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };

        private ResourceGroup _rg;
        private string _rgPrefix = "rg";

        public TaggableResourceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUpAsync()
        {
            _rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName(_rgPrefix));
            _rg = await _rg.AddTagAsync("key1", "value1");
            _rg = await _rg.AddTagAsync("key2", "value2");
        }

        [Test]
        [RecordedTest]
        public async Task TestAddTags()
        {
            var result = await _rg.AddTagAsync("UpdateKey3", "UpdateValue3");
            Assert.AreEqual(result.Value.Data.Tags, ExpectedAddTags);
        }

        [Test]
        [RecordedTest]
        public async Task TestStartAddTags()
        {
            var result = await (await _rg.StartAddTagAsync("UpdateKey3", "UpdateValue3")).WaitForCompletionAsync();
            Assert.AreEqual(result.Value.Data.Tags, ExpectedAddTags);
        }

        [Test]
        [RecordedTest]
        public async Task TestSetTags()
        {
            var result = await _rg.SetTagsAsync(UpdateTags);
            Assert.AreEqual(result.Value.Data.Tags, UpdateTags);
        }

        [Test]
        [RecordedTest]
        public async Task TestStartSetTags()
        {
            var result = await (await _rg.StartSetTagsAsync(UpdateTags)).WaitForCompletionAsync();
            Assert.AreEqual(result.Value.Data.Tags, UpdateTags);
        }

        [TestCaseSource(nameof(TagSource))]
        [RecordedTest]
        public async Task TestRemoveTag(string key, IDictionary<string, string> tags)
        {
            var result = await _rg.RemoveTagAsync(key);
            Assert.AreEqual(result.Value.Data.Tags, tags);
        }

        [TestCaseSource(nameof(TagSource))]
        [RecordedTest]
        public async Task TestStartRemoveTag(string key, IDictionary<string, string> tags)
        {
            var result = await (await _rg.StartRemoveTagAsync(key)).WaitForCompletionAsync();
            Assert.AreEqual(result.Value.Data.Tags, tags);
        }

        static IEnumerable<object[]> TagSource()
        {
            IDictionary<string, string> OriKey1 = new Dictionary<string, string> { { "key1", "value1" } };
            IDictionary<string, string> OriKey2 = new Dictionary<string, string> { { "key2", "value2" } };

            return new[] { new object[] {"key1", OriKey2 },
                new object[] {"key2", OriKey1 },
                new object[] {"NullKey", OriTags }
            };
        }
    }
}
