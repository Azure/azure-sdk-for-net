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
        [Ignore("The test subscription cannot purchase the SaaS because the payment instrument is invalid")]
        public async Task Get()
        {
            string monitorName = Recording.GenerateAssetName("testDT-");
            DynatraceMonitorResource monitorResource1 = await CreateMonitorResourceAsync(monitorName);
            DynatraceMonitorResource monitorResource2 = await monitorResource1.GetAsync();

            Assert.That(monitorResource2.Data.Name, Is.EqualTo(monitorResource1.Data.Name));
            Assert.That(monitorResource2.Data.Id, Is.EqualTo(monitorResource1.Data.Id));
            Assert.That(monitorResource2.Data.ResourceType, Is.EqualTo(monitorResource1.Data.ResourceType));
            Assert.That(monitorResource2.Data.Location, Is.EqualTo(monitorResource1.Data.Location));
            Assert.That(monitorResource2.Data.Tags, Is.EqualTo(monitorResource1.Data.Tags));
        }

        [TestCase]
        [RecordedTest]
        [Ignore("The test subscription cannot purchase the SaaS because the payment instrument is invalid")]
        public async Task GetVMPayload()
        {
            string monitorName = Recording.GenerateAssetName("testDT-");
            DynatraceMonitorResource monitorResource = await CreateMonitorResourceAsync(monitorName);

            var payload = monitorResource.GetVmHostPayloadAsync().Result.Value;

            Assert.That(monitorResource.Data.DynatraceEnvironmentProperties.EnvironmentInfo.EnvironmentId, Is.EqualTo(payload.EnvironmentId));
        }
    }
}
