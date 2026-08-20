// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.PlatformValidation.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.PlatformValidation.Tests
{
    public class ExecutionPlanConfigurationTests
    {
        [Test]
        public void ModelReaderWriterWritesTestStoreExecutionPlanShape()
        {
            var package = new CertificationPackageReference(
                "Linux",
                "V1",
                "X64",
                new CertificationPackageStorageProfile(
                    new CertificationPackageDiskImage(new Uri("https://contoso.example/img.vhd"))));
            package.RecommendedVmSizes.Add("Standard_D4s_v3");

            var configuration = new ExecutionPlanConfiguration("contoso-linux-cert", package);
            configuration.Steps.Add(ValidationStep.Test(
                "os-disk-size",
                "/providers/Microsoft.Validate/validationTests/os-disk-size/versions/1.0.0"));
            configuration.Steps.Add(ValidationStep.Test(
                "linux-quality-validation",
                "/providers/Microsoft.Validate/validationTests/linux-quality-validation/versions/1.0.0"));
            configuration.Steps[1].Inputs = BinaryData.FromObjectAsJson(new { concurrency = 1 });

            BinaryData actual = ModelReaderWriter.Write(configuration);

            const string expected = """
                {
                  "apiVersion": "microsoft.validate/executionPlan.v0",
                  "kind": "ExecutionPlan",
                  "metadata": {"name": "contoso-linux-cert"},
                  "parameters": {"certificationPackageReference": {
                    "osType":"Linux", "vmGenerationType":"V1", "architectureType":"X64",
                    "recommendedVMSizes":["Standard_D4s_v3"],
                    "storageProfile":{"osDiskImage":{"sourceVhdUri":"https://contoso.example/img.vhd"},"dataDiskImages":[]},
                    "additionalProperties":{}
                  }},
                  "authoring":{"steps":[
                    {"name":"os-disk-size","type":"test","testRef":"/providers/Microsoft.Validate/validationTests/os-disk-size/versions/1.0.0"},
                    {"name":"linux-quality-validation","type":"test","testRef":"/providers/Microsoft.Validate/validationTests/linux-quality-validation/versions/1.0.0","inputs":{"concurrency":1}}
                  ]}
                }
                """;

            using JsonDocument actualDocument = JsonDocument.Parse(actual);
            using JsonDocument expectedDocument = JsonDocument.Parse(expected);
            Assert.That(
                JsonSerializer.Serialize(actualDocument.RootElement),
                Is.EqualTo(JsonSerializer.Serialize(expectedDocument.RootElement)));
        }

        [Test]
        public void ModelReaderWriterRoundTripsWithPlatformValidationContext()
        {
            var configuration = CreateConfiguration();
            configuration.CertificationPackageReference.RecommendedVmSizes.Add("Standard_D4s_v3");
            configuration.CertificationPackageReference.AdditionalProperties.Add(
                "offer",
                BinaryData.FromObjectAsJson("contoso-linux"));
            configuration.Steps.Add(ValidationStep.Test(
                "linux-quality-validation",
                "/providers/Microsoft.Validate/validationTests/linux-quality-validation/versions/1.0.0"));
            configuration.Steps[0].Inputs = BinaryData.FromObjectAsJson(new { concurrency = 1 });

            BinaryData serialized = ModelReaderWriter.Write(configuration);
            ExecutionPlanConfiguration reflectionRoundTripped = ModelReaderWriter.Read<ExecutionPlanConfiguration>(serialized);
            ExecutionPlanConfiguration contextRoundTripped = ModelReaderWriter.Read<ExecutionPlanConfiguration>(
                serialized,
                ModelReaderWriterOptions.Json,
                AzureResourceManagerPlatformValidationContext.Default);

            Assert.That(reflectionRoundTripped.Name, Is.EqualTo(configuration.Name));
            Assert.That(contextRoundTripped.CertificationPackageReference.OsType, Is.EqualTo("Linux"));
            Assert.That(contextRoundTripped.CertificationPackageReference.RecommendedVmSizes, Is.EqualTo(new[] { "Standard_D4s_v3" }));
            Assert.That(contextRoundTripped.CertificationPackageReference.StorageProfile.DataDiskImages, Is.Empty);
            Assert.That(contextRoundTripped.CertificationPackageReference.AdditionalProperties["offer"].ToObjectFromJson<string>(), Is.EqualTo("contoso-linux"));
            Assert.That(contextRoundTripped.Steps, Has.Count.EqualTo(1));
            Assert.That(contextRoundTripped.Steps[0].TestRef, Is.EqualTo(configuration.Steps[0].TestRef));
            using JsonDocument inputs = JsonDocument.Parse(contextRoundTripped.Steps[0].Inputs);
            Assert.That(inputs.RootElement.GetProperty("concurrency").GetInt32(), Is.EqualTo(1));
        }

        [Test]
        public void TestStepOmitsInputsWhenNullAndPreservesCompleteTestReference()
        {
            const string testRef = "/providers/Microsoft.PlatformValidation/validationTests/example/versions/2026-01-01";
            var configuration = CreateConfiguration();
            configuration.CertificationPackageReference.RecommendedVmSizes.Add("Standard_D4s_v3");
            configuration.Steps.Add(ValidationStep.Test("example", testRef));

            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(configuration));
            JsonElement step = document.RootElement.GetProperty("authoring").GetProperty("steps")[0];

            Assert.That(step.GetProperty("testRef").GetString(), Is.EqualTo(testRef));
            Assert.That(step.TryGetProperty("inputs", out _), Is.False);
        }

        [TestCase(null)]
        [TestCase("")]
        public void ConstructorRejectsMissingName(string name)
        {
            Assert.That(
                () => new ExecutionPlanConfiguration(name, CreatePackage()),
                Throws.Exception.TypeOf(name is null ? typeof(ArgumentNullException) : typeof(ArgumentException)));
        }

        [Test]
        public void ConstructorRejectsMissingCertificationPackage()
        {
            Assert.Throws<ArgumentNullException>(() => new ExecutionPlanConfiguration("plan", null));
        }

        [TestCase(null, "V1", "X64")]
        [TestCase("", "V1", "X64")]
        [TestCase("Linux", null, "X64")]
        [TestCase("Linux", "", "X64")]
        [TestCase("Linux", "V1", null)]
        [TestCase("Linux", "V1", "")]
        public void CertificationPackageRejectsMissingRequiredText(string osType, string vmGenerationType, string architectureType)
        {
            Assert.That(
                () => new CertificationPackageReference(
                    osType,
                    vmGenerationType,
                    architectureType,
                    new CertificationPackageStorageProfile(
                        new CertificationPackageDiskImage(new Uri("https://contoso.example/img.vhd")))),
                Throws.Exception.TypeOf(
                    osType is null || vmGenerationType is null || architectureType is null
                        ? typeof(ArgumentNullException)
                        : typeof(ArgumentException)));
        }

        [Test]
        public void CertificationPackageRejectsMissingStorageProfile()
        {
            Assert.Throws<ArgumentNullException>(() => new CertificationPackageReference("Linux", "V1", "X64", null));
        }

        [Test]
        public void StorageProfileRejectsMissingOsDiskImage()
        {
            Assert.Throws<ArgumentNullException>(() => new CertificationPackageStorageProfile(null));
        }

        [Test]
        public void DiskImageRejectsMissingSourceUri()
        {
            Assert.Throws<ArgumentNullException>(() => new CertificationPackageDiskImage(null));
        }

        [Test]
        public void DiskImageRejectsRelativeSourceUri()
        {
            Assert.Throws<ArgumentException>(() => new CertificationPackageDiskImage(new Uri("img.vhd", UriKind.Relative)));
        }

        [Test]
        public void SerializationRejectsMissingRecommendedVmSizes()
        {
            var configuration = CreateConfiguration();
            configuration.Steps.Add(ValidationStep.Test("step", "/providers/example"));

            Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(configuration));
        }

        [Test]
        public void SerializationRejectsMissingSteps()
        {
            var package = CreatePackage();
            package.RecommendedVmSizes.Add("Standard_D4s_v3");
            var configuration = new ExecutionPlanConfiguration("plan", package);

            Assert.Throws<InvalidOperationException>(() => ModelReaderWriter.Write(configuration));
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestRejectsMissingName(string name)
        {
            Assert.That(
                () => ValidationStep.Test(name, "/providers/example"),
                Throws.Exception.TypeOf(name is null ? typeof(ArgumentNullException) : typeof(ArgumentException)));
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestRejectsMissingTestReference(string testRef)
        {
            Assert.That(
                () => ValidationStep.Test("step", testRef),
                Throws.Exception.TypeOf(testRef is null ? typeof(ArgumentNullException) : typeof(ArgumentException)));
        }

        private static ExecutionPlanConfiguration CreateConfiguration() =>
            new ExecutionPlanConfiguration("plan", CreatePackage());

        private static CertificationPackageReference CreatePackage() =>
            new CertificationPackageReference(
                "Linux",
                "V1",
                "X64",
                new CertificationPackageStorageProfile(
                    new CertificationPackageDiskImage(new Uri("https://contoso.example/img.vhd"))));
    }
}
