using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Maintenance.Tests.Scenario
{
    public sealed class MaintenancePublicConfigurationTests : MaintenanceManagementTestBase
    {
        private SubscriptionResource _subscription;

        public MaintenancePublicConfigurationTests(bool isAsync) : base(isAsync) { }

        [SetUp]
        public async Task Setup()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
        }

        [RecordedTest]
        public async Task MaintenancePublicConfigurationGetForResourceTest()
        {
            string assetName = "resource";
            string resourceName = Recording.GenerateAssetName(assetName);
            ResourceIdentifier maintenanceConfigurationResourceId = MaintenancePublicConfigurationResource.CreateResourceIdentifier(_subscription.Id, resourceName);
            MaintenancePublicConfigurationResource maintenancePublicConfiguration = Client.GetMaintenancePublicConfigurationResource(maintenanceConfigurationResourceId);

            MaintenancePublicConfigurationResource result = await maintenancePublicConfiguration.GetAsync();

            MaintenanceConfigurationData resourceData = result.Data;

            Assert.IsNotNull(resourceData);
        }
    }
}
