// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.IotFirmwareDefense.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.IotFirmwareDefense.Tests
{
    public class CompatibilityTests
    {
        private static IEnumerable<TestCaseData> SummaryFactories()
        {
            yield return SummaryFactory(() => ArmIotFirmwareDefenseModelFactory.FirmwareSummary(provisioningState: FirmwareProvisioningState.Succeeded), "Firmware");
            yield return SummaryFactory(() => ArmIotFirmwareDefenseModelFactory.CveSummary(provisioningState: FirmwareProvisioningState.Succeeded), "CommonVulnerabilitiesAndExposures");
            yield return SummaryFactory(() => ArmIotFirmwareDefenseModelFactory.BinaryHardeningSummary(provisioningState: FirmwareProvisioningState.Succeeded), "BinaryHardening");
            yield return SummaryFactory(() => ArmIotFirmwareDefenseModelFactory.CryptoCertificateSummary(provisioningState: FirmwareProvisioningState.Succeeded), "CryptoCertificate");
            yield return SummaryFactory(() => ArmIotFirmwareDefenseModelFactory.CryptoKeySummary(provisioningState: FirmwareProvisioningState.Succeeded), "CryptoKey");
            yield return SummaryFactory(() => ArmIotFirmwareDefenseModelFactory.CveAnalysisSummary(provisioningState: FirmwareProvisioningState.Succeeded), "CVE");
            yield return SummaryFactory(() => ArmIotFirmwareDefenseModelFactory.SbomSummary(provisioningState: FirmwareProvisioningState.Succeeded), "SBOM");
            yield return SummaryFactory(() => ArmIotFirmwareDefenseModelFactory.PasswordHashSummary(provisioningState: FirmwareProvisioningState.Succeeded), "PasswordHash");
            yield return SummaryFactory(() => ArmIotFirmwareDefenseModelFactory.UnsafeFunctionCallsSummary(provisioningState: FirmwareProvisioningState.Succeeded), "UnsafeFunctionCalls");
            yield return SummaryFactory(() => ArmIotFirmwareDefenseModelFactory.FirmwareAnalysisSummaryProperties("FutureSummary", FirmwareProvisioningState.Succeeded), "FutureSummary");
        }

        private static TestCaseData SummaryFactory(Func<FirmwareAnalysisSummaryProperties> create, string summaryType)
            => new TestCaseData(create, summaryType).SetName($"SummaryFactoryRoundTrips_{summaryType}");

        [TestCaseSource(nameof(SummaryFactories))]
        public void SummaryFactoryRoundTrips(Func<FirmwareAnalysisSummaryProperties> create, string summaryType)
        {
            FirmwareAnalysisSummaryProperties model = create();
            AssertSummaryFactoryRoundTrips(model, summaryType);
            Assert.AreEqual(FirmwareProvisioningState.Succeeded, model.ProvisioningState);
        }

        [Test]
        public void LegacyFirmwareSummaryFactoryRoundTrips()
        {
            AssertSummaryFactoryRoundTrips(ArmIotFirmwareDefenseModelFactory.FirmwareSummary(1, 2, 3, 4, 5, 6, 7), "Firmware");
        }

        [Test]
        public void SummaryFactoryRetainsUnknownDefault()
        {
            AssertSummaryFactoryRoundTrips(ArmIotFirmwareDefenseModelFactory.FirmwareAnalysisSummaryProperties(), "unknown");
        }

        private static void AssertSummaryFactoryRoundTrips(FirmwareAnalysisSummaryProperties model, string summaryType)
        {
            BinaryData data = ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json, AzureResourceManagerIotFirmwareDefenseContext.Default);
            using JsonDocument document = JsonDocument.Parse(data);
            Assert.AreEqual(summaryType, document.RootElement.GetProperty("summaryType").GetString());
            FirmwareAnalysisSummaryProperties roundTrip = ModelReaderWriter.Read<FirmwareAnalysisSummaryProperties>(data, ModelReaderWriterOptions.Json, AzureResourceManagerIotFirmwareDefenseContext.Default);
            Assert.AreEqual(model.GetType(), roundTrip.GetType());
            Assert.AreEqual(model.ProvisioningState, roundTrip.ProvisioningState);
        }

        [Test]
        public void WorkspaceCreatePreservesEmptyPropertiesEnvelope()
        {
            var workspace = new FirmwareAnalysisWorkspaceData(AzureLocation.EastUS);
            BinaryData data = ModelReaderWriter.Write(workspace, new ModelReaderWriterOptions("W"), AzureResourceManagerIotFirmwareDefenseContext.Default);
            using JsonDocument document = JsonDocument.Parse(data);
            Assert.AreEqual("{}", document.RootElement.GetProperty("properties").GetRawText());
        }

        [TestCase("J")]
        [TestCase("W")]
        public void WorkspacePatchSkuDoesNotRequireName(string format)
        {
            var patch = new FirmwareAnalysisWorkspacePatch
            {
                Sku = new IotFirmwareDefenseSkuUpdate { Capacity = 2 }
            };

            BinaryData data = ModelReaderWriter.Write(patch, new ModelReaderWriterOptions(format), AzureResourceManagerIotFirmwareDefenseContext.Default);
            using JsonDocument document = JsonDocument.Parse(data);
            JsonElement sku = document.RootElement.GetProperty("sku");
            Assert.AreEqual(2, sku.GetProperty("capacity").GetInt32());
            Assert.IsFalse(sku.TryGetProperty("name", out _));

            FirmwareAnalysisWorkspacePatch roundTrip = ModelReaderWriter.Read<FirmwareAnalysisWorkspacePatch>(data, new ModelReaderWriterOptions(format), AzureResourceManagerIotFirmwareDefenseContext.Default);
            Assert.AreEqual(2, roundTrip.Sku.Capacity);
            Assert.IsNull(roundTrip.Sku.Name);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void SkuUpdateRoundTripsAllProperties(string format)
        {
            var sku = ArmIotFirmwareDefenseModelFactory.IotFirmwareDefenseSkuUpdate("Free", IotFirmwareDefenseSkuTier.Free, "small", "family", 2);
            var options = new ModelReaderWriterOptions(format);
            BinaryData data = ModelReaderWriter.Write(sku, options, AzureResourceManagerIotFirmwareDefenseContext.Default);
            IotFirmwareDefenseSkuUpdate roundTrip = ModelReaderWriter.Read<IotFirmwareDefenseSkuUpdate>(data, options, AzureResourceManagerIotFirmwareDefenseContext.Default);

            Assert.AreEqual(sku.Name, roundTrip.Name);
            Assert.AreEqual(sku.Tier, roundTrip.Tier);
            Assert.AreEqual(sku.Size, roundTrip.Size);
            Assert.AreEqual(sku.Family, roundTrip.Family);
            Assert.AreEqual(sku.Capacity, roundTrip.Capacity);
        }

        [Test]
        public void SkuUpdatePreservesUnknownPropertiesInPersistedJson()
        {
            var data = BinaryData.FromString("{\"capacity\":2,\"futureProperty\":{\"enabled\":true}}");
            IotFirmwareDefenseSkuUpdate sku = ModelReaderWriter.Read<IotFirmwareDefenseSkuUpdate>(data, ModelReaderWriterOptions.Json, AzureResourceManagerIotFirmwareDefenseContext.Default);
            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(sku, ModelReaderWriterOptions.Json, AzureResourceManagerIotFirmwareDefenseContext.Default));
            Assert.IsTrue(document.RootElement.GetProperty("futureProperty").GetProperty("enabled").GetBoolean());
        }

        [Test]
        public void ModelFactoriesRemainUnambiguous()
        {
            Assert.IsNotNull(ArmIotFirmwareDefenseModelFactory.CveResult());
            Assert.IsNotNull(ArmIotFirmwareDefenseModelFactory.FirmwareAnalysisWorkspaceData());
            var workspace = ArmIotFirmwareDefenseModelFactory.FirmwareAnalysisWorkspaceData(
                id: null, name: null, resourceType: default, systemData: null, tags: null,
                location: AzureLocation.EastUS, sku: new IotFirmwareDefenseSku("Free"),
                provisioningState: FirmwareProvisioningState.Accepted);
            Assert.AreEqual("Free", workspace.Sku.Name);
            Assert.AreEqual(FirmwareProvisioningState.Accepted, workspace.ProvisioningState);
            Assert.AreEqual("Accepted", FirmwareProvisioningState.Accepted.ToString());
            Assert.AreEqual("ocspSigning", CertificateUsage.OcspSigning.ToString());
        }

        [Test]
        public void WorkspacePatchFactoryPreservesOptionalArguments()
        {
            var sku = new IotFirmwareDefenseSkuUpdate { Name = "Free" };
            Assert.AreSame(sku, ArmIotFirmwareDefenseModelFactory.FirmwareAnalysisWorkspacePatch(sku: sku).Sku);
            var tags = new Dictionary<string, string> { ["key"] = "value" };
            Assert.AreEqual("value", ArmIotFirmwareDefenseModelFactory.FirmwareAnalysisWorkspacePatch(tags: tags).Tags["key"]);
        }

        [Test]
        public void UsageMetricConstructorPreservesCounts()
        {
            var metrics = new UsageMetricProperties(2, 5);
            Assert.AreEqual(2, metrics.MonthlyFirmwareUploadCount);
            Assert.AreEqual(5, metrics.TotalFirmwareCount);
        }
    }
}
