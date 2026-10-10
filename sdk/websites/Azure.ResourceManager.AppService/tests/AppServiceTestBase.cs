// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.AppService.Tests
{
    public class AppServiceTestBase : ManagementRecordedTestBase<AppServiceTestEnviroment>
    {
        protected AzureLocation DefaultLocation => AzureLocation.EastUS;
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        public AppServiceTestBase(bool isAsync) : base(isAsync)
        {
            // After migrating to the TypeSpec generator, operations returning no body no longer send the
            // "Accept" header. Existing recordings still include it, so allow Accept to differ without
            // breaking the match.
            LegacyExcludedHeaders.Add("Accept");
        }

        public AppServiceTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            LegacyExcludedHeaders.Add("Accept");
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
