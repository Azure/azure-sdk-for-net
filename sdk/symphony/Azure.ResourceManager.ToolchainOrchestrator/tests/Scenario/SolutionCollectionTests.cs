// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.ToolchainOrchestrator.Tests;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.ToolchainOrchestrator;
using System;

namespace Azure.ResourceManager.Service.Tests
{
    public class SolutionCollectionTests : ToolchainOrchestratorManagementTestBase
    {
        public SolutionCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string name = Recording.GenerateAssetName("testsc");
            SolutionResource scr = await this.CreateOrUpdateSolution(name, verifyResult: true);
        }
    }
}
