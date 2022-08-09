// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ContainerRegistry.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.ContainerRegistry.Tests
{
    public class ContainerRegistryManagementTestBase : ManagementRecordedTestBase<ContainerRegistryManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected SubscriptionResource Subscription { get; private set; }

        // protected static Dictionary<string, string> DefaultTags = new Dictionary<string, string>
        // {
        //     { "key1","value1"},
        //     { "key2","value2"}
        // };
        // protected static Dictionary<string, string> DefaultNewTags = new Dictionary<string, string>
        // {
        //     { "key2","value2"},
        //     { "key3","value3"},
        //     { "key4","value4"}
        // };

        protected static Uri DefaultWebhookServiceUri = new Uri("http://www.microsoft.com");

        protected ContainerRegistryManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ContainerRegistryManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            Subscription = await Client.GetDefaultSubscriptionAsync();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<ContainerRegistryResource> CreateContainerRegistryAsync(ResourceGroupResource resourceGroup, string registryName)
        {
            var registryData = new ContainerRegistryData(resourceGroup.Data.Location, new ContainerRegistrySku(ContainerRegistrySkuName.Premium))
            {
                Tags =
                {
                    { "key1","value1"},
                    { "key2","value2"}
                }
            };
            var lro = await resourceGroup.GetContainerRegistries().CreateOrUpdateAsync(WaitUntil.Completed, registryName, registryData);
            return lro.Value;
        }

        protected async Task<ContainerRegistryWebhookResource> CreateContainerWebhookAsync(ContainerRegistryResource registry, string webhookName)
        {
            var content = new ContainerRegistryWebhookCreateOrUpdateContent(registry.Data.Location)
            {
                ServiceUri = DefaultWebhookServiceUri,
                Actions =
                {
                    ContainerRegistryWebhookAction.Push
                },
                Tags =
                {
                    { "key1","value1"},
                    { "key2","value2"}
                }
            };
            var lro = await registry.GetContainerRegistryWebhooks().CreateOrUpdateAsync(WaitUntil.Completed, webhookName, content);
            return lro.Value;
        }
    }
}
