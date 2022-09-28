// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Dynatrace.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Dynatrace.Tests
{
    public class MonitorResourceOperationsTests : DynatraceManagementTestBase
    {
        public MonitorResourceOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Creation of dynatrace monitor will fail and need fix.")]
        public async Task Get()
        {
            string monitorName = Recording.GenerateAssetName("testDT-");
            DynatraceMonitorResource monitorResource1 = await CreateMonitorResourceAsync(monitorName);
            DynatraceMonitorResource monitorResource2 = await monitorResource1.GetAsync();

            Assert.AreEqual(monitorResource1.Data.Name, monitorResource2.Data.Name);
            Assert.AreEqual(monitorResource1.Data.Id, monitorResource2.Data.Id);
            Assert.AreEqual(monitorResource1.Data.ResourceType, monitorResource2.Data.ResourceType);
            Assert.AreEqual(monitorResource1.Data.Location, monitorResource2.Data.Location);
            Assert.AreEqual(monitorResource1.Data.Tags, monitorResource2.Data.Tags);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Creation of dynatrace monitor will fail and need fix.")]
        public async Task GetVMPayload()
        {
            string monitorName = Recording.GenerateAssetName("testDT-");
            DynatraceMonitorResource monitorResource = await CreateMonitorResourceAsync(monitorName);

            var payload = monitorResource.GetVmHostPayloadAsync().Result.Value;

            Assert.AreEqual(payload.EnvironmentId, monitorResource.Data.DynatraceEnvironmentProperties.EnvironmentInfo.EnvironmentId);
        }
    }
}
