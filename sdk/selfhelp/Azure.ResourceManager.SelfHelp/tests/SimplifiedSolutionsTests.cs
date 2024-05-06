// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.SelfHelp.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.SelfHelp.Tests
{
    public class SimplifiedSolutionsTests : SelfHelpManagementTestBase
    {
        public SimplifiedSolutionsTests(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task CreateAndGetSimplifiedSolutionsTest()
        {
            var subId = "6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba";
            var resourceGroupName = "DiagnosticsRp-Gateway-Public-Dev-Global";
            var resourceName = "DiagRpGwPubDev";
            var solutionResourceName = Recording.GenerateAssetName("testResource");
            ResourceIdentifier scope = new ResourceIdentifier($"/subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{resourceName}");
            SelfHelpSimplifiedSolutionData resourceData = CreateSelfHelpSimplifiedSolutionData(scope);

            var createSolutionData = await Client.GetSelfHelpSimplifiedSolutions(scope).CreateOrUpdateAsync(WaitUntil.Started, solutionResourceName, resourceData);
            Assert.NotNull(createSolutionData);

            var readSolutionData = await Client.GetSelfHelpSimplifiedSolutionAsync(scope, solutionResourceName);
            Assert.NotNull(readSolutionData);
        }

        private SelfHelpSimplifiedSolutionData CreateSelfHelpSimplifiedSolutionData(ResourceIdentifier scope)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "SearchText","Can not RDP"}
            };

            var solutionId = "9004345-7759";

            List<SelfHelpSection> sections = new List<SelfHelpSection>();
            ResourceType resourceType = new ResourceType("Microsoft.KeyVault/vaults");
            var data = new SelfHelpSimplifiedSolutionData(scope, null, resourceType, null, solutionId, parameters, null, null, null, null, null);

            return data;
        }
    }
}
