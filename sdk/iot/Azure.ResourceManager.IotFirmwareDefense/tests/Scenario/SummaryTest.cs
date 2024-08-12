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
            var summaryName = FirmwareAnalysisSummaryName.Firmware;
            ResourceGroupResource testRg = await testSubscription.GetResourceGroupAsync(rgName);
            FirmwareAnalysisWorkspaceResource testWorkspace = await testRg.GetFirmwareAnalysisWorkspaceAsync(workspaceName);
            IotFirmwareResource testFirmware = await testWorkspace.GetIotFirmwareAsync(firmwareId);

            var response = await testFirmware.GetFirmwareAnalysisSummaryAsync(summaryName);
            FirmwareSummary summary = (FirmwareSummary) response.Value.Data.Properties;
            Assert.AreEqual(summary.SummaryType.ToString(), summaryName.ToString());
            Assert.Greater(summary.FileSize, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetBinaryHardeningSummary()
        {
            var summaryName = FirmwareAnalysisSummaryName.BinaryHardening;
            ResourceGroupResource testRg = await testSubscription.GetResourceGroupAsync(rgName);
            FirmwareAnalysisWorkspaceResource testWorkspace = await testRg.GetFirmwareAnalysisWorkspaceAsync(workspaceName);
            IotFirmwareResource testFirmware = await testWorkspace.GetIotFirmwareAsync(firmwareId);

            var response = await testFirmware.GetFirmwareAnalysisSummaryAsync(summaryName);
            BinaryHardeningSummary summary = (BinaryHardeningSummary) response.Value.Data.Properties;
            Assert.AreEqual(summary.SummaryType.ToString(), summaryName.ToString());
            Assert.GreaterOrEqual(summary.NXPercentage, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCveSummary()
        {
            var summaryName = FirmwareAnalysisSummaryName.Cve;
            ResourceGroupResource testRg = await testSubscription.GetResourceGroupAsync(rgName);
            FirmwareAnalysisWorkspaceResource testWorkspace = await testRg.GetFirmwareAnalysisWorkspaceAsync(workspaceName);
            IotFirmwareResource testFirmware = await testWorkspace.GetIotFirmwareAsync(firmwareId);

            var response = await testFirmware.GetFirmwareAnalysisSummaryAsync(summaryName);
            CveSummary summary = (CveSummary) response.Value.Data.Properties;
            Assert.AreEqual(summary.SummaryType.ToString(), summaryName.ToString());
            Assert.GreaterOrEqual(summary.Critical, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCryptoCertificateSummary()
        {
            var summaryName = FirmwareAnalysisSummaryName.CryptoCertificate;
            ResourceGroupResource testRg = await testSubscription.GetResourceGroupAsync(rgName);
            FirmwareAnalysisWorkspaceResource testWorkspace = await testRg.GetFirmwareAnalysisWorkspaceAsync(workspaceName);
            IotFirmwareResource testFirmware = await testWorkspace.GetIotFirmwareAsync(firmwareId);

            var response = await testFirmware.GetFirmwareAnalysisSummaryAsync(summaryName);
            CryptoCertificateSummary summary = (CryptoCertificateSummary) response.Value.Data.Properties;
            Assert.AreEqual(summary.SummaryType.ToString(), summaryName.ToString());
            Assert.GreaterOrEqual(summary.TotalCertificates, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCryptoKeySummary()
        {
            var summaryName = FirmwareAnalysisSummaryName.CryptoKey;
            ResourceGroupResource testRg = await testSubscription.GetResourceGroupAsync(rgName);
            FirmwareAnalysisWorkspaceResource testWorkspace = await testRg.GetFirmwareAnalysisWorkspaceAsync(workspaceName);
            IotFirmwareResource testFirmware = await testWorkspace.GetIotFirmwareAsync(firmwareId);

            var response = await testFirmware.GetFirmwareAnalysisSummaryAsync(summaryName);
            CryptoKeySummary summary = (CryptoKeySummary) response.Value.Data.Properties;
            Assert.AreEqual(summary.SummaryType.ToString(), summaryName.ToString());
            Assert.GreaterOrEqual(summary.TotalKeys, 0);
        }
    }
}
