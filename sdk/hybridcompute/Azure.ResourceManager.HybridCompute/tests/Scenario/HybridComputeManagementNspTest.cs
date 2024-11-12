// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HybridCompute;
using NUnit.Framework;
using Azure.Core;
using Azure.ResourceManager.HybridCompute.Models;
using System.Diagnostics;

namespace Azure.ResourceManager.HybridCompute.Tests.Scenario
{
    public class HybridComputeManagementNspTest : HybridComputeManagementTestBase
    {
        public HybridComputeManagementNspTest(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CanGetNsp()
        {
            NetworkSecurityPerimeterConfigurationData resourceData = await getNsp();
            Assert.AreEqual(perimeterName, resourceData.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CanGetNspCollection()
        {
            NetworkSecurityPerimeterConfigurationCollection resourceCollection = await getNspCollection();
            Assert.IsNotNull(resourceCollection);
        }

        [TestCase]
        [RecordedTest]
        public async Task CanInvokeNsp()
        {
            await invokeNsp();
        }
    }
}
