// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Avs.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Avs.Tests.Scenario
{
    public class PrivateCloudResourceTest: AvsManagementTestBase
    {
        public PrivateCloudResourceTest(bool isAsync) : base(isAsync)
        {
        }

        [TestCase, Order(1)]
        [RecordedTest]
        public async Task Get()
        {
            var privateCloudResource = await  getAvsPrivateCloudResource();
            Assert.That(privateCloudResource.Data.Name, Is.EqualTo(PRIVATE_CLOUD_NAME));
        }

        [TestCase, Order(2)]
        [RecordedTest]
        public async Task Update()
        {
            var privateCloudResource = await getAvsPrivateCloudResource();
            AvsPrivateCloudPatch patch = new AvsPrivateCloudPatch();
            patch.Tags.Add("sdk-test", "sdk-test");
            ArmOperation<AvsPrivateCloudResource> lro = await privateCloudResource.UpdateAsync(WaitUntil.Completed, patch);
            Assert.That(lro.Value.Data.Tags.ContainsKey("sdk-test"), Is.True);
        }

        [TestCase, Order(3)]
        [RecordedTest]
        public async Task RotateNsxtPassword()
        {
            var privateCloudResource = await getAvsPrivateCloudResource();
            ArmOperation lro = await privateCloudResource.RotateNsxtPasswordAsync(WaitUntil.Started);
        }

         [TestCase]
         [RecordedTest]
        public async Task Delete()
        {
            var privateCloudResource = await getAvsPrivateCloudResource();
            ArmOperation lro = await privateCloudResource.DeleteAsync(WaitUntil.Started);
        }
    }
}
