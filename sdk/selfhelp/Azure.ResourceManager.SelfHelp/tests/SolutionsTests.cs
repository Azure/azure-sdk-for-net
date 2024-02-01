// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.SelfHelp.Tests
{
    using Azure.Core.TestFramework;
    using Azure.Core;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using System;
    using Azure.ResourceManager.SelfHelp.Models;
    using System.Collections.Generic;

    public class SolutionsTests : SelfHelpManagementTestBase
    {
        public SolutionsTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        [RecordedTest]
        public async Task CreateAndGetSolutionsTest()
        {
            var subId = "6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba";
            var resourceGroupName = "DiagnosticsRp-Gateway-Public-Dev-Global";
            var resourceName = "DiagRpGwPubDev";
            var solutionResourceName = Recording.GenerateAssetName("testResource");
            ResourceIdentifier scope = new ResourceIdentifier($"/subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{resourceName}");
            SolutionResourceData resourceData = CreateSolutionResourceData(scope);

            var createSolutionData = await Client.GetSolutionResources(scope).CreateOrUpdateAsync(WaitUntil.Started, solutionResourceName, resourceData);
            Assert.NotNull(createSolutionData);

            var readSolutionData = await Client.GetSolutionResourceAsync(scope, solutionResourceName);
            Assert.NotNull(readSolutionData);
        }

        private SolutionResourceData CreateSolutionResourceData(ResourceIdentifier scope)
        {
            List<TriggerCriterion> triggerCriterionList = new List<TriggerCriterion>()
            {
                new TriggerCriterion
                {
                    Name = "SolutionId",
                    Value = "keyvault-lostdeletedkeys-apollo-solution"
                }
            };
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                { "SearchText","Can not RDP"}
            };

            List<SelfHelpSection> sections = new List<SelfHelpSection>();
            SolutionResourceProperties properties = new SolutionResourceProperties(triggerCriterionList, parameters, null, null, null, null, null, sections, null);
            ;
            ResourceType resourceType = new ResourceType("Microsoft.KeyVault/vaults");
            var data = new SolutionResourceData(scope, null, resourceType, null, properties, null);

            return data;
        }
    }
}
