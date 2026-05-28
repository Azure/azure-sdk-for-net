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
            var summaryType = FirmwareAnalysisSummaryType.Firmware;
            ResourceGroupResource testRg = await testSubscription.GetResourceGroupAsync(rgName);
            FirmwareAnalysisWorkspaceResource testWorkspace = await testRg.GetFirmwareAnalysisWorkspaceAsync(workspaceName);
            IotFirmwareResource testFirmware = await testWorkspace.GetIotFirmwareAsync(firmwareId);

            var response = await testFirmware.GetFirmwareAnalysisSummaryAsync(summaryType);
            FirmwareSummary summary = (FirmwareSummary) response.Value.Data.Properties;
            Assert.AreEqual(summary.SummaryType.ToString(), summaryType.ToString());
            Assert.Greater(summary.FileSize, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetBinaryHardeningSummary()
        {
            var summaryType = FirmwareAnalysisSummaryType.BinaryHardening;
            ResourceGroupResource testRg = await testSubscription.GetResourceGroupAsync(rgName);
            FirmwareAnalysisWorkspaceResource testWorkspace = await testRg.GetFirmwareAnalysisWorkspaceAsync(workspaceName);
            IotFirmwareResource testFirmware = await testWorkspace.GetIotFirmwareAsync(firmwareId);

            var response = await testFirmware.GetFirmwareAnalysisSummaryAsync(summaryType);
            BinaryHardeningSummary summary = (BinaryHardeningSummary) response.Value.Data.Properties;
            Assert.AreEqual(summary.SummaryType.ToString(), summaryType.ToString());
            Assert.GreaterOrEqual(summary.NotExecutableStackCount, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCommonVulnerabilitiesAndExposuresSummary()
        {
            var summaryType = FirmwareAnalysisSummaryType.CommonVulnerabilitiesAndExposures;
            ResourceGroupResource testRg = await testSubscription.GetResourceGroupAsync(rgName);
            FirmwareAnalysisWorkspaceResource testWorkspace = await testRg.GetFirmwareAnalysisWorkspaceAsync(workspaceName);
            IotFirmwareResource testFirmware = await testWorkspace.GetIotFirmwareAsync(firmwareId);

            var response = await testFirmware.GetFirmwareAnalysisSummaryAsync(summaryType);
            CveSummary summary = (CveSummary) response.Value.Data.Properties;
            Assert.AreEqual(summary.SummaryType.ToString(), summaryType.ToString());
            Assert.GreaterOrEqual(summary.CriticalCveCount, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCryptoCertificateSummary()
        {
            var summaryType = FirmwareAnalysisSummaryType.CryptoCertificate;
            ResourceGroupResource testRg = await testSubscription.GetResourceGroupAsync(rgName);
            FirmwareAnalysisWorkspaceResource testWorkspace = await testRg.GetFirmwareAnalysisWorkspaceAsync(workspaceName);
            IotFirmwareResource testFirmware = await testWorkspace.GetIotFirmwareAsync(firmwareId);

            var response = await testFirmware.GetFirmwareAnalysisSummaryAsync(summaryType);
            CryptoCertificateSummary summary = (CryptoCertificateSummary) response.Value.Data.Properties;
            Assert.AreEqual(summary.SummaryType.ToString(), summaryType.ToString());
            Assert.GreaterOrEqual(summary.TotalCertificateCount, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetCryptoKeySummary()
        {
            var summaryType = FirmwareAnalysisSummaryType.CryptoKey;
            ResourceGroupResource testRg = await testSubscription.GetResourceGroupAsync(rgName);
            FirmwareAnalysisWorkspaceResource testWorkspace = await testRg.GetFirmwareAnalysisWorkspaceAsync(workspaceName);
            IotFirmwareResource testFirmware = await testWorkspace.GetIotFirmwareAsync(firmwareId);

            var response = await testFirmware.GetFirmwareAnalysisSummaryAsync(summaryType);
            CryptoKeySummary summary = (CryptoKeySummary) response.Value.Data.Properties;
            Assert.AreEqual(summary.SummaryType.ToString(), summaryType.ToString());
            Assert.GreaterOrEqual(summary.TotalKeyCount, 0);
        }
    }
}
