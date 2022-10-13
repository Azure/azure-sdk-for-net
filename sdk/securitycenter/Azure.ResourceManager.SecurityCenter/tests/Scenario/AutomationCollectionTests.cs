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
    internal class AutomationCollectionTests : SecurityCenterManagementTestBase
    {
        private AutomationCollection _automationCollection => _resourceGroup.GetAutomations();
        private ResourceGroupResource _resourceGroup;

        public AutomationCollectionTests(bool isAsync) : base(isAsync,RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string automationName = Recording.GenerateAssetName("automation");
            AutomationData data = new AutomationData(_resourceGroup.Data.Location)
            {
            };
            var automation = await _automationCollection.CreateOrUpdateAsync(WaitUntil.Completed, automationName, data);
            Assert.IsNotNull(automation);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _automationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        private void ValidateAscLocation(AscLocationResource ascLocation, string ascLocationName)
        {
            Assert.IsNotNull(ascLocation);
            Assert.IsNotNull(ascLocation.Data.Id);
            Assert.AreEqual(ascLocationName, ascLocation.Data.Name);
            Assert.AreEqual("Microsoft.Security/locations", ascLocation.Data.ResourceType.ToString());
        }
    }
}
