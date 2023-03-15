// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Maintenance.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Maintenance.Tests
{
    public sealed class MaintenanceApplyUpdateTests : MaintenanceManagementTestBase
    {
        private SubscriptionResource _subscription;
        private string rgGroupNamePrefix;
        private string assetName;
        private string providerName;
        private string resourceType;
        private string applyUpdateName;
        private string resourceParentType;

        public MaintenanceApplyUpdateTests(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
        { }

        [SetUp]
        public async Task Setup()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
            rgGroupNamePrefix = "testRg";
            assetName = "resource";
            providerName = "Microsoft.Maintenance";
            resourceType = "virtualNMachineScaleSets";
            applyUpdateName = "e9b9685d-78e4-44c4-a81c-64a14f9b87b6";
            resourceParentType = "virtualMachineScaleSets";
        }

        [RecordedTest]
        public async Task ApplyUpdatesGetParentTest()
        {
            ResourceGroupResource rg = await CreateResourceGroup(_subscription, rgGroupNamePrefix, new AzureLocation("EastUS2EUAP"));
            string resourceName = Recording.GenerateAssetName(assetName);
            string subscriptionId = _subscription.Id;
            string resourceParentName = "smdtest1";
            ResourceIdentifier resourceIdentifier = MaintenanceApplyUpdateResource.CreateResourceIdentifier(subscriptionId, rg.Data.Name, providerName, resourceType, resourceName, applyUpdateName);

            // invoke the operation
            ResourceGroupResourceGetApplyUpdatesByParentOptions options = new ResourceGroupResourceGetApplyUpdatesByParentOptions(providerName, resourceParentType, resourceParentName, resourceType, resourceName, applyUpdateName);
            MaintenanceApplyUpdateResource result = await rg.GetApplyUpdatesByParentAsync(options);
            MaintenanceApplyUpdateData resourceData = result.Data;
            Assert.AreEqual(resourceName, resourceData.Name);
            Assert.AreEqual(resourceType, resourceData.ResourceType);
            Assert.AreEqual((string)subscriptionId, resourceData.ResourceId);
        }

        [RecordedTest]
        public async Task ApplyUpdatesGetTest()
        {
            ResourceGroupResource rg = await CreateResourceGroup(_subscription, rgGroupNamePrefix, new AzureLocation("EastUS2EUAP"));
            string resourceName = Recording.GenerateAssetName(assetName);
            string subscriptionId = _subscription.Id;
            ResourceIdentifier resourceIdentifier = MaintenanceApplyUpdateResource.CreateResourceIdentifier(subscriptionId, rg.Data.Name, providerName, resourceType, resourceName, applyUpdateName);
            MaintenanceApplyUpdateResource maintenanceApplyUpdate = Client.GetMaintenanceApplyUpdateResource(resourceIdentifier);

            // invoke the operation
            MaintenanceApplyUpdateResource result = await maintenanceApplyUpdate.GetAsync();

            MaintenanceApplyUpdateData resourceData = result.Data;

            Assert.AreEqual(resourceName, resourceData.Name);
            Assert.AreEqual(resourceType, resourceData.ResourceType);
            Assert.AreEqual(((string)subscriptionId), resourceData.ResourceId);
        }

        [RecordedTest]
        public async Task ApplyUpdatesCreateOrUpdateParentTest()
        {
            ResourceGroupResource rg = await CreateResourceGroup(_subscription, rgGroupNamePrefix, new AzureLocation("EastUS2EUAP"));
            string resourceName = Recording.GenerateAssetName(assetName);
            string subscriptionId = _subscription.Id;
            string resourceParentName = "smdtest1";
            ResourceIdentifier resourceIdentifier = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, rg.Data.Name);

            MaintenanceApplyUpdateResource result = await rg.CreateOrUpdateApplyUpdateByParentAsync(providerName, resourceParentType,
                resourceParentName, resourceType, resourceName);

            MaintenanceApplyUpdateData resourceData = result.Data;

            Assert.AreEqual(resourceName, resourceData.Name);
            Assert.AreEqual(resourceType, resourceData.ResourceType);
            Assert.AreEqual(((string)subscriptionId), resourceData.ResourceId);
        }

        [RecordedTest]
        public async Task ApplyUpdatesCreateOrUpdateTest()
        {
            string subscriptionId = _subscription.Id;
            string resourceName = Recording.GenerateAssetName(assetName);
            ResourceGroupResource rg = await CreateResourceGroup(_subscription, rgGroupNamePrefix, new AzureLocation("EastUS2EUAP"));
            ResourceIdentifier resourceIdentifier = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, rg.Data.Name);

            // invoke the operation
            MaintenanceApplyUpdateResource result = await rg.CreateOrUpdateApplyUpdateAsync(providerName, resourceType, resourceName);

            MaintenanceApplyUpdateData resourceData = result.Data;

            Assert.AreEqual((string)subscriptionId, resourceData.ResourceId);
            Assert.AreEqual(resourceName, resourceData.Name);
            Assert.AreEqual(resourceType, resourceData.ResourceType);
        }
    }
}
