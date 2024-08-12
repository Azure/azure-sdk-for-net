// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Confluent.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Confluent.Tests
{
    public class ConfluentManagementTestBase : ManagementRecordedTestBase<ConfluentManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected AzureLocation DefaultLocation => "eastus2euap";
        public static ResourceGroupResource _resourceGroup;
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected ConfluentManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ConfluentManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }
        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            _resourceGroup = await CreateResourceGroupAsync();
            Console.WriteLine("DefaultSubscription: " + DefaultSubscription.GetAsync().Status);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            Console.WriteLine("Create Resource group ----");
            string rgName = Recording.GenerateAssetName("SDKTestLiftrConfluent");
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            Console.WriteLine("ResourceGroup: " + lro.Value.Id);
            _resourceGroup = lro.Value;
            return _resourceGroup;
        }

        protected ConfluentOrganizationCollection GetConfluentOrganizationCollectionAsync()
        {
            return _resourceGroup.GetConfluentOrganizations();
        }
    }
}
