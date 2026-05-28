// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Subscription.Tests
{
    public class SubscriptionManagementTestBase : ManagementRecordedTestBase<SubscriptionManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected SubscriptionManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            IgnoreApiVersionInTagOperations();
        }

        protected SubscriptionManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            IgnoreApiVersionInTagOperations();
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        private void IgnoreApiVersionInTagOperations()
        {
            // Ignore the api-version of tagNames operations including list
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                @"/subscriptions/[^/]+/tagNames[/]?[^/]*api-version=(?<group>[a-z0-9-]+)")
            {
                GroupForReplace = "group",
                Value = "**"
            });
            // Ignore the api-version of tagValues operations
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                @"/subscriptions/[^/]+/tagNames/[^/]+/tagValues/[^/]+api-version=(?<group>[a-z0-9-]+)")
            {
                GroupForReplace = "group",
                Value = "**"
            });
        }
    }
}
