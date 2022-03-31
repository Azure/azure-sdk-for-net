// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace Azure.ResourceManager.Resources.Tests
{
    public class JitRequestResourceOperationsTests : ResourcesTestBase
    {
        private string _tagKey;
        private string TagKey => _tagKey ??= Recording.GenerateAssetName("TagKey-");
        private string _tagValue;
        private string TagValue => _tagValue ??= Recording.GenerateAssetName("TagValue-");

        public JitRequestResourceOperationsTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        public async Task AddTag()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-7-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            //string jitRequestName = Recording.GenerateAssetName("jitrequestEx-D-");
            string jitRequestName = "91fbb00f-e4e1-4f08-979c-7e2bf5ce58b1";
            JitRequestData jData = CreateJitRequestData(AzureLocation.WestUS2);
            JitRequestResource jitRequestResource = (await rg.GetJitRequests().CreateOrUpdateAsync(WaitUntil.Completed, jitRequestName, jData)).Value;
            var jitRequestResource2 = await jitRequestResource.AddTagAsync(TagKey, TagValue);
            Assert.IsTrue(jitRequestResource2.Value.Data.Tags.ContainsKey(TagKey));
            Assert.AreEqual(jitRequestResource2.Value.Data.Tags[TagKey], TagValue);
        }

        [RecordedTest]
        public async Task RemoveTag()
        {
            await AddTag();
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-7-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string jitRequestName = Recording.GenerateAssetName("jitrequestEx-D-");
            JitRequestData jData = CreateJitRequestData(AzureLocation.WestUS2);
            JitRequestResource jitRequestResource = (await rg.GetJitRequests().CreateOrUpdateAsync(WaitUntil.Completed, jitRequestName, jData)).Value;
            var jitRequestResource2 = await jitRequestResource.RemoveTagAsync(TagKey);
            Assert.IsFalse(jitRequestResource2.Value.Data.Tags.ContainsKey(TagKey));
        }

        [RecordedTest]
        public async Task SetTags()
        {
            await AddTag();
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-7-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string jitRequestName = Recording.GenerateAssetName("jitrequestEx-D-");
            JitRequestData jData = CreateJitRequestData(AzureLocation.WestUS2);
            JitRequestResource jitRequestResource = (await rg.GetJitRequests().CreateOrUpdateAsync(WaitUntil.Completed, jitRequestName, jData)).Value;
            var key = Recording.GenerateAssetName("TagKey-");
            var value = Recording.GenerateAssetName("TagValue-");
            var tags = new Dictionary<string, string>();
            var jitRequestResource2 = await subscription.SetTagsAsync(tags);
            Assert.IsFalse(jitRequestResource2.Value.Data.Tags.ContainsKey(TagKey));
            Assert.IsTrue(jitRequestResource2.Value.Data.Tags.ContainsKey(key));
            Assert.AreEqual(jitRequestResource2.Value.Data.Tags[key], value);
        }
    }
}
