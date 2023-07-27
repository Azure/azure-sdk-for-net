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
    internal class ResourceGroupLocationTaskTests : SecurityCenterManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceGroupSecurityTaskCollection _resourceGroupLocationTaskCollection;

        public ResourceGroupLocationTaskTests(bool isAsync) : base(isAsync)// ,RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            DefaultLocation = AzureLocation.CentralUS;
            _resourceGroup = await CreateResourceGroup();
            _resourceGroupLocationTaskCollection = _resourceGroup.GetResourceGroupSecurityTasks(DefaultLocation);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _resourceGroupLocationTaskCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
