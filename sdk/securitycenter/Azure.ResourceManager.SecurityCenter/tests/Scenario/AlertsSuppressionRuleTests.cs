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
    internal class AlertsSuppressionRuleTests : SecurityCenterManagementTestBase
    {
        private AlertsSuppressionRuleCollection _alertsSuppressionRuleCollection => DefaultSubscription.GetAlertsSuppressionRules();
        private const string _existAscLocationName = "centralus";

        public AlertsSuppressionRuleTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void TestSetUp()
        {
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var data = new AlertsSuppressionRuleData()
            {
                AlertType = "VM_EICAR",
            };
            var xx = await _alertsSuppressionRuleCollection.CreateOrUpdateAsync(WaitUntil.Completed, "JustForTest", data);

            var list = await _alertsSuppressionRuleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            await xx.Value.DeleteAsync(WaitUntil.Completed);
            list = await _alertsSuppressionRuleCollection.GetAllAsync().ToEnumerableAsync();
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
