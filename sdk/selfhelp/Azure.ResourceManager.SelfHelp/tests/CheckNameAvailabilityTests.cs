// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.SelfHelp.Tests
{
    using Azure.Core.TestFramework;
    using Azure.Core;
    using System.Threading.Tasks;
    using Azure.ResourceManager.SelfHelp.Tests;
    using NUnit.Framework;
    using System;
    using Azure.ResourceManager.SelfHelp.Models;
    using System.Collections.Generic;

    public class CheckNameAvailabilityTests : SelfHelpManagementTestBase
    {
        public CheckNameAvailabilityTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task CheckNameAvailabilityTest_NameDoesntExist()
        {
            var subId = "6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba";
            ResourceIdentifier checkNameScope = new ResourceIdentifier($"/subscriptions/{subId}");
            CheckNameAvailabilityContent resourceData = CreateCheckNameAvailabilityResource("sampleName");

            var checkNameAvailabilityData = await Client.CheckNameAvailabilityDiagnosticAsync(checkNameScope, resourceData);
            Assert.NotNull(checkNameAvailabilityData);
            Assert.IsTrue(checkNameAvailabilityData.Value.NameAvailable);
        }

        [Test]
        public async Task CheckNameAvailabilityTest_NameExists()
        {
            var subId = "6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba";
            var resourceGroupName = "DiagnosticsRp-Gateway-Public-Dev-Global";
            var resourceName = "DiagRpGwPubDev";
            var insightsResourceName = Recording.GenerateAssetName("testResource");
            ResourceIdentifier scope = new ResourceIdentifier($"/subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{resourceName}");
            ResourceIdentifier checkNameScope = new ResourceIdentifier($"/subscriptions/{subId}");
            SelfHelpDiagnosticResourceData resourceData = CreateDiagnosticResourceData(scope);

            var createDiagnosticData = await Client.GetSelfHelpDiagnosticResources(scope).CreateOrUpdateAsync(WaitUntil.Started, insightsResourceName, resourceData);
            Assert.NotNull(createDiagnosticData);

            CheckNameAvailabilityContent data = CreateCheckNameAvailabilityResource(insightsResourceName);

            var checkNameAvailabilityData = await Client.CheckNameAvailabilityDiagnosticAsync(checkNameScope, data);
            Assert.NotNull(checkNameAvailabilityData);
            Assert.IsFalse(checkNameAvailabilityData.Value.NameAvailable);
        }

        private CheckNameAvailabilityContent CreateCheckNameAvailabilityResource(string name)
        {
            var data = new CheckNameAvailabilityContent();
            data.Name = name;
            data.ResourceType = "diagnostics";

            return data;
        }

        private SelfHelpDiagnosticResourceData CreateDiagnosticResourceData(ResourceIdentifier scope)
        {
            List<DiagnosticInvocation> insights = new List<DiagnosticInvocation>
            {
                new DiagnosticInvocation(){SolutionId = "Demo2InsightV2",}
            };
            Dictionary<string, string> globalParameters = new Dictionary<string, string>();
            globalParameters.Add("startTime", "2020-07-01");
            ResourceType resourceType = new ResourceType("Microsoft.KeyVault/vaults");
            var data = new SelfHelpDiagnosticResourceData(scope, null, resourceType, null, globalParameters, insights, null, null, null);

            return data;
        }
    }
}
