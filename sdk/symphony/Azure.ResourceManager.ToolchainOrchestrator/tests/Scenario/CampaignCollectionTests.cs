// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.ToolchainOrchestrator.Tests;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.ToolchainOrchestrator;
using System;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Service.Tests
{
    public class CampaignCollectionTests : ToolchainOrchestratorManagementTestBase
    {
        public CampaignCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string name = Recording.GenerateAssetName("testcampaign");
            CampaignResource scr = await this.CreateOrUpdateCampaign(name, verifyResult: true);
            string name2 = Recording.GenerateAssetName("testcampaignversion");
            CampaignVersionResource camVersion = await this.CreateOrUpdateCampaignVersion(scr, name2, verifyResult: true);
        }
    }
}
