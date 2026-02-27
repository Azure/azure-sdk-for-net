// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Discovery.Tests
{
    /// <summary>
    /// Base class for Azure.ResourceManager.Discovery tests.
    /// Provides ARM client creation and common test utilities.
    /// </summary>
    public class DiscoveryManagementTestBase : ManagementRecordedTestBase<DiscoveryManagementTestEnvironment>
    {
        private const string EuapHost = "eastus2euap.management.azure.com";
        protected AzureLocation DefaultLocation => new AzureLocation("centraluseuap");
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        public DiscoveryManagementTestBase(bool isAsync) : base(isAsync)
        {
        }

        public DiscoveryManagementTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        [SetUp]
        public async Task SetUpAsync()
        {
            // Use EUAP endpoint for 2026-02-01-preview API
            var armOptions = new ArmClientOptions();
            var euapEndpoint = Environment.GetEnvironmentVariable("AZURE_ARM_ENDPOINT") ?? $"https://{EuapHost}";
            armOptions.Environment = new ArmEnvironment(new Uri(euapEndpoint), "https://management.azure.com/.default");

            // Add redirect policy to ensure all requests go to EUAP endpoint
            // This is needed because the SDK routes based on resource location
            armOptions.AddPolicy(new RedirectToEuapPolicy(EuapHost), HttpPipelinePosition.PerRetry);

            Client = GetArmClient(armOptions);
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new resource group for testing.
        /// </summary>
        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            var resourceGroupName = Recording.GenerateAssetName("discovery-rg-");
            var rgOp = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(DefaultLocation)
                {
                    Tags =
                    {
                        { "test", "discovery" }
                    }
                });
            return rgOp.Value;
        }

        /// <summary>
        /// Gets an existing resource group by name.
        /// </summary>
        protected async Task<ResourceGroupResource> GetResourceGroupAsync(string resourceGroupName)
        {
            return await DefaultSubscription.GetResourceGroups().GetAsync(resourceGroupName);
        }
    }
}
