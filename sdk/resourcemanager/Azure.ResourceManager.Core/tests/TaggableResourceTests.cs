// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Ignore("Will remove after ADO 5122")]
    [TestFixture]
    public class TaggableResourceTests
    {
        private static readonly IDictionary<string, string> UpdateTags = new Dictionary<string, string> { { "UpdateKey1", "UpdateValue1" }, { "UpdateKey2", "UpdateValue2" } };
        private static readonly IDictionary<string, string> OriTags = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };

        private ResourceGroup _rg;

        [SetUp]
        public void GlobalSetUp()
        {
            var armClient = new AzureResourceManagerClient();
            _rg = armClient.DefaultSubscription.GetResourceGroupContainer().Construct(LocationData.WestUS2).CreateOrUpdate($"{Environment.UserName}-rg-{Environment.TickCount}").Value;

            _rg = _rg.AddTag("key1", "value1");
            _rg = _rg.AddTag("key2", "value2");
        }

        [TearDown]
        public void GlobalTearDown()
        {
            _rg.StartDelete();
        }

        [Test]
        public void TestSetTagsActivator()
        {
            var result = _rg.SetTags(UpdateTags);
            Assert.AreEqual(result.Value.Data.Tags, UpdateTags);
        }

        [Test]
        public async Task TestSetTagsAsyncActivator()
        {
            var result = await _rg.SetTagsAsync(UpdateTags);
            Assert.AreEqual(result.Value.Data.Tags, UpdateTags);
        }

        [Test]
        public void TestStartSetTagsActivator()
        {
            var result = _rg.StartSetTags(UpdateTags).WaitForCompletionAsync().Result;
            Assert.AreEqual(result.Value.Data.Tags, UpdateTags);
        }

        [Test]
        public async Task TestStartSetTagsAsyncActivator()
        {
            var result = await _rg.StartSetTagsAsync(UpdateTags);
            Assert.AreEqual(result.Value.Data.Tags, UpdateTags);
        }

        [TestCaseSource(nameof(TagSource))]
        public void TestRemoveTagActivator(string key, IDictionary<string, string> tags)
        {
            var result = _rg.RemoveTag(key);
            Assert.AreEqual(result.Value.Data.Tags, tags);
        }

        [TestCaseSource(nameof(TagSource))]
        public async Task TestRemoveTagAsyncActivator(string key, IDictionary<string, string> tags)
        {
            var result = await _rg.RemoveTagAsync(key);
            Assert.AreEqual(result.Value.Data.Tags, tags);
        }

        [TestCaseSource(nameof(TagSource))]
        public void TestStartRemoveTagActivator(string key, IDictionary<string, string> tags)
        {
            var result = _rg.StartRemoveTag(key).WaitForCompletionAsync().Result;
            Assert.AreEqual(result.Value.Data.Tags, tags);
        }

        [TestCaseSource(nameof(TagSource))]
        public async Task TestStartRemoveTagAsyncActivator(string key, IDictionary<string, string> tags)
        {
            var result = await _rg.StartRemoveTagAsync(key);
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
