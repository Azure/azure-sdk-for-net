// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class ComputeTestBase : ManagementRecordedTestBase<ComputeTestEnvironment>
    {
        protected AzureLocation DefaultLocation => AzureLocation.WestUS2;
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        public ComputeTestBase(bool isAsync) : base(isAsync)
        {
            IgnoreAcceptHeader();
        }

        public ComputeTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            IgnoreAcceptHeader();
        }

        protected ComputeTestBase(bool isAsync, ResourceType resourceType, string apiVersion, RecordedTestMode? mode = null)
            : base(isAsync, resourceType, apiVersion, mode)
        {
            IgnoreAcceptHeader();
        }

        private void IgnoreAcceptHeader()
        {
            // The migrated generator no longer emits Accept consistently for all management operations.
            // Ignore it so playback matching focuses on semantic request changes.
            LegacyExcludedHeaders.Add("Accept");

            UriRegexSanitizers.Add(
                new UriRegexSanitizer("/resourceGroups/")
                {
                    Value = "/resourcegroups/"
                });
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            var resourceGroupName = Recording.GenerateAssetName("testRG-");
            var rgOp = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(DefaultLocation)
                {
                    Tags =
                    {
                        { "test", "env" }
                    }
                });
            return rgOp.Value;
        }
    }
}
