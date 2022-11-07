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
    internal class AdaptiveApplicationControlGroupTests : SecurityCenterManagementTestBase
    {
        private AdaptiveApplicationControlGroupCollection _adaptiveApplicationControlGroupCollection => GetAdaptiveApplicationControlGroupCollection().Result;
        public AdaptiveApplicationControlGroupTests(bool isAsync) : base(isAsync)
        {
        }

        private async Task<AdaptiveApplicationControlGroupCollection> GetAdaptiveApplicationControlGroupCollection(string existAscLocationName = "centralus")
        {
            var ascLocation = await DefaultSubscription.GetSecurityCenterLocations().GetAsync(existAscLocationName);
            return ascLocation.Value.GetAdaptiveApplicationControlGroups();
        }

        [SetUp]
        public void TestSetUp()
        {
        }

        [RecordedTest]
        [Ignore("The SDK doesn't support create a AdaptiveApplicationControlGroupResource")]
        public async Task Update()
        {
            string groupName = "TestGroup";

            // Update
            var data = new AdaptiveApplicationControlGroupData()
            {
                ProtectionMode = new SecurityCenterFileProtectionMode()
                {
                    Exe = "Audit",
                    Msi = "None",
                    Script = "None",
                },
            };
            var adaptiveApplicationControlGroup = await _adaptiveApplicationControlGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, groupName, data);
            Assert.IsNotNull(adaptiveApplicationControlGroup);

            // Exist
            bool flag = await _adaptiveApplicationControlGroupCollection.ExistsAsync(groupName);
            Assert.IsTrue(flag);

            // Get
            var getAdaptiveApplicationControlGroup = await _adaptiveApplicationControlGroupCollection.GetAsync(groupName);
            Assert.IsNotNull(getAdaptiveApplicationControlGroup);

            // Delete
            await adaptiveApplicationControlGroup.Value.DeleteAsync(WaitUntil.Completed);
            flag = await _adaptiveApplicationControlGroupCollection.ExistsAsync(groupName);
            Assert.IsFalse(flag);
        }
    }
}
