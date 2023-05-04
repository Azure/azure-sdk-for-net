﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Core;
using System.Threading.Tasks;
using Azure.ResourceManager.SelfHelp.Tests;
using NUnit.Framework;
using System;
using Azure.ResourceManager.SelfHelp.Models;
using System.Collections.Generic;

namespace Azure.ResourceManager.SelfHelp.Tests.Scenario
{
    public class DiagnosticsTests : SelfHelpManagementTestBase
    {
        public DiagnosticsTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task CreateAndGetDiagnosticsTest()
        {
            var subId = "db1ab6f0-4769-4b27-930e-01e2ef9c123c";
            var resourceGroupName = "DiagnosticsRp-Gateway-Public-Dev-Global";
            var resourceName = "DiagRpGwPubDev2";
            var insightsResourceName = Recording.GenerateAssetName("testResource");
            ResourceIdentifier scope = new ResourceIdentifier($"/subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{resourceName}");
            SelfHelpDiagnosticResourceData resourceData = CreateDiagnosticResourceData(scope);

            var createDiagnosticData = await Client.GetSelfHelpDiagnosticResources(scope).CreateOrUpdateAsync(WaitUntil.Started, insightsResourceName, resourceData);
            Assert.NotNull(createDiagnosticData);

            var readDiagnosticData = await Client.GetSelfHelpDiagnosticResourceAsync(scope, insightsResourceName);
            Assert.NotNull(readDiagnosticData);
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
