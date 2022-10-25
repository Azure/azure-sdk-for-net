// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class ResourceGroupLocationAlertTests : SecurityCenterManagementTestBase
    {
        //private ResourceGroupResource _resourceGroup;
        //private ResourceGroupLocationAlertCollection _resourceGroupLocationAlertCollection;
        public ResourceGroupLocationAlertTests(bool isAsync) : base(isAsync)//,RecordedTestMode.Record)
        {
        }

        //[SetUp]
        //public async Task TestSetUp()
        //{
        //    DefaultLocation = AzureLocation.CentralUS;
        //    _resourceGroup = await CreateResourceGroup();
        //    _resourceGroupLocationAlertCollection = _resourceGroup.GetResourceGroupSecurityAlerts();.GetResourceGroupLocationAlerts(DefaultLocation);
        //}

        //[RecordedTest]
        //public async Task GetAll()
        //{
        //    var list  = await _resourceGroupLocationAlertCollection.GetAllAsync().ToEnumerableAsync();
        //    Assert.IsEmpty(list);
        //}
    }
}
