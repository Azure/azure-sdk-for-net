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

    public class DiagnosticsTests : SelfHelpManagementTestBase
    {
        public DiagnosticsTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task CreateAndGetDiagnosticsTest()
        {
            var subId = "6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba";
            var resourceGroupName = "DiagnosticsRp-Gateway-Public-Dev-Global";
            var resourceName = "DiagRpGwPubDev";
            var insightsResourceName = Recording.GenerateAssetName("testResource");
            ResourceIdentifier scope = new ResourceIdentifier($"/subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{resourceName}");
            SelfHelpDiagnosticData resourceData = CreateDiagnosticResourceData(scope);

            var createDiagnosticData = await Client.GetSelfHelpDiagnostics(scope).CreateOrUpdateAsync(WaitUntil.Started, insightsResourceName, resourceData);
            Assert.NotNull(createDiagnosticData);

            var readDiagnosticData = await Client.GetSelfHelpDiagnosticAsync(scope, insightsResourceName);
            Assert.NotNull(readDiagnosticData);
        }

        private SelfHelpDiagnosticData CreateDiagnosticResourceData(ResourceIdentifier scope)
        {
            List<SelfHelpDiagnosticInvocation> insights = new List<SelfHelpDiagnosticInvocation>
            {
                new SelfHelpDiagnosticInvocation(){SolutionId = "Demo2InsightV2",}
            };
            Dictionary<string, string> globalParameters = new Dictionary<string, string>();
            globalParameters.Add("startTime", "2020-07-01");
            ResourceType resourceType = new ResourceType("Microsoft.KeyVault/vaults");
            var data = new SelfHelpDiagnosticData(scope, null, resourceType, null, globalParameters, insights, null, null, null, null);

            return data;
        }
    }
}
