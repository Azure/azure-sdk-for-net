// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    public class TagsOperationsTests : ResourceManagerTestBase
    {
        private ResourceGroup _rg;
        private string _rgPrefix = "rg";

        public TagsOperationsTests(bool isAsync)
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

        [TestCaseSource(nameof(OperationType))]
        [RecordedTest]
        public async Task GetTagsRestOperations(TagsPatchResourceOperation type, IDictionary<string, string> expect)
        {
            var operation = Client.DefaultSubscription.GetTagsOperations();
            var restOperations = new TagsRestOperations(operation.Diagnostics, operation.Pipeline, Client.DefaultSubscription.Id.SubscriptionId, operation.BaseUri);
            var tags = new Tags();
            tags.TagsValue.Add("key1", "newValue1");
            tags.TagsValue.Add("newKey2", "value2");
            var tagsPatchResource = new TagsPatchResource() 
            { 
                Operation = type, 
                Properties = tags 
            };
            var result = await restOperations.UpdateAtScopeAsync(_rg.Id, tagsPatchResource).ConfigureAwait(false);
            CollectionAssert.AreEqual(
               result.Value.Properties.TagsValue.OrderBy(kv => kv.Key).ToList(),
               expect.OrderBy(kv => kv.Key).ToList()
            );
        }

        static IEnumerable<object[]> OperationType()
        {
            IDictionary<string, string> expectReplace = new Dictionary<string, string> { { "key1", "newValue1" }, { "newKey2", "value2" } };
            IDictionary<string, string> expectMerge = new Dictionary<string, string> { { "key1", "newValue1" }, { "key2", "value2" }, { "newKey2", "value2" } };
            IDictionary<string, string> expectDelete = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };

            return new[] { new object[] { TagsPatchResourceOperation.Replace, expectReplace },
                new object[] { TagsPatchResourceOperation.Merge, expectMerge },
                new object[] {TagsPatchResourceOperation.Delete, expectDelete }
            };
        }
    }
}
