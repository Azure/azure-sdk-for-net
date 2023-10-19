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
            await BaseSetUp();
        }

        [TestCase]
        [RecordedTest]
        public async Task SandboxCustomImageTests()
        {
            // Custom Image only works on clusters with skus supporing hyper-threading
            // Since DatabaseCmkTests require devSku this test uses the follower cluster resource
            // Once DatabaseCmk feature if publicly available - change follower cluster back to regular sku and work on regular cluster
            var sandboxCustomImageCollection = FollowingCluster.GetSandboxCustomImages();

            var sandboxCustomImageName = "sdksandboxcustomimage";

            var sandboxCustomImageDataCreate = new SandboxCustomImageData()
            {
                Language = SandboxCustomImageLanguage.Python,
                LanguageVersion = "3.9.7",
                RequirementsFileContent = "Requests\n urllib3"
            };

            var sandboxCustomImageDataUpdate = new SandboxCustomImageData()
            {
                Language = SandboxCustomImageLanguage.Python,
                LanguageVersion = "3.10.8",
                RequirementsFileContent = "Pillow"
            };

            Task<ArmOperation<SandboxCustomImageResource>> CreateOrUpdateSandboxCustomImageAsync(
                string sandboxCustomImageName,
                SandboxCustomImageData sandboxCustomImageData
            ) => sandboxCustomImageCollection.CreateOrUpdateAsync(
                WaitUntil.Completed, sandboxCustomImageName, sandboxCustomImageData
            );

            await CollectionTests(
                sandboxCustomImageName,
                GetFullClusterChildResourceName(sandboxCustomImageName, TE.FollowingClusterName),
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
