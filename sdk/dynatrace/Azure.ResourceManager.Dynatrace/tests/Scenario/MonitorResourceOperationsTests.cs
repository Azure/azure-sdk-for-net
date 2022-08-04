// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Dynatrace.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Dynatrace.Tests
{
    public class MonitorResourceOperationsTests : MonitorTestBase
    {
        public MonitorResourceOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetMonitorResourceCollectionAsync();
            string monitorName = Recording.GenerateAssetName("testDT-");

            var input = GetMonitorInput();

            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, monitorName, input);
            MonitorResource monitorResource1 = lro.Value;

            MonitorResource monitorResource2 = await collection.GetAsync(monitorName);

            Assert.AreEqual(monitorResource1.Data.Name, monitorResource2.Data.Name);
            Assert.AreEqual(monitorResource1.Data.Id, monitorResource2.Data.Id);
            Assert.AreEqual(monitorResource1.Data.ResourceType, monitorResource2.Data.ResourceType);
            Assert.AreEqual(monitorResource1.Data.Location, monitorResource2.Data.Location);
            Assert.AreEqual(monitorResource1.Data.Tags, monitorResource2.Data.Tags);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetVMPayload()
        {
            string monitorName = Recording.GenerateAssetName("testDT-");
            MonitorResource monitorResource = await CreateMonitorResourceAsync(monitorName);

            var payload = monitorResource.GetVmHostPayloadAsync().Result.Value;

            Assert.AreEqual(payload.EnvironmentId, monitorResource.Data.DynatraceEnvironmentProperties.EnvironmentInfo.EnvironmentId);
        }
    }
}
