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
    public class InstanceCollectionTests : ToolchainOrchestratorManagementTestBase
    {
        public InstanceCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string name = Recording.GenerateAssetName("testsoltionforinstance");
            SolutionResource scr = await this.CreateOrUpdateSolution(name, verifyResult: true);
            string name2 = Recording.GenerateAssetName("testsoltionversionforinstance");
            SolutionVersionResource solutionVersion = await this.CreateOrUpdateSolutionVersion(scr, name2, verifyResult: true);
            string name3 = Recording.GenerateAssetName("testtargetforinstance");
            TargetResource target = await this.CreateOrUpdateTarget(name3, verifyResult: true);
            string name4 = Recording.GenerateAssetName("testinstance");
            InstanceResource ins = await this.CreateOrUpdateInstance(name3, name + "-v-" + name2, target.Data.Name, verifyResult: true);
        }
    }
}
