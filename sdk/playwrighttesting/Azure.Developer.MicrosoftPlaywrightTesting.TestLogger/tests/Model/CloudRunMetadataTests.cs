// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Tests.Model
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class CloudRunMetadataTests
    {
        [Test]
        public void TestPortalUrl()
        {
            var metadata = new CloudRunMetadata
            {
                WorkspaceId = "eastus_2e8c076a-b67c-4984-b861-8d22d7b525c6",
                RunId = "#run456^1"
            };

            string portalUrl = metadata.PortalUrl!;

            string expectedPortalUrl = "https://playwright.microsoft.com/workspaces/eastus_2e8c076a-b67c-4984-b861-8d22d7b525c6/runs/%23run456%5E1";
            Assert.AreEqual(expectedPortalUrl, portalUrl);
        }

        [Test]
        public void TestEnableResultPublish()
        {
            var metadata = new CloudRunMetadata();

            bool enableResultPublish = metadata.EnableResultPublish;

            Assert.IsTrue(enableResultPublish);
        }

        [Test]
        public void TestEnableGithubSummary()
        {
            var metadata = new CloudRunMetadata();

            bool enableGithubSummary = metadata.EnableGithubSummary;

            Assert.IsTrue(enableGithubSummary);
        }
    }
}
