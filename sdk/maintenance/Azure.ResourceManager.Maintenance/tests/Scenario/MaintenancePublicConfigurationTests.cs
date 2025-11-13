// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Maintenance.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Maintenance.Tests
{
    public sealed class MaintenancePublicConfigurationTests : MaintenanceManagementTestBase
    {
        public MaintenancePublicConfigurationTests(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
        { }

        // TODO: This test is commented out for patch release.
        //[RecordedTest]
        //public async Task MaintenancePublicConfigurationGetForResourceTest()
        //{
        //    //string assetName = "maintenance-config-";
        //    string subscriptionId = "eee2cef4-bc47-4278-b4f8-cfc65f25dfd8";
        //    string resourceName = "aks-mrp-cfg-weekday_utc-7-eastus2euap";
        //    ResourceIdentifier maintenanceConfigurationResourceId = MaintenancePublicConfigurationResource.CreateResourceIdentifier(subscriptionId, resourceName);
        //    MaintenancePublicConfigurationResource maintenancePublicConfiguration = Client.GetMaintenancePublicConfigurationResource(maintenanceConfigurationResourceId);

        //    MaintenancePublicConfigurationResource result = await maintenancePublicConfiguration.GetAsync();

        //    MaintenanceConfigurationData resourceData = result.Data;

        //    Assert.IsNotNull(resourceData);
        //    Assert.IsTrue(resourceData.MaintenanceScope.Equals(MaintenanceScope.Resource));
        //}
    }
}
