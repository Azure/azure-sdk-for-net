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
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.IotFirmwareDefense.Tests
{
    public class SummaryTest : IotFirmwareDefenseManagementTestBase
    {
        private static readonly string subscriptionId = "07aed47b-60ad-4d6e-a07a-89b602418441";
        private static readonly string rgName = "sdk-tests-rg";
        private static readonly string workspaceName = "default";
        private static readonly string firmwareId = "cf833be1-3e8e-a00a-a037-ad27a0fc0497";
        private static SubscriptionResource testSubscription;

        public SummaryTest(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void setup()
        {
            var _ = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            testSubscription = Client.GetSubscriptionResource(_);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetFirmwareSummary()
        {
            var summaryName = SummaryName.Firmware;
            ResourceGroupResource testRg = await testSubscription.GetResourceGroupAsync(rgName);
            FirmwareWorkspaceResource testWorkspace = await testRg.GetFirmwareWorkspaceAsync(workspaceName);
            FirmwareResource testFirmware = await testWorkspace.GetFirmwareAsync(firmwareId);

            var response = await testFirmware.GetSummaryResourceAsync(summaryName);
            FirmwareSummary summary = (FirmwareSummary) response.Value.Data.Properties;
            Assert.AreEqual(summary.SummaryType.ToString(), summaryName.ToString());
            Assert.Greater(summary.FileSize, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetBinaryHardeningSummary()
        {
            var summaryName = SummaryName.BinaryHardening;
            ResourceGroupResource testRg = await testSubscription.GetResourceGroupAsync(rgName);
            FirmwareWorkspaceResource testWorkspace = await testRg.GetFirmwareWorkspaceAsync(workspaceName);
            FirmwareResource testFirmware = await testWorkspace.GetFirmwareAsync(firmwareId);

            var response = await testFirmware.GetSummaryResourceAsync(summaryName);
            BinaryHardeningSummary summary = (BinaryHardeningSummary) response.Value.Data.Properties;
            Assert.AreEqual(summary.SummaryType.ToString(), summaryName.ToString());
            Assert.GreaterOrEqual(summary.Nx, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCveSummary()
        {
            var summaryName = SummaryName.CVE;
            ResourceGroupResource testRg = await testSubscription.GetResourceGroupAsync(rgName);
            FirmwareWorkspaceResource testWorkspace = await testRg.GetFirmwareWorkspaceAsync(workspaceName);
            FirmwareResource testFirmware = await testWorkspace.GetFirmwareAsync(firmwareId);

            var response = await testFirmware.GetSummaryResourceAsync(summaryName);
            CveSummary summary = (CveSummary) response.Value.Data.Properties;
            Assert.AreEqual(summary.SummaryType.ToString(), summaryName.ToString());
            Assert.GreaterOrEqual(summary.Critical, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCryptoCertificateSummary()
        {
            var summaryName = SummaryName.FirmwareCryptoCertificate;
            ResourceGroupResource testRg = await testSubscription.GetResourceGroupAsync(rgName);
            FirmwareWorkspaceResource testWorkspace = await testRg.GetFirmwareWorkspaceAsync(workspaceName);
            FirmwareResource testFirmware = await testWorkspace.GetFirmwareAsync(firmwareId);

            var response = await testFirmware.GetSummaryResourceAsync(summaryName);
            FirmwareCryptoCertificateSummary summary = (FirmwareCryptoCertificateSummary) response.Value.Data.Properties;
            Assert.AreEqual(summary.SummaryType.ToString(), summaryName.ToString());
            Assert.GreaterOrEqual(summary.TotalCertificates, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCryptoKeySummary()
        {
            var summaryName = SummaryName.FirmwareCryptoKey;
            ResourceGroupResource testRg = await testSubscription.GetResourceGroupAsync(rgName);
            FirmwareWorkspaceResource testWorkspace = await testRg.GetFirmwareWorkspaceAsync(workspaceName);
            FirmwareResource testFirmware = await testWorkspace.GetFirmwareAsync(firmwareId);

            var response = await testFirmware.GetSummaryResourceAsync(summaryName);
            FirmwareCryptoKeySummary summary = (FirmwareCryptoKeySummary) response.Value.Data.Properties;
            Assert.AreEqual(summary.SummaryType.ToString(), summaryName.ToString());
            Assert.GreaterOrEqual(summary.TotalKeys, 0);
        }
    }
}
