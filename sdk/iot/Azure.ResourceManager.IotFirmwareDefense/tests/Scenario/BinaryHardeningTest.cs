// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using FluentAssertions;
using NUnit.Framework;
using Azure.ResourceManager.IotFirmwareDefense.Models;

namespace Azure.ResourceManager.IotFirmwareDefense.Tests
{
    public class BinaryHardeningTest : IotFirmwareDefenseManagementTestBase
    {
        private static readonly string rgName = "testRg";
        private static ResourceGroupResource testRg;
        private static FirmwareWorkspaceResource testWorkspace;
        private static FirmwareResource testFirmware;
        private static BinaryHardeningResult testBinaryHardeningResult;

        public BinaryHardeningTest(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async void setup()
        {
            FirmwareData testFirmwareData = new FirmwareData
            {
                FileName = "testFileName",
                FileSize = 1,
                Vendor = "testVendor",
                Model = "testModel",
                Version = "testVersion",
                Description = "testDescription"
            };

            testBinaryHardeningResult = new BinaryHardeningResult
            {
                BinaryHardeningId = Recording.GenerateId(),
                Architecture = "testArch",
                FilePath = "/test/file/path",
                Class = "testCpuClass",
                Runpath = "testRunpath",
                Rpath = "testRpath",
                Nx = true,
                Pie = false,
                Relro = true,
                Canary = false,
                Stripped = true
            };

            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            testRg = await CreateResourceGroup(subscription, rgName, AzureLocation.EastUS);
            testWorkspace = await CreateWorkspace(testRg);
            testFirmware = await CreateFirmware(testWorkspace, testFirmwareData);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetBinaryHardeningResults()
        {
            BinaryHardeningListResult response = await testFirmware.GetBinaryHardeningResultsAsync();
            // response.value[0].id.Should().Equals(testBinaryHardeningResult.BinaryHardeningId);
        }
    }
}
