// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class TaggableResourceTests : ResourceManagerTestBase
    {
        private static readonly IDictionary<string, string> UpdateTags = new Dictionary<string, string> { { "UpdateKey1", "UpdateValue1" }, { "UpdateKey2", "UpdateValue2" } };
        private static readonly IDictionary<string, string> ExpectedAddTags = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" }, { "UpdateKey3", "UpdateValue3" } };
        private static readonly IDictionary<string, string> OriTags = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };

        private ResourceGroupResource _rg;
        private string _rgPrefix = "rg";

        public TaggableResourceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUpAsync()
        {
            var rgOp = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName(_rgPrefix));
            _rg = rgOp.Value;
            _rg = await _rg.AddTagAsync("key1", "value1");
            _rg = await _rg.AddTagAsync("key2", "value2");
        }

        [TestCaseSource(nameof(TagAddSource))]
        [RecordedTest]
        public async Task TestAddTags(string key, string value, IDictionary<string, string> tags)
        {
            if (key is null || value is null)
            {
                var ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await _rg.AddTagAsync(key, value));
                Assert.That(ex.Message.Contains("Value cannot be null"));
            }
            else
            {
                var result = await _rg.AddTagAsync(key, value);
                Assert.AreEqual(result.Value.Data.Tags, tags);
            }
        }

        [Test]
        [RecordedTest]
        public async Task TestSetTags()
        {
            var result = await _rg.SetTagsAsync(UpdateTags);
            Assert.AreEqual(result.Value.Data.Tags, UpdateTags);
        }

        [TestCaseSource(nameof(TagRemoveSource))]
        [RecordedTest]
        public async Task TestRemoveTag(string key, IDictionary<string, string> tags)
        {
            var result = await _rg.RemoveTagAsync(key);
            Assert.AreEqual(result.Value.Data.Tags, tags);
        }

        static IEnumerable<object[]> TagAddSource()
        {
            IDictionary<string, string> keyChangeTag = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" }, { "UpdateKey1", "value1" } };
            IDictionary<string, string> valueChangeTag = new Dictionary<string, string> { { "key1", "updateValue1" }, { "key2", "value2" } };

            return new[] { new object[] { "key1", "value1", OriTags },
                new object[] {"key1", "updateValue1", valueChangeTag },
                new object[] {"UpdateKey1", "value1", keyChangeTag },
                new object[] {null, "nullValue", OriTags },
                new object[] { "nullKey", null, OriTags }
            };
        }

        static IEnumerable<object[]> TagRemoveSource()
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
