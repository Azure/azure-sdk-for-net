// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Kusto.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests.Scenario
{
    public class KustoSandboxCustomImageTests : KustoManagementTestBase
    {
        public KustoSandboxCustomImageTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        protected async Task SetUp()
        {
            await BaseSetUp(cluster: true);
        }

        [TestCase]
        [RecordedTest]
        public async Task SandboxCustomImageTests()
        {
            var sandboxCustomImageCollection = Cluster.GetSandboxCustomImages();

            var sandboxCustomImageName = GenerateAssetName("sdkSandboxCustomImage");

            var sandboxCustomImageDataCreate = new SandboxCustomImageData()
            {
                Language = Language.Python,
                LanguageVersion = "3.10.8",
                RequirementsFileContent = "Requests",
            };

            var sandboxCustomImageDataUpdate = new SandboxCustomImageData()
            {
                Language = Language.Python,
                LanguageVersion = "3.9.16",
                RequirementsFileContent = "Pillow",
            };

            Task<ArmOperation<SandboxCustomImageResource>> CreateOrUpdateSandboxCustomImageAsync(
                string sandboxCustomImageName,
                SandboxCustomImageData sandboxCustomImageData
            ) => sandboxCustomImageCollection.CreateOrUpdateAsync(
                WaitUntil.Completed, sandboxCustomImageName, sandboxCustomImageData
            );

            await CollectionTests(
                sandboxCustomImageName,
                GetFullClusterChildResourceName(sandboxCustomImageName),
                sandboxCustomImageDataCreate,
                sandboxCustomImageDataUpdate,
                CreateOrUpdateSandboxCustomImageAsync,
                sandboxCustomImageCollection.GetAsync,
                sandboxCustomImageCollection.GetAllAsync,
                sandboxCustomImageCollection.ExistsAsync,
                ValidateSandboxCustomImage
            );

            await DeletionTest(
                sandboxCustomImageName,
                sandboxCustomImageCollection.GetAsync,
                sandboxCustomImageCollection.ExistsAsync
            );
        }

        private static void ValidateSandboxCustomImage(
            string expectedFullSandboxCustomImageName,
            SandboxCustomImageData expectedSandboxCustomImageData,
            SandboxCustomImageData actualSandboxCustomImageData
        )
        {
            AssertEquality(expectedFullSandboxCustomImageName, expectedSandboxCustomImageData.Name);
            AssertEquality(expectedSandboxCustomImageData.Language, actualSandboxCustomImageData.Language);
            AssertEquality(expectedSandboxCustomImageData.LanguageVersion, actualSandboxCustomImageData.LanguageVersion);
            AssertEquality(expectedSandboxCustomImageData.RequirementsFileContent, actualSandboxCustomImageData.RequirementsFileContent);
        }
    }
}
