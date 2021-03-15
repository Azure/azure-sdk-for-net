// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests.Management
{
    internal class ManagementRecordedTestBaseTests : ManagementRecordedTestBase<TestEnvironmentTests.MockTestEnvironment>
    {
        public ManagementRecordedTestBaseTests(bool isAsync)
            : base(isAsync)
        {
            TestDiagnostics = false;
        }

        [Test]
        public void ValidateInstrumentTopLevelClient()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var result = client.Method();

            Assert.AreEqual("ManagementTestClientProxy", client.GetType().Name);
            Assert.AreEqual("success", result);
        }

        [Test]
        public void ValidateInstrumentDefaultSubscription()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var sub = client.DefaultSubscription;
            var result = sub.Method();

            Assert.AreEqual("ManagementTestOperationsProxy", sub.GetType().Name);
            Assert.AreEqual("success", result);
        }

        [Test]
        public async Task ValidateInstrumentArmOperation()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var sub = client.DefaultSubscription;
            var operation = (await sub.GetArmOperationAsync()).Value;
            var result = operation.Method();

            Assert.AreEqual("ManagementTestOperationsProxy", operation.GetType().Name);
            Assert.AreEqual("success", result);
        }

        [Test]
        public async Task ValidateInstrumentArmResponse()
        {
            ManagementTestClient client = InstrumentClient(new ManagementTestClient());
            var sub = client.DefaultSubscription;
            var response = (await sub.GetArmOperationAsync()).Value;
            var result = response.Method();

            Assert.AreEqual("ManagementTestOperationsProxy", response.GetType().Name);
            Assert.AreEqual("success", result);
        }
    }
}
