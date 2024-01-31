using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class TagResourceOperationsTests : ResourceManagerTestBase
    {
        private static readonly IDictionary<string, string> OriTags = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };

        public TagResourceOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        public async Task ValidateSetTags()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var rgOp = await subscription.GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroupResource rg = rgOp.Value;
            GenericResource availabilitySetResource = await CreateGenericAvailabilitySetAsync(rg.Id);

            // change the tags using TagResource
            var tagResource = availabilitySetResource.GetTagResource();
            var tagData = new TagResourceData(new Resources.Models.Tag());
            tagData.TagValues.ReplaceWith(OriTags);
            await tagResource.CreateOrUpdateAsync(WaitUntil.Completed, tagData);

            // fetch the new data on the availability set
            availabilitySetResource = await availabilitySetResource.GetAsync();
            CollectionAssert.AreEquivalent(OriTags, availabilitySetResource.Data.Tags);
        }
    }
}
